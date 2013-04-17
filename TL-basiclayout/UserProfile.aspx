<<<<<<< HEAD
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tomslist User Profile</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="94px" ImageUrl="~/Logo.png" Width="108px" />
                <br />
                User Profile
             <br />
                <asp:Button ID="UserPage" runat="server" Text="My Profile" PostBackUrl="~/UserProfile.aspx" />
                <asp:Button ID="MainPage" runat="server" Text="Home" PostBackUrl="~/MainPage.aspx" />
            </div>

            <div class="content">
                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />

            </div>
            <div class="push"></div>
        </div>
        <div class="footer">copyright</div>
    </form>
</body>
</html>
=======
﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tomslist-User Profile</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                User Profile
             <br />
                <asp:Button ID="UserPage" runat="server" Text="My Profile" PostBackUrl="./UserProfile.aspx" />
                <asp:Button ID="MainPage" runat="server" Text="Home" PostBackUrl="./MainPage.aspx" />
            </div>

            <div class="content">
                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />

            </div>
            <div class="push"></div>
        </div>
        <div class="footer">copyright</div>
    </form>
</body>
</html>
>>>>>>> a50fd820358d7239a9cff682c1f2c97d67eed80e
