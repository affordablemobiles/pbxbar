Module GlobalVars
    Public vdcClass As New vdc_db_query()
    Public func As New Functions()
    Public manager As New manager_send()

    Public jsVars As New Dictionary(Of String, String)
    Public jsArrays As New Dictionary(Of String, String())
    Public loggedIn As Boolean

    Public username As String
    Public password As String
    Public campaign As String

    Public recording As Boolean = False
    Public holding As Boolean = False
    Public holdingTime As Integer = 0
    Public timeSinceChange As Integer = 0
    Public numInConference As Integer = 0

    Public agentConnectTime As Integer = 0

    Public xferInProgress As Boolean = False
    Public xferWaitingConnect As Boolean = False
    Public xferCallTime As Integer = 0
    Public xferHold As Boolean = False

    Public MD_ring_secondS As Integer = 0
    Public AutoDialWaiting As Boolean = False
    Public AutoDialReady As Boolean = False
    Public PausedSeconds As Integer = 0
    Public VDRP_stage As String = "PAUSED"
    Public waitingForNextStep As Boolean = False
    Public MD_channel_look As Boolean = False
    Public VD_live_customer_call As Boolean = False
    Public VD_live_call_seconds As Integer = 0
    Public alt_dial_status_display As Boolean = False
    Public custchannellive As Boolean = False
    Public MD_call_live As Boolean = False
    Public MD_previewing_lead As Boolean = False

    Public uniqueid As String = String.Empty
    Public lead_id As String = String.Empty
    Public vendor_lead_code As String = String.Empty
    Public list_id As String = String.Empty
    Public lead_previous_dispo As String = String.Empty
    Public lead_previous_called_count As String = String.Empty

    Public phone_number As String = String.Empty
    Public phone_code As String = String.Empty

    Public recordingFilename As String = String.Empty
    Public recordingActualFilename As String = String.Empty
    Public recordingID As String = String.Empty

    Public inOUT As String = String.Empty
    Public sentHangupLog As Boolean = False

    Public blockReady As Boolean = True

    Public urlPop As String = String.Empty

    Public dialNextActive As Boolean = False
End Module
