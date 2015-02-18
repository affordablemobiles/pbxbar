Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class vdc_db_query
    Private user As String = ""
    Private pass As String = ""

    Public Sub setUserPass(username As String, password As String)
        Me.user = username
        Me.pass = password
    End Sub

    Public Function LoginCampaigns() As Dictionary(Of String, String)
        Dim variables As New Dictionary(Of String, String)
        variables("chklogin") = "0"
        variables("format") = "html"
        variables("user") = Me.user
        variables("pass") = Me.pass

        Dim strReturn As String = Me.postRequest("LogiNCamPaigns", variables)
        Dim dictValues As New Dictionary(Of String, String)

        'MessageBox.Show(strReturn)

        For Each match As Match In Regex.Matches(strReturn, "\<option value\=\""(.+)"">(.+)</option>", RegexOptions.IgnoreCase)
            dictValues(match.Groups.Item(1).ToString()) = match.Groups.Item(2).ToString()
        Next

        Return dictValues
    End Function

    Public Sub registerQueues()
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("campaign") = GlobalVars.campaign
        variables("comments") = String.Empty
        variables("qm_phone") = If(GlobalVars.jsVars.ContainsKey("qm_phone"), GlobalVars.jsVars("qm_phone"), String.Empty)
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)
        variables("dial_methodRATIO") = String.Empty

        Dim queues As String = " " & If(GlobalVars.jsArrays.ContainsKey("ingroups"), String.Join(" ", GlobalVars.jsArrays("ingroups")), String.Empty) & " -"
        ''variables("closer_choice") = " " & If(GlobalVars.jsVars.ContainsKey("VU_closer_campaigns"), GlobalVars.jsVars("VU_closer_campaigns"), String.Empty)
        ''MessageBox.Show("Registering for Queues" & vbLf & queues)
        variables("closer_choice") = queues

        Dim strReturn As String = Me.postRequest("regCLOSER", variables)
    End Sub

    Public Sub DialLog(task As String, nodeletevdac As String)
        Me.DialLog(task, nodeletevdac, "0")
    End Sub

    Public Sub DialLog(task As String, nodeletevdac As String, blindtransfer As String)
        Dim variables As New Dictionary(Of String, String)
        variables("format") = "text"
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("stage") = task
        variables("uniqueid") = GlobalVars.uniqueid
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("campaign") = GlobalVars.campaign
        variables("lead_id") = GlobalVars.lead_id
        variables("list_id") = GlobalVars.list_id
        variables("length_in_sec") = GlobalVars.VD_live_call_seconds.ToString()
        variables("phone_code") = GlobalVars.phone_code
        variables("phone_number") = GlobalVars.phone_number
        variables("exten") = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        variables("channel") = If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty)
        variables("start_epoch") = "undefined"
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("auto_dial_level"), GlobalVars.jsVars("auto_dial_level"), String.Empty)
        variables("VDstop_rec_after_each_call") = If(GlobalVars.jsVars.ContainsKey("VDstop_rec_after_each_call"), GlobalVars.jsVars("VDstop_rec_after_each_call"), String.Empty)
        variables("conf_silent_prefix") = If(GlobalVars.jsVars.ContainsKey("conf_silent_prefix"), GlobalVars.jsVars("conf_silent_prefix"), String.Empty)
        variables("protocol") = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        variables("extension") = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("user_abb") = If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("MDnextCID") = If(GlobalVars.jsVars.ContainsKey("LasTCID"), GlobalVars.jsVars("LasTCID"), String.Empty)
        variables("inOUT") = GlobalVars.inOUT
        variables("alt_dial") = If(GlobalVars.jsVars.ContainsKey("dialed_label"), GlobalVars.jsVars("dialed_label"), String.Empty)
        variables("DB") = "0"
        variables("agentchannel") = If(GlobalVars.jsVars.ContainsKey("dialed_label"), GlobalVars.jsVars("agentchannel"), String.Empty)
        variables("conf_dialed") = If(GlobalVars.jsVars.ContainsKey("conf_dialed"), GlobalVars.jsVars("conf_dialed"), String.Empty)
        variables("leaving_threeway") = If(GlobalVars.jsVars.ContainsKey("leaving_threeway"), GlobalVars.jsVars("leaving_threeway"), String.Empty)
        variables("hangup_all_non_reserved") = If(GlobalVars.jsVars.ContainsKey("hangup_all_non_reserved"), GlobalVars.jsVars("hangup_all_non_reserved"), String.Empty)
        variables("blind_transfer") = blindtransfer
        variables("dial_method" & If(GlobalVars.jsVars.ContainsKey("dial_method"), GlobalVars.jsVars("dial_method"), String.Empty)) = String.Empty
        variables("nodeletevdac") = nodeletevdac
        variables("alt_num_status") = If(GlobalVars.jsVars.ContainsKey("alt_num_status"), GlobalVars.jsVars("alt_num_status"), String.Empty)
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)

        Dim strReturn As String = Me.postRequest("manDiaLlogCaLL", variables)
    End Sub

    Public Function refresh_agents() As Dictionary(Of String, String)
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("user_group") = If(GlobalVars.jsVars.ContainsKey("VU_user_group"), GlobalVars.jsVars("VU_user_group"), String.Empty)
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("extension") = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        variables("protocol") = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        variables("stage") = If(GlobalVars.jsVars.ContainsKey("agent_status_view_time"), GlobalVars.jsVars("agent_status_view_time"), String.Empty)
        variables("campaign") = GlobalVars.campaign
        variables("comments") = "AgentXferViewSelect"

        Dim strReturn As String = postRequest("AGENTSview", variables)
        ''MessageBox.Show(strReturn)
        Dim dictValues As New Dictionary(Of String, String)

        For Each match As Match In Regex.Matches(strReturn, "<a href\=""\#"" onclick\=""AgentsXferSelect\(\'([^']+)\'\,\'AgentXferViewSelect\'\)\;return false\;"">([^<]+)<\/a>", RegexOptions.IgnoreCase)
            If Not match.Groups.Item(1).ToString() = GlobalVars.username Then
                dictValues(match.Groups.Item(1).ToString()) = match.Groups.Item(2).ToString()
            End If
            ''MessageBox.Show(match.Groups.Item(1).ToString() & vbLf & match.Groups.Item(2).ToString())
        Next

        Return dictValues
    End Function

    Public Sub dispoSubmit(dispo As String)
        Me.dispoSubmit(dispo, String.Empty, String.Empty, String.Empty, False)
    End Sub

    Public Sub dispoSubmit(dispo As String, callback_datetime As String, recipient As String, comments As String, callback As Boolean)
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("dispo_choice") = dispo
        variables("lead_id") = GlobalVars.lead_id
        variables("campaign") = GlobalVars.campaign
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("auto_dial_level"), GlobalVars.jsVars("auto_dial_level"), String.Empty)
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("CallBackDatETimE") = callback_datetime
        variables("list_id") = GlobalVars.list_id
        variables("recipient") = recipient
        variables("use_internal_dnc") = If(GlobalVars.jsVars.ContainsKey("use_internal_dnc"), GlobalVars.jsVars("use_internal_dnc"), String.Empty)
        variables("use_campaign_dnc") = If(GlobalVars.jsVars.ContainsKey("use_campaign_dnc"), GlobalVars.jsVars("use_campaign_dnc"), String.Empty)
        variables("MDnextCID") = If(GlobalVars.jsVars.ContainsKey("MDnextCID"), GlobalVars.jsVars("MDnextCID"), String.Empty)
        variables("stage") = If(GlobalVars.jsVars.ContainsKey("VDCL_group_id") And GlobalVars.jsVars("VDCL_group_id").Length > 1, GlobalVars.jsVars("VDCL_group_id"), GlobalVars.campaign)
        variables("vtiger_callback_id") = "0"
        variables("phone_number") = GlobalVars.phone_number
        variables("phone_code") = GlobalVars.phone_code
        variables("dial_method" & GlobalVars.jsVars("dial_method")) = String.Empty
        variables("uniqueid") = GlobalVars.uniqueid
        variables("CallBackLeadStatus") = If(callback = True, "CALLBK", String.Empty)
        variables("comments") = comments
        variables("custom_field_names") = "|"
        variables("call_notes") = String.Empty
        variables("qm_dispo_code") = String.Empty

        Dim strReturn As String = Me.postRequest("updateDISPO", variables)
    End Sub

    Public Sub pauseCodeSubmit(status As String)
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("format") = "text"
        variables("status") = status
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("campaign") = GlobalVars.campaign
        variables("extension") = If(GlobalVars.jsVars.ContainsKey("extension"), GlobalVars.jsVars("extension"), String.Empty)
        variables("protocol") = If(GlobalVars.jsVars.ContainsKey("protocol"), GlobalVars.jsVars("protocol"), String.Empty)
        variables("phone_ip") = If(GlobalVars.jsVars.ContainsKey("phone_ip"), GlobalVars.jsVars("phone_ip"), String.Empty)
        variables("enable_sipsak_messages") = If(GlobalVars.jsVars.ContainsKey("enable_sipsak_messages"), GlobalVars.jsVars("enable_sipsak_messages"), String.Empty)
        variables("campaign_cid") = If(GlobalVars.jsVars.ContainsKey("LastCallCID"), GlobalVars.jsVars("LastCallCID"), String.Empty)
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("starting_dial_level"), GlobalVars.jsVars("starting_dial_level"), String.Empty)
        variables("stage") = GlobalVars.PauseCode_Count.ToString()

        Dim strReturn As String = Me.postRequest("PauseCodeSubmit", variables)

        Dim check_PC_array As String() = strReturn.Split(vbLf)
        Try
            If check_PC_array(1) = "Next agent_log_id:" Then
                GlobalVars.jsVars("agent_log_id") = check_PC_array(2)
            End If
        Catch ex As Exception

        End Try

        GlobalVars.PauseCode_Count += 1
    End Sub

    Public Sub updateLead(title As String, firstName As String, middleName As String, lastName As String, _
                          addressLine1 As String, townCity As String, county As String, postCode As String, _
                          phoneNumber As String, altPhoneNumber As String, email As String, comments As String)

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("campaign") = GlobalVars.campaign
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("lead_id") = GlobalVars.lead_id
        variables("vendor_lead_code") = String.Empty
        variables("title") = title
        variables("first_name") = firstName
        variables("middle_initial") = middleName
        variables("last_name") = lastName
        variables("address1") = addressLine1
        variables("address2") = String.Empty
        variables("address3") = String.Empty
        variables("city") = townCity
        variables("province") = String.Empty
        variables("postal_code") = postCode
        variables("country_code") = String.Empty
        variables("phone_number") = phoneNumber
        variables("alt_phone") = altPhoneNumber
        variables("email") = email
        variables("security_phrase") = String.Empty
        variables("comments") = comments

        Me.postRequest("updateLEAD", variables)
    End Sub

    Public Function callbackList() As String
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("campaign") = GlobalVars.campaign
        variables("format") = "text"
        Dim strReturn As String = Me.postRequest("CalLBacKLisT", variables)
        'Dim strParsed As String() = strReturn.Split(vbLf)
        'If strParsed.GetLength(0) > 1 Then
        '    For i As Integer = 1 To strParsed.GetLength(0) - 1
        '        Dim strParsedLine As String() = strParsed(i).Split(" ~")

        '        MessageBox.Show(strParsedLine.)
        '    Next
        'End If

        Return "Fail"
    End Function

    Public Function manualDialCheckChannel(fromXfer As Boolean) As String
        Dim CIDcheck As String
        Dim stage As String
        If fromXfer Then
            CIDcheck = If(GlobalVars.jsVars.ContainsKey("XDnextCID"), GlobalVars.jsVars("XDnextCID"), String.Empty)
            stage = "YES"
        Else
            CIDcheck = If(GlobalVars.jsVars.ContainsKey("MDnextCID"), GlobalVars.jsVars("MDnextCID"), String.Empty)
            stage = "NO"
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("MDnextCID") = CIDcheck
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("lead_id") = GlobalVars.lead_id
        variables("DiaL_SecondS") = GlobalVars.MD_ring_secondS
        variables("stage") = stage

        Dim strReturn As String = Me.postRequest("manDiaLlookCaLL", variables)
        Dim MDlookReturn As String() = strReturn.Split(vbLf)
        Dim MDlookCID As String = MDlookReturn(0)
        If MDlookCID = "NO" Then
            Return "FALSE"
        Else
            If Regex.IsMatch(MDlookReturn(1), "^SIP") Then
                If fromXfer Then
                    GlobalVars.jsVars("XDuniqueid") = MDlookReturn(0)
                    GlobalVars.jsVars("XDchannel") = MDlookReturn(1)
                    Dim XDalert As String = MDlookReturn(2)
                    If XDalert = "ERROR" Then
                        MessageBox.Show("Transfer Dial Failed")
                        Return "ERROR"
                    End If
                    Return "TRUE"
                Else
                    GlobalVars.jsVars("MDuniqueid") = MDlookReturn(0)
                    GlobalVars.jsVars("MDchannel") = MDlookReturn(1)
                    GlobalVars.jsVars("lastcustchannel") = MDlookReturn(1)
                    Dim slice As New PBXBar.Toast.ToastForm(5000, "Outgoing Call Connected" & vbLf & vbLf & MDlookReturn(1) & vbLf & "ID: " & MDlookReturn(0))
                    slice.Height = 125
                    slice.Show()
                    Dim MDalert As String = MDlookReturn(2)
                    If MDalert = "ERROR" Then
                        MessageBox.Show("Outbound Dial Failed")
                        Return "ERROR"
                    End If
                    Return "TRUE"
                End If
            Else
                Return "CONTINUE"
            End If
        End If
    End Function

    Private Function postRequest(method As String, variables As Dictionary(Of String, String)) As String
        variables("ACTION") = method

        Dim request As New PBXWebRequest()

        Return request.postRequest("vdc_db_query.php", variables)
    End Function
End Class
