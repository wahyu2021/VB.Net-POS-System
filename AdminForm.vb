Imports UAS_1.Models
Imports UAS_1.Repositories
Imports UAS_1.Core
Imports UAS_1.Utils
Imports System.Windows.Forms
Imports ZXing
Imports ZXing.Common
Imports ZXing.Windows.Compatibility

Public Class AdminForm
    Private _repoProduct As New ProductRepository()
    Private _repoSale As New SaleRepository()

    Private Sub AdminForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_admin_title.Text = $"ADMIN PANEL{vbCrLf}{Session.CurrentUser.FullName}"

        LoadProducts()
        LoadHistory()
    End Sub

    ' -- Navigation Logic --
    Private Sub btn_nav_products_Click(sender As Object, e As EventArgs) Handles btn_nav_products.Click
        tc_admin.SelectedIndex = 0
        lbl_page_title.Text = "Manajemen Produk"
    End Sub

    Private Sub btn_nav_history_Click(sender As Object, e As EventArgs) Handles btn_nav_history.Click
        tc_admin.SelectedIndex = 1
        lbl_page_title.Text = "Riwayat Transaksi"
        LoadHistory() ' Refresh data
    End Sub

    Private Sub btn_logout_Click(sender As Object, e As EventArgs) Handles btn_logout.Click
        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo
        msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Question
        Dim result = msg_dialog.Show("Logout dari Admin?", "Konfirmasi")

        If result = DialogResult.Yes Then
            Session.CurrentUser = Nothing
            Dim login As New LoginForm()
            login.Show()
            Me.Hide()
        End If
        ' Reset
        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
    End Sub

    Private Sub AdminForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub

    ' -- Product Logic --
    Private Sub LoadProducts()
        Try
            Dim list = _repoProduct.GetAllProducts()
            dgv_products.DataSource = list
        Catch ex As Exception
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Error load products: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btn_p_save_Click(sender As Object, e As EventArgs) Handles btn_p_save.Click
        ' Validation
        If String.IsNullOrEmpty(txt_p_code.Text) OrElse String.IsNullOrEmpty(txt_p_name.Text) Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
            msg_dialog.Show("Kode dan Nama wajib diisi!", "Validasi")
            Return
        End If

        Dim price As Integer
        Dim stock As Integer
        If Not Integer.TryParse(txt_p_price.Text, price) OrElse Not Integer.TryParse(txt_p_stock.Text, stock) Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
            msg_dialog.Show("Harga dan Stok harus berupa angka valid!", "Validasi")
            Return
        End If

        Try
            Dim p As New Product With {
                .Code = txt_p_code.Text,
                .Name = txt_p_name.Text,
                .Price = price,
                .Stock = stock
            }

            If btn_p_save.Text = "UPDATE" Then
                _repoProduct.UpdateProduct(p)
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
                msg_dialog.Show("Produk berhasil diperbarui!", "Sukses")
            Else
                _repoProduct.CreateProduct(p)
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
                msg_dialog.Show("Produk berhasil ditambahkan!", "Sukses")
            End If

            ClearForm()
            LoadProducts()
        Catch ex As Exception
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Error: " & ex.Message, "Gagal")
        End Try
    End Sub

    Private Sub btn_p_delete_Click(sender As Object, e As EventArgs) Handles btn_p_delete.Click
        If String.IsNullOrEmpty(txt_p_code.Text) Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
            msg_dialog.Show("Pilih produk untuk dihapus.", "Peringatan")
            Return
        End If

        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.YesNo
        msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
        If msg_dialog.Show("Hapus produk " & txt_p_name.Text & "?", "Hapus") = DialogResult.Yes Then
            Try
                _repoProduct.DeleteProduct(txt_p_code.Text)
                ClearForm()
                LoadProducts()
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Information
                msg_dialog.Show("Produk dihapus.", "Sukses")
            Catch ex As Exception
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
                msg_dialog.Show("Gagal hapus: " & ex.Message, "Error")
            End Try
        End If
        msg_dialog.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK
    End Sub

    Private Sub btn_p_clear_Click(sender As Object, e As EventArgs) Handles btn_p_clear.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txt_p_code.Text = ""
        txt_p_name.Text = ""
        txt_p_price.Text = ""
        txt_p_stock.Text = ""
        txt_p_code.Enabled = True
        btn_p_save.Text = "SIMPAN"
    End Sub

    Private Sub dgv_products_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_products.CellClick
        If e.RowIndex >= 0 Then
            Dim row = dgv_products.Rows(e.RowIndex)
            txt_p_code.Text = row.Cells("Code").Value.ToString()
            txt_p_name.Text = row.Cells("Name").Value.ToString()
            txt_p_price.Text = row.Cells("Price").Value.ToString()
            txt_p_stock.Text = row.Cells("Stock").Value.ToString()

            txt_p_code.Enabled = False
            btn_p_save.Text = "UPDATE"
        End If
    End Sub

    ' -- History Logic --
    Private Sub LoadHistory()
        Try
            Dim history = _repoSale.GetAllSales()
            dgv_history.DataSource = history
            If dgv_history.Columns.Contains("UserId") Then dgv_history.Columns("UserId").Visible = False
        Catch ex As Exception
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Error load history: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub btn_gen_qr_Click(sender As Object, e As EventArgs) Handles btn_gen_qr.Click
        If String.IsNullOrEmpty(txt_p_code.Text) Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
            msg_dialog.Show("Masukkan Kode Produk terlebih dahulu!", "Peringatan")
            Return
        End If

        Try
            Dim writer As New BarcodeWriter()
            writer.Format = BarcodeFormat.QR_CODE
            writer.Options = New EncodingOptions With {
                .Height = 300,
                .Width = 300,
                .Margin = 1
            }
            pic_qr.Image = writer.Write(txt_p_code.Text)
        Catch ex As Exception
            Logger.LogError("Gagal generate QR", ex)
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Gagal generate QR: " & ex.Message, "Error")
        End Try
    End Sub
End Class