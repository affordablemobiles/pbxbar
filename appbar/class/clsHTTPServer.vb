Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Web

Public Class clsHTTPServer
    Implements IDisposable

    Public Event RecordingStart()
    Public Event RecordingStop()

    Private Const bufferSize As Integer = 1024 * 512
    '512KB
    Private ReadOnly http As HttpListener
    Public Sub New()
        http = New HttpListener()
        http.Prefixes.Add("http://localhost:9871/")
        http.Start()
        http.BeginGetContext(AddressOf requestWait, Nothing)
    End Sub

    Public Sub Dispose() Implements System.IDisposable.Dispose
        http.[Stop]()
    End Sub

    Private Sub requestWait(ByVal ar As IAsyncResult)
        If Not http.IsListening Then
            Return
        End If

        Dim c = http.EndGetContext(ar)
        http.BeginGetContext(AddressOf requestWait, Nothing)
        Dim url = tuneUrl(c.Request.RawUrl)

        Select Case url
            Case "recording/start"
                RaiseEvent RecordingStart()
                writeString(c, ("200 OK" & vbLf & "Call Recording Started"))
                return200(c)
            Case "recording/stop"
                RaiseEvent RecordingStop()
                writeString(c, ("200 OK" & vbLf & "Call Recording Stopped"))
                return200(c)
            Case "about"
                writeString(c, ("200 OK" & vbLf & "PBXBar Web Method Call" & vbLf & "by Samuel Melrose" & vbLf & "sam@infitialis.com"))
                return200(c)
            Case "about/version"
                Dim myBuildInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(Application.ExecutablePath)
                writeString(c, ("200 OK" & vbLf & "Application Version: " & myBuildInfo.ProductVersion & " build " & myBuildInfo.ProductBuildPart))
                return200(c)
            Case Else
                writeString(c, "404 Requested Method Not Found")
                return404(c)
        End Select
    End Sub

    Private Sub writeString(ByVal context As HttpListenerContext, strValue As String)
        context.Response.ContentType = "text/plain"
        context.Response.ContentEncoding = Encoding.UTF8
        Using sw = New StreamWriter(context.Response.OutputStream)
            sw.WriteLine(strValue)
        End Using
        context.Response.OutputStream.Close()
    End Sub

    Private Shared Sub return404(ByVal context As HttpListenerContext)
        context.Response.StatusCode = 404
        context.Response.Close()
    End Sub

    Private Shared Sub return200(ByVal context As HttpListenerContext)
        context.Response.StatusCode = 200
        context.Response.Close()
    End Sub

    Private Shared Function tuneUrl(ByVal url As String) As String
        'url = url.Replace("/"c, "\"c)
        url = HttpUtility.UrlDecode(url, Encoding.UTF8)
        url = url.Substring(1)
        Return url
    End Function

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, ByVal value As T) As T
        target = value
        Return value
    End Function
End Class