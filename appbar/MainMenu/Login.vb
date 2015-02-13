Public Class Login
    Public Event loggedIn()

    Public campaigns As Dictionary(Of String, String)

    Public Sub DoCampaignGrab() Handles txtPassword.LostFocus
        GlobalVars.vdcClass.setUserPass(txtUsername.Text, txtPassword.Text)
        Me.campaigns = GlobalVars.vdcClass.LoginCampaigns()

        cmbCampaign.DisplayMember = "Value"
        cmbCampaign.ValueMember = "Key"
        cmbCampaign.DataSource = New BindingSource(Me.campaigns, Nothing)
    End Sub

    Public Sub DoCampaignChange() Handles cmbCampaign.SelectedValueChanged
        If Not cmbCampaign.SelectedValue = String.Empty And Not cmbCampaign.SelectedValue = "invalid" Then
            btnLogin.Enabled = True
        Else
            btnLogin.Enabled = False
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        GlobalVars.username = txtUsername.Text
        GlobalVars.password = txtPassword.Text
        GlobalVars.campaign = cmbCampaign.SelectedValue

        Dim worker As New LogonOff
        If worker.Login(GlobalVars.username, GlobalVars.password, GlobalVars.campaign) = True Then
            Me.Hide()
            GlobalVars.loggedIn = True
            GlobalVars.vdcClass.registerQueues()
            RaiseEvent loggedIn()
            Me.Close()
        Else
            MessageBox.Show("Login Failed - Sad face :(")
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnLogin

        lblSeperator.Width = Me.Width
        lblSeperator.Location = New Point(0, lblSeperator.Location.Y)
    End Sub
End Class