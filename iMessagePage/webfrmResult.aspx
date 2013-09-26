<%@ Page Language="vb" AutoEventWireup="false" Codebehind="webfrmResult.aspx.vb" Inherits="iMessagePage.webfrmResult"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>webfrmResult</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:image id="imgHeading" style="Z-INDEX: 100; LEFT: 11px; POSITION: absolute; TOP: 8px" runat="server" BorderStyle="None" ImageUrl="http://localhost/iMessagePage/Title.jpg" Width="95.96%" Height="84px" ForeColor="White"></asp:image>
			<asp:hyperlink id="hlRegistration" style="Z-INDEX: 107; LEFT: 10px; POSITION: absolute; TOP: 268px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="webfrmRegister.aspx">Back to registration page</asp:hyperlink>
			<asp:Label id="lblResult" style="Z-INDEX: 106; LEFT: 11px; POSITION: absolute; TOP: 168px" runat="server" Width="676px" Height="95px" Font-Size="Smaller" Font-Names="Verdana"></asp:Label>
			<asp:hyperlink id="hlHome" style="Z-INDEX: 101; LEFT: 8px; POSITION: absolute; TOP: 121px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="index.aspx">Home Page</asp:hyperlink>
			<asp:hyperlink id="hlDownload" style="Z-INDEX: 103; LEFT: 581px; POSITION: absolute; TOP: 122px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="webfrmDownload.aspx">Download Client</asp:hyperlink>
			<HR style="Z-INDEX: 104; LEFT: 8px; WIDTH: 95.96%; POSITION: absolute; TOP: 155px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<HR style="Z-INDEX: 105; LEFT: 8px; WIDTH: 95.96%; POSITION: absolute; TOP: 100px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<HR style="Z-INDEX: 130; LEFT: 8px; WIDTH: 96.71%; POSITION: absolute; TOP: 408px; HEIGHT: 2px" width="96.71%" noShade SIZE="2">
			<asp:label id="lblCopyright" style="Z-INDEX: 131; LEFT: 9px; POSITION: absolute; TOP: 416px" runat="server" Width="109px" Font-Size="XX-Small" Font-Names="Verdana">(c) Creativity Labs </asp:label>
		</form>
	</body>
</HTML>
