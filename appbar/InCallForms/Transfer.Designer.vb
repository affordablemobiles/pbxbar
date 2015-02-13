<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transfer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnXfer2Queue = New System.Windows.Forms.Button()
        Me.cmbQueueSelect = New System.Windows.Forms.ComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnXfer2Agent = New System.Windows.Forms.Button()
        Me.cmbAgentSelect = New System.Windows.Forms.ComboBox()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.cmbDialType = New System.Windows.Forms.ComboBox()
        Me.txtDialNumber = New System.Windows.Forms.TextBox()
        Me.btnWarmTransfer = New System.Windows.Forms.Button()
        Me.btnConference = New System.Windows.Forms.Button()
        Me.btnUnattended = New System.Windows.Forms.Button()
        Me.btnLeaveCall = New System.Windows.Forms.Button()
        Me.btnHangupBoth = New System.Windows.Forms.Button()
        Me.btnHangupXfer = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnXfer2Queue)
        Me.GroupBox1.Controls.Add(Me.cmbQueueSelect)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(558, 81)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transfer to Queue"
        '
        'btnXfer2Queue
        '
        Me.btnXfer2Queue.Enabled = False
        Me.btnXfer2Queue.Location = New System.Drawing.Point(190, 46)
        Me.btnXfer2Queue.Name = "btnXfer2Queue"
        Me.btnXfer2Queue.Size = New System.Drawing.Size(182, 23)
        Me.btnXfer2Queue.TabIndex = 1
        Me.btnXfer2Queue.Text = "Transfer to Queue"
        Me.btnXfer2Queue.UseVisualStyleBackColor = True
        '
        'cmbQueueSelect
        '
        Me.cmbQueueSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQueueSelect.FormattingEnabled = True
        Me.cmbQueueSelect.Location = New System.Drawing.Point(64, 19)
        Me.cmbQueueSelect.Name = "cmbQueueSelect"
        Me.cmbQueueSelect.Size = New System.Drawing.Size(430, 21)
        Me.cmbQueueSelect.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnXfer2Agent)
        Me.GroupBox2.Controls.Add(Me.cmbAgentSelect)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(558, 82)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Transfer to Agent"
        '
        'btnXfer2Agent
        '
        Me.btnXfer2Agent.Enabled = False
        Me.btnXfer2Agent.Location = New System.Drawing.Point(190, 46)
        Me.btnXfer2Agent.Name = "btnXfer2Agent"
        Me.btnXfer2Agent.Size = New System.Drawing.Size(182, 23)
        Me.btnXfer2Agent.TabIndex = 3
        Me.btnXfer2Agent.Text = "Transfer to Agent"
        Me.btnXfer2Agent.UseVisualStyleBackColor = True
        '
        'cmbAgentSelect
        '
        Me.cmbAgentSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAgentSelect.FormattingEnabled = True
        Me.cmbAgentSelect.Location = New System.Drawing.Point(64, 19)
        Me.cmbAgentSelect.Name = "cmbAgentSelect"
        Me.cmbAgentSelect.Size = New System.Drawing.Size(430, 21)
        Me.cmbAgentSelect.TabIndex = 2
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(254, 343)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cmbDialType)
        Me.GroupBox3.Controls.Add(Me.txtDialNumber)
        Me.GroupBox3.Controls.Add(Me.btnWarmTransfer)
        Me.GroupBox3.Controls.Add(Me.btnConference)
        Me.GroupBox3.Controls.Add(Me.btnUnattended)
        Me.GroupBox3.Controls.Add(Me.btnLeaveCall)
        Me.GroupBox3.Controls.Add(Me.btnHangupBoth)
        Me.GroupBox3.Controls.Add(Me.btnHangupXfer)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 187)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(558, 147)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Transfer to Number"
        '
        'cmbDialType
        '
        Me.cmbDialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDialType.FormattingEnabled = True
        Me.cmbDialType.Location = New System.Drawing.Point(6, 35)
        Me.cmbDialType.Name = "cmbDialType"
        Me.cmbDialType.Size = New System.Drawing.Size(113, 21)
        Me.cmbDialType.TabIndex = 7
        '
        'txtDialNumber
        '
        Me.txtDialNumber.Location = New System.Drawing.Point(125, 35)
        Me.txtDialNumber.Name = "txtDialNumber"
        Me.txtDialNumber.Size = New System.Drawing.Size(240, 20)
        Me.txtDialNumber.TabIndex = 6
        '
        'btnWarmTransfer
        '
        Me.btnWarmTransfer.Enabled = False
        Me.btnWarmTransfer.Location = New System.Drawing.Point(91, 106)
        Me.btnWarmTransfer.Name = "btnWarmTransfer"
        Me.btnWarmTransfer.Size = New System.Drawing.Size(179, 23)
        Me.btnWarmTransfer.TabIndex = 5
        Me.btnWarmTransfer.Text = "Customer Hold (Attended Transfer)"
        Me.btnWarmTransfer.UseVisualStyleBackColor = True
        '
        'btnConference
        '
        Me.btnConference.Enabled = False
        Me.btnConference.Location = New System.Drawing.Point(188, 77)
        Me.btnConference.Name = "btnConference"
        Me.btnConference.Size = New System.Drawing.Size(177, 23)
        Me.btnConference.TabIndex = 4
        Me.btnConference.Text = "Dial With Customer (Conference)"
        Me.btnConference.UseVisualStyleBackColor = True
        '
        'btnUnattended
        '
        Me.btnUnattended.Enabled = False
        Me.btnUnattended.Location = New System.Drawing.Point(6, 77)
        Me.btnUnattended.Name = "btnUnattended"
        Me.btnUnattended.Size = New System.Drawing.Size(176, 23)
        Me.btnUnattended.TabIndex = 3
        Me.btnUnattended.Text = "Straight Through (Unattended)"
        Me.btnUnattended.UseVisualStyleBackColor = True
        '
        'btnLeaveCall
        '
        Me.btnLeaveCall.Enabled = False
        Me.btnLeaveCall.Location = New System.Drawing.Point(373, 77)
        Me.btnLeaveCall.Name = "btnLeaveCall"
        Me.btnLeaveCall.Size = New System.Drawing.Size(179, 23)
        Me.btnLeaveCall.TabIndex = 2
        Me.btnLeaveCall.Text = "Leave 3-way Call"
        Me.btnLeaveCall.UseVisualStyleBackColor = True
        '
        'btnHangupBoth
        '
        Me.btnHangupBoth.Enabled = False
        Me.btnHangupBoth.Location = New System.Drawing.Point(373, 48)
        Me.btnHangupBoth.Name = "btnHangupBoth"
        Me.btnHangupBoth.Size = New System.Drawing.Size(179, 23)
        Me.btnHangupBoth.TabIndex = 1
        Me.btnHangupBoth.Text = "Hangup Both Lines"
        Me.btnHangupBoth.UseVisualStyleBackColor = True
        '
        'btnHangupXfer
        '
        Me.btnHangupXfer.Enabled = False
        Me.btnHangupXfer.Location = New System.Drawing.Point(373, 19)
        Me.btnHangupXfer.Name = "btnHangupXfer"
        Me.btnHangupXfer.Size = New System.Drawing.Size(179, 23)
        Me.btnHangupXfer.TabIndex = 0
        Me.btnHangupXfer.Text = "Hangup XFER Line"
        Me.btnHangupXfer.UseVisualStyleBackColor = True
        '
        'Transfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(582, 375)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.appbar.My.Resources.Icons.icoPeopleMap
        Me.Name = "Transfer"
        Me.Text = "Transfer To"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnXfer2Queue As System.Windows.Forms.Button
    Friend WithEvents cmbQueueSelect As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnXfer2Agent As System.Windows.Forms.Button
    Friend WithEvents cmbAgentSelect As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnWarmTransfer As System.Windows.Forms.Button
    Friend WithEvents btnConference As System.Windows.Forms.Button
    Friend WithEvents btnUnattended As System.Windows.Forms.Button
    Friend WithEvents btnLeaveCall As System.Windows.Forms.Button
    Friend WithEvents btnHangupBoth As System.Windows.Forms.Button
    Friend WithEvents btnHangupXfer As System.Windows.Forms.Button
    Friend WithEvents txtDialNumber As System.Windows.Forms.TextBox
    Friend WithEvents cmbDialType As System.Windows.Forms.ComboBox
End Class
