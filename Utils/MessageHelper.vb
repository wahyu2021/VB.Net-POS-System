Imports Guna.UI2.WinForms

Namespace Utils
    Public Class MessageHelper
        Private _dialog As Guna2MessageDialog

        Public Sub New(dialog As Guna2MessageDialog)
            _dialog = dialog
        End Sub

        Public Sub ShowError(message As String, Optional title As String = "Error")
            _dialog.Icon = MessageDialogIcon.Error
            _dialog.Show(message, title)
        End Sub

        Public Sub ShowWarning(message As String, Optional title As String = "Peringatan")
            _dialog.Icon = MessageDialogIcon.Warning
            _dialog.Show(message, title)
        End Sub

        Public Sub ShowInfo(message As String, Optional title As String = "Informasi")
            _dialog.Icon = MessageDialogIcon.Information
            _dialog.Show(message, title)
        End Sub

        Public Function Confirm(message As String, Optional title As String = "Konfirmasi") As Boolean
            _dialog.Icon = MessageDialogIcon.Question
            _dialog.Buttons = MessageDialogButtons.YesNo
            Dim result = _dialog.Show(message, title)
            _dialog.Buttons = MessageDialogButtons.OK
            Return result = DialogResult.Yes
        End Function
    End Class
End Namespace
