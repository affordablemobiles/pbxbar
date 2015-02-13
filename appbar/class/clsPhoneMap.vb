Imports System.Xml
Public Class clsPhoneMap
    Public Function fetchPhoneNumber() As String
        Try
            Dim sysInfo As New clsWMI()
            ''MessageBox.Show(sysInfo.ComputerName)

            Dim request As New PBXWebRequest()
            Dim strResponse As String = request.getRequest(My.Settings.mappingURL)

            Dim doc As New XmlDocument()
            doc.LoadXml(strResponse)

            Dim computerElement As XmlElement = doc.GetElementById(sysInfo.ComputerName.ToString().ToUpper())
            If computerElement.IsEmpty Then
                MessageBox.Show("Phone Mapping Doesn't Exist", "Phone Mapping Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return ""
            Else
                ''MessageBox.Show(computerElement.InnerText)
                Return computerElement.InnerText
            End If
        Catch ex As Exception
            MessageBox.Show("Mapping Failed, Using Default", "Phone Mapping Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return ""
        End Try
    End Function
End Class
