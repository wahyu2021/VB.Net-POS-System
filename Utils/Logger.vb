Imports System.IO

Namespace Utils
    Public Class Logger
        ' Simpan log di folder "Logs" agar lebih rapi
        Private Shared ReadOnly LogDirectory As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")
        Private Shared ReadOnly LockObj As New Object()

        ' Constructor statis untuk memastikan folder ada saat pertama kali class dipanggil
        Shared Sub New()
            Try
                If Not Directory.Exists(LogDirectory) Then
                    Directory.CreateDirectory(LogDirectory)
                End If
            Catch ex As Exception
                System.Diagnostics.Debug.WriteLine("Gagal membuat folder Logs: " & ex.Message)
            End Try
        End Sub

        ' Nama file log dibuat dinamis per hari (Log Rotation)
        Private Shared ReadOnly Property LogPath As String
            Get
                Return Path.Combine(LogDirectory, $"application_{DateTime.Now:yyyyMMdd}.log")
            End Get
        End Property

        Private Shared Sub WriteLog(level As String, message As String, Optional ex As Exception = Nothing)
            SyncLock LockObj
                Try
                    Using writer As New StreamWriter(LogPath, True)
                        Dim timestamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                        Dim logEntry As String = $"[{timestamp}] [{level}] {message}"

                        If ex IsNot Nothing Then
                            logEntry &= Environment.NewLine & $"Exception: {ex.GetType().Name}"
                            logEntry &= Environment.NewLine & $"Message: {ex.Message}"
                            logEntry &= Environment.NewLine & $"Stack Trace: {ex.StackTrace}"
                        End If

                        writer.WriteLine(logEntry)
                    End Using
                Catch internalEx As Exception
                    ' Jika logging gagal (misal disk penuh), jangan crash aplikasi.
                    ' Cukup output ke Debug console.
                    System.Diagnostics.Debug.WriteLine($"Logging failed: {internalEx.Message}")
                End Try
            End SyncLock
        End Sub

        Public Shared Sub LogInfo(message As String)
            WriteLog("INFO", message)
        End Sub

        Public Shared Sub LogWarning(message As String)
            WriteLog("WARNING", message)
        End Sub

        Public Shared Sub LogError(message As String, Optional ex As Exception = Nothing)
            WriteLog("ERROR", message, ex)
        End Sub
    End Class
End Namespace