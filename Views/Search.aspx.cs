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
        string parameter = Request["__EVENTARGUMENT"];
        if (parameter != null)
        {
            if (parameter == "")
            {
                fr_view.ActiveViewIndex = 2;
            }
            /* preview page */
            else
            {
                fr_view.ActiveViewIndex = 0;
                preview(parameter);
            }
        }
        else
        {
            fr_view.ActiveViewIndex = 1;
            getFeatured();
        }

    }

    private void preview(String id)
    {
        Listing listing = ListingDataService.getListing(id);
        view_item_title.Text = listing.title;
        view_item_description.Text = listing.description;
        view_item_price.Text = listing.price.ToString();
        view_item_location.Text = listing.location;
        view_item_date.Text = listing.date.ToString();

        User user = UserDataService.getUser(listing.userId);
        view_item_user.Text = user.name;
        view_item_user.Attributes.Add("userId", listing.userId.ToString());
    }



    private void putRecentlyListings()
    {
        List<Listing> returnList = new List<Listing>();
        // Guid guid = new Guid("12345678-1234-1234-1234-123456789123");
        // returnList.Add(new Listing(guid, "something", "description for something", 100, "place of something", DateTime.Now));
        
        /* get recently posted listings from database */
        returnList = ListingDataService.getRecentListings(3);



        featured1.InnerHtml = "<span> Recently Posted Items</span>";
        foreach (Listing listing in returnList)
            featured1.InnerHtml += createFeaturedItemDiv(listing);
    }

    private void putRecentApts()
    {
        List<Listing> returnList = new List<Listing>();
        // Guid guid = new Guid("12345678-1234-1234-1234-123456789123");
        // returnList.Add(new Listing(guid, "something", "description for something", 100, "place of something", DateTime.Now));

        /* get recently posted appartments and rooms from database */
        string[] tagslist = {"appartment"};
        foreach (string tag in tagslist)
            returnList.AddRange(searchWithTag(tag));

        featured2.InnerHtml = "<span> Nearby Appartments</span>";
        foreach (Listing listing in returnList)
            featured2.InnerHtml += createFeaturedItemDiv(listing);
    }

    private void putHighlights()
    {
        List<Listing> returnList = new List<Listing>();
        //Guid guid = new Guid("12345678-1234-1234-1234-123456789123");
        //returnList.Add(new Listing(guid, "something", "description for something", 100, "place of something", DateTime.Now));

        string[] tagslist = { "gadget"};
        foreach (string tag in tagslist)
            returnList.AddRange(searchWithTag(tag));

        returnList = returnList.Distinct().ToList();

        /* get most viewed items from database */
        featured3.InnerHtml = "<span> Electronics / Gadgets </span>";
        foreach (Listing listing in returnList)
            featured3.InnerHtml += createFeaturedItemDiv(listing);
    }

    private void getFeatured()
    {
        putRecentlyListings();
        putRecentApts();
        putHighlights();
    }


    private List<Listing> searchWithTag(string word)
    {
        List<Listing> returnList = new List<Listing>();

        List<Tag> taglist = TagDataService.getTagsByName(word);
        foreach (Tag tag in taglist)
        {
            String id = tag.id.ToString();
            List<int> listingIds = ListingDataService.getListingOfTag(id);
            foreach (int listingId in listingIds)
            {
                Listing listing = ListingDataService.getListing(listingId.ToString());
                returnList.Add(listing);
            }
        }

        return returnList;
    }

    protected void search(object sender, EventArgs e)
    {
        fr_view.ActiveViewIndex = 2;
        results.InnerHtml = "";

        /* get values from database table */
        List<Listing> all_results = new List<Listing>();
        string[] words = search_box.Text.Split(' ');
        foreach (string word in words)
        {
            /*
            List<Tag> taglist = TagDataService.getTagsByName(word);
            foreach(Tag tag in taglist) {
                String id = tag.id.ToString();
                List<int> listingIds = ListingDataService.getListingOfTag(id);
                foreach (int listingId in listingIds)
                {
                    Listing listing = ListingDataService.getListing(listingId.ToString());
                    string objectHTML = createSearchItemDiv(listing);
                    results.InnerHtml += objectHTML;
                }
            }
            */
            List<Listing> word_results = searchWithTag(word);
            all_results.AddRange(word_results);
        }

        foreach (Listing listing in all_results)
        {
            string objectHTML = createSearchItemDiv(listing);
            results.InnerHtml += objectHTML;
        }

    }


    /* search items will have larger divisions */
    private string createSearchItemDiv(Listing listing)
    {
        string objectHTML = "";
        
        //objectHTML = "<input type=\"button\" id=\"btnSave\" onclick=\"javascript:preview(" + listing.ListingId + ")\" value=\"click me\"/>";

        objectHTML += "<div class=\"search_item_div\" onclick=\"javascript:preview(" + listing.ListingId + ")\" runat=\"server\">";

        /* object image */
        objectHTML += "<div class=\"search_item_img\"><img>" + "" + "</img></div>";

        /* object title */
        objectHTML += "<div class=\"search_item_title\">" + listing.title + "</div>";

        /* object description */
        objectHTML += "<div class=\"search_item_description\">" + listing.description + "</div>";

        /* object price */
        objectHTML += "<div class=\"search_item_price\">" + listing.price + "</div>";

        objectHTML += "</div></br>";

        return objectHTML;
    }

    /* featured items will have smaller divisions */
    private string createFeaturedItemDiv(Listing listing)
    {
        string objectHTML = "<div id=\"featured_item_div\">";

        /* object image */
        objectHTML += "<div class=\"featured_item_img\"><img>" + "" + "</img></div>";

        /* object title */
        objectHTML += "<div class=\"featured_item_title\">" + listing.title + "</div>";

        /* object description */
        objectHTML += "<div class=\"featured_item_description\">" + listing.description + "</div>";

        /* object price */
        objectHTML += "<div class=\"featured_item_price\">" + listing.price + "</div>";

        objectHTML += "</div></br>";

        return objectHTML;
    }

}