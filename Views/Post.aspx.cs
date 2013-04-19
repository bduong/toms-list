using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string title = textbox_title.Text;
        decimal price = Convert.ToDecimal(textbox_price.Text);
        string description = textbox_description.Value.ToString();
        string location = textbox_location.Text;
        string tags = textbox_tags.Text;

        Guid guid = new Guid("70d833c6-83e3-419d-b4e2-d61ce2bb668f");
        Listing listing = new Listing(guid, title, description, price, location, DateTime.Now);
        ListingDataService.addListing(listing);

        textbox_title.Text = "";
        textbox_price.Text = "";
        textbox_description.Value = "";
        textbox_location.Text = "";
        textbox_tags.Text = "";

    }
}