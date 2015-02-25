Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class Keypad
    Public Event keypadButtonPress(ByVal key As String)

    Private Sub btnKeypad1_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad1.ClickButtonArea
        RaiseEvent keypadButtonPress("1")
    End Sub

    Private Sub btnKeypad2_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad2.ClickButtonArea
        RaiseEvent keypadButtonPress("2")
    End Sub

    Private Sub btnKeypad3_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad3.ClickButtonArea
        RaiseEvent keypadButtonPress("3")
    End Sub

    Private Sub btnKeypad4_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad4.ClickButtonArea
        RaiseEvent keypadButtonPress("4")
    End Sub

    Private Sub btnKeypad5_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad5.ClickButtonArea
        RaiseEvent keypadButtonPress("5")
    End Sub

    Private Sub btnKeypad6_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad6.ClickButtonArea
        RaiseEvent keypadButtonPress("6")
    End Sub

    Private Sub btnKeypad7_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad7.ClickButtonArea
        RaiseEvent keypadButtonPress("7")
    End Sub

    Private Sub btnKeypad8_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad8.ClickButtonArea
        RaiseEvent keypadButtonPress("8")
    End Sub

    Private Sub btnKeypad9_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad9.ClickButtonArea
        RaiseEvent keypadButtonPress("9")
    End Sub

    Private Sub btnKeypadStar_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypadStar.ClickButtonArea
        RaiseEvent keypadButtonPress("*")
    End Sub

    Private Sub btnKeypad0_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypad0.ClickButtonArea
        RaiseEvent keypadButtonPress("0")
    End Sub

    Private Sub btnKeypadHash_ClickButtonArea(Sender As Object, e As MouseEventArgs) Handles btnKeypadHash.ClickButtonArea
        RaiseEvent keypadButtonPress("#")
    End Sub
End Class