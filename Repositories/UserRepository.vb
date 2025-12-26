Imports MySql.Data.MySqlClient
Imports UAS_1.Core
Imports UAS_1.Models
Imports UAS_1.Utils

Namespace Repositories
    Public Class UserRepository
        Public Function Login(username As String, password As String) As User
            Dim user As User = Nothing
            Try
                Using conn = DatabaseConnection.GetConnection()
                    Dim query As String = "SELECT * FROM users WHERE username = @u AND password = @p AND is_active = 1"
                    Using cmd As New MySqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@u", username)
                        cmd.Parameters.AddWithValue("@p", password)
                        
                        Using rd = cmd.ExecuteReader()
                            If rd.Read() Then
                                user = New User With {
                                    .Id = Convert.ToInt32(rd("user_id")),
                                    .Username = rd("username").ToString(),
                                    .FullName = rd("full_name").ToString(),
                                    .Role = rd("role").ToString()
                                }
                            End If
                        End Using
                    End Using
                End Using
            Catch ex As Exception
                Logger.LogError($"Login failed for user: {username}", ex)
                Throw
            End Try
            Return user
        End Function
    End Class
End Namespace