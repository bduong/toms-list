<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemListing.aspx.cs" Inherits="ItemListing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tomslist Item Listing</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                <asp:ImageButton ID="TLogo" runat="server" Height="116px" ImageUrl="~/Logo.png" Width="110px" PostBackUrl="~/MainPage.aspx" />
                &nbsp;<br />
                itemlisting 
                <br />
                <asp:Button ID="UserProfile" runat="server" Text="My Profile" PostBackUrl="~/UserProfile.aspx" />
                <asp:Button ID="MainPage" runat="server" Text="Home" PostBackUrl="~/MainPage.aspx" />
            </div>

            <div class="content">
                <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
                &nbsp;Item information here...need to figure out how to format w/ picture on the side. Same for profile.
                <br />
                SQL retrieve and put into labels here<br />
                <br />
                Contact Seller:<br />
                <asp:TextBox ID="TextBox1" runat="server" Width="349px"></asp:TextBox>
                <asp:Button ID="messageSend" runat="server" Text="Send" Width="108px" />
                <br />
            </div>
            <div class="push"></div>
        </div>
        <div class="footer">footer</div>
    </form>
</body>
</html>
