using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Private_NetworkVerify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Guid test;
        if (string.IsNullOrEmpty(Request.QueryString["ID"]) || !Guid.TryParse(Request.QueryString["ID"], out test))
        {
            Info.Text = "Invalid ID";
            return;
        }
       
       
        Guid userId = new Guid(Request.QueryString["ID"]);
        if (Membership.GetUser(userId) == null)
        {
            Info.Text = "User does not exist";
            return;
        }

        MembershipUser loggedInUser = Membership.GetUser();
        Guid loggedInGuid = (Guid)loggedInUser.ProviderUserKey;
        if (!loggedInGuid.ToString().Equals(userId.ToString()))
        {
            Info.Text = "Incorrect User ID";
            return;
        }

        int networkId = 0;
        try
        {
            networkId = Convert.ToInt32(Request.QueryString["N"]);
        }
        catch
        {
            Info.Text = "Invalid Network";
        }

        if (networkId >= 0)
        {
            Network network = NetworkDataService.getNetwork(networkId);
            User user = UserDataService.getUser(userId);

            if (network == null)
            {
                Info.Text = "Network does not exist";
            }
            else if (NetworkDataService.doesUserBelongToNetwork(user, network)) {
                Info.Text = user.name + " is already part of " + network.name;
            }
            else if (UserDataService.addUserToNetwork(user, network))
            {
                Info.Text = user.name + " has been added to " + network.name;
            }
            else
            {
                Info.Text = "We cannot add you to the network at this time";
            }
            
        }
    }
}