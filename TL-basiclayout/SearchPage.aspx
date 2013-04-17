<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPage.aspx.cs" Inherits="SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tomslist Search</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                <asp:ImageButton ID="TLogo" runat="server" Height="116px" ImageUrl="~/Logo.png" Width="110px" PostBackUrl="~/MainPage.aspx" />
                &nbsp;<br />
                Search
            </div>
            <br />
            <asp:Button ID="UserProfile" runat="server" Text="My Profile" PostBackUrl="~/UserProfile.aspx" />
            <asp:Button ID="MainPage" runat="server" Text="Home" PostBackUrl="~/MainPage.aspx" />
            <div id="content">
                <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>
                <asp:Button ID="searchButton" runat="server" Text="Search" PostBackUrl="~/SearchPage.aspx" OnClick="searchButton_Click" />
                <br />
                results: (after query, these repopulate)
            <br />
                <asp:Button ID="Button1" runat="server" Text="Item1" PostBackUrl="~/ItemListing.aspx" />
                <br />
                <asp:Button ID="Button2" runat="server" Text="Item2" PostBackUrl="~/ItemListing.aspx" />
                <br />
                <asp:Button ID="Button3" runat="server" Text="Item3" PostBackUrl="~/ItemListing.aspx" />
                <br />
                <asp:Button ID="Button4" runat="server" Text="Item4" PostBackUrl="~/ItemListing.aspx" />
                <br />
            </div>
            <div class="push"></div>
        </div>
        <div class="footer">copyright</div>
    </form>
</body>
</html>