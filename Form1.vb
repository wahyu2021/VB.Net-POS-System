Imports UAS_1.Models
Imports UAS_1.Repositories
Imports UAS_1.Services
Imports UAS_1.Core
Imports UAS_1.Utils
Imports System.Collections.Generic
Imports System.Linq

Public Class Form1
    Private _repoProduct As New ProductRepository()
    Private _repoSale As New SaleRepository()
    Private _serviceDiscount As New DiscountService()
    Private _msgHelper As MessageHelper
    Private _scanner As BarcodeScanner

    ' Shopping cart
    Private _shoppingCart As New List(Of SaleDetail)
    Private _currentSubTotal As Integer = 0

    ' Products
    Private _cachedProducts As New List(Of Product)
    Private _selectedProduct As Product

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _msgHelper = New MessageHelper(msg_dialog)
        _scanner = New BarcodeScanner(pb_camera)

        If Session.CurrentUser Is Nothing Then
            _msgHelper.ShowError("Silakan login terlebih dahulu.", "Akses Ditolak")
            Application.Exit()
            Return
        End If

        lbl_welcome.Text = $"Halo, {Session.CurrentUser.FullName} ({Session.CurrentUser.Role})"
        Logger.LogInfo("Aplikasi kasir (Main Form) dimuat.")
        LoadProducts()
        InitCamera()
    End Sub

    Private Sub InitCamera()
        Try
            For Each device In _scanner.GetAvailableDevices()
                cb_devices.Items.Add(device)
            Next
            If cb_devices.Items.Count > 0 Then cb_devices.SelectedIndex = 0
        Catch ex As Exception
            Logger.LogError("Error init camera", ex)
        End Try
    End Sub

    Private Sub LoadProducts()
        Try
            _cachedProducts = _repoProduct.GetAllProducts()
            
            Dim source As New AutoCompleteStringCollection()
            For Each p In _cachedProducts
                source.Add(p.Name)
            Next
            
            txt_search_product.AutoCompleteCustomSource = source
            txt_search_product.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txt_search_product.AutoCompleteSource = AutoCompleteSource.CustomSource
            ResetInput()
        Catch ex As Exception
            Logger.LogError("Error loading products", ex)
            _msgHelper.ShowError("Error loading products: " & ex.Message)
        End Try
    End Sub

    Private Sub ResetInput()
        txt_search_product.Text = ""
        txt_price.Text = ""
        txt_qty.Text = ""
        _selectedProduct = Nothing
    End Sub

    Private Sub SelectProduct(p As Product)
        _selectedProduct = p
        txt_search_product.Text = p.Name
        txt_price.Text = "Rp " & p.Price.ToString("N0")
        txt_qty.Focus()
    End Sub

    Private Sub UpdateTotals()
        Dim discountAmount = _serviceDiscount.HitungDiskon(_currentSubTotal)
        Dim grandTotal = _currentSubTotal - discountAmount
        lbl_total.Text = "Rp " & _currentSubTotal.ToString("N0")
        lbl_discount.Text = "Rp " & discountAmount.ToString("N0")
        lbl_grand_total.Text = "Rp " & grandTotal.ToString("N0")
    End Sub

    Private Sub txt_search_product_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search_product.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query = txt_search_product.Text.Trim()
            If String.IsNullOrEmpty(query) Then Return
            
            Dim found = _cachedProducts.FirstOrDefault(Function(p) p.Name.Equals(query, StringComparison.OrdinalIgnoreCase) OrElse p.Code.Equals(query, StringComparison.OrdinalIgnoreCase))
            If found IsNot Nothing Then SelectProduct(found)
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            If _selectedProduct Is Nothing Then
                _msgHelper.ShowWarning("Pilih barang terlebih dahulu!")
                Return
            End If

            Dim qty As Integer
            If Not Integer.TryParse(txt_qty.Text, qty) OrElse qty <= 0 Then
                _msgHelper.ShowWarning("Masukkan jumlah yang valid!")
                Return
            End If

            If _selectedProduct.Stock < qty Then
                _msgHelper.ShowWarning($"Stok tidak cukup! Sisa stok: {_selectedProduct.Stock}", "Stok Habis")
                Return
            End If

            Dim price = _selectedProduct.Price
            Dim totalLine = price * qty

            _shoppingCart.Add(New SaleDetail With {
                .ProductId = _selectedProduct.Id,
                .Quantity = qty,
                .PriceAtMoment = price,
                .TotalLineItem = totalLine
            })

            _currentSubTotal += totalLine
            dgv_items.Rows.Add(_selectedProduct.Name, "Rp " & price.ToString("N0"), qty, "Rp " & totalLine.ToString("N0"))
            UpdateTotals()
            ResetInput()
        Catch ex As Exception
            Logger.LogError("Error adding item to cart", ex)
            _msgHelper.ShowError("Terjadi kesalahan saat menambahkan item.")
        End Try
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        _shoppingCart.Clear()
        dgv_items.Rows.Clear()
        _currentSubTotal = 0
        lbl_total.Text = "Rp 0"
        lbl_discount.Text = "Rp 0"
        lbl_grand_total.Text = "Rp 0"
        Logger.LogInfo("Daftar belanja dikosongkan.")
    End Sub

    Private Sub btn_calculate_Click(sender As Object, e As EventArgs) Handles btn_calculate.Click
        If _shoppingCart.Count = 0 Then
            _msgHelper.ShowWarning("Keranjang belanja kosong!")
            Return
        End If

        Dim discountAmount = _serviceDiscount.HitungDiskon(_currentSubTotal)
        Dim discountPercent = _serviceDiscount.GetDiscountPercentage(_currentSubTotal)
        Dim grandTotal = _currentSubTotal - discountAmount

        Dim sale As New Sale With {
            .InvoiceNumber = "INV-" & DateTime.Now.ToString("yyyyMMdd-HHmmss"),
            .SubTotal = _currentSubTotal,
            .DiscountPercent = discountPercent,
            .DiscountAmount = discountAmount,
            .GrandTotal = grandTotal,
            .UserId = Session.CurrentUser.Id,
            .TransactionDate = DateTime.Now
        }

        Try
            _repoSale.CreateSale(sale, _shoppingCart)
            _msgHelper.ShowInfo($"Transaksi Berhasil!{vbCrLf}Total: Rp {grandTotal:N0}{vbCrLf}Kasir: {Session.CurrentUser.FullName}", "Sukses")
            btn_clear_Click(Nothing, Nothing)
            LoadProducts()
        Catch ex As Exception
            _msgHelper.ShowError("Gagal menyimpan transaksi: " & ex.Message)
        End Try
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        If _msgHelper.Confirm("Apakah Anda yakin ingin logout?", "Logout") Then
            Session.CurrentUser = Nothing
            Dim login As New LoginForm()
            login.Show()
            Me.Hide()
        End If
    End Sub

    ' -- Scanner Logic --
    Private Sub btn_start_scan_Click(sender As Object, e As EventArgs) Handles btn_start_scan.Click
        Try
            If cb_devices.SelectedIndex < 0 Then
                _msgHelper.ShowInfo("Pilih kamera terlebih dahulu!")
                Return
            End If
            _scanner.StartScanning(cb_devices.SelectedIndex, Nothing)
            TimerScan.Start()
        Catch ex As Exception
            _msgHelper.ShowError("Error starting camera: " & ex.Message)
        End Try
    End Sub

    Private Sub TimerScan_Tick(sender As Object, e As EventArgs) Handles TimerScan.Tick
        Dim code = _scanner.TryDecode()
        If code IsNot Nothing Then
            TimerScan.Stop()
            _scanner.StopScanning()
            Console.Beep()
            
            Dim found = _cachedProducts.FirstOrDefault(Function(p) p.Code = code)
            If found IsNot Nothing Then
                SelectProduct(found)
                _msgHelper.ShowInfo("Produk Ditemukan!", "Scan Berhasil")
            Else
                _msgHelper.ShowWarning("Produk dengan kode " & code & " tidak ditemukan.", "Not Found")
            End If
        End If
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        _scanner?.StopScanning()
        Application.Exit()
    End Sub

    ' -- Navigation with TabControl --
    Private Sub btn_nav_home_Click(sender As Object, e As EventArgs) Handles btn_nav_home.Click
        tc_cashier.SelectedIndex = 0
        UpdateNavButtons("home")
    End Sub

    Private Sub btn_view_products_Click(sender As Object, e As EventArgs) Handles btn_view_products.Click
        tc_cashier.SelectedIndex = 1
        LoadProductListGrid()
        UpdateNavButtons("products")
    End Sub

    Private Sub UpdateNavButtons(activePage As String)
        ' Reset semua tombol
        btn_nav_home.FillColor = Color.Transparent
        btn_view_products.FillColor = Color.Transparent
        
        ' Set tombol aktif
        If activePage = "home" Then
            btn_nav_home.FillColor = Color.FromArgb(240, 127, 35)
        ElseIf activePage = "products" Then
            btn_view_products.FillColor = Color.FromArgb(240, 127, 35)
        End If
    End Sub

    Private Sub LoadProductListGrid(Optional searchQuery As String = "")
        Try
            Dim filteredProducts As List(Of Product)
            
            If String.IsNullOrWhiteSpace(searchQuery) Then
                filteredProducts = _cachedProducts
            Else
                filteredProducts = _cachedProducts.Where(Function(p) p.Name.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0 OrElse p.Code.IndexOf(searchQuery, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
            End If

            dgv_product_list.DataSource = Nothing
            dgv_product_list.DataSource = filteredProducts
            
            With dgv_product_list.Columns
                If .Contains("Id") Then .Item("Id").Visible = False
                If .Contains("Code") Then .Item("Code").HeaderText = "KODE" : .Item("Code").Width = 150
                If .Contains("Name") Then .Item("Name").HeaderText = "NAMA BARANG" : .Item("Name").Width = 400
                If .Contains("Price") Then .Item("Price").HeaderText = "HARGA" : .Item("Price").Width = 200 : .Item("Price").DefaultCellStyle.Format = "N0"
                If .Contains("Stock") Then .Item("Stock").HeaderText = "STOK" : .Item("Stock").Width = 100
            End With
        Catch ex As Exception
            Logger.LogError("Error loading product list grid", ex)
        End Try
    End Sub

    Private Sub txt_search_product_list_TextChanged(sender As Object, e As EventArgs) Handles txt_search_product_list.TextChanged
        LoadProductListGrid(txt_search_product_list.Text.Trim())
    End Sub
End Class
