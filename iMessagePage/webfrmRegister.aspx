<%@ Register TagPrefix="cr" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=9.1.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>
<%@ Page Language="vb" AutoEventWireup="false" Codebehind="webfrmRegister.aspx.vb" Inherits="iMessagePage.webfrmRegister" EnableViewState = false %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>Register for iMessaging Service</title>
		<META content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<META content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<META content="JavaScript" name="vs_defaultClientScript">
		<META content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<BODY bgColor="#ffffff" MS_POSITIONING="GridLayout">
		<FORM id="Form1" method="post" runat="server">
			<HR style="Z-INDEX: 101; LEFT: 9px; WIDTH: 95.96%; POSITION: absolute; TOP: 103px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
			<asp:hyperlink id="hlDownload" style="Z-INDEX: 145; LEFT: 582px; POSITION: absolute; TOP: 125px" runat="server" NavigateUrl="webfrmDownload.aspx" Font-Names="Verdana" Font-Size="Smaller">Download Client</asp:hyperlink><asp:hyperlink id="hlHome" style="Z-INDEX: 143; LEFT: 9px; POSITION: absolute; TOP: 124px" runat="server" NavigateUrl="index.aspx" Font-Names="Verdana" Font-Size="Smaller">Home Page</asp:hyperlink><asp:label id="lblValidateeMail" style="Z-INDEX: 142; LEFT: 539px; POSITION: absolute; TOP: 501px" runat="server" Font-Names="Verdana" Font-Size="X-Small" Visible="False" ForeColor="Red" Height="18px" Width="110px">Should have '@'  in e-MailId</asp:label><asp:label id="lblValidateRetypePassword" style="Z-INDEX: 141; LEFT: 537px; POSITION: absolute; TOP: 373px" runat="server" Font-Names="Verdana" Font-Size="X-Small" Visible="False" ForeColor="Red" Height="18px" Width="110px">Password doesnot match</asp:label><asp:label id="lblValidatePassword" style="Z-INDEX: 140; LEFT: 537px; POSITION: absolute; TOP: 334px" runat="server" Font-Names="Verdana" Font-Size="X-Small" Visible="False" ForeColor="Red" Height="18px" Width="149px">Password should have six characters</asp:label><asp:label id="lblValidateDate" style="Z-INDEX: 139; LEFT: 229px; POSITION: absolute; TOP: 477px" runat="server" Font-Names="Verdana" Font-Size="X-Small" Visible="False" ForeColor="Red" Height="18px" Width="110px">Invalid Date</asp:label><asp:requiredfieldvalidator id="valEmailId" style="Z-INDEX: 138; LEFT: 227px; POSITION: absolute; TOP: 510px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ControlToValidate="txtEmail" ErrorMessage="e-Mail Id required"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="valSchoolName" style="Z-INDEX: 137; LEFT: 538px; POSITION: absolute; TOP: 432px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="146px" ControlToValidate="txtFirstSchool" ErrorMessage="School name required"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="valReTypePassword" style="Z-INDEX: 136; LEFT: 227px; POSITION: absolute; TOP: 380px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ControlToValidate="txtReTypePassword" ErrorMessage="Retype Password "></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="valPassword" style="Z-INDEX: 135; LEFT: 227px; POSITION: absolute; TOP: 338px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ControlToValidate="txtPassword" ErrorMessage="Password required"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="valUserId" style="Z-INDEX: 134; LEFT: 227px; POSITION: absolute; TOP: 297px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ControlToValidate="txtUserId" ErrorMessage="UserId required"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="valLastName" style="Z-INDEX: 133; LEFT: 227px; POSITION: absolute; TOP: 255px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ControlToValidate="txtLastName" ErrorMessage="Last Name required"></asp:requiredfieldvalidator><asp:requiredfieldvalidator id="valFirstName" style="Z-INDEX: 131; LEFT: 227px; POSITION: absolute; TOP: 219px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ControlToValidate="txtFirstName" ErrorMessage="First Name required"></asp:requiredfieldvalidator><asp:image id="imgHeading" style="Z-INDEX: 130; LEFT: 12px; POSITION: absolute; TOP: 11px" runat="server" ForeColor="White" Height="84px" Width="95.96%" ImageUrl="http://localhost/iMessagePage/Title.jpg" BorderStyle="None"></asp:image><asp:label id="lblCopyright" style="Z-INDEX: 129; LEFT: 10px; POSITION: absolute; TOP: 704px" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Width="109px">(c) Creativity Labs </asp:label><asp:label id="lblMonthDDYYYY" style="Z-INDEX: 127; LEFT: 531px; POSITION: absolute; TOP: 472px" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Height="19px" Width="81px" Font-Italic="True">(Month,DD,YYYY)</asp:label><asp:label id="lblSixChar" style="Z-INDEX: 126; LEFT: 444px; POSITION: absolute; TOP: 363px" runat="server" Font-Names="Verdana" Font-Size="XX-Small" Height="13px" Width="81px" Font-Italic="True">(Min Six Chars)</asp:label><asp:textbox id="txtYear" style="Z-INDEX: 124; LEFT: 487px; POSITION: absolute; TOP: 470px" tabIndex="9" runat="server" Font-Names="Verdana" Font-Size="Smaller" Height="20px" Width="42px" EnableViewState="False"></asp:textbox><asp:dropdownlist id="ddlMonth" style="Z-INDEX: 122; LEFT: 372px; POSITION: absolute; TOP: 470px" tabIndex="7" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="78px" EnableViewState="False">
				<asp:ListItem Value="1" Selected="True">January</asp:ListItem>
				<asp:ListItem Value="2">Febraury</asp:ListItem>
				<asp:ListItem Value="3">March</asp:ListItem>
				<asp:ListItem Value="4">April</asp:ListItem>
				<asp:ListItem Value="5">May</asp:ListItem>
				<asp:ListItem Value="6">June</asp:ListItem>
				<asp:ListItem Value="7">July</asp:ListItem>
				<asp:ListItem Value="8">August</asp:ListItem>
				<asp:ListItem Value="9">September</asp:ListItem>
				<asp:ListItem Value="10">October</asp:ListItem>
				<asp:ListItem Value="11">November</asp:ListItem>
				<asp:ListItem Value="12">December</asp:ListItem>
			</asp:dropdownlist><asp:textbox id="txtFirstName" style="Z-INDEX: 121; LEFT: 372px; POSITION: absolute; TOP: 218px" tabIndex="1" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False"></asp:textbox><asp:textbox id="txtLastName" style="Z-INDEX: 120; LEFT: 372px; POSITION: absolute; TOP: 253px" tabIndex="2" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False"></asp:textbox><asp:textbox id="txtUserId" style="Z-INDEX: 119; LEFT: 372px; POSITION: absolute; TOP: 294px" tabIndex="3" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False"></asp:textbox><asp:textbox id="txtPassword" style="Z-INDEX: 118; LEFT: 372px; POSITION: absolute; TOP: 337px" tabIndex="4" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False" TextMode="Password"></asp:textbox><asp:textbox id="txtReTypePassword" style="Z-INDEX: 117; LEFT: 372px; POSITION: absolute; TOP: 377px" tabIndex="5" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False" TextMode="Password"></asp:textbox><asp:textbox id="txtEmail" style="Z-INDEX: 116; LEFT: 372px; POSITION: absolute; TOP: 507px" tabIndex="10" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False"></asp:textbox><asp:textbox id="txtFirstSchool" style="Z-INDEX: 115; LEFT: 372px; POSITION: absolute; TOP: 428px" tabIndex="6" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="156" EnableViewState="False"></asp:textbox><asp:label id="lblMsg2" style="Z-INDEX: 114; LEFT: 9px; POSITION: absolute; TOP: 560px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="682px">All the information are mandatory. Once you filled the form click the Submit button.  After succcessful registration you can download the iMessaging client software.</asp:label><asp:label id="lbleMail" style="Z-INDEX: 112; LEFT: 59px; POSITION: absolute; TOP: 515px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="93px">e-Mail</asp:label><asp:label id="lblDOB" style="Z-INDEX: 111; LEFT: 59px; POSITION: absolute; TOP: 476px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="93px">Date of Birth</asp:label><asp:label id="lblSecurityQuestion" style="Z-INDEX: 108; LEFT: 59px; POSITION: absolute; TOP: 436px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="279px">What was the name of your first school?</asp:label><asp:label id="lblReTypePassword" style="Z-INDEX: 107; LEFT: 59px; POSITION: absolute; TOP: 385px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="127px">Re-Type Password</asp:label><asp:label id="lblPassword" style="Z-INDEX: 106; LEFT: 59px; POSITION: absolute; TOP: 345px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="127px">Password</asp:label><asp:label id="lblUserId" style="Z-INDEX: 105; LEFT: 59px; POSITION: absolute; TOP: 302px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="127px">iMessaging UserId</asp:label><asp:label id="lblLastName" style="Z-INDEX: 104; LEFT: 59px; POSITION: absolute; TOP: 261px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="83px">Last Name</asp:label><asp:label id="lblFirstName" style="Z-INDEX: 103; LEFT: 59px; POSITION: absolute; TOP: 226px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Width="83px">First Name</asp:label><asp:label id="lblMsg1" style="Z-INDEX: 102; LEFT: 9px; POSITION: absolute; TOP: 166px" runat="server" Font-Names="Verdana" Font-Size="Smaller" Height="24px" Width="682px"> Register with iMessaging service and  download client software. Registering requires you to fill up the following form. </asp:label>
			<HR style="Z-INDEX: 109; LEFT: 9px; WIDTH: 96.71%; POSITION: absolute; TOP: 696px; HEIGHT: 2px" width="96.71%" noShade SIZE="2">
			<HR style="Z-INDEX: 110; LEFT: 9px; WIDTH: 96.47%; POSITION: absolute; TOP: 415px; HEIGHT: 2px" width="96.47%" noShade SIZE="2">
			<HR style="Z-INDEX: 113; LEFT: 9px; WIDTH: 96.46%; POSITION: absolute; TOP: 545px; HEIGHT: 2px" width="96.46%" noShade SIZE="2">
			<asp:textbox id="txtDate" style="Z-INDEX: 123; LEFT: 454px; POSITION: absolute; TOP: 470px" tabIndex="8" runat="server" Font-Names="Verdana" Font-Size="Smaller" Height="20px" Width="25px" EnableViewState="False"></asp:textbox><asp:label id="lblChangeUserId" style="Z-INDEX: 125; LEFT: 533px; POSITION: absolute; TOP: 297px" runat="server" Font-Names="Verdana" Font-Size="X-Small" Visible="False" ForeColor="Red" Height="23px" Width="160px">Username already exists</asp:label><asp:button id="cmdSubmit" style="Z-INDEX: 128; LEFT: 297px; POSITION: absolute; TOP: 630px" tabIndex="11" runat="server" Font-Names="Verdana" Font-Size="Smaller" Height="28px" Width="132px" Text="Submit"></asp:button><asp:validationsummary id="ValidationSummary1" style="Z-INDEX: 132; LEFT: 534px; POSITION: absolute; TOP: 647px" runat="server" Font-Names="Verdana" Font-Size="Smaller" ShowSummary="False" ShowMessageBox="True"></asp:validationsummary>
			<HR style="Z-INDEX: 144; LEFT: 9px; WIDTH: 95.96%; POSITION: absolute; TOP: 158px; HEIGHT: 2px" width="95.96%" noShade SIZE="2">
		</FORM>
	</BODY>
</HTML>