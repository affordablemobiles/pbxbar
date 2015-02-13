Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Public Class manager_send
    Public Sub ReconnectAgent()
        Dim proto As String = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        Dim extension As String = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        Dim protodial As String
        If proto = "EXTERNAL" Or proto = "Local" Then
            protodial = "Local"
        Else
            protodial = proto
        End If
        Dim origionatevalue As String = protodial & "/" & extension

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "OriginateVDRelogin"
        variables("format") = "Text"
        variables("channel") = origionatevalue
        variables("queryCID") = "AgentCallback"
        variables("exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("ext_priority") = "1"
        variables("extension") = extension
        variables("protocol") = proto
        variables("phone_ip") = If(GlobalVars.jsVars.ContainsKey("phone_ip"), GlobalVars.jsVars("phone_ip"), String.Empty)
        variables("enable_sipsak_messages") = If(GlobalVars.jsVars.ContainsKey("enable_sipsak_messages"), GlobalVars.jsVars("enable_sipsak_messages"), String.Empty)
        variables("allow_sipsak_messages") = If(GlobalVars.jsVars.ContainsKey("allow_sipsak_messages"), GlobalVars.jsVars("allow_sipsak_messages"), String.Empty)
        variables("campaign") = GlobalVars.campaign
        variables("outbound_cid") = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)

        GlobalVars.agentConnectTime = 0
    End Sub

    Public Sub parkCall(custchannel As String, custserverip As String)
        Dim proto As String = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        Dim extension As String = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        Dim protodial As String
        If proto = "EXTERNAL" Or proto = "Local" Then
            protodial = "Local"
        Else
            protodial = proto
        End If
        Dim origionatevalue As String = protodial & "/" & extension

        If If(GlobalVars.jsVars.ContainsKey("CalLCID"), GlobalVars.jsVars("CalLCID"), String.Empty).Length < 1 Then
            GlobalVars.jsVars("CalLCID") = If(GlobalVars.jsVars.ContainsKey("MDnextCID"), GlobalVars.jsVars("MDnextCID"), String.Empty)
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "RedirectToPark"
        variables("format") = "text"
        variables("channel") = custchannel
        variables("call_server_ip") = custserverip
        variables("queryCID") = "LPvdcW" & If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty) & If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("exten") = If(GlobalVars.jsVars.ContainsKey("park_on_extension"), GlobalVars.jsVars("park_on_extension"), String.Empty)
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("ext_priority") = "1"
        variables("extenName") = "park"
        variables("parkedby") = origionatevalue
        variables("session_id") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("CalLCID") = GlobalVars.jsVars("CalLCID")
        variables("uniqueid") = GlobalVars.uniqueid
        variables("lead_id") = GlobalVars.lead_id
        variables("campaign") = GlobalVars.campaign

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)
    End Sub

    Public Sub unparkCall(custchannel As String, custserverip As String)
        Dim dst_dialstring As String
        If If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty) = custserverip And custserverip.Length > 6 Then
            dst_dialstring = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        Else
            If custserverip.Length > 6 Then
                dst_dialstring = If(GlobalVars.jsVars.ContainsKey("server_ip_dialstring"), GlobalVars.jsVars("server_ip_dialstring"), String.Empty) & "" & If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
            Else
                dst_dialstring = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
            End If
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "RedirectFromPark"
        variables("format") = "text"
        variables("channel") = custchannel
        variables("call_server_ip") = custserverip
        variables("queryCID") = "LPvdcW" & If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty) & If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("exten") = dst_dialstring
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("ext_priority") = "1"
        variables("session_id") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("CalLCID") = If(GlobalVars.jsVars.ContainsKey("CalLCID"), GlobalVars.jsVars("CalLCID"), String.Empty)
        variables("uniqueid") = GlobalVars.uniqueid
        variables("lead_id") = GlobalVars.lead_id
        variables("campaign") = GlobalVars.campaign

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)
    End Sub

    Public Sub xferLocal(custchannel As String, custserverip As String, queue As String)
        Me.xferLocalExtended(custchannel, custserverip, queue, String.Empty)
    End Sub

    Public Sub xferToAgent(custchannel As String, custserverip As String, agent As String)
        Me.xferLocalExtended(custchannel, custserverip, "AGENTDIRECT", agent)
    End Sub

    Public Sub xferBlind(custchannel As String, custserverip As String, exten As String)
        Me.RedirectVR(custchannel, custserverip, exten, "XBvdcW")
    End Sub

    Private Sub xferLocalExtended(custchannel As String, custserverip As String, queue As String, agent As String)
        Dim redirectDestination As String = "990009*" & queue & "**" & GlobalVars.lead_id & "**" & GlobalVars.jsVars("dialed_number") & "*" & GlobalVars.username & "*" & agent & "*"

        Me.RedirectVR(custchannel, custserverip, redirectDestination, "XLvdcW")
    End Sub

    Private Sub RedirectVR(custchannel As String, custserverip As String, exten As String, cid As String)
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "RedirectVD"
        variables("format") = "text"
        variables("channel") = custchannel
        variables("call_server_ip") = custserverip
        variables("queryCID") = cid & If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty) & If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("exten") = exten
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("ext_priority") = "1"
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("auto_dial_level"), GlobalVars.jsVars("auto_dial_level"), String.Empty)
        variables("campaign") = GlobalVars.campaign
        variables("uniqueid") = GlobalVars.uniqueid
        variables("lead_id") = GlobalVars.lead_id
        variables("secondS") = GlobalVars.VD_live_call_seconds.ToString()
        variables("session_id") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)
    End Sub

    Public Sub conf_send_monitor(type As String, conference As String)
        Dim variables As New Dictionary(Of String, String)

        Dim tmp_uniqueid As String
        ''If GlobalVars.jsVars("inOUT") = "OUT" Then
        ''tmp_uniqueid = GlobalVars.uniqueid
        ''Else
        tmp_uniqueid = "IN"
        ''End If

        Dim tmp_channelrec As String = String.Empty
        Dim strFilename As String = String.Empty
        Dim tmp_recordingext As String = String.Empty

        If type = "MonitorConf" Then
            Dim tmp_vendorLeadCode As String = Regex.Replace(GlobalVars.vendor_lead_code, " ", "")
            strFilename = If(GlobalVars.jsVars.ContainsKey("LIVE_campaign_rec_filename"), GlobalVars.jsVars("LIVE_campaign_rec_filename"), String.Empty)

            strFilename = Regex.Replace(strFilename, "CAMPAIGN", GlobalVars.campaign)
            strFilename = Regex.Replace(strFilename, "CUSTPHONE", If(GlobalVars.jsVars.ContainsKey("lead_dial_number"), GlobalVars.jsVars("lead_dial_number"), String.Empty))
            strFilename = Regex.Replace(strFilename, "FULLDATE", If(GlobalVars.jsVars.ContainsKey("filedate"), GlobalVars.jsVars("filedate"), String.Empty))
            strFilename = Regex.Replace(strFilename, "TINYDATE", If(GlobalVars.jsVars.ContainsKey("tinydate"), GlobalVars.jsVars("tinydate"), String.Empty))
            strFilename = Regex.Replace(strFilename, "EPOCH", If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty))
            strFilename = Regex.Replace(strFilename, "AGENT", GlobalVars.username)
            strFilename = Regex.Replace(strFilename, "VENDORLEADCODE", tmp_vendorLeadCode)
            strFilename = Regex.Replace(strFilename, "LEADID", GlobalVars.lead_id)

            GlobalVars.recordingFilename = strFilename

            tmp_recordingext = If(GlobalVars.jsVars.ContainsKey("recording_exten"), GlobalVars.jsVars("recording_exten"), String.Empty)
            tmp_channelrec = "Local/" & If(GlobalVars.jsVars.ContainsKey("conf_silent_prefix"), GlobalVars.jsVars("conf_silent_prefix"), String.Empty) & String.Empty & conference & "@" & If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        ElseIf type = "StopMonitorConf" Then
            strFilename = GlobalVars.recordingFilename

            tmp_recordingext = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
            tmp_channelrec = "Local/" & If(GlobalVars.jsVars.ContainsKey("conf_silent_prefix"), GlobalVars.jsVars("conf_silent_prefix"), String.Empty) & String.Empty & conference & "@" & If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        Else
            Exit Sub
        End If

        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = type
        variables("format") = "text"
        variables("channel") = tmp_channelrec
        variables("filename") = strFilename
        variables("exten") = tmp_recordingext
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("lead_id") = GlobalVars.lead_id
        variables("ext_priority") = "1"
        variables("FROMvdc") = "YES"
        variables("uniqueid") = tmp_uniqueid

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)

        Dim strRCLookResponse() As String = strReturn.Split(vbLf)
        Dim strRCLookFile() As String = strRCLookResponse(1).Split("Filename: ")
        Dim strRCLookID() As String = strRCLookResponse(2).Split("RecorDing_ID: ")

        GlobalVars.recordingActualFilename = strRCLookFile(1)
        GlobalVars.recordingID = strRCLookID(1)
    End Sub

    Public Sub hangupRecordings(conference As String)
        Dim tmp_channelrec As String = "Local/" & If(GlobalVars.jsVars.ContainsKey("conf_silent_prefix"), GlobalVars.jsVars("conf_silent_prefix"), String.Empty) & String.Empty & conference & "@" & If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "HangupRecordings"
        variables("format") = "text"
        variables("channel") = tmp_channelrec
        variables("exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("lead_id") = GlobalVars.lead_id
        variables("ext_priority") = "1"
        variables("FROMvdc") = "YES"

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)
    End Sub

    Public Sub originateCall(tasknum As String, taskcid As String, isXfer As Boolean, callVariables As String)
        Dim originatevalue = "Local/" & tasknum & "@" & If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)

        Dim leadCID As String = GlobalVars.func.set_length(GlobalVars.lead_id, 10, "left")
        Dim epochCID As String = GlobalVars.func.set_length(If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty), 6, "right")
        Dim queryCID As String
        If isXfer Then
            queryCID = "DC" & epochCID & "W" & leadCID & "W"
        Else
            queryCID = "DV" & epochCID & "W" & leadCID & "W"
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "Originate"
        variables("format") = "text"
        variables("channel") = originatevalue
        variables("queryCID") = queryCID
        variables("exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("ext_priority") = "1"
        variables("outbound_cid") = taskcid
        variables("usegroupalias") = "0"
        variables("preset_name") = String.Empty
        variables("campaign") = GlobalVars.campaign
        variables("account") = String.Empty
        variables("agent_dialed_number") = "1"
        variables("agent_dialed_type") = If(GlobalVars.jsVars.ContainsKey("agent_dialed_type"), GlobalVars.jsVars("agent_dialed_type"), String.Empty)
        variables("lead_id") = GlobalVars.lead_id
        variables("stage") = If(GlobalVars.jsVars.ContainsKey("CheckDEADcallON"), GlobalVars.jsVars("CheckDEADcallON"), String.Empty)
        variables("alertCID") = "0"
        variables("call_variables") = callVariables

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)

        GlobalVars.MD_channel_look = True
        If isXfer Then
            GlobalVars.jsVars("XDnextCID") = queryCID
            GlobalVars.jsVars("XDcheck") = "YES"
        Else
            GlobalVars.jsVars("MDnextCID") = queryCID
            GlobalVars.jsVars("MDcheck") = "YES"
        End If

    End Sub

    Public Sub hangupXferLine()
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = "Hangup"
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("channel") = GlobalVars.jsVars("XDchannel")
        variables("queryCID") = "HXvdcW" & If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty) & If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("log_campaign") = GlobalVars.campaign
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)

        GlobalVars.jsVars("XDchannel") = String.Empty
    End Sub

    Public Sub Leave3wayCall()
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("ACTION") = "RedirectXtraNeW"
        variables("format") = "text"
        variables("channel") = GlobalVars.jsVars("lastcustchannel")
        variables("call_server_ip") = GlobalVars.jsVars("lastcustserverip")
        variables("queryCID") = "VXvdcW" & If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty) & If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("exten") = "NEXTAVAILABLE"
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("ext_priority") = "1"
        variables("extrachannel") = If(GlobalVars.jsVars.ContainsKey("XDchannel"), GlobalVars.jsVars("XDchannel"), String.Empty)
        variables("lead_id") = GlobalVars.lead_id
        variables("phone_code") = GlobalVars.phone_code
        variables("phone_number") = GlobalVars.phone_number
        variables("filename") = ""
        variables("campaign") = GlobalVars.campaign
        variables("session_id") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("agentchannel") = If(GlobalVars.jsVars.ContainsKey("agentchannel"), GlobalVars.jsVars("agentchannel"), String.Empty)
        variables("protocol") = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        variables("extension") = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("auto_dial_level"), GlobalVars.jsVars("auto_dial_level"), String.Empty)

        GlobalVars.agentConnectTime = 0

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)

        Dim vars As String() = strReturn.Split("|")
        If vars(0) = "NeWSessioN" Then
            GlobalVars.jsVars("session_id") = vars(1)
            ''MessageBox.Show("New Session ID: """ & vars(1) & """")
        End If
    End Sub
End Class
