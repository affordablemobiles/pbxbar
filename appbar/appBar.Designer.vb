<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mainform
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mainform))
        Me.cntMainRightClick = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLoginOrOff = New System.Windows.Forms.Button()
        Me.tmrRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblServerTime = New System.Windows.Forms.Label()
        Me.lblCampCalls = New System.Windows.Forms.Label()
        Me.btnReconnect = New System.Windows.Forms.Button()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblInboundCLI = New System.Windows.Forms.Label()
        Me.btnPauseResume = New System.Windows.Forms.Button()
        Me.lblFronter = New System.Windows.Forms.Label()
        Me.btnHangUp = New System.Windows.Forms.Button()
        Me.btnDialNext = New System.Windows.Forms.Button()
        Me.btnHold = New System.Windows.Forms.Button()
        Me.btnTransfer = New System.Windows.Forms.Button()
        Me.pxA1Logo = New System.Windows.Forms.PictureBox()
        Me.lblCallTime = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCallStatus = New System.Windows.Forms.Label()
        Me.lblOrderID = New System.Windows.Forms.Label()
        Me.btnManualDial = New System.Windows.Forms.Button()
        Me.btnCallbackList = New System.Windows.Forms.Button()
        Me.cntMainRightClick.SuspendLayout()
        CType(Me.pxA1Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cntMainRightClick
        '
        Me.cntMainRightClick.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripMenuItem2, Me.TestToolStripMenuItem, Me.ToolStripMenuItem1, Me.ExitToolStripMenuItem})
        Me.cntMainRightClick.Name = "cntMainRightClick"
        Me.cntMainRightClick.Size = New System.Drawing.Size(117, 104)
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.SettingsToolStripMenuItem.Text = "Settings"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(113, 6)
        '
        'TestToolStripMenuItem
        '
        Me.TestToolStripMenuItem.Name = "TestToolStripMenuItem"
        Me.TestToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.TestToolStripMenuItem.Text = "Test"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(113, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(116, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'btnLoginOrOff
        '
        Me.btnLoginOrOff.Location = New System.Drawing.Point(206, 2)
        Me.btnLoginOrOff.Name = "btnLoginOrOff"
        Me.btnLoginOrOff.Size = New System.Drawing.Size(70, 44)
        Me.btnLoginOrOff.TabIndex = 1
        Me.btnLoginOrOff.Text = "Login"
        Me.btnLoginOrOff.UseVisualStyleBackColor = True
        '
        'tmrRefresh
        '
        Me.tmrRefresh.Interval = 1000
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Server Time :"
        '
        'lblServerTime
        '
        Me.lblServerTime.AutoSize = True
        Me.lblServerTime.Location = New System.Drawing.Point(79, 2)
        Me.lblServerTime.Name = "lblServerTime"
        Me.lblServerTime.Size = New System.Drawing.Size(27, 13)
        Me.lblServerTime.TabIndex = 3
        Me.lblServerTime.Text = "N/A"
        '
        'lblCampCalls
        '
        Me.lblCampCalls.AutoSize = True
        Me.lblCampCalls.Location = New System.Drawing.Point(3, 17)
        Me.lblCampCalls.Name = "lblCampCalls"
        Me.lblCampCalls.Size = New System.Drawing.Size(37, 13)
        Me.lblCampCalls.TabIndex = 4
        Me.lblCampCalls.Text = "          "
        '
        'btnReconnect
        '
        Me.btnReconnect.Enabled = False
        Me.btnReconnect.Location = New System.Drawing.Point(282, 2)
        Me.btnReconnect.Name = "btnReconnect"
        Me.btnReconnect.Size = New System.Drawing.Size(80, 44)
        Me.btnReconnect.TabIndex = 5
        Me.btnReconnect.Text = "Reconnect" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Phone"
        Me.btnReconnect.UseVisualStyleBackColor = True
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Location = New System.Drawing.Point(3, 31)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblStatus.TabIndex = 6
        Me.lblStatus.Text = "          "
        '
        'lblInboundCLI
        '
        Me.lblInboundCLI.Location = New System.Drawing.Point(75, 17)
        Me.lblInboundCLI.Name = "lblInboundCLI"
        Me.lblInboundCLI.Size = New System.Drawing.Size(125, 13)
        Me.lblInboundCLI.TabIndex = 7
        Me.lblInboundCLI.Text = "                                      "
        Me.lblInboundCLI.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnPauseResume
        '
        Me.btnPauseResume.Enabled = False
        Me.btnPauseResume.Location = New System.Drawing.Point(368, 2)
        Me.btnPauseResume.Name = "btnPauseResume"
        Me.btnPauseResume.Size = New System.Drawing.Size(70, 44)
        Me.btnPauseResume.TabIndex = 8
        Me.btnPauseResume.Text = "Go" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ready"
        Me.btnPauseResume.UseVisualStyleBackColor = False
        '
        'lblFronter
        '
        Me.lblFronter.AutoSize = True
        Me.lblFronter.Location = New System.Drawing.Point(900, 31)
        Me.lblFronter.Name = "lblFronter"
        Me.lblFronter.Size = New System.Drawing.Size(37, 13)
        Me.lblFronter.TabIndex = 9
        Me.lblFronter.Text = "          "
        '
        'btnHangUp
        '
        Me.btnHangUp.Enabled = False
        Me.btnHangUp.Location = New System.Drawing.Point(672, 2)
        Me.btnHangUp.Name = "btnHangUp"
        Me.btnHangUp.Size = New System.Drawing.Size(70, 44)
        Me.btnHangUp.TabIndex = 10
        Me.btnHangUp.Text = "Hang Up"
        Me.btnHangUp.UseVisualStyleBackColor = False
        '
        'btnDialNext
        '
        Me.btnDialNext.Enabled = False
        Me.btnDialNext.Location = New System.Drawing.Point(596, 2)
        Me.btnDialNext.Name = "btnDialNext"
        Me.btnDialNext.Size = New System.Drawing.Size(70, 44)
        Me.btnDialNext.TabIndex = 11
        Me.btnDialNext.Text = "Dial" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Next"
        Me.btnDialNext.UseVisualStyleBackColor = False
        '
        'btnHold
        '
        Me.btnHold.Enabled = False
        Me.btnHold.Location = New System.Drawing.Point(748, 2)
        Me.btnHold.Name = "btnHold"
        Me.btnHold.Size = New System.Drawing.Size(70, 44)
        Me.btnHold.TabIndex = 12
        Me.btnHold.Text = "Hold"
        Me.btnHold.UseVisualStyleBackColor = False
        '
        'btnTransfer
        '
        Me.btnTransfer.Enabled = False
        Me.btnTransfer.Location = New System.Drawing.Point(824, 2)
        Me.btnTransfer.Name = "btnTransfer"
        Me.btnTransfer.Size = New System.Drawing.Size(70, 44)
        Me.btnTransfer.TabIndex = 13
        Me.btnTransfer.Text = "Transfer"
        Me.btnTransfer.UseVisualStyleBackColor = False
        '
        'pxA1Logo
        '
        Me.pxA1Logo.Image = CType(resources.GetObject("pxA1Logo.Image"), System.Drawing.Image)
        Me.pxA1Logo.InitialImage = CType(resources.GetObject("pxA1Logo.InitialImage"), System.Drawing.Image)
        Me.pxA1Logo.Location = New System.Drawing.Point(1063, 7)
        Me.pxA1Logo.Name = "pxA1Logo"
        Me.pxA1Logo.Size = New System.Drawing.Size(156, 34)
        Me.pxA1Logo.TabIndex = 14
        Me.pxA1Logo.TabStop = False
        '
        'lblCallTime
        '
        Me.lblCallTime.Location = New System.Drawing.Point(140, 31)
        Me.lblCallTime.Name = "lblCallTime"
        Me.lblCallTime.Size = New System.Drawing.Size(60, 13)
        Me.lblCallTime.TabIndex = 15
        Me.lblCallTime.Text = "          "
        Me.lblCallTime.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(900, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Call Status :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(900, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Order ID :"
        '
        'lblCallStatus
        '
        Me.lblCallStatus.AutoSize = True
        Me.lblCallStatus.Location = New System.Drawing.Point(982, 2)
        Me.lblCallStatus.Name = "lblCallStatus"
        Me.lblCallStatus.Size = New System.Drawing.Size(27, 13)
        Me.lblCallStatus.TabIndex = 18
        Me.lblCallStatus.Text = "N/A"
        '
        'lblOrderID
        '
        Me.lblOrderID.AutoSize = True
        Me.lblOrderID.Location = New System.Drawing.Point(982, 17)
        Me.lblOrderID.Name = "lblOrderID"
        Me.lblOrderID.Size = New System.Drawing.Size(27, 13)
        Me.lblOrderID.TabIndex = 19
        Me.lblOrderID.Text = "N/A"
        '
        'btnManualDial
        '
        Me.btnManualDial.Enabled = False
        Me.btnManualDial.Location = New System.Drawing.Point(520, 2)
        Me.btnManualDial.Name = "btnManualDial"
        Me.btnManualDial.Size = New System.Drawing.Size(70, 44)
        Me.btnManualDial.TabIndex = 20
        Me.btnManualDial.Text = "Manual" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Dial"
        Me.btnManualDial.UseVisualStyleBackColor = False
        '
        'btnCallbackList
        '
        Me.btnCallbackList.Enabled = False
        Me.btnCallbackList.Location = New System.Drawing.Point(444, 2)
        Me.btnCallbackList.Name = "btnCallbackList"
        Me.btnCallbackList.Size = New System.Drawing.Size(70, 44)
        Me.btnCallbackList.TabIndex = 21
        Me.btnCallbackList.Text = "Call Back" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "List"
        Me.btnCallbackList.UseVisualStyleBackColor = False
        '
        'mainform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1222, 48)
        Me.ContextMenuStrip = Me.cntMainRightClick
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCallbackList)
        Me.Controls.Add(Me.btnManualDial)
        Me.Controls.Add(Me.lblOrderID)
        Me.Controls.Add(Me.lblCallStatus)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblCallTime)
        Me.Controls.Add(Me.pxA1Logo)
        Me.Controls.Add(Me.btnTransfer)
        Me.Controls.Add(Me.btnHold)
        Me.Controls.Add(Me.btnDialNext)
        Me.Controls.Add(Me.btnHangUp)
        Me.Controls.Add(Me.lblFronter)
        Me.Controls.Add(Me.btnPauseResume)
        Me.Controls.Add(Me.lblStatus)
        Me.Controls.Add(Me.btnReconnect)
        Me.Controls.Add(Me.lblCampCalls)
        Me.Controls.Add(Me.lblServerTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLoginOrOff)
        Me.Controls.Add(Me.lblInboundCLI)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Name = "mainform"
        Me.cntMainRightClick.ResumeLayout(False)
        CType(Me.pxA1Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cntMainRightClick As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLoginOrOff As System.Windows.Forms.Button
    Friend WithEvents tmrRefresh As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblServerTime As System.Windows.Forms.Label
    Friend WithEvents lblCampCalls As System.Windows.Forms.Label
    Friend WithEvents btnReconnect As System.Windows.Forms.Button
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblInboundCLI As System.Windows.Forms.Label
    Friend WithEvents btnPauseResume As System.Windows.Forms.Button
    Friend WithEvents lblFronter As System.Windows.Forms.Label
    Friend WithEvents btnHangUp As System.Windows.Forms.Button
    Friend WithEvents btnDialNext As System.Windows.Forms.Button
    Friend WithEvents btnHold As System.Windows.Forms.Button
    Friend WithEvents btnTransfer As System.Windows.Forms.Button
    Friend WithEvents pxA1Logo As System.Windows.Forms.PictureBox
    Friend WithEvents lblCallTime As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCallStatus As System.Windows.Forms.Label
    Friend WithEvents lblOrderID As System.Windows.Forms.Label
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnManualDial As System.Windows.Forms.Button
    Friend WithEvents btnCallbackList As System.Windows.Forms.Button
End Class
