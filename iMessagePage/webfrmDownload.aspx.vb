Public Class webfrmDownload
    Inherits System.Web.UI.Page
    Protected WithEvents lblMsg1 As System.Web.UI.WebControls.Label
    Protected WithEvents Label2 As System.Web.UI.WebControls.Label
    Protected WithEvents lblMsg2 As System.Web.UI.WebControls.Label
    Protected WithEvents hlDownloadSmall As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlDownloadBig As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlRegistration As System.Web.UI.WebControls.HyperLink
    Protected WithEvents hlStartingPage As System.Web.UI.WebControls.HyperLink
    Protected WithEvents Image1 As System.Web.UI.WebControls.Image

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub

#End Region

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Put user code to initialize the page here
    End Sub

End Class
