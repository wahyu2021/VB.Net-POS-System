Imports MySql.Data.MySqlClient
Imports System.Data
Imports UAS_1.Utils

Namespace Core
    Public Class DatabaseConnection
        ' Hapus Singleton (_instance) karena menyebabkan masalah "Connection Disposed"
        ' saat menggunakan blok 'Using' di repository.

        Public Shared Function GetConnection() As MySqlConnection
            Dim conn As New MySqlConnection("Server=localhost;Database=uas_vb_db_penjualan;Uid=root;Pwd=;")
            Try
                conn.Open()
                ' Logger.LogInfo("Koneksi database berhasil dibuka.") ' Optional: Terlalu berisik jika setiap query log ini
            Catch ex As Exception
                Logger.LogError("Gagal membuka koneksi database.", ex)
                Throw
            End Try
            Return conn
        End Function
    End Class
End Namespace