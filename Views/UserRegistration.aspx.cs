using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class TL_basiclayout_UserRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
    {
        MembershipUser info = Membership.GetUser(CreateUserWizard1.UserName);
        Guid guid = (Guid)info.ProviderUserKey;

        User user = new User(guid, info.UserName, info.Email);
        UserDataService.addUser(user);
    }
    protected void CreateUserWizard1_SendingMail(object sender, MailMessageEventArgs e)
    {
        MembershipUser newUser = Membership.GetUser(CreateUserWizard1.UserName);
        Guid newUserId = (Guid)newUser.ProviderUserKey;

        string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority) + Request.ApplicationPath;
        string verifyUrl = "/Views/AccountVerify.aspx?ID=" + newUserId.ToString();
        e.Message.Body = e.Message.Body.Replace("<%VerifyUrl%>", baseUrl + verifyUrl);
    }
}