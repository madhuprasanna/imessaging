<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="index.aspx.vb" Inherits="iMessagePage.index"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>iMessaging</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:hyperlink id="hlRegistration" style="Z-INDEX: 108; LEFT: 14px; POSITION: absolute; TOP: 124px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="webfrmRegister.aspx" Width="125px">Registration Page</asp:hyperlink>
			<asp:Label id="Label5" style="Z-INDEX: 113; LEFT: 31px; POSITION: absolute; TOP: 320px" runat="server" Width="645px" Font-Names="Verdana" Font-Size="Smaller" Height="29px" ForeColor="Black" Font-Italic="True">Automatic gateway configuration allows you to use this service even if you don't have Internet connection on your system</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 112; LEFT: 31px; POSITION: absolute; TOP: 274px" runat="server" Width="653px" Font-Names="Verdana" Font-Size="Smaller" Height="29px" ForeColor="Black" Font-Italic="True">Messsage Archiving - This software can be used to send official mail within the organisation that spreads over this world</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 111; LEFT: 31px; POSITION: absolute; TOP: 241px" runat="server" Width="612px" Font-Names="Verdana" Font-Size="Smaller" Height="12px" ForeColor="Black" Font-Italic="True">Group Messaging Service - Form groups and send messages to groups as a whole</asp:Label>
			<asp:hyperlink id="hlDownload" style="Z-INDEX: 107; LEFT: 589px; POSITION: absolute; TOP: 122px" runat="server" Font-Size="Smaller" Font-Names="Verdana" NavigateUrl="webfrmDownload.aspx">Download Client</asp:hyperlink>
			<asp:Label id="Label2" style="Z-INDEX: 105; LEFT: 11px; POSITION: absolute; TOP: 415px" runat="server" Width="109px" Font-Names="Verdana" Font-Size="XX-Small">(c) Creativity Labs </asp:Label>
			<asp:Label id="lblMsg2" style="Z-INDEX: 103; LEFT: 14px; POSITION: absolute; TOP: 362px" runat="server" Width="683px" Font-Names="Verdana" Font-Size="Smaller">To use this service you have to register for an iMessaging UserId. To utilize this service you need the iMessaging Client. The links for registration and downloading client are given above. </asp:Label>
			<asp:Image id="Image1" style="Z-INDEX: 100; LEFT: 13px; POSITION: absolute; TOP: 11px" runat="server" Width="95.96%" Height="84px" BorderStyle="None" ImageUrl="http://localhost/iMessagePage/Title.jpg"></asp:Image>
			<HR style="Z-INDEX: 101; LEFT: 12px; WIDTH: 95.96%; POSITION: absolute; TOP: 103px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<asp:Label id="lblMsg1" style="Z-INDEX: 102; LEFT: 13px; POSITION: absolute; TOP: 169px" runat="server" Width="683" Height="24px" Font-Names="Verdana" Font-Size="Smaller">iMessaging  is a software for sending and receiving instant messages. The software has a  lot of specialized features that are not available in other Instant Messengers. </asp:Label>
			<HR style="Z-INDEX: 104; LEFT: 13px; WIDTH: 95.96%; POSITION: absolute; TOP: 410px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<HR style="Z-INDEX: 106; LEFT: 13px; WIDTH: 95.96%; POSITION: absolute; TOP: 158px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<asp:Label id="Label1" style="Z-INDEX: 110; LEFT: 31px; POSITION: absolute; TOP: 212px" runat="server" Width="467px" Font-Names="Verdana" Font-Size="Smaller" Height="17px" ForeColor="Black" Font-Italic="True">Timed Messaging Service - Messages that knocks at specified time.</asp:Label>
		</form>
	</body>
</HTML>
