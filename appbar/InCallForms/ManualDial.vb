Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class ManualDial
    Public numberToDial As String
    Public dialPrefix As String

    Public Event makeCall()

    Private Sub ManualDial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim values As New Dictionary(Of String, String)
        values("ext") = "External"
        values("int") = "Internal"

        cmbDialType.DisplayMember = "Value"
        cmbDialType.ValueMember = "Key"
        cmbDialType.DataSource = New BindingSource(values, Nothing)

        Me.AcceptButton = btnCall
    End Sub

    Private Sub txtDialNumber_TextChanged(sender As Object, e As EventArgs) Handles txtDialNumber.TextChanged
        If Regex.IsMatch(txtDialNumber.Text, "[^0-9]") Then
            txtDialNumber.Text = Regex.Replace(txtDialNumber.Text, "[^0-9]", "")
            MessageBox.Show("Only Numbers Allowed Here!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If

        Me.validateNumber()
    End Sub

    Private Sub validateNumber()
        If cmbDialType.SelectedValue = "ext" Then
            If GlobalVars.func.validNumber(txtDialNumber.Text, False) Then
                btnCall.Enabled = True
            Else
                btnCall.Enabled = False
            End If
        Else
            If GlobalVars.func.validNumber(txtDialNumber.Text, True) Then
                btnCall.Enabled = True
            Else
                btnCall.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnCall_Click(sender As Object, e As EventArgs) Handles btnCall.Click
        If cmbDialType.SelectedValue = "ext" Then
            '' Add Dial Prefix Here.
            Me.dialPrefix = If(GlobalVars.jsVars.ContainsKey("dial_prefix"), GlobalVars.jsVars("dial_prefix"), String.Empty)
            Me.numberToDial = txtDialNumber.Text
            ''MessageBox.Show("External Dial")
        Else
            '' Number as-is.
            Me.numberToDial = txtDialNumber.Text
            ''MessageBox.Show("Internal Dial")
        End If

        RaiseEvent makeCall()
        Me.Close()
    End Sub

    Private Sub cmbDialType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDialType.SelectedIndexChanged
        Me.validateNumber()
    End Sub
End Class