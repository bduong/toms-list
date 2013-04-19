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

    private string createItemDiv(Listing listing)
    {
        string objectHTML = "<div class=\"item_div\">";

        /* object image */
        objectHTML += "<div class=\"item_img\"><img>" + "" + "</img></div>";

        /* object title */
        objectHTML += "<div class=\"item_title\">" + listing.title + "</div>";

        /* object description */
        objectHTML += "<div class=\"item_description\">" + listing.description + "</div>";

        /* object price */
        objectHTML += "<div class=\"item_price\">" + listing.price + "</div>";

        objectHTML += "</div></br>";

        return objectHTML;
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
                    string objectHTML = createItemDiv(listing);
                    results.InnerHtml += objectHTML;
                }
            }
        }
       


    }
}