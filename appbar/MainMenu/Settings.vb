Public Class Settings
    Public WithEvents authBox As AdminAuth

    Public Sub ShowWithAuth()
        If IsNothing(Me.authBox) Then
            Me.authBox = New AdminAuth("password")
        ElseIf Not Me.authBox.Visible Then
            Me.authBox = New AdminAuth("password")
        End If
        Me.authBox.Show()
    End Sub

    Public Sub showAfterAuth() Handles authBox.ValidAuth
        Me.Show()
    End Sub

    Private Sub Settings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnSave

        txtAgentURL.Text = My.Settings.agentURL
        txtMappingURL.Text = My.Settings.mappingURL

        If My.Settings.isChrome = True Then
            rbtnChromeYes.Checked = True
        Else
            rbtnChromeNo.Checked = True
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        My.Settings.agentURL = txtAgentURL.Text
        My.Settings.mappingURL = txtMappingURL.Text

        If rbtnChromeYes.Checked = True Then
            My.Settings.isChrome = True
        Else
            My.Settings.isChrome = False
        End If

        My.Settings.Save()
        Me.Close()
    End Sub
End Class