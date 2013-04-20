using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        Response.Redirect("~/Views/Private/Profile.aspx");
    }
    protected void go_notifications(object sender, EventArgs e)
    {
        Response.Redirect("~/Views/Private/Notifications.aspx");
    }

}
