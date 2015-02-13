Public Class AdminAuth
    Public Event ValidAuth()
    Private password As String

    Public Sub New(password As String)
        Me.password = password

        Me.InitializeComponent()
    End Sub

    Private Sub AdminAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AcceptButton = btnLogin
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        If txtPassword.Text = Me.password Then
            RaiseEvent ValidAuth()
            Me.Close()
        Else
            MessageBox.Show("Invalid Login", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class