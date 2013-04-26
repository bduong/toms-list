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
    protected void Delete_user(object sender, EventArgs e)
    {
        if (ListBox1.SelectedItem != null)
        {
            string name = ListBox1.SelectedItem.Text;
            Guid userid = (Guid)Membership.GetUser(name).ProviderUserKey;
            try
            {
                Membership.DeleteUser(name, true);
                UserDataService.deleteUser(userid);
                //ListBox1.DataBind();
                ListBox1.Items.Clear();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("The name does not exist.  Did you hit the back button?");
            }
        }
    }

    protected void Delete_network(object sender, EventArgs e)
    {
        if (ListBox2.SelectedItem != null)
        {
            string network = ListBox2.SelectedItem.Text;
            List<Network> networks = NetworkDataService.searchForNetworksByName(network);

            try
            {
                List<int> id = networks.Select(t => t.id).ToList();
                NetworkDataService.deleteNetwork(id[ListBox2.SelectedIndex]);
               // ListBox2.DataBind();
                ListBox2.Items.Clear();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("The network does not exist.  Did you hit the back button?");
            }
        }
    }

    protected void Delete_tag(object sender, EventArgs e)
    {
        if (ListBox3.SelectedItem != null)
        {
            string tag = ListBox3.SelectedItem.Text;
            List<Tag> tags = TagDataService.searchForTagByName(tag);

            try
            {
                List<int> id = tags.Select(t => t.id).ToList();
                TagDataService.deleteTag(id[ListBox3.SelectedIndex]);
//                ListBox3.DataBind();
                ListBox3.Items.Clear();
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("The tag does not exist.  Did you hit the back button?");
            }
        }
    }
    protected void User_search(object sender, EventArgs e)
    {
        string search = TextBox1.Text;
        List<User> users = UserDataService.searchForUserByName(search);

        ListBox1.DataSource = users.Select(t => t.name).ToList();
        ListBox1.DataBind();
    }
    protected void Network_search(object sender, EventArgs e)
    {
        string search = TextBox2.Text; ;
        List<Network> networks = NetworkDataService.searchForNetworksByName(search);

        ListBox2.DataSource = networks.Select(t => t.name).ToList();
        ListBox2.DataBind();
    }
    protected void Tag_search(object sender, EventArgs e)
    {
        string search = TextBox3.Text; ;
        List<Tag> tags = TagDataService.searchForTagByName(search);
               
        ListBox3.DataSource = tags.Select(t => t.name).ToList();
        ListBox3.DataBind();
    }
}