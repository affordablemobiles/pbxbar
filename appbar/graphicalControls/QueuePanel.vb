Public Class QueuePanel : Inherits Panel
    Public value As Integer = 0

    Public Sub New()
        Me.DoubleBuffered = True
    End Sub

    ' Override the Panel's paint method, draw the clock and then call the base paint event
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        e.Graphics.Clear(Me.BackColor)

        Dim strValue As String

        Dim paintColor As Color

        If value < 1 Then
            paintColor = Color.Green
        ElseIf value < 5 Then
            paintColor = Color.Orange
        ElseIf value < 15 Then
            paintColor = Color.OrangeRed
        Else
            paintColor = Color.Red
        End If

        Dim font1 As Font

        If value < 100 Then
            font1 = New Font("Arial", Me.Height / 1.6, FontStyle.Bold, GraphicsUnit.Pixel)
            strValue = value.ToString()
        Else
            font1 = New Font("Arial", Me.Height / 2, FontStyle.Bold, GraphicsUnit.Pixel)
            strValue = "AH"
        End If


        Dim aPen As New Pen(paintColor)
        Dim aBrush As New SolidBrush(paintColor)
        Dim rect As New Rectangle(1, 1, Me.Width - 2, Me.Height - 2)
        Dim stringFormat As New StringFormat()

        aPen.Width = 1.0F

        e.Graphics.DrawEllipse(aPen, rect)
        e.Graphics.FillEllipse(aBrush, rect)

        stringFormat.Alignment = StringAlignment.Center
        stringFormat.LineAlignment = StringAlignment.Center

        e.Graphics.DrawString(strValue, font1, Brushes.White, rect, stringFormat)

        font1.Dispose()
        aPen.Dispose()
        aBrush.Dispose()
        stringFormat.Dispose()

        MyBase.OnPaint(e)
    End Sub
End Class