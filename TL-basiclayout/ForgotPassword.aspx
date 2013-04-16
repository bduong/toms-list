<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="TL_basiclayout_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Recover Password</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">header</div>
            <div class="content">
                <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
                </asp:PasswordRecovery>
                <br />
                <br />
                <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/TL-basiclayout/LandingPage.aspx">Back to Log In page</asp:LinkButton>
            </div>
            <div class="push"></div>
        </div>
        <div class="footer">footer</div>
    </form>
</body>
</html>
