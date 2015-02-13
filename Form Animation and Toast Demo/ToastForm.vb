Imports System.Runtime.InteropServices

Public Class ToastForm

#Region " Variables "

    ''' <summary>
    ''' The list of currently open ToastForms.
    ''' </summary>
    Private Shared openForms As New List(Of ToastForm)

    ''' <summary>
    ''' Indicates whether the form can receive focus or not.
    ''' </summary>
    Private allowFocus As Boolean = False
    ''' <summary>
    ''' The object that creates the sliding animation.
    ''' </summary>
    Private animator As FormAnimator
    ''' <summary>
    ''' The handle of the window that currently has focus.
    ''' </summary>
    Private currentForegroundWindow As IntPtr

#End Region 'Variables

#Region " APIs "

    ''' <summary>
    ''' Gets the handle of the window that currently has focus.
    ''' </summary>
    ''' <returns>
    ''' The handle of the window that currently has focus.
    ''' </returns>
    <DllImport("user32")> _
    Private Shared Function GetForegroundWindow() As IntPtr
    End Function

    ''' <summary>
    ''' Activates the specified window.
    ''' </summary>
    ''' <param name="hWnd">
    ''' The handle of the window to be focused.
    ''' </param>
    ''' <returns>
    ''' True if the window was focused; False otherwise.
    ''' </returns>
    <DllImport("user32")> _
    Private Shared Function SetForegroundWindow(ByVal hWnd As IntPtr) As Boolean
    End Function

#End Region 'APIs

#Region " Constructors "

    ''' <summary>
    ''' Creates a new ToastForm object that is displayed for the specified length of time.
    ''' </summary>
    ''' <param name="lifeTime">
    ''' The length of time, in milliseconds, that the form will be displayed.
    ''' </param>
    Public Sub New(ByVal lifeTime As Integer, ByVal message As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'Set the time for which the form should be displayed and the message to display.
        Me.lifeTimer.Interval = lifeTime
        Me.messageLabel.Text = message

        'Display the form by sliding up.
        Me.animator = New FormAnimator(Me, _
                                       FormAnimator.AnimationMethod.Slide, _
                                       FormAnimator.AnimationDirection.Up, _
                                       500)
    End Sub

#End Region 'Constructors

#Region " Methods "

    ''' <summary>
    ''' Displays the form.
    ''' </summary>
    ''' <remarks>
    ''' Required to allow the form to determine the current foreground window     before being displayed.
    ''' </remarks>
    Public Shadows Sub Show()
        'Determine the current foreground window so it can be reactivated each time this form tries to get the focus.
        Me.currentForegroundWindow = GetForegroundWindow()

        'Display the form.
        MyBase.Show()
    End Sub

#End Region 'Methods

#Region " Event Handlers "

    Private Sub ToastForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Display the form just above the system tray.
        Me.Location = New Point(Screen.PrimaryScreen.WorkingArea.Width - Me.Width - 5, _
                                (Screen.PrimaryScreen.WorkingArea.Height + 50) - Me.Height - 5)

        'Move each open form upwards to make room for this one.
        For Each openForm As ToastForm In ToastForm.openForms
            openForm.Top -= Me.Height + 5
        Next

        'Add this form from the open form list.
        ToastForm.openForms.Add(Me)

        'Start counting down the form's liftime.
        Me.lifeTimer.Start()
    End Sub

    Private Sub ToastForm_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        'Prevent the form taking focus when it is initially shown.
        If Not Me.allowFocus Then
            'Activate the window that previously had the focus.
            SetForegroundWindow(Me.currentForegroundWindow)
        End If
    End Sub

    Private Sub ToastForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'Once the animation has completed the form can receive focus.
        Me.allowFocus = True

        'Close the form by sliding down.
        Me.animator.Direction = FormAnimator.AnimationDirection.Down
    End Sub

    Private Sub ToastForm_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
        'Move down any open forms above this one.
        For Each openForm As ToastForm In ToastForm.openForms
            If openForm Is Me Then
                'The remaining forms are below this one.
                Exit For
            End If

            openForm.Top += Me.Height + 5
        Next

        'Remove this form from the open form list.
        ToastForm.openForms.Remove(Me)
    End Sub

    Private Sub lifeTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles lifeTimer.Tick
        'The form's lifetime has expired.
        Me.Close()
    End Sub

#End Region 'Event Handlers

End Class