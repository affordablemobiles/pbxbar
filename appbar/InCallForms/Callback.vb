Public Class Callback
    Public Event CallbackComplete()
    Public Event CallbackFail()

    Public dateTime As String
    Public meOnly As Boolean
    Public comment As String

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.comment = txtComments.Text
        Me.meOnly = chkMeOnly.Checked
        Me.dateTime = dpckCallbackDate.Value.ToString("yyyy-MM-dd") & " " & dpckCallbackTime.Value.ToString("HH:mm") & ":00"

        RaiseEvent CallbackComplete()
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent CallbackFail()
        Me.Close()
    End Sub
End Class