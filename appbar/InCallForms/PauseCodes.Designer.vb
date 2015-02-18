<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PauseCodes
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
        Me.chkPauseCodeList = New System.Windows.Forms.CheckedListBox()
        Me.SuspendLayout()
        '
        'chkPauseCodeList
        '
        Me.chkPauseCodeList.CheckOnClick = True
        Me.chkPauseCodeList.FormattingEnabled = True
        Me.chkPauseCodeList.Items.AddRange(New Object() {"1", "2", "3", "4", "4", "5", "6", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27"})
        Me.chkPauseCodeList.Location = New System.Drawing.Point(8, 8)
        Me.chkPauseCodeList.Name = "chkPauseCodeList"
        Me.chkPauseCodeList.Size = New System.Drawing.Size(306, 394)
        Me.chkPauseCodeList.TabIndex = 0
        '
        'PauseCodes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 411)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkPauseCodeList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.appbar.My.Resources.Icons.icoHourglass
        Me.Name = "PauseCodes"
        Me.Text = "Not Ready Reason"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkPauseCodeList As System.Windows.Forms.CheckedListBox
    Dim pfc As System.Drawing.Text.PrivateFontCollection
    Dim ifc As System.Drawing.Text.InstalledFontCollection
End Class
