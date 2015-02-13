Imports System.Array

Public Class CallDisposition
    Private dispoList As Dictionary(Of String, String)
    Private WithEvents callbk As Callback

    Public Event DispoComplete(callDirect As Boolean)
    Public dispoValue As String
    Public dispoCallback As Boolean
    Public dispoCbkDateTime As String
    Public dispoCbkMeOnly As Boolean
    Public dispoCbkComment As String

    Sub New()
        pfc = New System.Drawing.Text.PrivateFontCollection()
        ifc = New System.Drawing.Text.InstalledFontCollection()
        LoadPrivateFonts({My.Resources.Fonts.MSMHEI})

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub CallDisposition_Disposed() Handles Me.Disposed
        pfc.Dispose()
        ifc.Dispose()
    End Sub

    ''' <summary>Loads the private fonts.</summary>
    ''' <param name="fonts">The fonts to be loaded into the private font collection.</param>
    Private Sub LoadPrivateFonts(ByVal fonts As IEnumerable(Of Byte()))
        For Each resFont As Byte() In fonts
            pfc.AddMemoryFont(Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement(resFont, 0), resFont.Length)
        Next
    End Sub

    Public Sub checkNotReadyBox()
        Me.chkNotReady.Checked = True
        Me.chkNotReady.Enabled = False
    End Sub

    Public Sub dispoSet() Handles chkDispoList.ItemCheck
        If chkDispoList.IndexFromPoint(chkDispoList.PointToClient(Cursor.Position).X, chkDispoList.PointToClient(Cursor.Position).Y) <= -1 Then
            Exit Sub
        ElseIf String.IsNullOrEmpty(chkDispoList.SelectedValue) Then
            Exit Sub
        Else
            If chkDispoList.SelectedValue = "CALLBK" Then
                Me.dispoValue = "CBHOLD"
                Me.dispoCallback = True
                If IsNothing(Me.callbk) Then
                    Me.callbk = New Callback()
                ElseIf Me.callbk.Visible = False Then
                    Me.callbk = New Callback()
                End If
                Me.callbk.Show()
                Me.Hide()
            Else
                Me.dispoValue = chkDispoList.SelectedValue
                Me.dispoCallback = False
                RaiseEvent DispoComplete(False)
                Me.Close()
            End If
        End If
    End Sub

    Public Sub callbackComplete() Handles callbk.CallbackComplete
        Me.dispoCbkDateTime = callbk.dateTime
        Me.dispoCbkMeOnly = callbk.meOnly
        Me.dispoCbkComment = callbk.comment

        RaiseEvent DispoComplete(False)
        Me.Close()
    End Sub

    Public Sub callbackFail() Handles callbk.CallbackFail
        Me.dispoValue = chkDispoList.SelectedValue
        Me.dispoCallback = False
        RaiseEvent DispoComplete(False)
        Me.Close()
    End Sub

    Private Sub CallDisposition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.dispoList = GlobalVars.func.getDispoList()

        chkDispoList.DisplayMember = "Value"
        chkDispoList.ValueMember = "Key"
        Me.chkDispoList.DataSource = New BindingSource(Me.dispoList, Nothing)
    End Sub
End Class