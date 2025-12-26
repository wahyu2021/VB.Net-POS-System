Imports System

Namespace Models
    Public Class Sale
        Public Property Id As Integer
        Public Property InvoiceNumber As String
        Public Property TransactionDate As DateTime
        Public Property UserId As Integer ' Foreign Key ke Users
        Public Property SubTotal As Integer
        Public Property DiscountPercent As Integer
        Public Property DiscountAmount As Integer
        Public Property GrandTotal As Integer
        
        ' Property tambahan untuk tampilan (bukan masuk DB sales)
        Public Property CashierName As String 
    End Class
End Namespace