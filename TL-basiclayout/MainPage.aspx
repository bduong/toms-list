<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Tomslist-Main Page</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                MainPage
                <br />
                <asp:Button ID="UserProfile" runat="server" Text="My Profile" PostBackUrl="./UserProfile.aspx" />
                <asp:Button ID="MainPage" runat="server" Text="Home" PostBackUrl="./MainPage.aspx" />
            </div>

            <div class="content">
                <div id="search">
                    <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="Search" PostBackUrl="./SearchPage.aspx" />
                    <br />
                    Example: Red Leather Couch
                </div>

                <br />
                <asp:Button ID="addItem" runat="server" Text="Add Item" PostBackUrl="./AddListing.aspx" />
                <br />
                <br />
                <br />
                Recently Posted Items:<br />
                <br />
                <div class="columns">
                    <asp:Button ID="itemListing" runat="server" Text="Recent items" PostBackUrl="./ItemListing.aspx" Width="160px" />
                    <asp:Button ID="Button1" runat="server" Text="Recent items" PostBackUrl="./ItemListing.aspx" Width="160px" />
                    <asp:Button ID="Button4" runat="server" Text="Recent items" PostBackUrl="./ItemListing.aspx" Width="160px" />

                    <asp:Button ID="Button5" runat="server" Text="Recent items" PostBackUrl="./ItemListing.aspx" Width="160px" />
                    <asp:Button ID="Button3" runat="server" Text="Recent items" PostBackUrl="./ItemListing.aspx" Width="160px" />
                    <asp:Button ID="Button2" runat="server" Text="Recent items" PostBackUrl="./ItemListing.aspx" Width="160px" />
                    &nbsp;(sql queries for recent items that match this person&#39;s
                    interests? will divide up into 3 columns of items.<br />
                </div>

            </div>
            <div class="push"></div>
        </div>
    </form>
    <div class="footer">copyright</div>
</body>
</html>
