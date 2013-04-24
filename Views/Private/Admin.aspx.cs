using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Guid AspUserId = (Guid)Membership.GetUser().ProviderUserKey;
            User user = UserDataService.getUser(AspUserId);

        }
        catch (System.NullReferenceException)
        {
            Response.Redirect("~/Views/Login.aspx");
        }

    }
    protected void Deletebutton_Click(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem != null)
        {
            string name;
            Guid userid;
            try
            {
                name = ListBox1.SelectedItem.Text;
                userid = (Guid)Membership.GetUser(name).ProviderUserKey;
                Membership.DeleteUser(name, true);
                UserDataService.deleteUser(userid);
                ListBox1.DataBind();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("The ID does not exist.  Did you hit the back button?");
            }
        }
    }
}