<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Settings
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
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.txtAgentURL = New System.Windows.Forms.TextBox()
        Me.lblAgentURL = New System.Windows.Forms.Label()
        Me.txtMappingURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbtnChromeYes = New System.Windows.Forms.RadioButton()
        Me.rbtnChromeNo = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(238, 100)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(319, 100)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'txtAgentURL
        '
        Me.txtAgentURL.Location = New System.Drawing.Point(110, 16)
        Me.txtAgentURL.Name = "txtAgentURL"
        Me.txtAgentURL.Size = New System.Drawing.Size(510, 20)
        Me.txtAgentURL.TabIndex = 2
        '
        'lblAgentURL
        '
        Me.lblAgentURL.AutoSize = True
        Me.lblAgentURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAgentURL.Location = New System.Drawing.Point(12, 19)
        Me.lblAgentURL.Name = "lblAgentURL"
        Me.lblAgentURL.Size = New System.Drawing.Size(77, 13)
        Me.lblAgentURL.TabIndex = 3
        Me.lblAgentURL.Text = "Agent URL :"
        '
        'txtMappingURL
        '
        Me.txtMappingURL.Location = New System.Drawing.Point(110, 42)
        Me.txtMappingURL.Name = "txtMappingURL"
        Me.txtMappingURL.Size = New System.Drawing.Size(510, 20)
        Me.txtMappingURL.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Mapping URL :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Use Chrome :"
        '
        'rbtnChromeYes
        '
        Me.rbtnChromeYes.AutoSize = True
        Me.rbtnChromeYes.Location = New System.Drawing.Point(3, 0)
        Me.rbtnChromeYes.Name = "rbtnChromeYes"
        Me.rbtnChromeYes.Size = New System.Drawing.Size(43, 17)
        Me.rbtnChromeYes.TabIndex = 7
        Me.rbtnChromeYes.TabStop = True
        Me.rbtnChromeYes.Text = "Yes"
        Me.rbtnChromeYes.UseVisualStyleBackColor = True
        '
        'rbtnChromeNo
        '
        Me.rbtnChromeNo.AutoSize = True
        Me.rbtnChromeNo.Location = New System.Drawing.Point(52, 0)
        Me.rbtnChromeNo.Name = "rbtnChromeNo"
        Me.rbtnChromeNo.Size = New System.Drawing.Size(39, 17)
        Me.rbtnChromeNo.TabIndex = 8
        Me.rbtnChromeNo.TabStop = True
        Me.rbtnChromeNo.Text = "No"
        Me.rbtnChromeNo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbtnChromeYes)
        Me.Panel1.Controls.Add(Me.rbtnChromeNo)
        Me.Panel1.Location = New System.Drawing.Point(110, 68)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(510, 26)
        Me.Panel1.TabIndex = 9
        '
        'Settings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(632, 135)
        Me.ControlBox = False
        Me.Icon = My.Resources.Icons.icoSettings
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMappingURL)
        Me.Controls.Add(Me.lblAgentURL)
        Me.Controls.Add(Me.txtAgentURL)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Settings"
        Me.Text = "Settings"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents txtAgentURL As System.Windows.Forms.TextBox
    Friend WithEvents lblAgentURL As System.Windows.Forms.Label
    Friend WithEvents txtMappingURL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbtnChromeYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnChromeNo As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
