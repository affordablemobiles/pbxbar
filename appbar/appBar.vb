Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class mainform
#Region "Windows AppBar Variables"
    Private Structure RECT
        Public left As Integer
        Public top As Integer
        Public right As Integer
        Public bottom As Integer
    End Structure

    Private Structure APPBARDATA
        Public cbSize As Integer
        Public hWnd As IntPtr
        Public uCallbackMessage As Integer
        Public uEdge As Integer
        Public rc As RECT
        Public lParam As IntPtr
    End Structure

    Private Enum ABMsg As Integer
        ABM_NEW = 0
        ABM_REMOVE = 1
        ABM_QUERYPOS = 2
        ABM_SETPOS = 3
        ABM_GETSTATE = 4
        ABM_GETTASKBARPOS = 5
        ABM_ACTIVATE = 6
        ABM_GETAUTOHIDEBAR = 7
        ABM_SETAUTOHIDEBAR = 8
        ABM_WINDOWPOSCHANGED = 9
        ABM_SETSTATE = 10
    End Enum

    Private Enum ABNotify As Integer
        ABN_STATECHANGE = 0
        ABN_POSCHANGED
        ABN_FULLSCREENAPP
        ABN_WINDOWARRANGE
    End Enum

    Private Enum ABEdge As Integer
        ABE_LEFT = 0
        ABE_TOP
        ABE_RIGHT
        ABE_BOTTOM
    End Enum

    Private fBarRegistered As Boolean = False

    Private Declare Function SHAppBarMessage Lib "shell32.dll" Alias "SHAppBarMessage" _
    (ByVal dwMessage As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef pData As  _
    APPBARDATA) As Integer

    Private Declare Function GetSystemMetrics Lib "user32" Alias "GetSystemMetrics" _
    (ByVal nIndex As Integer) As Integer

    Private Declare Function MoveWindow Lib "user32" Alias "MoveWindow" (ByVal hwnd As Integer, _
    ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Integer, _
    ByVal bRepaint As Integer) As Integer

    Private Declare Function RegisterWindowMessage Lib "user32" Alias "RegisterWindowMessageA" _
    (ByVal lpString As String) As Integer

    Private uCallBack As Integer

    <FlagsAttribute()> _
    Public Enum EXECUTION_STATE As UInteger
        ES_SYSTEM_REQUIRED = &H1
        ES_DISPLAY_REQUIRED = &H2
        ES_CONTINUOUS = &H80000000UI
    End Enum

    <DllImport("Kernel32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)> _
    Private Shared Function SetThreadExecutionState(ByVal state As EXECUTION_STATE) As EXECUTION_STATE
    End Function
#End Region

#Region "Declared App Variables"
    Public WithEvents httpServer As clsHTTPServer

    Public WithEvents ctrlQueuePanel As QueuePanel
#End Region

#Region "Declared Form Variables"
    Public WithEvents frmLogin As Login
    Public WithEvents frmPauseCodes As PauseCodes
    Public WithEvents frmTransfer As Transfer
    Public WithEvents frmDispo As CallDisposition
    Public WithEvents frmManualDial As ManualDial
    Public WithEvents frmLeadInfo As LeadInfoScript
#End Region

#Region "Declared Events"
    Public Event Logout(ByVal reason As String)
    Public Event manualDialConnected()
    Public Event manualDialFailed()
#End Region

#Region "Windows AppBar Functions"
    Private Sub mainform_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        RegisterBar()

        CefSharp.CEF.Shutdown()
    End Sub

    Private Sub appBar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1224, 50)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow

        RegisterBar()
        Me.Invalidate()

        Dim settings As New CefSharp.Settings()
        settings.PackLoadingDisabled = False
        CefSharp.CEF.Initialize(settings)

        Me.pxA1Logo.Location = New System.Drawing.Point(Me.Width - 175, Me.pxA1Logo.Location.Y)
    End Sub

    Private Sub mainform_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'e.Graphics.DrawLine(New Pen(Color.White, 3), 0, 0, Me.Width, 0)
        'e.Graphics.DrawLine(New Pen(Color.White, 3), 0, 0, 0, Me.Height)

        '' 1px Bottom Border to Toolbar
        e.Graphics.DrawLine(New Pen(Color.Black, 1), 0, Me.Height - 1, Me.Width, Me.Height - 1)

        'e.Graphics.DrawLine(New Pen(Color.Black, 3), Me.Width - 3, 0, Me.Width - 3, Me.Height)
    End Sub

    Private Sub RegisterBar()
        Dim abd As New APPBARDATA
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle
        If Not fBarRegistered Then
            uCallBack = RegisterWindowMessage("AppBarMessage")
            abd.uCallbackMessage = uCallBack

            Dim ret As Integer = SHAppBarMessage(CType(ABMsg.ABM_NEW, Integer), abd)
            fBarRegistered = True

            ABSetPos()
        Else
            SHAppBarMessage(CType(ABMsg.ABM_REMOVE, Integer), abd)
            fBarRegistered = False
        End If
    End Sub

    Private Sub ABSetPos()
        Dim abd As New APPBARDATA()
        abd.cbSize = Marshal.SizeOf(abd)
        abd.hWnd = Me.Handle
        abd.uEdge = CInt(ABEdge.ABE_TOP)

        If abd.uEdge = CInt(ABEdge.ABE_LEFT) OrElse abd.uEdge = CInt(ABEdge.ABE_RIGHT) Then
            abd.rc.top = 0
            abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height
            If abd.uEdge = CInt(ABEdge.ABE_LEFT) Then
                abd.rc.left = 0
                abd.rc.right = Size.Width
            Else
                abd.rc.right = SystemInformation.PrimaryMonitorSize.Width
                abd.rc.left = abd.rc.right - Size.Width

            End If
        Else
            abd.rc.left = 0
            abd.rc.right = SystemInformation.PrimaryMonitorSize.Width
            If abd.uEdge = CInt(ABEdge.ABE_TOP) Then
                abd.rc.top = 0
                abd.rc.bottom = Size.Height
            Else
                abd.rc.bottom = SystemInformation.PrimaryMonitorSize.Height
                abd.rc.top = abd.rc.bottom - Size.Height
            End If
        End If

        ' Query the system for an approved size and position. 
        SHAppBarMessage(CInt(ABMsg.ABM_QUERYPOS), abd)

        ' Adjust the rectangle, depending on the edge to which the 
        ' appbar is anchored. 
        Select Case abd.uEdge
            Case CInt(ABEdge.ABE_LEFT)
                abd.rc.right = abd.rc.left + Size.Width
                Exit Select
            Case CInt(ABEdge.ABE_RIGHT)
                abd.rc.left = abd.rc.right - Size.Width
                Exit Select
            Case CInt(ABEdge.ABE_TOP)
                abd.rc.bottom = abd.rc.top + Size.Height
                Exit Select
            Case CInt(ABEdge.ABE_BOTTOM)
                abd.rc.top = abd.rc.bottom - Size.Height
                Exit Select
        End Select

        ' Pass the final bounding rectangle to the system. 
        SHAppBarMessage(CInt(ABMsg.ABM_SETPOS), abd)

        ' Move and size the appbar so that it conforms to the 
        ' bounding rectangle passed to the system. 
        MoveWindow(abd.hWnd, abd.rc.left, abd.rc.top, abd.rc.right - abd.rc.left, abd.rc.bottom - abd.rc.top, True)
    End Sub

    Protected Overloads Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = uCallBack Then
            Select Case m.WParam.ToInt32()
                Case CInt(ABNotify.ABN_POSCHANGED)
                    ABSetPos()
                    Exit Select
            End Select
        End If

        MyBase.WndProc(m)
    End Sub

    Protected Overloads Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            cp.Style = cp.Style And (Not 12582912)
            ' WS_CAPTION
            cp.Style = cp.Style And (Not 8388608)
            ' WS_BORDER
            cp.ExStyle = 128 Or 8
            ' WS_EX_TOOLWINDOW | WS_EX_TOPMOST
            Return cp
        End Get
    End Property
#End Region

