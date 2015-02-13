Imports System
Imports System.IO
Imports System.Net
Imports System.Text

Public Class PBXWebRequest
    Public Function AcceptAllCertifications(ByVal sender As Object, ByVal certification As System.Security.Cryptography.X509Certificates.X509Certificate, ByVal chain As System.Security.Cryptography.X509Certificates.X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
        Return True
    End Function

    Public Function postRequest(url As String, variables As Dictionary(Of String, String)) As String
        Dim request As WebRequest = WebRequest.Create(My.Settings.agentURL & url)
        Dim dataStream As Stream

        ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

        request.Method = "POST"
        Dim postData As String = ""

        For Each pair As KeyValuePair(Of String, String) In variables
            postData = postData & "&" & pair.Key & "=" & pair.Value
        Next

        Dim byteArray As Byte() = Encoding.UTF8.GetBytes(postData)

        request.ContentType = "application/x-www-form-urlencoded"
        request.ContentLength = byteArray.Length
        CType(request, HttpWebRequest).UserAgent = "PBXBAR UA (Chrome/Firefox Compatible) v1.0"

        dataStream = request.GetRequestStream()
        dataStream.Write(byteArray, 0, byteArray.Length)
        dataStream.Close()

        Dim response As WebResponse = request.GetResponse()

        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        reader.Close()
        response.Close()

        Return responseFromServer
    End Function

    Public Function getRequest(url As String) As String
        Dim request As WebRequest = WebRequest.Create(url)
        Dim dataStream As Stream

        ServicePointManager.ServerCertificateValidationCallback = AddressOf AcceptAllCertifications

        request.Method = "GET"

        CType(request, HttpWebRequest).UserAgent = "PBXBAR UA (Chrome/Firefox Compatible) v1.0"

        Dim response As WebResponse = request.GetResponse()

        dataStream = response.GetResponseStream()
        Dim reader As New StreamReader(dataStream)
        Dim responseFromServer As String = reader.ReadToEnd()

        reader.Close()
        response.Close()

        Return responseFromServer
    End Function
End Class
