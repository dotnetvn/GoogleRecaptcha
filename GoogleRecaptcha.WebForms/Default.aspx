<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GoogleRecaptcha.WebForms.Default" %>
<%@ Register TagPrefix="asp" Namespace="GoogleRecaptchaWebForms" Assembly="GoogleRecaptchaWebForms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test the Google Recapcha V2 Server Control</title>
</head>
<body>
    <form id="frm" runat="server">
		<div>
			<asp:RecaptchaV2Control ID="gRecapcha" SiteKey="6LeF-QMTAAAAAPBTi98JAMFTF1lBzKrbyCri0JB_" SecretKey="6LeF-QMTAAAAAOw8M2RTtxoY6ifOhhUb4GlXpdB3" runat="server"/>
		</div>
		<asp:Button ID="btnVerify" runat="server" Text="Submit" OnClick="btnVerify_OnClick"/>
    </form>
	
	<script src='https://www.google.com/recaptcha/api.js'></script>
</body>
</html>
