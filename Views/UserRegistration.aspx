<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Views/Layout.master" CodeFile="UserRegistration.aspx.cs" Inherits="TL_basiclayout_UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Views/Landing.aspx" OnCreatedUser="CreateUserWizard1_CreatedUser" OnSendingMail="CreateUserWizard1_SendingMail" Height="400px" Width="445px">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" />
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" />
            </WizardSteps>
            <MailDefinition BodyFileName="~/Templates/NewAccountTemplate.html" From="toms.list.verify@gmail.com" IsBodyHtml="true" Subject="Welcome to Toms List" Priority="High" />
        </asp:CreateUserWizard>
        <br />
    </div>
    <div>
        <asp:HyperLink ID="ReturnLogin" runat="server" NavigateUrl="~/Views/Login.aspx">Return to Login Page</asp:HyperLink>
    </div>
    &nbsp;
</asp:Content>

