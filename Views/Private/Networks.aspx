﻿<%@ Page Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Networks.aspx.cs" Inherits="Views_Private_Networks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    Search For Networks<br />
    <br />
    <asp:TextBox ID="Network_Search" runat="server" ></asp:TextBox>
    <asp:Button ID="Do_Search" runat="server" Text="Search" OnClick="Do_Search_Click" />
    <br />
    <br />

    <asp:ListBox ID="Results" runat="server" Width="50%" Font-Size="Large"></asp:ListBox><br /><br />
    <asp:Button ID="Join" Text="Join" runat="server"  Visible="false" OnClick="Join_Click" /> 
    <br />
    <br />
    <asp:Label ID="Domain" runat="server" Visible="false"></asp:Label><br /><br />
    <asp:Label ID="Info" runat="server" Text="Enter Email" Visible="false"></asp:Label>
    <br />
    <br />
    <asp:TextBox ID="Email" runat="server" Visible="false" ></asp:TextBox><br />
    <asp:Button ID="Send" Width="10%" runat="server" Text="Send" Visible="false" OnClick="Send_Click" />
    <asp:Button ID="Cancel" Width="10%" runat="server" Text="Cancel" Visible="false" OnClick="Cancel_Click" />
    <br />
    <br />
    <asp:Label ID="ErrorMessage" runat="server"></asp:Label>
</asp:Content>
