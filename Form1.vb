Imports UAS_1.Models
Imports UAS_1.Repositories
Imports UAS_1.Services
Imports UAS_1.Core
Imports UAS_1.Utils
Imports System.Collections.Generic

Public Class Form1
    Private _repoProduct As New ProductRepository()
    Private _repoSale As New SaleRepository()
    Private _serviceDiscount As New DiscountService()

    ' Temporary shopping cart storage
    Private _shoppingCart As New List(Of SaleDetail)
    Private _currentSubTotal As Integer = 0

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
    End Sub

    Private Sub LoadProducts()
        Try
            Dim products = _repoProduct.GetAllProducts()
            cb_product.DataSource = products
            cb_product.DisplayMember = "Name"
            cb_product.ValueMember = "Id"

            ' Reset fields
            cb_product.SelectedIndex = -1
            txt_price.Text = ""
            txt_qty.Text = ""
        Catch ex As Exception
            Dim msg = "Error loading products: " & ex.Message
            Logger.LogError(msg, ex)
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show(msg, "Error")
        End Try
    End Sub

    Private Sub cb_product_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cb_product.SelectedIndexChanged
        If cb_product.SelectedItem IsNot Nothing Then
            Dim selectedProduct = DirectCast(cb_product.SelectedItem, Product)
            txt_price.Text = "Rp " & selectedProduct.Price.ToString("N0")
        Else
            txt_price.Text = ""
        End If
    End Sub

    Private Sub btn_add_Click(sender As Object, e As EventArgs) Handles btn_add.Click
        Try
            If cb_product.SelectedItem Is Nothing Then
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

            Dim selectedProduct = DirectCast(cb_product.SelectedItem, Product)

            ' Check stock (Optional based on requirement, but good practice)
            If selectedProduct.Stock < qty Then
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
                msg_dialog.Show($"Stok tidak cukup! Sisa stok: {selectedProduct.Stock}", "Stok Habis")
                Return
            End If

            Dim price = selectedProduct.Price
            Dim totalLine = price * qty

            ' Create detail object
            Dim detail As New SaleDetail With {
                .ProductId = selectedProduct.Id,
                .Quantity = qty,
                .PriceAtMoment = price,
                .TotalLineItem = totalLine
            }

            _shoppingCart.Add(detail)
            _currentSubTotal += totalLine

            ' Update DataGridView instead of ListBox
            dgv_items.Rows.Add(selectedProduct.Name, "Rp " & price.ToString("N0"), qty, "Rp " & totalLine.ToString("N0"))

            ' Calculate Discount & Grand Total dynamically
            Dim discountAmount = _serviceDiscount.HitungDiskon(_currentSubTotal)
            Dim grandTotal = _currentSubTotal - discountAmount

            ' Update All Labels
            lbl_total.Text = "Rp " & _currentSubTotal.ToString("N0")
            lbl_discount.Text = "Rp " & discountAmount.ToString("N0")
            lbl_grand_total.Text = "Rp " & grandTotal.ToString("N0")

            ' Clear input
            txt_qty.Text = ""
            cb_product.SelectedIndex = -1
            cb_product.SelectedItem = Nothing
            txt_price.Text = ""
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

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class
