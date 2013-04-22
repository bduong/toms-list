using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Post : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (textbox_title.Text != ""
            && textbox_price.Text != ""
            && textbox_description.Value != ""
            && textbox_location.Text != ""
            && textbox_tags.Text != "")
        {
            string title = textbox_title.Text;
            decimal price = 0;
            try
            {
                price = Convert.ToDecimal(textbox_price.Text);
                string description = textbox_description.Value.ToString();
                string location = textbox_location.Text;
                string tags = textbox_tags.Text;

                MembershipUser user = Membership.GetUser();
                Guid userId = (Guid)user.ProviderUserKey;

                Listing listing = new Listing(userId, title, description, price, location, DateTime.Now);
                Listing newListing = ListingDataService.addListing(listing);

                /* save the tags along with the listing id */
                string[] words = textbox_tags.Text.Split(' ');
                for (int i = 0; i < words.Length; i++ )
                {
                    Tag newTag = TagDataService.createNewTag(words[i]);
                    ListingDataService.addListingTag(newListing, newTag);
                }

                textbox_title.Text = "";
                textbox_price.Text = "";
                textbox_description.Value = "";
                textbox_location.Text = "";
                textbox_tags.Text = "";

                addlisting_output.Text = "Listing added successfully!";
                addlisting_output.Style.Add("color", "#00ff00");


            }
            catch (Exception ex)
            {
                
                addlisting_output.Style.Add("color", "#ff0000");
                if (ex is OverflowException)
                {
                    addlisting_output.Text = "Please enter a smaller price value.";
                }
                else if (ex is FormatException)
                {
                    addlisting_output.Text = "Please enter a valid price value.";
                }
                else
                {
                    addlisting_output.Text = ex.Message;
                }
            }
            
        }
        else
        {
            /* Please fill all fields */
            addlisting_output.Text = "Please fill all of the fields.";
            addlisting_output.Style.Add("color", "#ff0000");

        }




    }
}