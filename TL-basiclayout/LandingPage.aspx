<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LandingPage.aspx.cs" Inherits="LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tomslist-Login</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    .blocktext {
        margin-left: auto;
        margin-right: auto;
        margin-bottom: auto;
        margin-top: auto;
        width: 1000px;
        background-color: cadetblue;
    }
</style>
</head>

<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                Tomslist<br />
                Boston University
                <div class="content">
                    <asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt">
                        <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                    </asp:Login>
                    <asp:Button ID="loggedin" runat="server" Text="Logged In" PostBackUrl="~/MainPage.aspx" />
                </div>
                <br />
                <br />
            </div>
            
        </div>
        <div class="footer">footer</div>
    </form>
</body>
</html>
