<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManualDial
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDialNumber = New System.Windows.Forms.TextBox()
        Me.btnCall = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.cmbDialType = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(94, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(184, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Make a Call"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'txtDialNumber
        '
        Me.txtDialNumber.Location = New System.Drawing.Point(131, 46)
        Me.txtDialNumber.Name = "txtDialNumber"
        Me.txtDialNumber.Size = New System.Drawing.Size(229, 20)
        Me.txtDialNumber.TabIndex = 1
        Me.txtDialNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCall
        '
        Me.btnCall.Enabled = False
        Me.btnCall.Location = New System.Drawing.Point(108, 78)
        Me.btnCall.Name = "btnCall"
        Me.btnCall.Size = New System.Drawing.Size(75, 23)
        Me.btnCall.TabIndex = 2
        Me.btnCall.Text = "Call"
        Me.btnCall.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(189, 78)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'cmbDialType
        '
        Me.cmbDialType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDialType.FormattingEnabled = True
        Me.cmbDialType.Location = New System.Drawing.Point(12, 46)
        Me.cmbDialType.Name = "cmbDialType"
        Me.cmbDialType.Size = New System.Drawing.Size(113, 21)
        Me.cmbDialType.TabIndex = 4
        '
        'ManualDial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(372, 115)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmbDialType)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnCall)
        Me.Controls.Add(Me.txtDialNumber)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.appbar.My.Resources.Icons.icoCallBook
        Me.Name = "ManualDial"
        Me.Text = "Manual Dial"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDialNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnCall As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cmbDialType As System.Windows.Forms.ComboBox
End Class
