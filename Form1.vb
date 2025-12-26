Imports UAS_1.Models
Imports UAS_1.Repositories
Imports UAS_1.Services
Imports UAS_1.Core
Imports UAS_1.Utils
Imports System.Collections.Generic
Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports ZXing.Windows.Compatibility
Imports System.Linq

Public Class Form1
    Private _repoProduct As New ProductRepository()
    Private _repoSale As New SaleRepository()
    Private _serviceDiscount As New DiscountService()

    ' Temporary shopping cart storage
    Private _shoppingCart As New List(Of SaleDetail)
    Private _currentSubTotal As Integer = 0

    ' Camera Variables
    Dim FilterInfo As FilterInfoCollection
    Dim CaptureDevice As VideoCaptureDevice

    ' Search Variables
    Private _cachedProducts As New List(Of Product)
    Private _selectedProduct As Product

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cek Session
        If Session.CurrentUser Is Nothing Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Silakan login terlebih dahulu.", "Akses Ditolak")
            Application.Exit()
            Return
        End If

        lbl_welcome.Text = $"Halo, {Session.CurrentUser.FullName} ({Session.CurrentUser.Role})"
        Logger.LogInfo("Aplikasi kasir (Main Form) dimuat.")
        LoadProducts()

        ' Init Camera Devices
        Try
            FilterInfo = New FilterInfoCollection(FilterCategory.VideoInputDevice)
            For Each Device As FilterInfo In FilterInfo
                cb_devices.Items.Add(Device.Name)
            Next
            If cb_devices.Items.Count > 0 Then
                cb_devices.SelectedIndex = 0
            End If
        Catch ex As Exception
            Logger.LogError("Error init camera", ex)
        End Try
    End Sub

    Private Sub LoadProducts()
        Try
            _cachedProducts = _repoProduct.GetAllProducts()
            
            ' Setup AutoComplete
            Dim source As New AutoCompleteStringCollection()
            For Each p In _cachedProducts
                source.Add(p.Name)
            Next
            
            txt_search_product.AutoCompleteCustomSource = source
            txt_search_product.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txt_search_product.AutoCompleteSource = AutoCompleteSource.CustomSource
            
            ResetInput()
        Catch ex As Exception
            Dim msg = "Error loading products: " & ex.Message
            Logger.LogError(msg, ex)
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show(msg, "Error")
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

    Private Sub txt_search_product_KeyDown(sender As Object, e As KeyEventArgs) Handles txt_search_product.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim query = txt_search_product.Text.Trim()
            If String.IsNullOrEmpty(query) Then Return
            
            Dim found = _cachedProducts.FirstOrDefault(Function(p) p.Name.Equals(query, StringComparison.OrdinalIgnoreCase) OrElse p.Code.Equals(query, StringComparison.OrdinalIgnoreCase))
            
            If found IsNot Nothing Then
                SelectProduct(found)
            Else
                 ' Optional: Show toast or ignore
            End If
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            If _selectedProduct Is Nothing Then
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                msg_dialog.Show("Pilih barang terlebih dahulu!", "Peringatan")
                Return
            End If

            Dim qty As Integer
            If Not Integer.TryParse(txt_qty.Text, qty) OrElse qty <= 0 Then
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                msg_dialog.Show("Masukkan jumlah yang valid!", "Peringatan")
                Return
            End If

            ' Check stock
            If _selectedProduct.Stock < qty Then
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                msg_dialog.Show($"Stok tidak cukup! Sisa stok: {_selectedProduct.Stock}", "Stok Habis")
                Return
            End If

            Dim price = _selectedProduct.Price
            Dim totalLine = price * qty

            ' Create detail object
            Dim detail As New SaleDetail With {
                .ProductId = _selectedProduct.Id,
                .Quantity = qty,
                .PriceAtMoment = price,
                .TotalLineItem = totalLine
            }

            _shoppingCart.Add(detail)
            _currentSubTotal += totalLine

            ' Update DataGridView instead of ListBox
            dgv_items.Rows.Add(_selectedProduct.Name, "Rp " & price.ToString("N0"), qty, "Rp " & totalLine.ToString("N0"))

            ' Calculate Discount & Grand Total dynamically
            Dim discountAmount = _serviceDiscount.HitungDiskon(_currentSubTotal)
            Dim grandTotal = _currentSubTotal - discountAmount

            ' Update All Labels
            lbl_total.Text = "Rp " & _currentSubTotal.ToString("N0")
            lbl_discount.Text = "Rp " & discountAmount.ToString("N0")
            lbl_grand_total.Text = "Rp " & grandTotal.ToString("N0")

            ' Clear input
            ResetInput()
        Catch ex As Exception
            Logger.LogError("Error adding item to cart", ex)
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Terjadi kesalahan saat menambahkan item.", "Error")
        End Try
    End Sub

    Private Sub btn_clear_Click(sender As Object, e As EventArgs) Handles btn_clear.Click
        _shoppingCart.Clear()
        dgv_items.Rows.Clear() ' Clear Grid
        _currentSubTotal = 0

        lbl_total.Text = "Rp 0"
        lbl_discount.Text = "Rp 0"
        lbl_grand_total.Text = "Rp 0"

        Logger.LogInfo("Daftar belanja dikosongkan.")
    End Sub

    Private Sub btn_calculate_Click(sender As Object, e As EventArgs) Handles btn_calculate.Click
        If _shoppingCart.Count = 0 Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
            msg_dialog.Show("Keranjang belanja kosong!", "Peringatan")
            Return
        End If

        ' Calculate Discount
        Dim discountAmount = _serviceDiscount.HitungDiskon(_currentSubTotal)
        Dim discountPercent = _serviceDiscount.GetDiscountPercentage(_currentSubTotal)
        Dim grandTotal = _currentSubTotal - discountAmount

        ' Update Labels
        lbl_discount.Text = "Rp " & discountAmount.ToString("N0")
        lbl_grand_total.Text = "Rp " & grandTotal.ToString("N0")

        ' Create Sale Header
        Dim sale As New Sale With {
            .InvoiceNumber = "INV-" & DateTime.Now.ToString("yyyyMMdd-HHmmss"),
            .SubTotal = _currentSubTotal,
            .DiscountPercent = discountPercent,
            .DiscountAmount = discountAmount,
            .GrandTotal = grandTotal,
            .UserId = Session.CurrentUser.Id, ' AMBIL ID DARI SESSION
            .TransactionDate = DateTime.Now
        }

        Try
            ' Save to Database
            _repoSale.CreateSale(sale, _shoppingCart)

            Dim successMsg = $"Transaksi Berhasil!{vbCrLf}Total: Rp {grandTotal:N0}{vbCrLf}Kasir: {Session.CurrentUser.FullName}"
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
            msg_dialog.Show(successMsg, "Sukses")

            ' Reset UI
            btn_clear_Click(Nothing, Nothing)
            LoadProducts() ' Reload to update stock
        Catch ex As Exception
            Dim msg = "Gagal menyimpan transaksi: " & ex.Message
            ' Logging is handled in Repository
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show(msg, "Error")
        End Try
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question
        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo
        Dim result = msg_dialog.Show("Apakah Anda yakin ingin logout?", "Logout")

        If result = DialogResult.Yes Then
            Session.CurrentUser = Nothing
            Dim login As New LoginForm()
            login.Show()
            Me.Hide()
        End If
        ' Reset buttons back to OK for future usage
        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
    End Sub

    ' Camera & Scan Logic
    Private Sub btn_start_scan_Click(sender As Object, e As EventArgs) Handles btn_start_scan.Click
        Try
            If CaptureDevice IsNot Nothing AndAlso CaptureDevice.IsRunning Then
                CaptureDevice.SignalToStop()
                CaptureDevice.WaitForStop()
            End If

            If cb_devices.SelectedIndex < 0 Then
                msg_dialog.Show("Pilih kamera terlebih dahulu!", "Info")
                Return
            End If

            CaptureDevice = New VideoCaptureDevice(FilterInfo(cb_devices.SelectedIndex).MonikerString)
            AddHandler CaptureDevice.NewFrame, AddressOf Capture_NewFrame
            CaptureDevice.Start()
            TimerScan.Start()
        Catch ex As Exception
            Logger.LogError("Error starting camera", ex)
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Error starting camera: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub Capture_NewFrame(sender As Object, eventArgs As NewFrameEventArgs)
        Try
            Dim bmp = DirectCast(eventArgs.Frame.Clone(), Bitmap)
            If pb_camera.InvokeRequired Then
                pb_camera.Invoke(Sub() pb_camera.Image = bmp)
            Else
                pb_camera.Image = bmp
            End If
        Catch ex As Exception
            Logger.LogError("Error capturing frame", ex)
        End Try
    End Sub

    Private Sub TimerScan_Tick(sender As Object, e As EventArgs) Handles TimerScan.Tick
        If pb_camera.Image IsNot Nothing Then
            Try
                Dim Reader As New BarcodeReader()
                Dim Result As Result = Reader.Decode(DirectCast(pb_camera.Image, Bitmap))

                If Result IsNot Nothing Then
                    TimerScan.Stop()
                    CaptureDevice.SignalToStop()
                    Console.Beep()
                    FindProductByCode(Result.Text)
                End If
            Catch ex As Exception
                Logger.LogError("Error scanning/decoding", ex)
            End Try
        End If
    End Sub

    Private Sub FindProductByCode(code As String)
        Try
            Dim found = _cachedProducts.FirstOrDefault(Function(p) p.Code = code)

            If found IsNot Nothing Then
                SelectProduct(found)
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
                msg_dialog.Show("Produk Ditemukan!", "Scan Berhasil")
            Else
                 msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                 msg_dialog.Show("Produk dengan kode " & code & " tidak ditemukan di daftar.", "Not Found")
            End If
        Catch ex As Exception
            Logger.LogError("Error finding product", ex)
        End Try
    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        If CaptureDevice IsNot Nothing AndAlso CaptureDevice.IsRunning Then
            CaptureDevice.SignalToStop()
            CaptureDevice.WaitForStop()
        End If
        Application.Exit()
    End Sub
End Class
