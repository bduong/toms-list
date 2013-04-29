using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.IO;

public partial class Views_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(Request["__EVENTARGUMENT"]))
        {
            MembershipUser currentUser = Membership.GetUser(Request["__EVENTARGUMENT"]);
            if (currentUser != null) sendMail(currentUser);
        }
    }
    protected void Login1_LoginError(object sender, EventArgs e)
    {
        MembershipUser currentUser = Membership.GetUser(Login1.UserName);
        if (currentUser == null)
        {
            Login1.FailureText = "Invalid Username. Please try again.";
        } else if(!currentUser.IsApproved) {
            Login1.FailureText = "Account has not been verified yet <br /> Click to resend verfication email to <br/> " + currentUser.Email + " <button onclick=\"javascript:resend('" + currentUser.UserName + "')\" runat=\"server\">Resend</button>";
        } else {
            Login1.FailureText = "Invalid Password. Please try again.";
        }        
    }


    private void sendMail(MembershipUser user)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("toms.list.verify@gmail.com");
        mailMessage.Subject = "Welcome To Tom's List";
        mailMessage.To.Add(new MailAddress(user.Email));

        Guid userId = (Guid)user.ProviderUserKey;
        string body = "";
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Templates/NewAccountTemplate.html")))
        {
            body = reader.ReadToEnd();
        }

        body = body.Replace("<%UserName%>", user.UserName);

        string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority) + (Request.ApplicationPath.Equals("/") ? "" : Request.ApplicationPath);
        string verifyUrl = "/Views/AccountVerify.aspx?ID=" + userId.ToString();

        body = body.Replace("<%VerifyUrl%>", baseUrl + verifyUrl);
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = true;

        new SmtpClient().Send(mailMessage);
    }
}