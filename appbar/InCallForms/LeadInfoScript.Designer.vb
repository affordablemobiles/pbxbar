<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeadInfoScript
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
        Me.tabctrlMain = New System.Windows.Forms.TabControl()
        Me.tabLeadInfo = New System.Windows.Forms.TabPage()
        Me.lblSaveInfo = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtComments = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtAltPhoneNo = New System.Windows.Forms.TextBox()
        Me.txtPhoneNo = New System.Windows.Forms.TextBox()
        Me.txtPostCode = New System.Windows.Forms.TextBox()
        Me.txtCounty = New System.Windows.Forms.TextBox()
        Me.txtTownCity = New System.Windows.Forms.TextBox()
        Me.txtAddressLine1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtLastName = New System.Windows.Forms.TextBox()
        Me.txtMiddleName = New System.Windows.Forms.TextBox()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.txtTitle = New System.Windows.Forms.TextBox()
        Me.tabCallScript = New System.Windows.Forms.TabPage()
        Me.tmrLabelChange = New System.Windows.Forms.Timer(Me.components)
        Me.tabOutboundInfo = New System.Windows.Forms.TabPage()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblPreviousCalledCount = New System.Windows.Forms.Label()
        Me.lblPreviousDisposition = New System.Windows.Forms.Label()
        Me.lblCallbackTimeRequested = New System.Windows.Forms.Label()
        Me.lblCallBackLoggedTime = New System.Windows.Forms.Label()
        Me.lblCallbackLoggedUser = New System.Windows.Forms.Label()
        Me.lblCallbackComments = New System.Windows.Forms.Label()
        Me.tabctrlMain.SuspendLayout()
        Me.tabLeadInfo.SuspendLayout()
        Me.tabOutboundInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabctrlMain
        '
        Me.tabctrlMain.Controls.Add(Me.tabLeadInfo)
        Me.tabctrlMain.Controls.Add(Me.tabCallScript)
        Me.tabctrlMain.Controls.Add(Me.tabOutboundInfo)
        Me.tabctrlMain.Location = New System.Drawing.Point(0, 0)
        Me.tabctrlMain.Name = "tabctrlMain"
        Me.tabctrlMain.SelectedIndex = 0
        Me.tabctrlMain.Size = New System.Drawing.Size(891, 636)
        Me.tabctrlMain.TabIndex = 0
        '
        'tabLeadInfo
        '
        Me.tabLeadInfo.Controls.Add(Me.lblSaveInfo)
        Me.tabLeadInfo.Controls.Add(Me.btnReset)
        Me.tabLeadInfo.Controls.Add(Me.btnSave)
        Me.tabLeadInfo.Controls.Add(Me.Label12)
        Me.tabLeadInfo.Controls.Add(Me.Label11)
        Me.tabLeadInfo.Controls.Add(Me.Label10)
        Me.tabLeadInfo.Controls.Add(Me.Label9)
        Me.tabLeadInfo.Controls.Add(Me.Label8)
        Me.tabLeadInfo.Controls.Add(Me.Label7)
        Me.tabLeadInfo.Controls.Add(Me.Label6)
        Me.tabLeadInfo.Controls.Add(Me.Label5)
        Me.tabLeadInfo.Controls.Add(Me.txtComments)
        Me.tabLeadInfo.Controls.Add(Me.txtEmail)
        Me.tabLeadInfo.Controls.Add(Me.txtAltPhoneNo)
        Me.tabLeadInfo.Controls.Add(Me.txtPhoneNo)
        Me.tabLeadInfo.Controls.Add(Me.txtPostCode)
        Me.tabLeadInfo.Controls.Add(Me.txtCounty)
        Me.tabLeadInfo.Controls.Add(Me.txtTownCity)
        Me.tabLeadInfo.Controls.Add(Me.txtAddressLine1)
        Me.tabLeadInfo.Controls.Add(Me.Label4)
        Me.tabLeadInfo.Controls.Add(Me.Label3)
        Me.tabLeadInfo.Controls.Add(Me.Label2)
        Me.tabLeadInfo.Controls.Add(Me.Label1)
        Me.tabLeadInfo.Controls.Add(Me.txtLastName)
        Me.tabLeadInfo.Controls.Add(Me.txtMiddleName)
        Me.tabLeadInfo.Controls.Add(Me.txtFirstName)
        Me.tabLeadInfo.Controls.Add(Me.txtTitle)
        Me.tabLeadInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabLeadInfo.Name = "tabLeadInfo"
        Me.tabLeadInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabLeadInfo.Size = New System.Drawing.Size(883, 610)
        Me.tabLeadInfo.TabIndex = 0
        Me.tabLeadInfo.Text = "Lead Info"
        Me.tabLeadInfo.UseVisualStyleBackColor = True
        '
        'lblSaveInfo
        '
        Me.lblSaveInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSaveInfo.ForeColor = System.Drawing.Color.Green
        Me.lblSaveInfo.Location = New System.Drawing.Point(573, 574)
        Me.lblSaveInfo.Name = "lblSaveInfo"
        Me.lblSaveInfo.Size = New System.Drawing.Size(251, 23)
        Me.lblSaveInfo.TabIndex = 26
        Me.lblSaveInfo.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(444, 569)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 25
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(363, 569)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 24
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 379)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(203, 17)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Comments :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 331)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(203, 17)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Email Address :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 305)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(203, 17)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "Alternate Phone Number :"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(8, 279)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(203, 17)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Phone Number :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label8
        '
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(8, 227)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(203, 17)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Post Code :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label7
        '
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 201)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(203, 17)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "County :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 175)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(203, 17)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Town / City :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(203, 17)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "Address Line 1 :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtComments
        '
        Me.txtComments.Location = New System.Drawing.Point(217, 376)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New System.Drawing.Size(607, 178)
        Me.txtComments.TabIndex = 15
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(217, 328)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(607, 20)
        Me.txtEmail.TabIndex = 14
        '
        'txtAltPhoneNo
        '
        Me.txtAltPhoneNo.Location = New System.Drawing.Point(217, 302)
        Me.txtAltPhoneNo.Name = "txtAltPhoneNo"
        Me.txtAltPhoneNo.Size = New System.Drawing.Size(607, 20)
        Me.txtAltPhoneNo.TabIndex = 13
        '
        'txtPhoneNo
        '
        Me.txtPhoneNo.Location = New System.Drawing.Point(217, 276)
        Me.txtPhoneNo.Name = "txtPhoneNo"
        Me.txtPhoneNo.Size = New System.Drawing.Size(607, 20)
        Me.txtPhoneNo.TabIndex = 12
        '
        'txtPostCode
        '
        Me.txtPostCode.Location = New System.Drawing.Point(217, 224)
        Me.txtPostCode.Name = "txtPostCode"
        Me.txtPostCode.Size = New System.Drawing.Size(607, 20)
        Me.txtPostCode.TabIndex = 11
        '
        'txtCounty
        '
        Me.txtCounty.Location = New System.Drawing.Point(217, 198)
        Me.txtCounty.Name = "txtCounty"
        Me.txtCounty.Size = New System.Drawing.Size(607, 20)
        Me.txtCounty.TabIndex = 10
        '
        'txtTownCity
        '
        Me.txtTownCity.Location = New System.Drawing.Point(217, 172)
        Me.txtTownCity.Name = "txtTownCity"
        Me.txtTownCity.Size = New System.Drawing.Size(607, 20)
        Me.txtTownCity.TabIndex = 9
        '
        'txtAddressLine1
        '
        Me.txtAddressLine1.Location = New System.Drawing.Point(217, 146)
        Me.txtAddressLine1.Name = "txtAddressLine1"
        Me.txtAddressLine1.Size = New System.Drawing.Size(607, 20)
        Me.txtAddressLine1.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 98)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(203, 17)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Last Name :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(203, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Middle Name :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(203, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "First Name :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(203, 17)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Title :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(217, 95)
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(607, 20)
        Me.txtLastName.TabIndex = 3
        '
        'txtMiddleName
        '
        Me.txtMiddleName.Location = New System.Drawing.Point(217, 69)
        Me.txtMiddleName.Name = "txtMiddleName"
        Me.txtMiddleName.Size = New System.Drawing.Size(607, 20)
        Me.txtMiddleName.TabIndex = 2
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(217, 43)
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(607, 20)
        Me.txtFirstName.TabIndex = 1
        '
        'txtTitle
        '
        Me.txtTitle.Location = New System.Drawing.Point(217, 17)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New System.Drawing.Size(607, 20)
        Me.txtTitle.TabIndex = 0
        '
        'tabCallScript
        '
        Me.tabCallScript.Location = New System.Drawing.Point(4, 22)
        Me.tabCallScript.Name = "tabCallScript"
        Me.tabCallScript.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCallScript.Size = New System.Drawing.Size(883, 610)
        Me.tabCallScript.TabIndex = 1
        Me.tabCallScript.Text = "Call Script"
        Me.tabCallScript.UseVisualStyleBackColor = True
        '
        'tmrLabelChange
        '
        Me.tmrLabelChange.Interval = 5000
        '
        'tabOutboundInfo
        '
        Me.tabOutboundInfo.Controls.Add(Me.lblCallbackComments)
        Me.tabOutboundInfo.Controls.Add(Me.lblCallbackLoggedUser)
        Me.tabOutboundInfo.Controls.Add(Me.lblCallBackLoggedTime)
        Me.tabOutboundInfo.Controls.Add(Me.lblCallbackTimeRequested)
        Me.tabOutboundInfo.Controls.Add(Me.lblPreviousDisposition)
        Me.tabOutboundInfo.Controls.Add(Me.lblPreviousCalledCount)
        Me.tabOutboundInfo.Controls.Add(Me.Label18)
        Me.tabOutboundInfo.Controls.Add(Me.Label17)
        Me.tabOutboundInfo.Controls.Add(Me.Label16)
        Me.tabOutboundInfo.Controls.Add(Me.Label15)
        Me.tabOutboundInfo.Controls.Add(Me.Label14)
        Me.tabOutboundInfo.Controls.Add(Me.Label13)
        Me.tabOutboundInfo.Location = New System.Drawing.Point(4, 22)
        Me.tabOutboundInfo.Name = "tabOutboundInfo"
        Me.tabOutboundInfo.Padding = New System.Windows.Forms.Padding(3)
        Me.tabOutboundInfo.Size = New System.Drawing.Size(883, 610)
        Me.tabOutboundInfo.TabIndex = 2
        Me.tabOutboundInfo.Text = "Outbound Info"
        Me.tabOutboundInfo.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(76, 61)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(203, 17)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Times Previously Called :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label14
        '
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(76, 88)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(203, 17)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Previous Disposition :"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label15
        '
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(76, 115)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(203, 17)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "Callback Time Requested :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label16
        '
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(76, 142)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(203, 17)
        Me.Label16.TabIndex = 8
        Me.Label16.Text = "Time Callback was Logged :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label17
        '
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(76, 168)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(203, 17)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Callback Logged by User :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label18
        '
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(76, 195)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(203, 17)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Callback Comments :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'lblPreviousCalledCount
        '
        Me.lblPreviousCalledCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousCalledCount.Location = New System.Drawing.Point(285, 61)
        Me.lblPreviousCalledCount.Name = "lblPreviousCalledCount"
        Me.lblPreviousCalledCount.Size = New System.Drawing.Size(589, 17)
        Me.lblPreviousCalledCount.TabIndex = 11
        Me.lblPreviousCalledCount.Text = "N/A"
        '
        'lblPreviousDisposition
        '
        Me.lblPreviousDisposition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPreviousDisposition.Location = New System.Drawing.Point(285, 88)
        Me.lblPreviousDisposition.Name = "lblPreviousDisposition"
        Me.lblPreviousDisposition.Size = New System.Drawing.Size(589, 17)
        Me.lblPreviousDisposition.TabIndex = 12
        Me.lblPreviousDisposition.Text = "N/A"
        '
        'lblCallbackTimeRequested
        '
        Me.lblCallbackTimeRequested.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallbackTimeRequested.Location = New System.Drawing.Point(285, 115)
        Me.lblCallbackTimeRequested.Name = "lblCallbackTimeRequested"
        Me.lblCallbackTimeRequested.Size = New System.Drawing.Size(589, 17)
        Me.lblCallbackTimeRequested.TabIndex = 13
        Me.lblCallbackTimeRequested.Text = "N/A"
        '
        'lblCallBackLoggedTime
        '
        Me.lblCallBackLoggedTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallBackLoggedTime.Location = New System.Drawing.Point(285, 142)
        Me.lblCallBackLoggedTime.Name = "lblCallBackLoggedTime"
        Me.lblCallBackLoggedTime.Size = New System.Drawing.Size(589, 17)
        Me.lblCallBackLoggedTime.TabIndex = 14
        Me.lblCallBackLoggedTime.Text = "N/A"
        '
        'lblCallbackLoggedUser
        '
        Me.lblCallbackLoggedUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallbackLoggedUser.Location = New System.Drawing.Point(285, 168)
        Me.lblCallbackLoggedUser.Name = "lblCallbackLoggedUser"
        Me.lblCallbackLoggedUser.Size = New System.Drawing.Size(589, 17)
        Me.lblCallbackLoggedUser.TabIndex = 15
        Me.lblCallbackLoggedUser.Text = "N/A"
        '
        'lblCallbackComments
        '
        Me.lblCallbackComments.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCallbackComments.Location = New System.Drawing.Point(285, 195)
        Me.lblCallbackComments.Name = "lblCallbackComments"
        Me.lblCallbackComments.Size = New System.Drawing.Size(589, 17)
        Me.lblCallbackComments.TabIndex = 16
        Me.lblCallbackComments.Text = "N/A"
        '
        'LeadInfoScript
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(890, 634)
        Me.Controls.Add(Me.tabctrlMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.appbar.My.Resources.Icons.icoPhoneBubble
        Me.MaximizeBox = False
        Me.Name = "LeadInfoScript"
        Me.Text = "Script / Lead Info"
        Me.TopMost = True
        Me.tabctrlMain.ResumeLayout(False)
        Me.tabLeadInfo.ResumeLayout(False)
        Me.tabLeadInfo.PerformLayout()
        Me.tabOutboundInfo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabctrlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabLeadInfo As System.Windows.Forms.TabPage
    Friend WithEvents tabCallScript As System.Windows.Forms.TabPage
    Friend WithEvents txtTitle As System.Windows.Forms.TextBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtComments As System.Windows.Forms.TextBox
    Friend WithEvents txtEmail As System.Windows.Forms.TextBox
    Friend WithEvents txtAltPhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents txtPostCode As System.Windows.Forms.TextBox
    Friend WithEvents txtCounty As System.Windows.Forms.TextBox
    Friend WithEvents txtTownCity As System.Windows.Forms.TextBox
    Friend WithEvents txtAddressLine1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtLastName As System.Windows.Forms.TextBox
    Friend WithEvents txtMiddleName As System.Windows.Forms.TextBox
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents tmrLabelChange As System.Windows.Forms.Timer
    Friend WithEvents lblSaveInfo As System.Windows.Forms.Label
    Friend WithEvents tabOutboundInfo As System.Windows.Forms.TabPage
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents lblCallbackComments As System.Windows.Forms.Label
    Friend WithEvents lblCallbackLoggedUser As System.Windows.Forms.Label
    Friend WithEvents lblCallBackLoggedTime As System.Windows.Forms.Label
    Friend WithEvents lblCallbackTimeRequested As System.Windows.Forms.Label
    Friend WithEvents lblPreviousDisposition As System.Windows.Forms.Label
    Friend WithEvents lblPreviousCalledCount As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
End Class
