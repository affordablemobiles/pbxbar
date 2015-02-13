<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Callback
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
        Me.dpckCallbackTime = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dpckCallbackDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.chkMeOnly = New System.Windows.Forms.CheckBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'dpckCallbackTime
        '
        Me.dpckCallbackTime.CustomFormat = "hh:mm tt"
        Me.dpckCallbackTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpckCallbackTime.Location = New System.Drawing.Point(246, 40)
        Me.dpckCallbackTime.Name = "dpckCallbackTime"
        Me.dpckCallbackTime.ShowUpDown = True
        Me.dpckCallbackTime.Size = New System.Drawing.Size(91, 20)
        Me.dpckCallbackTime.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(133, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(145, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Call Back When?"
        '
        'dpckCallbackDate
        '
        Me.dpckCallbackDate.CustomFormat = "ddd, dd MMMM yyyy"
        Me.dpckCallbackDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpckCallbackDate.Location = New System.Drawing.Point(74, 40)
        Me.dpckCallbackDate.Name = "dpckCallbackDate"
        Me.dpckCallbackDate.Size = New System.Drawing.Size(166, 20)
        Me.dpckCallbackDate.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(173, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Comments"
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(74, 88)
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(263, 20)
        Me.txtComments.TabIndex = 4
        '
        'chkMeOnly
        '
        Me.chkMeOnly.AutoSize = True
        Me.chkMeOnly.Enabled = False
        Me.chkMeOnly.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkMeOnly.Location = New System.Drawing.Point(125, 114)
        Me.chkMeOnly.Name = "chkMeOnly"
        Me.chkMeOnly.Size = New System.Drawing.Size(161, 21)
        Me.chkMeOnly.TabIndex = 5
        Me.chkMeOnly.Text = "Call Back By Me Only"
        Me.chkMeOnly.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(127, 141)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(208, 141)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 7
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Callback
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(411, 175)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.chkMeOnly)
        Me.Controls.Add(Me.txtComments)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dpckCallbackDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpckCallbackTime)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = Global.appbar.My.Resources.Icons.icoCalendarTime
        Me.Name = "Callback"
        Me.Text = "Callback"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dpckCallbackTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpckCallbackDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents chkMeOnly As System.Windows.Forms.CheckBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
End Class
