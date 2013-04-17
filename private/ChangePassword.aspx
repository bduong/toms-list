<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangePassword.aspx.cs" Inherits="private_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Change Password</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">header</div>
            <div class="content"><asp:ChangePassword ID="ChangePassword1" runat="server" CancelDestinationPageUrl="~/private/MainPage.aspx" ContinueDestinationPageUrl="~/private/MainPage.aspx"></asp:ChangePassword>
            </div>
            <div class="push"></div>
        </div>
        <div class="footer">footer</div>
    </form>
</body>
</html>
