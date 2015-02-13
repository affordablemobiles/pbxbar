Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Linq
Public Class Transfer
    Public queues As New Dictionary(Of String, String)
    Public agents As New Dictionary(Of String, String)
    Public agentsEnabled As Boolean = False

    Public Event xferInProgress()
    Public Event xferComplete()
    Public Event xferCleanup()
    Public Event xferHangup()
    Public Event xferHold()
    Public Event xferUnhold()

    Private Sub Transfer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim values As New Dictionary(Of String, String)
        values("ext") = "External"
        values("int") = "Internal"

        cmbDialType.DisplayMember = "Value"
        cmbDialType.ValueMember = "Key"
        cmbDialType.DataSource = New BindingSource(values, Nothing)

        If GlobalVars.jsArrays("xfergroups").Length = GlobalVars.jsArrays("xfergroupsnames").Length Then
            For i As Integer = 0 To GlobalVars.jsArrays("xfergroups").Length - 1
                If GlobalVars.jsArrays("xfergroups")(i) = "AGENTDIRECT" Then
                    ' Setup AGENT Direct Transfer here...
                    Me.agentsEnabled = True
                    Me.agents = GlobalVars.vdcClass.refresh_agents()
                    If Me.agents.Count > 0 Then
                        cmbAgentSelect.DisplayMember = "Value"
                        cmbAgentSelect.ValueMember = "Key"
                        cmbAgentSelect.DataSource = New BindingSource(Me.agents, Nothing)
                    End If
                Else
                    queues.Add(GlobalVars.jsArrays("xfergroups")(i), GlobalVars.jsArrays("xfergroupsnames")(i))
                End If
            Next
        Else
            MessageBox.Show("Transferrable Groups and Their Names Don't Match!" & vbLf & "Something Went Very Wrong")
        End If

        cmbQueueSelect.DisplayMember = "Value"
        cmbQueueSelect.ValueMember = "Key"
        cmbQueueSelect.DataSource = New BindingSource(Me.queues, Nothing)
    End Sub

    Public Sub doQueueChange() Handles cmbQueueSelect.SelectedValueChanged
        If Not cmbQueueSelect.SelectedValue = String.Empty And Not GlobalVars.xferInProgress Then
            btnXfer2Queue.Enabled = True
        Else
            btnXfer2Queue.Enabled = False
        End If
    End Sub

    Public Sub doAgentChange() Handles cmbAgentSelect.SelectedValueChanged
        If Not cmbAgentSelect.SelectedValue = String.Empty And Not GlobalVars.xferInProgress Then
            btnXfer2Agent.Enabled = True
        Else
            btnXfer2Agent.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnXfer2Queue_Click(sender As Object, e As EventArgs) Handles btnXfer2Queue.Click
        GlobalVars.manager.xferLocal(If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty), If(GlobalVars.jsVars.ContainsKey("lastcustserverip"), GlobalVars.jsVars("lastcustserverip"), String.Empty), cmbQueueSelect.SelectedValue)
        RaiseEvent xferComplete()
        Me.Close()
    End Sub

    Private Sub btnXfer2Agent_Click(sender As Object, e As EventArgs) Handles btnXfer2Agent.Click
        GlobalVars.manager.xferToAgent(If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty), If(GlobalVars.jsVars.ContainsKey("lastcustserverip"), GlobalVars.jsVars("lastcustserverip"), String.Empty), cmbAgentSelect.SelectedValue)
        RaiseEvent xferComplete()
        Me.Close()
    End Sub

    Private Sub btnUnattended_Click(sender As Object, e As EventArgs) Handles btnUnattended.Click
        GlobalVars.manager.xferBlind(If(GlobalVars.jsVars.ContainsKey("lastcustchannel"), GlobalVars.jsVars("lastcustchannel"), String.Empty), If(GlobalVars.jsVars.ContainsKey("lastcustserverip"), GlobalVars.jsVars("lastcustserverip"), String.Empty), Me.getNumberToDial())
        RaiseEvent xferComplete()
        Me.Close()
    End Sub

    Private Sub txtDialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtDialNumber.TextChanged
        If Regex.IsMatch(txtDialNumber.Text, "[^0-9]") Then
            txtDialNumber.Text = Regex.Replace(txtDialNumber.Text, "[^0-9]", "")
            MessageBox.Show("Only Numbers Allowed Here!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Me.validateNumber()
    End Sub

    Private Sub btnConference_Click(sender As Object, e As EventArgs) Handles btnConference.Click
        GlobalVars.xferHold = False

        Me.xferStart()
    End Sub

    Private Function getNumberToDial() As String
        Dim numberToDial As String = String.Empty

        If cmbDialType.SelectedValue = "ext" Then
            '' Add Dial Prefix Here.
            numberToDial = If(GlobalVars.jsVars.ContainsKey("dial_prefix"), GlobalVars.jsVars("dial_prefix"), String.Empty) & txtDialNumber.Text
            ''MessageBox.Show("External Dial")
        Else
            '' Number as-is.
            numberToDial = txtDialNumber.Text
            ''MessageBox.Show("Internal Dial")
        End If

        Return numberToDial
    End Function

    Private Sub xferStart()
        GlobalVars.xferInProgress = True
        RaiseEvent xferInProgress()
        Me.disableAllButtons()

        GlobalVars.func.SendManualDial(Me.getNumberToDial(), True)
    End Sub

    Public Sub xferConnected()
        btnHangupXfer.Enabled = True
        If GlobalVars.xferHold = False Then
            btnHangupBoth.Enabled = True
        End If
        btnLeaveCall.Enabled = True
    End Sub

    Public Sub xferErrorCleanup()
        GlobalVars.xferInProgress = False
        GlobalVars.xferHold = False
        Me.disableAllButtons()
        Me.enableDefaultButtons()
        RaiseEvent xferCleanup()
    End Sub

    Private Sub disableAllButtons()
        btnXfer2Queue.Enabled = False
        btnXfer2Agent.Enabled = False

        btnUnattended.Enabled = False
        btnConference.Enabled = False
        btnWarmTransfer.Enabled = False

        btnHangupXfer.Enabled = False
        btnHangupBoth.Enabled = False
        btnLeaveCall.Enabled = False

        txtDialNumber.Enabled = False

        btnCancel.Enabled = False
    End Sub

    Private Sub enableDefaultButtons()
        If Not cmbQueueSelect.SelectedValue = String.Empty Then
            btnXfer2Queue.Enabled = True
        End If
        If Not cmbAgentSelect.SelectedValue = String.Empty And Me.agentsEnabled Then
            btnXfer2Agent.Enabled = True
        End If

        Me.validateNumber()

        txtDialNumber.Enabled = True

        btnCancel.Enabled = True
    End Sub

    Private Sub enableTransferButtonsReal()
        btnUnattended.Enabled = True
        btnConference.Enabled = True
        btnWarmTransfer.Enabled = True
    End Sub

    Private Sub disableTransferButtonsReal()
        btnUnattended.Enabled = False
        btnConference.Enabled = False
        btnWarmTransfer.Enabled = False
    End Sub

    Private Sub validateNumber()
        If cmbDialType.SelectedValue = "ext" Then
            If GlobalVars.func.validNumber(txtDialNumber.Text, False) Then
                Me.enableTransferButtonsReal()
            Else
                Me.disableTransferButtonsReal()
            End If
        Else
            If GlobalVars.func.validNumber(txtDialNumber.Text, True) Then
                Me.enableTransferButtonsReal()
            Else
                Me.disableTransferButtonsReal()
            End If
        End If
    End Sub

    Private Sub btnHangupXfer_Click(sender As Object, e As EventArgs) Handles btnHangupXfer.Click
        GlobalVars.manager.hangupXferLine()

        If GlobalVars.xferHold = True Then
            RaiseEvent xferUnhold()
            GlobalVars.xferHold = False
        End If

        Me.xferErrorCleanup()
    End Sub

    Private Sub btnHangupBoth_Click(sender As Object, e As EventArgs) Handles btnHangupBoth.Click
        GlobalVars.manager.hangupXferLine()

        Me.xferErrorCleanup()

        RaiseEvent xferHangup()
    End Sub

    Private Sub btnLeaveCall_Click(sender As Object, e As EventArgs) Handles btnLeaveCall.Click
        If GlobalVars.xferHold = True Then
            RaiseEvent xferUnhold()
            GlobalVars.xferHold = False
        End If

        GlobalVars.manager.Leave3wayCall()

        Me.xferErrorCleanup()

        RaiseEvent xferComplete()
    End Sub

    Private Sub btnWarmTransfer_Click(sender As Object, e As EventArgs) Handles btnWarmTransfer.Click
        GlobalVars.xferHold = True

        RaiseEvent xferHold()

        Me.xferStart()
    End Sub

    Private Sub cmbDialType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDialType.SelectedIndexChanged
        Me.validateNumber()
    End Sub
End Class