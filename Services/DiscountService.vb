Namespace Services
    Public Class DiscountService
        ' Fungsi murni matematika (Input Total -> Output Diskon)
        Public Function HitungDiskon(totalBelanja As Integer) As Integer
            If totalBelanja > 500000 Then
                Return CInt(totalBelanja * 0.15) ' Diskon 15%
            ElseIf totalBelanja > 200000 Then
                Return CInt(totalBelanja * 0.10) ' Diskon 10%
            Else
                Return 0
            End If
        End Function
        
        Public Function GetDiscountPercentage(totalBelanja As Integer) As Integer
             If totalBelanja > 500000 Then
                Return 15
            ElseIf totalBelanja > 200000 Then
                Return 10
            Else
                Return 0
            End If
        End Function
    End Class
End Namespace
