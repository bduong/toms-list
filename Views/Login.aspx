
<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Views_Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="login_form" align="center">
        <div class="login">
            
            <asp:Login ID="Login1" runat="server" Height="165px" DestinationPageUrl="~/Views/Private/Profile.aspx">
                <LayoutTemplate>
                    <fieldset>
                        <a class="login_label">Username</a><asp:TextBox ID="UserName" class="login_field" runat="server"></asp:TextBox><br /><br />
                        <a class="login_label">Password</a><asp:TextBox ID="Password" class="login_field" runat="server" TextMode="Password"></asp:TextBox> <br /><br />
                        <a class="login_label"></a><asp:Button ID="submitLoginBtn" class="login_button" runat="server" CommandName="Login" defaultbutton="SubmitButton" Text="Login" /><br />
                        
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                    </fieldset>
                </LayoutTemplate>
            </asp:Login>
            <br />
            <asp:HyperLink ID="ForgotPassword" runat="server" NavigateUrl="~/Views/PassRecovery.aspx" >I forgot my password!</asp:HyperLink>

            
        </div>

    </div>

    &nbsp;
</asp:Content>
