
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="PassRecovery.aspx.cs" Inherits="Views_Recovery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:PasswordRecovery ID="PasswordRecovery1" runat="server" Height="182px">
        </asp:PasswordRecovery>
        <br />
    </div>
    <div>
        <asp:HyperLink ID="ReturnLogin" runat="server" NavigateUrl="~/Views/Login.aspx">Return to Login Page</asp:HyperLink>
    </div>
    &nbsp;
</asp:Content>
