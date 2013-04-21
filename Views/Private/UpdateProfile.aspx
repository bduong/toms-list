<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="UpdateProfile.aspx.cs" Inherits="Views_UpdateProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Hello <asp:LoginName ID="LoginName1" runat="server" />!<br /><br />
    <div style="text-align:left">Profile Info:<br /><br /><br />
        You:<br /><br />
        <asp:Image ID="Image1" runat="server" />
        <br /><br /><br /><br />
        Name: 
        <asp:Label ID="NameLabel" runat="server" Text="Label"></asp:Label>
        <br /><br />
        Location: 
        <asp:TextBox ID="LocationTextBox" runat="server"></asp:TextBox>
        <br /><br />
        E-mail: 
        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        <br /><br />
    </div>
    <div>
        <asp:Button ID="ChangeInfo" runat="server" Text="Update My Info" OnClick="ChangeInfo_Click" />
    </div>
</asp:Content>

