<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CallDisposition
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
        Me.chkDispoList = New System.Windows.Forms.CheckedListBox()
        Me.chkNotReady = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'chkDispoList
        '
        Me.chkDispoList.CheckOnClick = True
        Me.chkDispoList.Font = New System.Drawing.Font(pfc.Families(0), 13)
        Me.chkDispoList.FormattingEnabled = True
        Me.chkDispoList.Items.AddRange(New Object() {"1", "2", "3", "4", "4", "5", "6", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27"})
        Me.chkDispoList.Location = New System.Drawing.Point(8, 8)
        Me.chkDispoList.Name = "chkDispoList"
        Me.chkDispoList.Size = New System.Drawing.Size(306, 394)
        Me.chkDispoList.TabIndex = 0
        '
        'chkNotReady
        '
        Me.chkNotReady.AutoSize = True
        Me.chkNotReady.Font = New System.Drawing.Font(pfc.Families(0), 13)
        Me.chkNotReady.Location = New System.Drawing.Point(69, 405)
        Me.chkNotReady.Name = "chkNotReady"
        Me.chkNotReady.Size = New System.Drawing.Size(184, 28)
        Me.chkNotReady.TabIndex = 1
        Me.chkNotReady.Text = "Not Ready After Call"
        Me.chkNotReady.UseVisualStyleBackColor = True
        '
        'CallDisposition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 436)
        Me.ControlBox = False
        Me.Icon = My.Resources.Icons.icoHourglass
        Me.Controls.Add(Me.chkNotReady)
        Me.Controls.Add(Me.chkDispoList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "CallDisposition"
        Me.Text = "Call Disposition"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents chkDispoList As System.Windows.Forms.CheckedListBox
    Friend WithEvents chkNotReady As System.Windows.Forms.CheckBox
    Dim pfc As System.Drawing.Text.PrivateFontCollection
    Dim ifc As System.Drawing.Text.InstalledFontCollection
End Class