#Region "Button On-Click Events"
    Private Sub btnLoginOrOff_Click(sender As Object, e As EventArgs) Handles btnLoginOrOff.Click
        If GlobalVars.loggedIn = False Then
            If IsNothing(frmLogin) Then
                frmLogin = New Login()
            ElseIf Not frmLogin.Visible Then
                frmLogin = New Login()
            End If
            frmLogin.Show()
            GlobalVars.agentConnectTime = 0
        Else
            RaiseEvent Logout(String.Empty)
        End If
    End Sub

    Private Sub btnReconnect_Click(sender As Object, e As EventArgs) Handles btnReconnect.Click
        GlobalVars.manager.ReconnectAgent()
    End Sub

    Private Sub btnPauseResume_Click(sender As Object, e As EventArgs) Handles btnPauseResume.Click
        If GlobalVars.VDRP_stage = "PAUSED" Then
            AutoDial_Resume_Pause("VDADready")
        Else
            If GlobalVars.VD_live_customer_call = False Then
                AutoDial_Resume_Pause("VDADpause")
            Else
                MessageBox.Show("Can't pause, you're in the middle of a call!")
            End If
        End If
    End Sub

    Private Sub btnCallbackList_Click() Handles btnCallbackList.Click
        MessageBox.Show(GlobalVars.vdcClass.callbackList())
    End Sub

    Private Sub btnManualDial_Click() Handles btnManualDial.Click
        If GlobalVars.func.isCallLive() Then
            MessageBox.Show("You're Already In A Call!")
            Exit Sub
        End If

        If GlobalVars.dialNextActive Then
            Me.ManualDialSkip()
        Else
            If IsNothing(frmManualDial) Then
                frmManualDial = New ManualDial()
            ElseIf Not frmManualDial.Visible Then
                frmManualDial = New ManualDial()
            End If
            frmManualDial.Show()
        End If
    End Sub

    Private Sub btnDialNext_Click() Handles btnDialNext.Click
        If GlobalVars.func.isCallLive() Then
            MessageBox.Show("You're Already In A Call!")
            Exit Sub
        Else
            If GlobalVars.dialNextActive Then
                Me.ManualDialOnly()
            Else
                Me.ManualDialNext(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, "0", String.Empty, String.Empty, True)
            End If
        End If
    End Sub

    Private Sub btnHangupClicked() Handles btnHangUp.Click
        Me.sendHangup()
    End Sub

    Private Sub btnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        If GlobalVars.holding = True Then
            Me.unHold()
        Else
            Me.hold()
        End If
    End Sub

    Private Sub btnTransfer_Click(sender As Object, e As EventArgs) Handles btnTransfer.Click
        If IsNothing(frmTransfer) Then
            frmTransfer = New Transfer()
        ElseIf Not frmTransfer.Visible Then
            frmTransfer = New Transfer()
        End If
        frmTransfer.Show()
    End Sub
#End Region

#Region "Timer Events"
    Private Sub doRefresh() Handles tmrRefresh.Tick
        ' Catch not logged in error.
        If GlobalVars.loggedIn = False Then
            Exit Sub
        End If

        GlobalVars.func.updateDateTime()

        If GlobalVars.waitingForNextStep = False Then
            check_for_conf_calls(If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty), False)
        End If

        If GlobalVars.AutoDialWaiting = True Then
            check_for_auto_incoming()
        End If

        If GlobalVars.VD_live_customer_call = True Then
            GlobalVars.VD_live_call_seconds += 1
            GlobalVars.timeSinceChange += 1
            If GlobalVars.holding = True Then
                GlobalVars.holdingTime += 1
                Me.UpdateCallSeconds(GlobalVars.holdingTime)
            Else
                Me.UpdateCallSeconds(GlobalVars.VD_live_call_seconds)
            End If
        ElseIf GlobalVars.AutoDialReady = False Then
            GlobalVars.PausedSeconds += 1
            Me.UpdateCallSeconds(GlobalVars.PausedSeconds)
        End If

        If GlobalVars.xferInProgress = True And GlobalVars.MD_channel_look = False Then
            GlobalVars.xferCallTime += 1
        End If

        If GlobalVars.MD_channel_look = True Then
            GlobalVars.MD_ring_secondS += 1
            If GlobalVars.xferInProgress = True Then
                Dim strResult As String = GlobalVars.vdcClass.manualDialCheckChannel(True)
                If strResult = "TRUE" Then
                    GlobalVars.MD_channel_look = False
                    frmTransfer.xferConnected()
                ElseIf strResult = "ERROR" Then
                    GlobalVars.MD_channel_look = False
                    frmTransfer.xferErrorCleanup()
                End If
            Else
                Dim strResult As String = GlobalVars.vdcClass.manualDialCheckChannel(False)
                If strResult = "TRUE" Then
                    GlobalVars.MD_channel_look = False
                    RaiseEvent manualDialConnected()
                ElseIf strResult = "ERROR" Then
                    GlobalVars.MD_channel_look = False
                    RaiseEvent manualDialFailed()
                End If
            End If
            If MD_ring_secondS > CType(If(GlobalVars.jsVars.ContainsKey("dial_timeout"), GlobalVars.jsVars("dial_timeout"), "60"), Integer) Then
                GlobalVars.MD_channel_look = False
            End If
        End If
    End Sub
#End Region

#Region "Local Event Handlers"
#Region "Login / Out"
    Private Sub doLogout(reason As String) Handles Me.Logout
        Dim worker As New LogonOff
        If worker.Logoff(reason) = True Then
            tmrRefresh.Stop()
            lblServerTime.Text = "N/A"
            lblStatus.Text = ""
            lblCampCalls.Text = String.Empty
            lblCallTime.Text = String.Empty
            GlobalVars.loggedIn = False
            btnLoginOrOff.Text = "Login"
            btnReconnect.Enabled = False
            Me.btnPauseResume_Disable()
            Me.btnCallbackList_Disable()
            Me.btnManualDial_Disable()
            Me.btnDialNext_Disable()
            GlobalVars.timeSinceChange = 0
            GlobalVars.PauseCode_Count = 1

            GlobalVars.jsVars = New Dictionary(Of String, String)
            GlobalVars.jsArrays = New Dictionary(Of String, String())

            GlobalVars.blockReady = True

            Me.httpServer.Dispose()
            Me.httpServer = Nothing

            Me.queuePanelHide()

            '' Tell Kernel we're ok to sleep again now we've logged out.
            SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
        Else
            MessageBox.Show("Log Off Failed")
        End If
    End Sub
#End Region
#Region "Manual Dial Events"
    Private Sub manualDialConnect() Handles Me.manualDialConnected
        GlobalVars.MD_call_live = True
        Me.beginCall_VariablesSet()
        GlobalVars.jsVars("CalLCID") = GlobalVars.jsVars("MDnextCID")
        GlobalVars.uniqueid = GlobalVars.jsVars("MDuniqueid")
        GlobalVars.jsVars("lastcustchannel") = GlobalVars.jsVars("MDchannel")
        GlobalVars.vdcClass.DialLog("start", "undefined")
        Me.inCallButtons_Enable()
    End Sub

    Private Sub manualDialFail() Handles Me.manualDialFailed
        MessageBox.Show("Manual Dial Failed")
    End Sub
#End Region
#End Region

#Region "Declared Form Events"
#Region "frmLogin Events"
    Private Sub loggedIn() Handles frmLogin.loggedIn
        '' Tell Kernel to stop the computer from sleeping while we're logged in.
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_SYSTEM_REQUIRED)

        btnLoginOrOff.Text = "Log Off"
        tmrRefresh.Start()
        btnReconnect.Enabled = True
        Me.btnPauseResume_Enable()
        Me.btnCallbackList_Enable()

        GlobalVars.VDRP_stage = GlobalVars.jsVars("VDRP_stage")
        If GlobalVars.VDRP_stage = "PAUSED" Then
            Me.btnPauseResume_Paused()
        Else
            Me.btnPauseResume_Ready()
        End If

        Me.httpServer = New clsHTTPServer()

        Me.queuePanelShow()

        Dim slice As New PBXBar.Toast.ToastForm(5000, "Logged In" & vbLf & vbLf & GlobalVars.username & vbLf & GlobalVars.campaign)
        slice.Height = 125
        slice.Show()
    End Sub
#End Region

#Region "frmPauseCodes Events"
    Public Sub afterPauseCode() Handles frmPauseCodes.PauseCodeComplete
        ' Submit Pause Code
        GlobalVars.vdcClass.pauseCodeSubmit(frmPauseCodes.pauseCodeValue)

        ' Reset buttons ready to continue.
        Me.btnPauseResume_Enable()
    End Sub
#End Region

