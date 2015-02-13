Public Class Form1

    Private rng As New Random

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Static sliceCount As Integer = 0

        sliceCount += 1

        Dim slice As New ToastForm(Me.rng.Next(2000, 10000), "Slice " & sliceCount)

        slice.Height = Me.rng.Next(50, 200)
        slice.Show()
    End Sub

End Class
