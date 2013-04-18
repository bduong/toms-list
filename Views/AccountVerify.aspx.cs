using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;


public partial class TL_basiclayout_AccountVerify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Guid test;
        if (string.IsNullOrEmpty(Request.QueryString["ID"]) || !Guid.TryParse(Request.QueryString["ID"], out test))
        {
            Information.Text = "Invalid ID";
        }
        else
        {
            Guid user = new Guid(Request.QueryString["ID"]);
            MembershipUser info = Membership.GetUser(user);
            if (info == null)
            {
                Information.Text = "User not found!";
            }
            else
            {
                info.IsApproved = true;
                Membership.UpdateUser(info);
                Information.Text = "Your account has been verified!";
            }
        }
    }
}