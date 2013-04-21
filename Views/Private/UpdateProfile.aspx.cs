using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_UpdateProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Guid AspUserId = (Guid)Membership.GetUser().ProviderUserKey;
                User user = UserDataService.getUser(AspUserId);

                NameLabel.Text = user.name;
                LocationTextBox.Text = user.location;
                EmailTextBox.Text = user.email;
            }
            catch (Exception)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

    }
    protected void ChangeInfo_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser AspUser = Membership.GetUser();
            Guid AspUserId = (Guid)Membership.GetUser().ProviderUserKey;
            User user = UserDataService.getUser(AspUserId);

            user.location = LocationTextBox.Text;
            user.email = EmailTextBox.Text.ToString();
            AspUser.Email = user.email.ToString();

            Membership.UpdateUser(AspUser);
            UserDataService.updateUser(user.uid, user);
            string url = ResolveUrl("~/Views/Private/Profile.aspx");
            Response.Redirect(url);
        }
        catch (System.NullReferenceException)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
    }
}