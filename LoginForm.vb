Imports UAS_1.Repositories
Imports UAS_1.Core
Imports UAS_1.Utils
Imports System.Windows.Forms

Public Class LoginForm
    Private _repoUser As New UserRepository()

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        Dim username = txt_username.Text.Trim()
        Dim password = txt_password.Text.Trim()

        If String.IsNullOrEmpty(username) OrElse String.IsNullOrEmpty(password) Then
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Warning
            msg_dialog.Show("Username dan Password harus diisi!", "Peringatan")
            Return
        End If

        Try
            Dim user = _repoUser.Login(username, password)
            If user IsNot Nothing Then
                ' Login Sukses
                Session.CurrentUser = user
                Logger.LogInfo($"User logged in: {user.Username} ({user.Role})")
                
                Me.Hide()
                
                If user.Role = "Admin" Then
                    Dim adminForm As New AdminForm()
                    adminForm.Show()
                Else
                    Dim cashierForm As New Form1()
                    cashierForm.Show()
                End If
            Else
                msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
                msg_dialog.Show("Username atau Password salah!", "Login Gagal")
            End If
        Catch ex As Exception
            msg_dialog.Icon = Guna.UI2.WinForms.MessageDialogIcon.Error
            msg_dialog.Show("Terjadi kesalahan server: " & ex.Message, "Error")
        End Try
    End Sub

    Private Sub LoginForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Application.Exit()
    End Sub
End Class