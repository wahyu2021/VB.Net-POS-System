Imports MySql.Data.MySqlClient
Imports UAS_1.Core
Imports UAS_1.Models
Imports UAS_1.Utils
Imports System.Collections.Generic

Namespace Repositories
    Public Class ProductRepository
        Public Function GetAllProducts() As List(Of Product)
            Dim listBarang As New List(Of Product)
            Try
                Using conn = DatabaseConnection.GetConnection()
                    Dim cmd As New MySqlCommand("SELECT * FROM products", conn)
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            listBarang.Add(New Product With {
                                .Id = Convert.ToInt32(rd("product_id")),
                                .Code = rd("product_code").ToString(),
                                .Name = rd("product_name").ToString(),
                                .Price = Convert.ToInt32(rd("price")),
                                .Stock = Convert.ToInt32(rd("stock"))
                            })
                        End While
                    End Using
                End Using
            Catch ex As Exception
                Logger.LogError("Gagal mengambil data produk.", ex)
                Throw
            End Try
            Return listBarang
        End Function
        
        Public Function GetProductById(id As Integer) As Product
             Dim prod As Product = Nothing
             Using conn = DatabaseConnection.GetConnection()
                 Dim cmd As New MySqlCommand("SELECT * FROM products WHERE product_id = @id", conn)
                 cmd.Parameters.AddWithValue("@id", id)
                 Using rd = cmd.ExecuteReader()
                     If rd.Read() Then
                         prod = New Product With {
                            .Id = Convert.ToInt32(rd("product_id")),
                            .Code = rd("product_code").ToString(),
                            .Name = rd("product_name").ToString(),
                            .Price = Convert.ToInt32(rd("price")),
                            .Stock = Convert.ToInt32(rd("stock"))
                        }
                     End If
                 End Using
             End Using
             Return prod
        End Function

        Public Sub CreateProduct(p As Product)
            Using conn = DatabaseConnection.GetConnection()
                Dim query As String = "INSERT INTO products (product_code, product_name, price, stock) VALUES (@code, @name, @price, @stock)"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", p.Code)
                cmd.Parameters.AddWithValue("@name", p.Name)
                cmd.Parameters.AddWithValue("@price", p.Price)
                cmd.Parameters.AddWithValue("@stock", p.Stock)
                cmd.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub UpdateProduct(p As Product)
            Using conn = DatabaseConnection.GetConnection()
                Dim query As String = "UPDATE products SET product_name=@name, price=@price, stock=@stock WHERE product_code=@code"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", p.Code)
                cmd.Parameters.AddWithValue("@name", p.Name)
                cmd.Parameters.AddWithValue("@price", p.Price)
                cmd.Parameters.AddWithValue("@stock", p.Stock)
                cmd.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DeleteProduct(code As String)
            Using conn = DatabaseConnection.GetConnection()
                Dim query As String = "DELETE FROM products WHERE product_code=@code"
                Dim cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@code", code)
                cmd.ExecuteNonQuery()
            End Using
        End Sub
    End Class
End Namespace