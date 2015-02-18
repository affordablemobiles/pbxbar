Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class Functions
    Public Function stripHTML(data As String) As String
        If Regex.IsMatch(data, "<.+>(.+)</.+>", RegexOptions.IgnoreCase) Then
            Dim match As Match = Regex.Match(data, "<.+>(.+)</.+>", RegexOptions.IgnoreCase)

            Return match.Groups.Item(1).ToString()
        Else
            Return data
        End If
    End Function

    Public Function set_length(value As String, length As Integer, where As String) As String
        While value.Length < length
            If where = "left" Then
                value = "0" & value
            Else
                value = value & "0"
            End If
        End While

        While value.Length > length
            If where = "left" Then
                value = value.Remove(0, 1)
            Else
                value = value.Remove(value.Length - 1, 1)
            End If
        End While

        Return value
    End Function

    Public Function isCallLive() As Boolean
        If Not GlobalVars.MD_call_live And Not GlobalVars.VD_live_customer_call Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function getAgentHandset() As String
        Dim proto As String = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        Dim extension As String = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        Dim protodial As String

        If proto = "EXTERNAL" Or proto = "Local" Then
            protodial = "Local"
        Else
            protodial = proto
        End If

        Return protodial & "/" & extension
    End Function

    Public Sub SendManualDial(number As String, isFromXfer As Boolean)
        Dim outbound_cid As String = "00000000"
        Dim callVariables As String = ""
        If isFromXfer Then
            If Not GlobalVars.jsVars.ContainsKey("three_way_call_cid") Then
                GlobalVars.jsVars("three_way_call_cid") = String.Empty
            End If

            If GlobalVars.jsVars("three_way_call_cid") = "CAMPAIGN" Then
                outbound_cid = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)
            ElseIf GlobalVars.jsVars("three_way_call_cid") = "AGENT_PHONE" Then
                outbound_cid = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)
            ElseIf GlobalVars.jsVars("three_way_call_cid") = "CUSTOMER" Then
                outbound_cid = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)
            End If

            GlobalVars.jsVars("agent_dialed_type") = "XFER_3WAY"

            GlobalVars.xferCallTime = 0

            callVariables = "__vendor_lead_code=" & GlobalVars.vendor_lead_code & ",__lead_id=" & GlobalVars.lead_id
        Else
            If Not GlobalVars.jsVars.ContainsKey("manual_dial_cid") Then
                GlobalVars.jsVars("manual_dial_cid") = String.Empty
            End If

            If GlobalVars.jsVars("manual_dial_cid") = "AGENT_PHONE" Then
                outbound_cid = If(GlobalVars.jsVars.ContainsKey("outbound_cid"), GlobalVars.jsVars("outbound_cid"), String.Empty)
            End If

            outbound_cid = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)
        End If

        GlobalVars.manager.originateCall(number, outbound_cid, isFromXfer, callVariables)
    End Sub

    Public Function getDispoList() As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        If GlobalVars.jsArrays("statuses").Length = GlobalVars.jsArrays("statusnames").Length Then
            If GlobalVars.jsArrays("statuses").Length = GlobalVars.jsArrays("SELstatuses").Length Then
                For i As Integer = 0 To GlobalVars.jsArrays("statuses").Length - 1
                    If GlobalVars.jsArrays("SELstatuses")(i) = "Y" Then
                        result.Add(GlobalVars.jsArrays("statuses")(i), GlobalVars.jsArrays("statusnames")(i))
                    End If
                Next
            Else
                MessageBox.Show("Error! Dispo Statuses and Select Allow List Not The Same Length!")
            End If
        Else
            MessageBox.Show("Error! Dispo Statuses and Status Names List Not The Same Length!")
        End If

        Return result
    End Function

    Public Function getPauseCodeList() As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)
        If GlobalVars.jsArrays("pause_codes").Length = GlobalVars.jsArrays("pause_code_names").Length Then
            For i As Integer = 0 To GlobalVars.jsArrays("pause_codes").Length - 1
                result.Add(GlobalVars.jsArrays("pause_codes")(i), GlobalVars.jsArrays("pause_code_names")(i))
            Next
        Else
            MessageBox.Show("Error! Pause Code list and name match-up list not the same length!")
        End If

        Return result
    End Function

    Public Sub updateDateTime()
        Dim now As DateTime = DateTime.Now
        GlobalVars.jsVars("filedate") = now.ToString("yyyyMMdd-HHmmss")
        GlobalVars.jsVars("tinydate") = (now.Year - 2000).ToString() & now.ToString("MMdd-HHmmss")
        GlobalVars.jsVars("SQLdate") = now.ToString("yyyy-MM-dd HH:mm:ss")
        GlobalVars.jsVars("epoch_sec") = (DateTime.Now - New DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds.ToString()
    End Sub

    Public Function isValidURL(url As String) As Boolean
        Dim pattern As String = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
        If Regex.IsMatch(url, pattern) Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub launchBrowser(url As String)
        If Me.isValidURL(url) Then
            If My.Settings.isChrome Then
                If File.Exists("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe") Then
                    Dim proc As New System.Diagnostics.Process()
                    proc = System.Diagnostics.Process.Start("C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", url)
                ElseIf File.Exists("C:\Program Files\Google\Chrome\Application\chrome.exe") Then
                    Dim proc As New System.Diagnostics.Process()
                    proc = System.Diagnostics.Process.Start("C:\Program Files\Google\Chrome\Application\chrome.exe", url)
                Else
                    MessageBox.Show("Chrome Not Found", "Screenpop Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                If File.Exists("C:\Program Files (x86)\Mozilla Firefox\firefox.exe") Then
                    Dim proc As New System.Diagnostics.Process()
                    proc = System.Diagnostics.Process.Start("C:\Program Files (x86)\Mozilla Firefox\firefox.exe", "-new-tab " & url)
                ElseIf File.Exists("C:\Program Files\Mozilla Firefox\firefox.exe") Then
                    Dim proc As New System.Diagnostics.Process()
                    proc = System.Diagnostics.Process.Start("C:\Program Files\Mozilla Firefox\firefox.exe", "-new-tab " & url)
                Else
                    MessageBox.Show("Firefox Not Found", "Screenpop Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Public Function validNumber(number As String, internal As Boolean) As Boolean
        If internal = True Then
            If Regex.IsMatch(number, "^([468]{1})([0-9]{3})$") Then
                Return True
            Else
                Return False
            End If
        Else
            If Regex.IsMatch(number, "^(?:(?:\(?(?:0(?:0|11)\)?[\s-]?\(?|\+)44\)?[\s-]?(?:\(?0\)?[\s-]?)?)|(?:\(?0))(?:(?:\d{5}\)?[\s-]?\d{4,5})|(?:\d{4}\)?[\s-]?(?:\d{5}|\d{3}[\s-]?\d{3}))|(?:\d{3}\)?[\s-]?\d{3}[\s-]?\d{3,4})|(?:\d{2}\)?[\s-]?\d{4}[\s-]?\d{4}))(?:[\s-]?(?:x|ext\.?|\#)\d{3,4})?$") Then
                Return True
            Else
                Return False
            End If
        End If
    End Function

    Public Function stripNonNumeric(strNumber As String) As String
        Return Regex.Replace(strNumber, "[^0-9]", "")
    End Function
End Class
