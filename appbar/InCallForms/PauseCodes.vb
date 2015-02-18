Imports System.Array

Public Class PauseCodes
    Private pauseCodeList As Dictionary(Of String, String)

    Public Event PauseCodeComplete()
    Public pauseCodeValue As String

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

    Public Sub pauseCodeSet() Handles chkPauseCodeList.ItemCheck
        If chkPauseCodeList.IndexFromPoint(chkPauseCodeList.PointToClient(Cursor.Position).X, chkPauseCodeList.PointToClient(Cursor.Position).Y) <= -1 Then
            Exit Sub
        ElseIf String.IsNullOrEmpty(chkPauseCodeList.SelectedValue) Then
            Exit Sub
        Else
            Me.pauseCodeValue = chkPauseCodeList.SelectedValue
            RaiseEvent PauseCodeComplete()
            Me.Close()
        End If
    End Sub

    Public Sub AutoComplete(reason As String)
        Me.pauseCodeValue = reason

        RaiseEvent PauseCodeComplete()
    End Sub

    Private Sub PauseCodes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.pauseCodeList = GlobalVars.func.getPauseCodeList()

        chkPauseCodeList.DisplayMember = "Value"
        chkPauseCodeList.ValueMember = "Key"
        Me.chkPauseCodeList.DataSource = New BindingSource(Me.pauseCodeList, Nothing)
    End Sub
End Class