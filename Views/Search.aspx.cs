using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Landing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        fr_view.ActiveViewIndex = 0;
    }

    protected void search(object sender, EventArgs e)
    {
        fr_view.ActiveViewIndex = 1;

        /* get values from database table */
        string[] words = search_box.Text.Split(' ');
        foreach (string word in words)
        {
            List<Tag> taglist = TagDataService.getTagsByName(word);
            foreach(Tag tag in taglist) {
                String id = tag.id.ToString();
                List<int> listingIds = ListingDataService.getListingOfTag(id);
                foreach (int listingId in listingIds)
                {
                    Listing listing = ListingDataService.getListing(listingId.ToString());
                    String objectHTML = "<div><p>" + listing.title + "</p><p>" + listing.description + "</p><p>" + listing.date.ToString() + "</p></div><br/><br/>";
                    results.InnerHtml += objectHTML;
                    ListBox1.Items.Add(new ListItem(listing.description, listing.description));
                }
            }
        }
       


    }
}