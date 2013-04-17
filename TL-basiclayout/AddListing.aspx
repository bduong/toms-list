<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AddListing.aspx.cs" Inherits="AddListing" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tomslist Add Item</title>
    <link href="PageStyles.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">
                <div id="logo" style="width: 300px; float:left">
                    <asp:ImageButton ID="TLogo" runat="server" Height="116px" ImageUrl="~/Logo.png" Width="110px" PostBackUrl="~/MainPage.aspx" />
                    &nbsp;<br />
                </div>
                <div id="searchbar" style="width:250px">
                    <asp:TextBox ID="SearchBox" runat="server"></asp:TextBox>
                    <asp:Button ID="searchButton" runat="server" Text="Search" PostBackUrl="~/SearchPage.aspx" OnClick="searchButton_Click" />
                    <br />
                </div>
                Add Listing
            <br />

                <asp:Button ID="UserProfile" runat="server" Text="My Profile" PostBackUrl="~/UserProfile.aspx" />
                <asp:Button ID="MainPage" runat="server" Text="Home" PostBackUrl="~/MainPage.aspx" />
            </div>

            <div class="content">
                <div id="imageupload" style="height: 300px; width: 300px; float: left;">
                    <asp:Image ID="Image1" runat="server" Height="171px" Width="183px" />
                    <br />
                    <asp:Button ID="uploadImage" runat="server" Text="Upload Image" />
                </div>
                <br />
                <br />
                
                <asp:Label ID="Label1" runat="server" Text="Title"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox1" runat="server" Width="215px"></asp:TextBox>
                <br />
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
                &nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" Width="250px" Height="71px"></asp:TextBox>
                <br />
                <asp:Label ID="Label3" runat="server" Text="Location"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox3" runat="server" Width="108px"></asp:TextBox>
                <asp:Button ID="areas" runat="server" Text="Browse Areas" />
                <br />
                <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox4" runat="server" Width="81px"></asp:TextBox>
                &nbsp;add logic to restrict to numbers...do this in sql or here?<br />
                <asp:Label ID="Label5" runat="server" Text="Tags"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="TextBox5" runat="server" Width="215px"></asp:TextBox>
                &nbsp;dropdown appears to auto-complete tags as they are added?
            </div>
            <div class="push"></div>
        </div>
        <div class="footer">copyright</div>
    </form>
</body>
</html>
