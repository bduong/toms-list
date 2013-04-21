using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Profile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Guid AspUserId = (Guid)Membership.GetUser().ProviderUserKey;
            User user = UserDataService.getUser(AspUserId);

            name.Text = user.name;
            location.Text = user.location;
            email.Text = user.email;
        }
        catch (System.NullReferenceException)
        {
            Response.Redirect("~/Views/Login.aspx");
        }

    }
}