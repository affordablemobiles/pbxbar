Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class LogonOff
    Public Function Login(username As String, password As String, campaign As String) As Boolean
        Dim phoneInfo As New clsPhoneMap()

        Dim variables As New Dictionary(Of String, String)
        variables("relogin") = "NO"
        variables("DB") = String.Empty
        variables("JS_browser_height") = "1080"
        variables("JS_browser_width") = "1920"
        variables("phone_login") = phoneInfo.fetchPhoneNumber()
        variables("phone_pass") = "goautodial"
        variables("VD_login") = username
        variables("VD_pass") = password
        variables("VD_campaign") = campaign
        variables("SUBMIT.x") = "33"
        variables("SUBMIT.y") = "20"

        Dim request As New PBXWebRequest()

        Dim strReturn As String = request.postRequest("agent.php", variables)

        For Each match As Match In Regex.Matches(strReturn, "var ([a-zA-Z0-9_]+)\s*\=\s*(.+)\;", RegexOptions.IgnoreCase)
            GlobalVars.jsVars(match.Groups.Item(1).ToString()) = match.Groups.Item(2).ToString().Replace("'", "").Trim()
        Next

        For Each match As Match In Regex.Matches(strReturn, "VAR([a-zA-Z0-9_]+)\s*\=\s*new\s*Array\((.+)\)\;", RegexOptions.IgnoreCase)
            GlobalVars.jsArrays(match.Groups.Item(1).ToString()) = match.Groups.Item(2).ToString().Replace("'", "").Trim().Split(",")
            'MessageBox.Show(match.Groups.Item(1).ToString() & vbLf & vbLf & match.Groups.Item(2).ToString().Replace("'", "").Trim())
        Next

        If GlobalVars.jsVars.ContainsKey("session_id") Then
            If Not GlobalVars.jsVars("session_id") = String.Empty Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If

    End Function

    Public Function Logoff(tmpReason As String) As Boolean
        If tmpReason = String.Empty Then
            If GlobalVars.MD_channel_look = True Then
                MessageBox.Show("You cannot log out during a Dial attempt." & vbLf & "Wait 50 seconds for the dial to fail out if it is not answered")
                Return False
            ElseIf GlobalVars.VD_live_customer_call = True Then
                MessageBox.Show("STILL A LIVE CALL! Hang it up then you can log out.")
                Return False
            ElseIf GlobalVars.alt_dial_status_display = True Then
                MessageBox.Show("You are in ALT dial mode, you must finish the lead before logging out." & vbLf & GlobalVars.jsVars("reselect_alt_dial"))
                Return False
            End If
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = "userLOGout"
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("campaign") = GlobalVars.campaign
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("extension") = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        variables("protocol") = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("no_delete_sessions") = If(GlobalVars.jsVars.ContainsKey("no_delete_sessions"), GlobalVars.jsVars("no_delete_sessions"), String.Empty)
        variables("phone_ip") = If(GlobalVars.jsVars.ContainsKey("phone_ip"), GlobalVars.jsVars("phone_ip"), String.Empty)
        variables("enable_sipsak_messages") = If(GlobalVars.jsVars.ContainsKey("enable_sipsak_messages"), GlobalVars.jsVars("enable_sipsak_messages"), String.Empty)
        variables("LogouTKicKAlL") = If(GlobalVars.jsVars.ContainsKey("LogouTKicKAlL"), GlobalVars.jsVars("LogouTKicKAlL"), String.Empty)
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)

        Dim request As New PBXWebRequest()

        Dim strReturn As String = request.postRequest("vdc_db_query.php", variables)

        If tmpReason = "SHIFT" Then
            MessageBox.Show("Your Shift is over or has changed, you have been logged out of your session")
        ElseIf tmpReason = "API" Then
            MessageBox.Show("The system has received a command to log you out, you have been logged out of your session")
        End If

        Return True
    End Function
End Class