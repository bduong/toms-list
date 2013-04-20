
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Views_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:Login ID="Login1" runat="server" Height="165px" DestinationPageUrl="~/Views/Private/Profile.aspx">
        </asp:Login>
        <br />
    </div>
    <div style ="text-align:left">
    <asp:HyperLink ID="ForgotPassword" runat="server" NavigateUrl="~/Views/PassRecovery.aspx" >I forgot my password!</asp:HyperLink>
    </div>
    &nbsp;
</asp:Content>
