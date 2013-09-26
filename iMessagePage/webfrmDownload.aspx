<%@ Page Language="vb" AutoEventWireup="false" Codebehind="webfrmDownload.aspx.vb" Inherits="iMessagePage.webfrmDownload"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>iMessage client download</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:Image id="Image1" style="Z-INDEX: 100; LEFT: 13px; POSITION: absolute; TOP: 12px" runat="server" ImageUrl="http://localhost/iMessagePage/Title.jpg" BorderStyle="None" Height="84px" Width="95.96%"></asp:Image>
			<asp:hyperlink id="hlRegistration" style="Z-INDEX: 112; LEFT: 571px; POSITION: absolute; TOP: 122px" runat="server" Width="116px" NavigateUrl="webfrmRegister.aspx" Font-Names="Verdana" Font-Size="Smaller"> Registration Page</asp:hyperlink>
			<asp:hyperlink id="hlStartingPage" style="Z-INDEX: 111; LEFT: 11px; POSITION: absolute; TOP: 122px" runat="server" NavigateUrl="index.aspx" Font-Names="Verdana" Font-Size="Smaller">Home Page</asp:hyperlink>
			<asp:HyperLink id="hlDownloadBig" style="Z-INDEX: 109; LEFT: 13px; POSITION: absolute; TOP: 288px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="http://localhost/iMessagePage/Client and Framework.zip">Download client and .Net framework setup.</asp:HyperLink>
			<asp:HyperLink id="hlDownloadSmall" style="Z-INDEX: 107; LEFT: 12px; POSITION: absolute; TOP: 203px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="http://localhost/iMessagePage/Client.zip">Download client program setup.</asp:HyperLink>
			<asp:Label id="lblMsg2" style="Z-INDEX: 106; LEFT: 12px; POSITION: absolute; TOP: 246px" runat="server" Height="24px" Width="683" Font-Size="Smaller" Font-Names="Verdana">If .Net platform is not available then download file from this link. A Zip file will be downloaded  which contains both client and .Net framework setup programs.</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 104; LEFT: 14px; POSITION: absolute; TOP: 415px" runat="server" Width="109px" Font-Size="XX-Small" Font-Names="Verdana">(c) Creativity Labs </asp:Label>
			<HR style="Z-INDEX: 101; LEFT: 12px; WIDTH: 95.96%; POSITION: absolute; TOP: 104px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<asp:Label id="lblMsg1" style="Z-INDEX: 102; LEFT: 12px; POSITION: absolute; TOP: 164px" runat="server" Height="24px" Width="683" Font-Size="Smaller" Font-Names="Verdana">If .Net platform is available in your system then download file from this link. A Zip file will be downloaded  which contains the client setup program.</asp:Label>
			<HR style="Z-INDEX: 103; LEFT: 13px; WIDTH: 95.96%; POSITION: absolute; TOP: 409px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<HR style="Z-INDEX: 108; LEFT: 11px; WIDTH: 95.96%; POSITION: absolute; TOP: 230px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<HR style="Z-INDEX: 110; LEFT: 11px; WIDTH: 95.96%; POSITION: absolute; TOP: 154px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
		</form>
	</body>
</HTML>