#Region "frmTransfer Events"
    Public Sub transferComplete() Handles frmTransfer.xferComplete
        GlobalVars.vdcClass.DialLog("end", "0", "1")

        Me.cleanupAfterCall()
    End Sub

    Public Sub xferInProgress() Handles frmTransfer.xferInProgress
        If GlobalVars.xferHold = False Then
            Me.btnHold_Disable()
        End If
        Me.btnHangup_Disable()
    End Sub

    Public Sub xferCleanup() Handles frmTransfer.xferCleanup
        Me.btnHangup_Enable()
    End Sub

    Public Sub xferHold() Handles frmTransfer.xferHold
        Me.hold()
    End Sub

    Public Sub xferUnhold() Handles frmTransfer.xferUnhold
        Me.unHold()
    End Sub

    Private Sub transferFinishedHangup() Handles frmTransfer.xferHangup
        Me.sendHangup()

        Me.cleanupAfterCall()
    End Sub

    Private Sub xferOpening() Handles frmTransfer.Shown
        Me.btnHold_Disable()
    End Sub

    Private Sub xferClosing() Handles frmTransfer.FormClosed
        Me.btnHold_Enable()
    End Sub
#End Region

#Region "frmDispo Events"
    Public Sub afterDispo(callDirect As Boolean) Handles frmDispo.DispoComplete
        If callDirect = False Then
            If frmDispo.dispoCallback = True Then
                GlobalVars.vdcClass.dispoSubmit(frmDispo.dispoValue, frmDispo.dispoCbkDateTime, If(frmDispo.dispoCbkMeOnly = True, "USERONLY", "ANYONE"), frmDispo.dispoCbkComment, True)
            Else
                GlobalVars.vdcClass.dispoSubmit(frmDispo.dispoValue)
            End If

            Me.postDispoCleanup()

            If frmDispo.chkNotReady.Checked Then
                Me.AutoDial_Resume_Pause("VDADpause", "NEW_ID")
            Else
                Me.AutoDial_Resume_Pause("VDADready", "NEW_ID")
            End If
        Else
            Me.postDispoCleanup()

            Me.AutoDial_Resume_Pause("VDADpause", "NEW_ID")
        End If

    End Sub
#End Region

#Region "frmManualDial Events"
    Private Sub makeManualCall() Handles frmManualDial.makeCall
        ''GlobalVars.func.SendManualDial(frmManualDial.numberToDial, False)

        ''GlobalVars.inOUT = "OUT"
        GlobalVars.jsVars("dialed_label") = "MANUAL_DIALNOW"
        Me.ManualDialNext(String.Empty, String.Empty, String.Empty, frmManualDial.numberToDial, "lookup", String.Empty, "0", GlobalVars.jsVars("dialed_label"), frmManualDial.dialPrefix, False)
    End Sub
#End Region
#End Region

#Region "Declared Class Events"
#Region "httpServer"
    Private Sub httpRecordingStart() Handles httpServer.RecordingStart
        If GlobalVars.VD_live_customer_call = True Then
            If GlobalVars.recording = False Then
                RecordingStart()
            End If
        End If
    End Sub

    Private Sub httpRecordingStop() Handles httpServer.RecordingStop
        If GlobalVars.VD_live_customer_call = True Then
            If GlobalVars.recording = True Then
                RecordingStop()
            End If
        End If
    End Sub
#End Region
#End Region

