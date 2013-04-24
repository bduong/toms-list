<%@ Page Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Views_Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <asp:Label ID="error_caption" CssClass="error_title" runat="server" ></asp:Label><br />
    <asp:Label ID="error_description" CssClass="error_text" runat="server"></asp:Label><br />
    <asp:Image ID="error_image" Width="400px" Height="300px" runat="server" />


</asp:Content>
