<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserRegistration.aspx.cs" Inherits="TL_basiclayout_UserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register</title>
    <link href="../public/css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="header">header</div>
            <div class="content">
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" ContinueDestinationPageUrl="~/Views/Landing.aspx" OnCreatedUser="CreateUserWizard1_CreatedUser" OnSendingMail="CreateUserWizard1_SendingMail">
                    <WizardSteps>
                        <asp:CreateUserWizardStep runat="server" />
                        <asp:CompleteWizardStep runat="server" />
                    </WizardSteps>
                    <MailDefinition BodyFileName="~/Templates/NewAccountTemplate.html" From="toms.list.verify@gmail.com" IsBodyHtml="true" Subject="Welcome to Toms List" Priority="High" />
                </asp:CreateUserWizard>
            </div>
            <div class="push"></div>
        </div>
        <div class="footer">footer</div>
    </form>
</body>
</html>