#Region "Functions"
#Region "Call Handling"
    Private Sub RecordingStart()
        GlobalVars.manager.conf_send_monitor("MonitorConf", If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty))
        GlobalVars.recording = True
    End Sub

    Private Sub RecordingStop()
        GlobalVars.manager.hangupRecordings(If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty))
        GlobalVars.recording = False
    End Sub

    Private Sub check_for_conf_calls(session_id As String, force As Boolean)
        Dim variables As New Dictionary(Of String, String)
        variables("client") = "vdc"
        variables("campagentstdisp") = "YES"
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("conf_exten") = session_id
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("auto_dial_level"), GlobalVars.jsVars("auto_dial_level"), String.Empty)

        Dim request As New PBXWebRequest()

        Dim strReturn As String = request.postRequest("conf_exten_check.php", variables)

        Dim check_ALL_array As String() = strReturn.Split(vbLf)
        Dim check_TIME_array As String() = check_ALL_array(0).Split("|")
        Dim check_CONF_array As String() = check_ALL_array(1).Split("|")

        Dim timeArray As String() = check_TIME_array(0).Split(New String() {"DateTime:"}, StringSplitOptions.None)
        lblServerTime.Text = timeArray(1).Trim()

        Dim campCalls As String() = check_TIME_array(3).Split(New String() {"CampCalls:"}, StringSplitOptions.None)
        Dim numCallsString As String = GlobalVars.func.stripHTML(campCalls(1).Trim())
        lblCampCalls.Text = numCallsString

        If Regex.IsMatch(numCallsString, "Calls in Queue\: ([0-9]+)") Then
            Dim strTest As String() = numCallsString.Split(New String() {"Calls in Queue:"}, StringSplitOptions.None)
            queuePanelUpdate(CType(strTest(1), Integer))
        End If

        Dim statusArray As String() = check_TIME_array(4).Split(New String() {"Status:"}, StringSplitOptions.None)
        lblStatus.Text = "Status : " & statusArray(1).Trim()

        Dim aLoginArray As String() = check_TIME_array(2).Split(New String() {"Logged-in:"}, StringSplitOptions.None)
        Dim alogin As String = aLoginArray(1)
        If alogin = "DEAD_VLA" Then
            ' Agent Call Dropped, re-origionate using manager_send?
            GlobalVars.manager.ReconnectAgent()
        ElseIf alogin = "API_LOGOUT" Then
            If GlobalVars.MD_channel_look = False And GlobalVars.VD_live_customer_call = False And GlobalVars.alt_dial_status_display = False Then
                RaiseEvent Logout("API")
            End If
        ElseIf alogin = "SHIFT_LOGOUT" Then
            If GlobalVars.MD_channel_look = False And GlobalVars.VD_live_customer_call = False And GlobalVars.alt_dial_status_display = False Then
                RaiseEvent Logout("SHIFT")
            End If
        End If

        Dim vlaStatusArray As String() = check_TIME_array(4).Split(New String() {"Status:"}, StringSplitOptions.None)
        Dim vlaStatus As String = vlaStatusArray(1)

        If vlaStatus = "PAUSED" And GlobalVars.AutoDialWaiting = True Then
            MessageBox.Show("Your session has been paused")
            AutoDial_Resume_Pause("VDADpause")
        End If

        ' Check for conference consistency
        Try
            GlobalVars.agentConnectTime += 1
            Dim numInConference As Integer = CType(check_CONF_array(0), Integer)
            If Not numInConference = GlobalVars.numInConference Then
                ' Set number in global vars so we don't hit this again.
                Dim oldNumber As Integer = GlobalVars.numInConference
                GlobalVars.numInConference = numInConference
                ' We've had a change, deal with it here.

                ' Check if we've lost ourselves
                If Regex.IsMatch(check_CONF_array(1), GlobalVars.func.getAgentHandset()) Then
                    Dim match As Match = Regex.Match(check_CONF_array(1), "(" & GlobalVars.func.getAgentHandset() & "([a-zA-Z0-9\-]+))\s")
                    GlobalVars.jsVars("agentchannel") = match.Groups.Item(1).ToString()

                    If GlobalVars.VD_live_customer_call = True Then
                        ' If we're on a call, check if we've lost our customer (cust hangup)
                        If GlobalVars.timeSinceChange > 3 And GlobalVars.holding = False Then
                            If (GlobalVars.recording = False And numInConference < 2) Or (GlobalVars.recording = True And numInConference < 3) Then
                                Me.customerHangup()
                            End If
                        Else
                            GlobalVars.numInConference = oldNumber
                        End If

                        GlobalVars.blockReady = False
                    Else
                        If numInConference > 1 Then
                            GlobalVars.blockReady = True
                        Else
                            GlobalVars.blockReady = False
                        End If
                    End If
                Else
                    If GlobalVars.agentConnectTime > 8 Then
                        ' Looks like we have, reconnect the agent.
                        Dim slice As New PBXBar.Toast.ToastForm(5000, "Lost Agent Phone" & vbLf & "Automatic Re-Connect")
                        slice.Height = 75
                        slice.Show()
                        GlobalVars.manager.ReconnectAgent()
                    End If

                    GlobalVars.blockReady = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub check_for_auto_incoming()
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("campaign") = GlobalVars.campaign
        variables("ACTION") = "VDADcheckINCOMING"
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("vdc_db_query.php", variables)

        Dim check_VDIC_array As String() = strReturn.Split(vbLf)
        If check_VDIC_array(0) = "1" Then
            GlobalVars.AutoDialWaiting = False

            Dim VDIC_data_VDAC As String() = check_VDIC_array(1).Split("|")
            Dim VDIC_data_VDIG As String() = check_VDIC_array(2).Split("|")
            Dim queueName As String = VDIC_data_VDIG(1)

            GlobalVars.jsVars("CIDcheck") = VDIC_data_VDAC(2)
            GlobalVars.jsVars("CalLCID") = VDIC_data_VDAC(2)
            GlobalVars.jsVars("LastCallCID") = VDIC_data_VDAC(2)
            GlobalVars.jsVars("LasTCID") = VDIC_data_VDAC(2)

            GlobalVars.jsVars("lastcustchannel") = VDIC_data_VDAC(3)
            GlobalVars.jsVars("lastcustserverip") = VDIC_data_VDAC(4)

            ' POP URL!
            GlobalVars.jsVars("VDIC_web_form_address") = VDIC_data_VDIG(0)

            GlobalVars.jsVars("VDCL_group_id") = VDIC_data_VDIG(4)
            GlobalVars.jsVars("CalL_ScripT_id") = VDIC_data_VDIG(5)
            GlobalVars.jsVars("CalL_AutO_LauncH") = VDIC_data_VDIG(6)
            GlobalVars.jsVars("CalL_XC_a_Dtmf") = VDIC_data_VDIG(7)
            GlobalVars.jsVars("CalL_XC_a_NuMber") = VDIC_data_VDIG(8)
            GlobalVars.jsVars("CalL_XC_b_Dtmf") = VDIC_data_VDIG(9)
            GlobalVars.jsVars("CalL_XC_b_NuMber") = VDIC_data_VDIG(10)

            If (VDIC_data_VDIG(11).Length > 1) And Not (VDIC_data_VDIG(11) = "---NONE---") Then
                GlobalVars.jsVars("LIVE_default_xfer_group") = VDIC_data_VDIG(11)
            Else
                GlobalVars.jsVars("LIVE_default_xfer_group") = If(GlobalVars.jsVars.ContainsKey("default_xfer_group"), GlobalVars.jsVars("default_xfer_group"), String.Empty)
            End If
            If (VDIC_data_VDIG(12).Length > 1) And Not (VDIC_data_VDIG(12) = "DISABLED") Then
                GlobalVars.jsVars("LIVE_campaign_recording") = VDIC_data_VDIG(12)
            Else
                GlobalVars.jsVars("LIVE_campaign_recording") = If(GlobalVars.jsVars.ContainsKey("campaign_recording"), GlobalVars.jsVars("campaign_recording"), String.Empty)
            End If

            If (VDIC_data_VDIG(13).Length > 1) And Not (VDIC_data_VDIG(13) = "NONE") Then
                GlobalVars.jsVars("LIVE_campaign_rec_filename") = VDIC_data_VDIG(13)
            Else
                GlobalVars.jsVars("LIVE_campaign_rec_filename") = If(GlobalVars.jsVars.ContainsKey("campaign_rec_filename"), GlobalVars.jsVars("campaign_rec_filename"), String.Empty)
            End If

            If (VDIC_data_VDIG(14).Length > 1) And Not (VDIC_data_VDIG(14) = "NONE") Then
                GlobalVars.jsVars("LIVE_default_group_alias") = VDIC_data_VDIG(14)
            Else
                GlobalVars.jsVars("LIVE_default_group_alias") = If(GlobalVars.jsVars.ContainsKey("default_group_alias"), GlobalVars.jsVars("default_group_alias"), String.Empty)
            End If

            If (VDIC_data_VDIG(15).Length > 1) And Not (VDIC_data_VDIG(15) = "NONE") Then
                GlobalVars.jsVars("LIVE_caller_id_number") = VDIC_data_VDIG(15)
            Else
                GlobalVars.jsVars("LIVE_caller_id_number") = If(GlobalVars.jsVars.ContainsKey("default_group_alias_cid"), GlobalVars.jsVars("default_group_alias_cid"), String.Empty)
            End If

            If VDIC_data_VDIG(16).Length > 0 Then
                GlobalVars.jsVars("LIVE_web_vars") = VDIC_data_VDIG(16)
            Else
                GlobalVars.jsVars("LIVE_web_vars") = If(GlobalVars.jsVars.ContainsKey("default_web_vars"), GlobalVars.jsVars("default_web_vars"), String.Empty)
            End If

            If VDIC_data_VDIG(17).Length > 5 Then
                GlobalVars.jsVars("VDIC_web_form_address_two") = VDIC_data_VDIG(17)
            End If

            GlobalVars.jsVars("CalL_XC_c_NuMber") = VDIC_data_VDIG(21)
            GlobalVars.jsVars("CalL_XC_d_NuMber") = VDIC_data_VDIG(22)
            GlobalVars.jsVars("CalL_XC_e_NuMber") = VDIC_data_VDIG(23)
            GlobalVars.jsVars("CalL_XC_e_NuMber") = VDIC_data_VDIG(23)
            GlobalVars.jsVars("uniqueid_status_display") = VDIC_data_VDIG(24)
            GlobalVars.jsVars("uniqueid_status_prefix") = VDIC_data_VDIG(26)
            GlobalVars.jsVars("did_id") = VDIC_data_VDIG(28)
            GlobalVars.jsVars("did_extension") = VDIC_data_VDIG(29)
            GlobalVars.jsVars("did_pattern") = VDIC_data_VDIG(30)
            GlobalVars.jsVars("did_description") = VDIC_data_VDIG(31)
            GlobalVars.jsVars("closecallid") = VDIC_data_VDIG(32)
            GlobalVars.jsVars("xfercallid") = VDIC_data_VDIG(33)

            GlobalVars.jsVars("lead_dial_number") = check_VDIC_array(12)

            GlobalVars.lead_id = VDIC_data_VDAC(0)
            GlobalVars.uniqueid = VDIC_data_VDAC(1)

            GlobalVars.list_id = check_VDIC_array(9)
            GlobalVars.vendor_lead_code = check_VDIC_array(8)
            GlobalVars.phone_number = check_VDIC_array(12)
            GlobalVars.phone_code = check_VDIC_array(11)

            GlobalVars.inOUT = "IN"

            Me.beginCall_VariablesSet()
            GlobalVars.custchannellive = True

            GlobalVars.jsVars("dialed_number") = check_VDIC_array(12)
            lblInboundCLI.Text = check_VDIC_array(12)
            lblFronter.Text = VDIC_data_VDIG(1)

            '' Start call recording...
            RecordingStart()

            '' Show Toast Form
            Dim slice As New PBXBar.Toast.ToastForm(5000, "Incoming Call" & vbLf & vbLf & VDIC_data_VDIG(1) & vbLf & check_VDIC_array(12))
            slice.Height = 125
            slice.Show()

            '' Show Lead Window
            frmLeadInfo = New LeadInfoScript()

            frmLeadInfo.txtTitle.Text = check_VDIC_array(13)
            frmLeadInfo.txtFirstName.Text = check_VDIC_array(14)
            frmLeadInfo.txtMiddleName.Text = check_VDIC_array(15)
            frmLeadInfo.txtLastName.Text = check_VDIC_array(16)

            frmLeadInfo.txtAddressLine1.Text = check_VDIC_array(17)
            frmLeadInfo.txtTownCity.Text = check_VDIC_array(20)
            frmLeadInfo.txtCounty.Text = check_VDIC_array(21)
            frmLeadInfo.txtPostCode.Text = check_VDIC_array(23)

            frmLeadInfo.txtPhoneNo.Text = GlobalVars.func.stripNonNumeric(check_VDIC_array(12))
            frmLeadInfo.txtAltPhoneNo.Text = GlobalVars.func.stripNonNumeric(check_VDIC_array(27))
            frmLeadInfo.txtEmail.Text = check_VDIC_array(28)

            frmLeadInfo.txtComments.Text = Regex.Replace(check_VDIC_array(28), "\|\|A1_POPURL:(.+)\|A1_ORDID:(.+)\|A1_FULLNAME:(.+)\|A1_REJECTREASON:(.+)\|A1_ORDERSTATUS:(.+)\|A1_STOCKSTATUS:(.+)\|A1_WISPER:(.+)\|A1_VERIFIED:(.+)\|\|", "")

            frmLeadInfo.Show()

            '' Enable In-Call Buttons HERE!
            Me.inCallButtons_Enable()

            Me.processVariables(check_VDIC_array(30))
        End If
    End Sub

    Private Sub ManualDialNext(mdnCBid As String, mdnDBleadid As String, mdnDiaLCodE As String, mdnPhonENumbeR As String, mdnStagE As String, mdVendorid As String, mdgroupalias As String, mdtype As String, dialPrefix As String, previewLead As Boolean)
        If GlobalVars.jsVars("dial_method") = "INBOUND_MAN" Then
            If Not GlobalVars.VDRP_stage = "PAUSED" Then
                AutoDial_Resume_Pause("VDADpause")
            End If
        End If

        Dim man_preview As String = String.Empty
        If previewLead = True Then
            '' Preview Lead Code here.
            man_preview = "YES"
        Else
            man_preview = "NO"
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = "manDiaLnextCaLL"
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("campaign") = GlobalVars.campaign
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("dial_timeout") = If(GlobalVars.jsVars.ContainsKey("dial_timeout"), GlobalVars.jsVars("dial_timeout"), String.Empty)
        variables("dial_prefix") = dialPrefix
        variables("campaign_cid") = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)
        variables("preview") = man_preview
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("callback_id") = mdnCBid
        variables("lead_id") = mdnDBleadid
        variables("phone_code") = mdnDiaLCodE
        variables("phone_number") = mdnPhonENumbeR
        variables("list_id") = If(GlobalVars.jsVars.ContainsKey("mdnLisT_id"), GlobalVars.jsVars("mdnLisT_id"), String.Empty)
        variables("stage") = mdnStagE
        variables("use_internal_dnc") = If(GlobalVars.jsVars.ContainsKey("use_internal_dnc"), GlobalVars.jsVars("use_internal_dnc"), String.Empty)
        variables("use_campaign_dnc") = If(GlobalVars.jsVars.ContainsKey("use_campaign_dnc"), GlobalVars.jsVars("use_campaign_dnc"), String.Empty)
        variables("omit_phone_code") = If(GlobalVars.jsVars.ContainsKey("omit_phone_code"), GlobalVars.jsVars("omit_phone_code"), String.Empty)
        variables("manual_dial_filter") = If(GlobalVars.jsVars.ContainsKey("manual_dial_filter"), GlobalVars.jsVars("manual_dial_filter"), String.Empty)
        variables("vendor_lead_code") = mdVendorid
        variables("usegroupalias") = mdgroupalias
        variables("account") = If(GlobalVars.jsVars.ContainsKey("active_group_alias"), GlobalVars.jsVars("active_group_alias"), String.Empty)
        variables("agent_dialed_number") = mdnPhonENumbeR
        variables("agent_dialed_type") = mdtype
        variables("vtiger_callback_id") = If(GlobalVars.jsVars.ContainsKey("vtiger_callback_id"), GlobalVars.jsVars("vtiger_callback_id"), String.Empty)
        variables("dial_method") = If(GlobalVars.jsVars.ContainsKey("dial_method"), GlobalVars.jsVars("dial_method"), String.Empty)
        variables("manual_dial_call_time_check") = If(GlobalVars.jsVars.ContainsKey("manual_dial_call_time_check"), GlobalVars.jsVars("manual_dial_call_time_check"), String.Empty)
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("vdc_db_query.php", variables)

        Dim MDnextResponse As String() = strReturn.Split(vbLf)

        GlobalVars.jsVars("MDnextCID") = MDnextResponse(0)
        GlobalVars.jsVars("LastCallCID") = MDnextResponse(0)

        If Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "HOPPER EMPTY") Or Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "DNC") Or Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "CAMPLISTS") Or Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "OUTSIDE") Then
            If Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "HOPPER EMPTY") Then
                MessageBox.Show("No more leads in the hopper for campaign:" & vbLf & GlobalVars.campaign)
            ElseIf Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "DNC") Then
                MessageBox.Show("This number is on the DNC list:" & vbLf & mdnPhonENumbeR)
            ElseIf Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "CAMPLISTS") Then
                MessageBox.Show("This phone number is not in the campaign lists:" & vbLf & mdnPhonENumbeR)
            ElseIf Regex.IsMatch(GlobalVars.jsVars("MDnextCID"), "OUTSIDE") Then
                MessageBox.Show("This phone number is outside of the local call time:" & vbLf & mdnPhonENumbeR)
            Else
                MessageBox.Show("Unspecified Error:" & vbLf & mdnPhonENumbeR & " | " & GlobalVars.jsVars("MDnextCID"))
            End If

            If GlobalVars.jsVars("dial_method") = "INBOUND_MAN" Then
                '' Cancel everything and let them go back to the next dial.
                GlobalVars.dialNextActive = True
                Me.cleanupAfterCall()
                Me.AutoDial_Resume_Pause("VDADpause")
                Exit Sub
            End If
        Else
            GlobalVars.inOUT = "OUT"

            GlobalVars.sentHangupLog = False

            GlobalVars.jsVars("CIDcheck") = MDnextResponse(0)
            GlobalVars.jsVars("CalLCID") = MDnextResponse(0)
            GlobalVars.jsVars("LastCallCID") = MDnextResponse(0)
            GlobalVars.jsVars("LasTCID") = MDnextResponse(0)
            GlobalVars.jsVars("lead_dial_number") = mdnPhonENumbeR

            GlobalVars.jsVars("lastcustserverip") = GlobalVars.jsVars("server_ip")

            GlobalVars.lead_id = MDnextResponse(1)
            GlobalVars.lead_previous_dispo = MDnextResponse(2)
            GlobalVars.lead_previous_called_count = MDnextResponse(27)
            GlobalVars.vendor_lead_code = MDnextResponse(4)
            GlobalVars.list_id = MDnextResponse(5)

            GlobalVars.phone_code = MDnextResponse(7)
            GlobalVars.phone_number = MDnextResponse(8)

            GlobalVars.jsVars("VDCL_group_id") = GlobalVars.campaign

            'previous_called_count = MDnextResponse(27)
            'previous_dispo = MDnextResponse(2)
            'CBentry_time = MDnextResponse(28)
            'CBcallback_time = MDnextResponse(29)
            'CBuser = MDnextResponse(30)
            'CBcomments = MDnextResponse(31)
            'dialed_number = MDnextResponse(32)
            'dialed_label = MDnextResponse(33)

            Dim comments As String = Regex.Replace(MDnextResponse(26), "!N", vbLf)

            '' Start call recording...
            RecordingStart()

            If previewLead = True Then
                GlobalVars.MD_previewing_lead = True
                Me.btnPauseResume_Disable()
                Me.btnCallbackList_Disable()

                Me.btnDialNext_DialLead()
                Me.btnManualDial_SkipLead()
            Else
                '' Show Toast Form
                Dim slice As New PBXBar.Toast.ToastForm(5000, "Outgoing Call Initiated" & vbLf & vbLf & mdnPhonENumbeR & vbLf & "CID: " & If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty))
                slice.Height = 125
                slice.Show()
            End If

            '' Show Lead Window
            frmLeadInfo = New LeadInfoScript()

            frmLeadInfo.txtTitle.Text = MDnextResponse(9)
            frmLeadInfo.txtFirstName.Text = MDnextResponse(10)
            frmLeadInfo.txtMiddleName.Text = MDnextResponse(11)
            frmLeadInfo.txtLastName.Text = MDnextResponse(12)

            frmLeadInfo.txtAddressLine1.Text = MDnextResponse(13)
            frmLeadInfo.txtTownCity.Text = MDnextResponse(16)
            frmLeadInfo.txtCounty.Text = MDnextResponse(18)
            frmLeadInfo.txtPostCode.Text = MDnextResponse(19)

            frmLeadInfo.txtPhoneNo.Text = GlobalVars.func.stripNonNumeric(MDnextResponse(8))
            frmLeadInfo.txtAltPhoneNo.Text = GlobalVars.func.stripNonNumeric(MDnextResponse(23))
            frmLeadInfo.txtEmail.Text = MDnextResponse(24)

            frmLeadInfo.lblCallBackLoggedTime.Text = MDnextResponse(28)
            frmLeadInfo.lblCallbackLoggedUser.Text = MDnextResponse(30)
            frmLeadInfo.lblCallbackTimeRequested.Text = MDnextResponse(29)
            frmLeadInfo.lblCallbackComments.Text = MDnextResponse(31)
            If Not MDnextResponse(27) = String.Empty Then
                frmLeadInfo.lblPreviousCalledCount.Text = (Convert.ToInt32(MDnextResponse(27)) - 1).ToString()
            End If
            frmLeadInfo.lblPreviousDisposition.Text = MDnextResponse(2)

            frmLeadInfo.txtComments.Text = Regex.Replace(comments, "\|\|A1_POPURL:(.+)\|A1_ORDID:(.+)\|A1_FULLNAME:(.+)\|A1_REJECTREASON:(.+)\|A1_ORDERSTATUS:(.+)\|A1_STOCKSTATUS:(.+)\|A1_WISPER:(.+)\|A1_VERIFIED:(.+)\|\|", "")

            frmLeadInfo.Show()

            If Not previewLead = True Then
                GlobalVars.MD_channel_look = True
            End If
        End If
    End Sub

    Private Sub ManualDialOnly()
        '' Show Toast Form
        Dim slice As New PBXBar.Toast.ToastForm(5000, "Outgoing Call Initiated" & vbLf & vbLf & GlobalVars.jsVars("lead_dial_number") & vbLf & "CID: " & If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty))
        slice.Height = 125
        slice.Show()

        Me.btnDialNext_Disable()
        Me.btnManualDial_Disable()

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = "manDiaLonly"
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("lead_id") = GlobalVars.lead_id
        variables("phone_number") = GlobalVars.phone_number
        variables("phone_code") = GlobalVars.phone_code
        variables("campaign") = GlobalVars.campaign
        variables("ext_context") = If(GlobalVars.jsVars.ContainsKey("ext_context"), GlobalVars.jsVars("ext_context"), String.Empty)
        variables("dial_timeout") = If(GlobalVars.jsVars.ContainsKey("dial_timeout"), GlobalVars.jsVars("dial_timeout"), String.Empty)
        If Regex.IsMatch(GlobalVars.phone_number, "^44.+") Then
            variables("dial_prefix") = "89"
        Else
            variables("dial_prefix") = If(GlobalVars.jsVars.ContainsKey("dial_prefix"), GlobalVars.jsVars("dial_prefix"), String.Empty)
        End If
        variables("campaign_cid") = If(GlobalVars.jsVars.ContainsKey("campaign_cid"), GlobalVars.jsVars("campaign_cid"), String.Empty)
        variables("omit_phone_code") = If(GlobalVars.jsVars.ContainsKey("omit_phone_code"), GlobalVars.jsVars("omit_phone_code"), String.Empty)
        variables("usergroupalias") = String.Empty
        variables("account") = If(GlobalVars.jsVars.ContainsKey("active_group_alias"), GlobalVars.jsVars("active_group_alias"), String.Empty)
        variables("agent_dialed_number") = String.Empty
        variables("agent_dialed_type") = String.Empty
        variables("dial_method") = If(GlobalVars.jsVars.ContainsKey("dial_method"), GlobalVars.jsVars("dial_method"), String.Empty)
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("security") = String.Empty
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)
        variables("old_CID") = String.Empty

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("vdc_db_query.php", variables)

        Dim MDOnextResponse As String() = strReturn.Split(vbLf)

        If MDOnextResponse(0) = " CALL NOT PLACED" Then
            MessageBox.Show("Call was not placed, there was an error: " & vbLf & strReturn, "Lead Dial Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

            Me.btnDialNext_DialLead()
            Me.btnManualDial_SkipLead()
        Else
            GlobalVars.jsVars("CIDcheck") = MDOnextResponse(0)
            GlobalVars.jsVars("CalLCID") = MDOnextResponse(0)
            GlobalVars.jsVars("LastCallCID") = MDOnextResponse(0)
            GlobalVars.jsVars("LasTCID") = MDOnextResponse(0)
            GlobalVars.jsVars("MDnextCID") = MDOnextResponse(0)
            GlobalVars.jsVars("lead_dial_number") = GlobalVars.phone_number

            GlobalVars.jsVars("agent_log_id") = MDOnextResponse(1)

            'custom_list_num = MDOnextResponse(2)

            ' Set this to false so we still get our DISPO box.
            GlobalVars.dialNextActive = False

            GlobalVars.MD_channel_look = True
        End If
    End Sub

    Private Sub ManualDialSkip()
        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = "manDiaLskip"
        variables("conf_exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("lead_id") = GlobalVars.lead_id
        variables("stage") = GlobalVars.lead_previous_dispo
        variables("called_count") = GlobalVars.lead_previous_called_count
        variables("campaign") = GlobalVars.campaign

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("vdc_db_query.php", variables)

        Dim MDSnextResponse As String() = strReturn.Split(vbLf)

        If MDSnextResponse(0) = "LEAD NOT REVERTED" Then
            MessageBox.Show("Lead was not reverted, there was an error: " & vbLf & strReturn, "Lead Skip Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            GlobalVars.dialNextActive = True
            Me.cleanupAfterCall()
            Me.AutoDial_Resume_Pause("VDADpause")
        End If
    End Sub

    Private Sub sendHangup()
        If GlobalVars.holding = True Then
            Me.unHold()
        End If

        If Not GlobalVars.sentHangupLog Then
            GlobalVars.vdcClass.DialLog("end", "0")
        End If

        Dim group As String
        If GlobalVars.jsVars("VDCL_group_id").Length > 1 Then
            group = GlobalVars.jsVars("VDCL_group_id")
        Else
            group = GlobalVars.campaign
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = "Hangup"
        variables("format") = "text"
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("channel") = If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty)
        variables("call_server_ip") = If(GlobalVars.jsVars.ContainsKey("lastcustserverip"), GlobalVars.jsVars("lastcustserverip"), String.Empty)
        variables("queryCID") = "HLagcW" & If(GlobalVars.jsVars.ContainsKey("epoch_sec"), GlobalVars.jsVars("epoch_sec"), String.Empty) & If(GlobalVars.jsVars.ContainsKey("user_abb"), GlobalVars.jsVars("user_abb"), String.Empty)
        variables("auto_dial_level") = If(GlobalVars.jsVars.ContainsKey("auto_dial_level"), GlobalVars.jsVars("auto_dial_level"), String.Empty)
        variables("CalLCID") = If(GlobalVars.jsVars.ContainsKey("CalLCID"), GlobalVars.jsVars("CalLCID"), String.Empty)
        variables("secondS") = GlobalVars.VD_live_call_seconds.ToString()
        variables("exten") = If(GlobalVars.jsVars.ContainsKey("session_id"), GlobalVars.jsVars("session_id"), String.Empty)
        variables("campaign") = group
        variables("stage") = "CALLHANGUP"
        variables("nodeletevdac") = String.Empty
        variables("log_campaign") = GlobalVars.campaign
        variables("qm_extension") = If(GlobalVars.jsVars.ContainsKey("qm_extension"), GlobalVars.jsVars("qm_extension"), String.Empty)

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("manager_send.php", variables)

        Me.cleanupAfterCall()

    End Sub

    Private Sub AutoDial_Resume_Pause(taskaction As String)
        Me.AutoDial_Resume_Pause(taskaction, "undefined")
    End Sub

    Private Sub AutoDial_Resume_Pause(taskaction As String, agent_log As String)
        Me.AutoDial_Resume_Pause(taskaction, agent_log, String.Empty, False)
    End Sub

    Private Sub AutoDial_Resume_Pause(taskaction As String, agent_log As String, temp_reason As String, temp_auto As Boolean)
        If taskaction = "VDADready" Then
            If GlobalVars.blockReady Then
                MessageBox.Show("You Can't Go Ready!" & vbLf & "Problem Detected" & vbLf & vbLf & "Either Your Headset Isn't Connected" & vbLf & "or" & vbLf & "Possible Rogue Customer Still On The Line?", "Problem Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                taskaction = "VDADpause"
            End If
        End If

        If taskaction = "VDADready" Then
            If GlobalVars.jsVars("VICIDiaL_closer_blended") = "0" Then
                GlobalVars.VDRP_stage = "CLOSER"
            Else
                GlobalVars.VDRP_stage = "READY"
            End If
            ' VDRP_stage = "CLOSER" for inbound only calls.
            GlobalVars.AutoDialReady = True
            GlobalVars.AutoDialWaiting = True
            lblCallTime.Text = String.Empty
        Else
            GlobalVars.VDRP_stage = "PAUSED"
            GlobalVars.AutoDialReady = False
            GlobalVars.AutoDialWaiting = False
            GlobalVars.PausedSeconds = 0
        End If

        If agent_log = "NEW_ID" Then
            ' If we're getting a new agent_log_id, reset the pause code count so we don't get another new one when we submit that!
            GlobalVars.PauseCode_Count = 0
        End If

        Dim variables As New Dictionary(Of String, String)
        variables("server_ip") = If(GlobalVars.jsVars.ContainsKey("server_ip"), GlobalVars.jsVars("server_ip"), String.Empty)
        variables("session_name") = If(GlobalVars.jsVars.ContainsKey("session_name"), GlobalVars.jsVars("session_name"), String.Empty)
        variables("ACTION") = taskaction
        variables("user") = GlobalVars.username
        variables("pass") = GlobalVars.password
        variables("stage") = GlobalVars.VDRP_stage
        variables("agent_log_id") = If(GlobalVars.jsVars.ContainsKey("agent_log_id"), GlobalVars.jsVars("agent_log_id"), String.Empty)
        variables("agent_log") = agent_log
        variables("wrapup") = "undefined"
        variables("campaign") = GlobalVars.campaign
        variables("dial_method" & GlobalVars.jsVars("dial_method")) = String.Empty
        variables("comments") = "undefined"
        variables("qm_extension") = GlobalVars.jsVars("qm_extension")

        Dim request As New PBXWebRequest()
        Dim strReturn As String = request.postRequest("vdc_db_query.php", variables)
        Dim check_DS_array As String() = strReturn.Split(vbLf)
        Try
            If check_DS_array(1) = "Next agent_log_id:" Then
                GlobalVars.jsVars("agent_log_id") = check_DS_array(2)
            End If
        Catch ex As Exception

        End Try

        If GlobalVars.VDRP_stage = "PAUSED" Then
            If GlobalVars.jsVars("agent_pause_codes_active") = "FORCE" Then
                Me.btnPauseResume_ReasonWait()

                If IsNothing(frmPauseCodes) Then
                    frmPauseCodes = New PauseCodes()
                ElseIf Not frmPauseCodes.Visible Then
                    frmPauseCodes = New PauseCodes()
                End If

                If temp_auto = True Then
                    frmPauseCodes.AutoComplete(temp_reason)
                Else
                    frmPauseCodes.Show()
                End If
            Else
                Me.btnPauseResume_Paused()
            End If
        Else
            Me.btnPauseResume_Ready()
        End If
    End Sub

    Private Sub hold()
        Me.mainxfer_send_redirect("ParK", If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty), If(GlobalVars.jsVars.ContainsKey("lastcustserverip"), GlobalVars.jsVars("lastcustserverip"), String.Empty))
        GlobalVars.holding = True
        GlobalVars.holdingTime = 0
        If GlobalVars.xferHold = False Then
            Me.btnHold_OnHold()
        End If
        GlobalVars.timeSinceChange = 0
    End Sub

    Private Sub unHold()
        Me.mainxfer_send_redirect("FROMParK", If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty), If(GlobalVars.jsVars.ContainsKey("lastcustserverip"), GlobalVars.jsVars("lastcustserverip"), String.Empty))
        GlobalVars.holding = False
        If GlobalVars.xferHold = False Then
            Me.btnHold_OffHold()
        End If
        GlobalVars.timeSinceChange = 0
    End Sub

    Public Sub mainxfer_send_redirect(destination As String, channel As String, serverip As String)
        If destination = "ParK" Then
            GlobalVars.manager.parkCall(channel, serverip)
        ElseIf destination = "FROMParK" Then
            GlobalVars.manager.unparkCall(channel, serverip)
        End If
    End Sub
#End Region
#Region "Application Handling"
    Private Sub beginCall_VariablesSet()
        GlobalVars.VD_live_customer_call = True
        GlobalVars.VD_live_call_seconds = 0
        GlobalVars.timeSinceChange = 0
        Me.UpdateCallSeconds(GlobalVars.VD_live_call_seconds)
    End Sub

    Private Sub inCallButtons_Enable()
        Me.btnHangup_Enable()
        Me.btnTransfer_Enable()
        Me.btnHold_Enable()

        Me.btnPauseResume_Disable()
        Me.btnCallbackList_Disable()
        Me.btnManualDial_Disable()
        Me.btnDialNext_Disable()
        btnLoginOrOff.Enabled = False
    End Sub

    Public Sub customerHangup()
        Dim slice As New PBXBar.Toast.ToastForm(5000, "Customer Hangup")
        slice.Height = 75
        slice.Show()

        If Not GlobalVars.sentHangupLog Then
            GlobalVars.vdcClass.DialLog("end", "0")
            GlobalVars.sentHangupLog = True
        End If
    End Sub

    Public Sub cleanupAfterCall()
        '' Stop call recording...
        If GlobalVars.recording = True Then
            RecordingStop()
        End If

        If Regex.IsMatch(GlobalVars.urlPop, "agentid=") Then
            GlobalVars.urlPop = Regex.Replace(GlobalVars.urlPop, "agentid=", "done=true&agentid=")
            GlobalVars.func.launchBrowser(GlobalVars.urlPop)
        End If
        GlobalVars.urlPop = String.Empty

        GlobalVars.VD_live_customer_call = False
        GlobalVars.VD_live_call_seconds = 0
        GlobalVars.jsVars("MD_ring_secondS") = "0"
        GlobalVars.jsVars("CalLCID") = String.Empty
        GlobalVars.jsVars("MDnextCID") = String.Empty
        GlobalVars.jsVars("lastcustchannel") = String.Empty
        GlobalVars.jsVars("lastcustserverip") = String.Empty
        GlobalVars.jsVars("MDchannel") = String.Empty
        GlobalVars.jsVars("dialed_label") = String.Empty

        GlobalVars.holding = False

        GlobalVars.sentHangupLog = False

        If Not IsNothing(frmTransfer) Then
            If frmTransfer.Visible Then
                frmTransfer.Close()
            End If
        End If

        If Not IsNothing(frmLeadInfo) Then
            If frmLeadInfo.Visible Then
                frmLeadInfo.btnSave_Click()
                frmLeadInfo.Close()
            End If
        End If

        Me.btnHangup_Disable()
        Me.btnTransfer_Disable()
        Me.btnHold_Disable()

        If GlobalVars.MD_call_live Then
            GlobalVars.MD_call_live = False
        End If

        If GlobalVars.dialNextActive = True Then
            GlobalVars.dialNextActive = False
            Me.postDispoCleanup()
        Else
            If IsNothing(frmDispo) Then
                frmDispo = New CallDisposition()
            ElseIf Not frmDispo.Visible Then
                frmDispo = New CallDisposition()
            End If

            If GlobalVars.inOUT = "OUT" Then
                frmDispo.checkNotReadyBox()
            End If
            GlobalVars.inOUT = String.Empty

            frmDispo.Show()
        End If
    End Sub

    Private Sub postDispoCleanup()
        Me.btnPauseResume_Enable()
        Me.btnCallbackList_Enable()
        btnLoginOrOff.Enabled = True

        lblInboundCLI.Text = String.Empty
        lblFronter.Text = String.Empty
        lblCallTime.Text = String.Empty

        lblCallStatus.Text = "N/A"
        lblCallStatus.ForeColor = Color.Black
        lblOrderID.Text = "N/A"

        GlobalVars.lead_id = String.Empty
    End Sub

    Private Sub UpdateCallSeconds(number As Integer)
        Dim min As Integer = Math.Floor(number / 60)
        Dim sec As Integer = number Mod 60
        lblCallTime.Text = If(min < 10, "0", String.Empty) & min.ToString() & ":" & If(sec < 10, "0", String.Empty) & sec.ToString()
    End Sub

    Private Sub processVariables(vars As String)
        If Regex.IsMatch(vars, "\|\|A1_POPURL:(.+)\|A1_ORDID:(.+)\|A1_FULLNAME:(.+)\|A1_REJECTREASON:(.+)\|A1_ORDERSTATUS:(.+)\|A1_STOCKSTATUS:(.+)\|A1_WISPER:(.*)\|A1_VERIFIED:(.+)\|\|") Then
            Dim match As Match = Regex.Match(vars, "\|\|A1_POPURL:(.+)\|A1_ORDID:(.+)\|A1_FULLNAME:(.+)\|A1_REJECTREASON:(.+)\|A1_ORDERSTATUS:(.+)\|A1_STOCKSTATUS:(.+)\|A1_WISPER:(.*)\|A1_VERIFIED:(.+)\|\|")

            If match.Groups.Item(8).ToString() = "true" Then
                lblCallStatus.ForeColor = Color.Green
                lblCallStatus.Text = "Verified"
            Else
                lblCallStatus.ForeColor = Color.Red
                lblCallStatus.Text = "Unverified"
            End If

            If match.Groups.Item(2).ToString() = "false" Then
                lblOrderID.Text = "Unknown"
            Else
                lblOrderID.Text = match.Groups.Item(2).ToString()
            End If

            If Not IsNothing(frmLeadInfo) Then
                If frmLeadInfo.Visible Then
                    If Not match.Groups.Item(3).ToString() = "false" Then
                        Dim fullname As String() = match.Groups.Item(3).ToString().Split(New String() {"--"}, StringSplitOptions.None)

                        frmLeadInfo.txtTitle.Text = fullname(0)
                        frmLeadInfo.txtFirstName.Text = fullname(1)
                        frmLeadInfo.txtLastName.Text = fullname(2)

                        If match.Groups.Item(8).ToString() = "true" Then
                            frmLeadInfo.txtComments.Text = "Customer Passed Automatic Verification on DOB, 1st Line of Address and Post Code."
                        Else
                            frmLeadInfo.txtComments.Text = "Customer Failed Automatic Verification"
                        End If
                    End If
                End If
            End If

            '' SCREENPOP
            GlobalVars.urlPop = Regex.Replace(match.Groups.Item(1).ToString(), "agentid=", "agentid=" & GlobalVars.username)
            GlobalVars.func.launchBrowser(GlobalVars.urlPop)
        Else
            lblCallStatus.ForeColor = Color.Red
            lblCallStatus.Text = "Unverified"

            lblOrderID.Text = "Unknown"
        End If
    End Sub

    Private Sub queuePanelShow()
        ctrlQueuePanel = New QueuePanel()
        ctrlQueuePanel.Name = "QueuePanel"
        ctrlQueuePanel.Width = 35
        ctrlQueuePanel.Height = 35
        ctrlQueuePanel.Left = ((Me.Width - 175) - ctrlQueuePanel.Width) - 16
        ctrlQueuePanel.Top = (Me.Height / 2) - (ctrlQueuePanel.Height / 2) - 1

        Me.Controls.Add(ctrlQueuePanel)
    End Sub

    Private Sub queuePanelHide()
        Me.Controls.Remove(ctrlQueuePanel)
        ctrlQueuePanel = Nothing
    End Sub

    Private Sub queuePanelUpdate(value As Integer)
        ctrlQueuePanel.value = value
        ctrlQueuePanel.Refresh()
    End Sub
#End Region
#End Region

#Region "Context Menu On-Click Events"
    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        Dim about As New AboutBox()
        about.Show()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Dim settings As New Settings()
        settings.ShowWithAuth()
    End Sub

    Private Sub TestToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TestToolStripMenuItem.Click
        ''Dim test As New LeadInfoScript()
        ''test.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        If btnReconnect.Enabled = True Then
            Dim result As DialogResult = MessageBox.Show("You are about to exit while still logged in!" & vbLf & "This incident will be logged with IT." & vbLf & vbLf & "You should only do this if there has been an error." & vbLf & vbLf & "Are you sure you'd like to continue?", "You Are Still Logged In", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If result = Windows.Forms.DialogResult.Yes Then
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub
#End Region

#Region "Button Enable/Disable Functions"
    Private Sub btnLogonOff_Enable()
        Me.btnLoginOrOff.Enabled = True
    End Sub
    Private Sub btnLogonOff_Disable()
        Me.btnLoginOrOff.Enabled = False
    End Sub

    Private Sub btnHangup_Enable()
        btnHangUp.BackColor = Color.LightCoral
        btnHangUp.Enabled = True
    End Sub
    Private Sub btnHangup_Disable()
        btnHangUp.Enabled = False
        btnHangUp.BackColor = Color.Empty
    End Sub

    Private Sub btnHold_Enable()
        If GlobalVars.holding = True Then
            Me.btnHold_OnHold()
        Else
            Me.btnHold_OffHold()
        End If
        btnHold.Enabled = True
    End Sub

    Private Sub btnHold_OnHold()
        btnHold.Text = "Resume" & vbLf & "Call"
        btnHold.BackColor = Color.SandyBrown

        Me.btnTransfer_Disable()
    End Sub

    Private Sub btnHold_OffHold()
        btnHold.Text = "Hold"
        btnHold.BackColor = Color.PaleTurquoise

        Me.btnTransfer_Enable()
    End Sub

    Private Sub btnHold_Disable()
        btnHold.Enabled = False
        btnHold.BackColor = Color.Empty
    End Sub

    Private Sub btnTransfer_Enable()
        btnTransfer.BackColor = Color.LightGreen
        btnTransfer.Enabled = True
    End Sub
    Private Sub btnTransfer_Disable()
        btnTransfer.Enabled = False
        btnTransfer.BackColor = Color.Empty
    End Sub

    Private Sub btnManualDial_Enable()
        btnManualDial.BackColor = Color.Plum
        btnManualDial.Text = "Manual" & vbLf & "Dial"
        btnManualDial.Enabled = True
    End Sub
    Private Sub btnManualDial_SkipLead()
        btnManualDial.BackColor = Color.LightCoral
        btnManualDial.Text = "Skip" & vbLf & "Dial"
        btnManualDial.Enabled = True
        GlobalVars.dialNextActive = True
    End Sub
    Private Sub btnManualDial_Disable()
        btnManualDial.Enabled = False
        btnManualDial.Text = "Manual" & vbLf & "Dial"
        btnManualDial.BackColor = Color.Empty
    End Sub

    Private Sub btnCallbackList_Enable()
        btnCallbackList.BackColor = Color.LightGoldenrodYellow
        btnCallbackList.Enabled = True
    End Sub

    Private Sub btnCallbackList_Disable()
        btnCallbackList.Enabled = False
        btnCallbackList.BackColor = Color.Empty
    End Sub

    Private Sub btnDialNext_Enable()
        btnDialNext.BackColor = Color.PaleTurquoise
        btnDialNext.Text = "Dial" & vbLf & "Next"
        btnDialNext.Enabled = True
    End Sub
    Private Sub btnDialNext_DialLead()
        btnDialNext.BackColor = Color.LightGreen
        btnDialNext.Text = "Dial" & vbLf & "Lead"
        btnDialNext.Enabled = True
        GlobalVars.dialNextActive = True
    End Sub
    Private Sub btnDialNext_Disable()
        btnDialNext.Enabled = False
        btnDialNext.Text = "Dial" & vbLf & "Next"
        btnDialNext.BackColor = Color.Empty
    End Sub

    Private Sub btnPauseResume_Enable()
        If GlobalVars.VDRP_stage = "PAUSED" Then
            Me.btnPauseResume_Paused()
        Else
            Me.btnPauseResume_Ready()
        End If
        btnPauseResume.Enabled = True
    End Sub
    Private Sub btnPauseResume_Paused()
        btnPauseResume.Text = "Go" & vbLf & "Ready"
        btnPauseResume.BackColor = Color.LightGreen
        Me.btnLogonOff_Enable()
        Me.btnManualDial_Enable()
        Me.btnDialNext_Enable()
    End Sub
    Private Sub btnPauseResume_ReasonWait()
        Me.btnLogonOff_Disable()
        Me.btnManualDial_Disable()
        Me.btnDialNext_Disable()
        Me.btnPauseResume_Disable()
    End Sub
    Private Sub btnPauseResume_Ready()
        btnPauseResume.Text = "Not" & vbLf & "Ready"
        btnPauseResume.BackColor = Color.LightCoral
        Me.btnLogonOff_Disable()
        Me.btnManualDial_Disable()
        Me.btnDialNext_Disable()
    End Sub
    Private Sub btnPauseResume_Disable()
        btnPauseResume.Enabled = False
        btnPauseResume.BackColor = Color.Empty
        Me.btnManualDial_Disable()
    End Sub
#End Region

End Class