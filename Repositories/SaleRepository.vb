Imports MySql.Data.MySqlClient
Imports UAS_1.Core
Imports UAS_1.Models
Imports UAS_1.Utils
Imports System.Collections.Generic
Imports System

Namespace Repositories
    Public Class SaleRepository
        Public Sub CreateSale(sale As Sale, details As List(Of SaleDetail))
            Using conn = DatabaseConnection.GetConnection()
                Dim transaction = conn.BeginTransaction()
                Try
                    ' 1. Insert Header
                    Dim sqlHeader As String = "INSERT INTO sales (invoice_number, user_id, subtotal, discount_percent, discount_amount, grand_total) VALUES (@inv, @uid, @sub, @discP, @discA, @grand); SELECT LAST_INSERT_ID();"
                    Dim cmdHeader As New MySqlCommand(sqlHeader, conn, transaction)
                    cmdHeader.Parameters.AddWithValue("@inv", sale.InvoiceNumber)
                    cmdHeader.Parameters.AddWithValue("@uid", sale.UserId)
                    cmdHeader.Parameters.AddWithValue("@sub", sale.SubTotal)
                    cmdHeader.Parameters.AddWithValue("@discP", sale.DiscountPercent)
                    cmdHeader.Parameters.AddWithValue("@discA", sale.DiscountAmount)
                    cmdHeader.Parameters.AddWithValue("@grand", sale.GrandTotal)
                    
                    Dim saleId = Convert.ToInt32(cmdHeader.ExecuteScalar())
                    sale.Id = saleId

                    ' 2. Insert Details
                    For Each detail In details
                        Dim sqlDetail As String = "INSERT INTO sale_details (sale_id, product_id, quantity, price_at_moment, total_line_item) VALUES (@sid, @pid, @qty, @price, @total)"
                        Dim cmdDetail As New MySqlCommand(sqlDetail, conn, transaction)
                        cmdDetail.Parameters.AddWithValue("@sid", saleId)
                        cmdDetail.Parameters.AddWithValue("@pid", detail.ProductId)
                        cmdDetail.Parameters.AddWithValue("@qty", detail.Quantity)
                        cmdDetail.Parameters.AddWithValue("@price", detail.PriceAtMoment)
                        cmdDetail.Parameters.AddWithValue("@total", detail.TotalLineItem)
                        cmdDetail.ExecuteNonQuery()
                        
                        ' Update Stock
                        Dim cmdStock As New MySqlCommand("UPDATE products SET stock = stock - @qty WHERE product_id = @pid", conn, transaction)
                        cmdStock.Parameters.AddWithValue("@qty", detail.Quantity)
                        cmdStock.Parameters.AddWithValue("@pid", detail.ProductId)
                        cmdStock.ExecuteNonQuery()
                    Next

                    transaction.Commit()
                    Logger.LogInfo($"Transaksi berhasil disimpan: {sale.InvoiceNumber} | Total: {sale.GrandTotal}")
                Catch ex As Exception
                    transaction.Rollback()
                    Logger.LogError($"Transaksi gagal dan dibatalkan. Invoice: {sale.InvoiceNumber}", ex)
                    Throw
                End Try
            End Using
        End Sub

        Public Function GetAllSales() As List(Of Sale)
            Dim listSales As New List(Of Sale)
            Using conn = DatabaseConnection.GetConnection()
                Dim query As String = "SELECT s.*, u.full_name FROM sales s JOIN users u ON s.user_id = u.user_id ORDER BY s.transaction_date DESC"
                Dim cmd As New MySqlCommand(query, conn)
                Using rd = cmd.ExecuteReader()
                    While rd.Read()
                        listSales.Add(New Sale With {
                            .Id = Convert.ToInt32(rd("sale_id")),
                            .InvoiceNumber = rd("invoice_number").ToString(),
                            .TransactionDate = Convert.ToDateTime(rd("transaction_date")),
                            .SubTotal = Convert.ToInt32(rd("subtotal")),
                            .DiscountAmount = Convert.ToInt32(rd("discount_amount")),
                            .GrandTotal = Convert.ToInt32(rd("grand_total")),
                            .CashierName = rd("full_name").ToString()
                        })
                    End While
                End Using
            End Using
            Return listSales
        End Function
    End Class
End Namespace