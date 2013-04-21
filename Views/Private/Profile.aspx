<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Profile.aspx.cs" Inherits="Views_Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Hello <asp:LoginName ID="LoginName1" runat="server" />!<br /><br />
    <div style="text-align:left">Profile Info:<br /><br /><br />
        You:<br /><br />
        <asp:Image ID="Image1" runat="server" />
        <br /><br />
        Name: 
        <asp:Label ID="name" runat="server" Text="Label"></asp:Label>
        <br /><br />
        Location: 
        <asp:Label ID="location" runat="server" Text="Label"></asp:Label>
        <br /><br />
        E-mail: 
        <asp:Label ID="email" runat="server" Text="Label"></asp:Label>
        <br /><br />
    </div>
    <div>
        <asp:Button ID="ChangeInfo" runat="server" Text="Update My Info" PostBackUrl="~/Views/Private/UpdateProfile.aspx" />
    </div>
</asp:Content>

