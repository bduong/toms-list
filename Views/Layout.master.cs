using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class Views_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void search_query(object sender, EventArgs e)
    {
        if(search_bar.Text != "" && search_bar.Text != null) {
            String query = search_bar.Text.Trim();
            Response.Redirect("~/Views/Search.aspx?query=" + query);
        }
        
    }
    protected void go_search(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Search.aspx");
    }
    protected void go_post(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Private/Post.aspx");
    }
    protected void go_profile(object sender, EventArgs e)
    {
        if (HttpContext.Current.User.Identity.IsAuthenticated)
        {
            MembershipUser userInfo = Membership.GetUser();
            Guid userId = (Guid)userInfo.ProviderUserKey;
            Response.Redirect("~/Views/Search.aspx?user=" + userId.ToString());
        }
        else
        {
            Response.Redirect("~/Views/Login.aspx");
        }

    }
    protected void go_notifications(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Private/Notifications.aspx");
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

    }
    protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
    {
        FormsAuthentication.SignOut();
        Roles.DeleteCookie();
        Session.Clear();
        Response.Redirect("~/Views/Login.aspx");
    }
}
