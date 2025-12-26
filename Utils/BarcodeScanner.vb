Imports AForge.Video
Imports AForge.Video.DirectShow
Imports ZXing
Imports ZXing.Windows.Compatibility
Imports System.Drawing

Namespace Utils
    Public Class BarcodeScanner
        Private _filterInfo As FilterInfoCollection
        Private _captureDevice As VideoCaptureDevice
        Private _targetPictureBox As PictureBox
        Private _onBarcodeDetected As Action(Of String)

        Public ReadOnly Property IsRunning As Boolean
            Get
                Return _captureDevice IsNot Nothing AndAlso _captureDevice.IsRunning
            End Get
        End Property

        Public Sub New(targetPictureBox As PictureBox)
            _targetPictureBox = targetPictureBox
        End Sub

        Public Function GetAvailableDevices() As List(Of String)
            Dim devices As New List(Of String)
            Try
                _filterInfo = New FilterInfoCollection(FilterCategory.VideoInputDevice)
                For Each device As FilterInfo In _filterInfo
                    devices.Add(device.Name)
                Next
            Catch ex As Exception
                Logger.LogError("Error getting camera devices", ex)
            End Try
            Return devices
        End Function

        Public Sub StartScanning(deviceIndex As Integer, onDetected As Action(Of String))
            Try
                StopScanning()

                If _filterInfo Is Nothing OrElse deviceIndex < 0 OrElse deviceIndex >= _filterInfo.Count Then
                    Throw New ArgumentException("Invalid device index")
                End If

                _onBarcodeDetected = onDetected
                _captureDevice = New VideoCaptureDevice(_filterInfo(deviceIndex).MonikerString)
                AddHandler _captureDevice.NewFrame, AddressOf OnNewFrame
                _captureDevice.Start()
            Catch ex As Exception
                Logger.LogError("Error starting camera", ex)
                Throw
            End Try
        End Sub

        Public Sub StopScanning()
            If _captureDevice IsNot Nothing AndAlso _captureDevice.IsRunning Then
                _captureDevice.SignalToStop()
                _captureDevice.WaitForStop()
            End If
        End Sub

        Private Sub OnNewFrame(sender As Object, eventArgs As NewFrameEventArgs)
            Try
                Dim bmp = DirectCast(eventArgs.Frame.Clone(), Bitmap)
                If _targetPictureBox.InvokeRequired Then
                    _targetPictureBox.Invoke(Sub() _targetPictureBox.Image = bmp)
                Else
                    _targetPictureBox.Image = bmp
                End If
            Catch ex As Exception
                Logger.LogError("Error capturing frame", ex)
            End Try
        End Sub

        Public Function TryDecode() As String
            If _targetPictureBox.Image Is Nothing Then Return Nothing

            Try
                Dim reader As New BarcodeReader()
                Dim result As Result = reader.Decode(DirectCast(_targetPictureBox.Image, Bitmap))
                If result IsNot Nothing Then
                    Return result.Text
                End If
            Catch ex As Exception
                Logger.LogError("Error decoding barcode", ex)
            End Try
            Return Nothing
        End Function
    End Class
End Namespace
