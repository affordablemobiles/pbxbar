Imports System
Imports System.IO
Imports System.Net
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic

Public Class LeadInfoScript
    Private browser As CefSharp.WinForms.WebView

    Private strTitle As String
    Private strFirstName As String
    Private strMiddleName As String
    Private strLastName As String

    Private strAddressLine1 As String
    Private strTownCity As String
    Private strCounty As String
    Private strPostCode As String

    Private strPhoneNo As String
    Private strAltPhoneNo As String
    Private strEmail As String

    Private strComments As String

    Private Sub LeadInfoScript_Load(sender As Object, e As EventArgs) Handles Me.Load
        If CefSharp.CEF.IsInitialized Then
            Me.browser = New CefSharp.WinForms.WebView("http://pbx.secure.a1comms.net/limesurvey/", New CefSharp.BrowserSettings())
            Me.browser.Dock = DockStyle.Fill
            tabCallScript.Controls.Add(Me.browser)
        End If
    End Sub

    Private Sub onShow() Handles Me.Shown
        Me.initialSave()
    End Sub

    Private Sub closeMe() Handles Me.FormClosing
        Me.btnSave_Click()

        Me.browser.Dispose()
        Me.browser = Nothing
    End Sub

    Public Sub btnSave_Click() Handles btnSave.Click
        GlobalVars.vdcClass.updateLead(txtTitle.Text, txtFirstName.Text, txtMiddleName.Text, txtLastName.Text, _
                                       txtAddressLine1.Text, txtTownCity.Text, txtCounty.Text, txtPostCode.Text, _
                                       txtPhoneNo.Text, txtAltPhoneNo.Text, txtEmail.Text, txtComments.Text)

        Me.initialSave()

        If Me.tmrLabelChange.Enabled = True Then
            Me.tmrLabelChange.Stop()
        End If

        Me.lblSaveInfo.Text = "Lead Info Saved Successfully!"

        Me.tmrLabelChange.Start()
    End Sub

    Private Sub initialSave()
        Me.strTitle = txtTitle.Text
        Me.strFirstName = txtFirstName.Text
        Me.strMiddleName = txtMiddleName.Text
        Me.strLastName = txtLastName.Text

        Me.strAddressLine1 = txtAddressLine1.Text
        Me.strTownCity = txtTownCity.Text
        Me.strCounty = txtCounty.Text
        Me.strPostCode = txtPostCode.Text

        Me.strPhoneNo = txtPhoneNo.Text
        Me.strAltPhoneNo = txtAltPhoneNo.Text
        Me.strEmail = txtEmail.Text

        Me.strComments = txtComments.Text
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        txtTitle.Text = Me.strTitle
        txtFirstName.Text = Me.strFirstName
        txtMiddleName.Text = Me.strMiddleName
        txtLastName.Text = Me.strLastName

        txtAddressLine1.Text = Me.strAddressLine1
        txtTownCity.Text = Me.strTownCity
        txtCounty.Text = Me.strCounty
        txtPostCode.Text = Me.strPostCode

        txtPhoneNo.Text = Me.strPhoneNo
        txtAltPhoneNo.Text = Me.strAltPhoneNo
        txtEmail.Text = Me.strEmail

        txtComments.Text = Me.strComments
    End Sub

    Private Sub tmrLabelChange_Tick(sender As Object, e As EventArgs) Handles tmrLabelChange.Tick
        lblSaveInfo.Text = String.Empty

        Me.tmrLabelChange.Stop()
    End Sub

    Private Sub txtPhoneNo_TextChanged(sender As Object, e As EventArgs) Handles txtPhoneNo.TextChanged
        If Regex.IsMatch(txtPhoneNo.Text, "[^0-9]") Then
            txtPhoneNo.Text = Regex.Replace(txtPhoneNo.Text, "[^0-9]", "")
            MessageBox.Show("Only Numbers Allowed Here!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub txtAltPhoneNo_TextChanged(sender As Object, e As EventArgs) Handles txtAltPhoneNo.TextChanged
        If Regex.IsMatch(txtAltPhoneNo.Text, "[^0-9]") Then
            txtAltPhoneNo.Text = Regex.Replace(txtAltPhoneNo.Text, "[^0-9]", "")
            MessageBox.Show("Only Numbers Allowed Here!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub
End Class