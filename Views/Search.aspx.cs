using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Landing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string parameter = Request["__EVENTARGUMENT"];
        string page = Request["__EVENTTARGET"];
        string query = Request.Params["query"];
        if (parameter != null)
        {
            if (parameter == "")
            {
                if (page == "1")
                {

                    fr_view.ActiveViewIndex = 1;
                    getFeatured();
                }
                else
                {
                    fr_view.ActiveViewIndex = 2;

                }

            }
            /* preview page */
            else
            {
                fr_view.ActiveViewIndex = 0;
                preview(parameter);
            }
        }
        else if (query != "" && query != null)
        {
            fr_view.ActiveViewIndex = 2;
            doQuery(query);
        }
        else
        {
            fr_view.ActiveViewIndex = 1;
            getFeatured();
        }

    }

    protected void contact_seller(object sender, EventArgs e)
    {
        string message = textarea_message.Value.ToString();
        if (message != null && message != "")
        {
            Guid receiverId = new Guid(view_item_userid.Value.ToString());

            MembershipUser user = Membership.GetUser();
            Guid senderId = (Guid)user.ProviderUserKey;

            Notification notification = new Notification(message, senderId, receiverId, DateTime.Now, 0);
            NotificationDataService.saveNotification(notification);

            contact_log.Style.Add("color", "#00ff00");
            contact_log.Text = "Your message has been sent!";
        }
        else
        {
            contact_log.Style.Add("color", "#ff0000");
            contact_log.Text = "Please enter your message";
        }
    }

    protected void backto_featured(object sender, EventArgs e)
    {
        fr_view.ActiveViewIndex = 1;
        getFeatured();
    }

    protected void backto_search(object sender, EventArgs e)
    {
        fr_view.ActiveViewIndex = 2;
    }

    private void preview(String id)
    {
        Listing listing = ListingDataService.getListing(id);
        view_item_userid.Value = listing.userId.ToString();
        view_item_title.Text = listing.title;
        view_item_description.Text = listing.description;
        view_item_price.Text = listing.price.ToString();
        view_item_location.Text = listing.location;
        view_item_date.Text = listing.date.ToString();
        item_image.ImageUrl = "~/Helpers/GetImage.ashx?ID=" + listing.imageId;

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

        featured1.InnerHtml = "";
        for (int i = returnList.Count - 1; i >= 0; i--)
        {
            featured1.InnerHtml += createFeaturedItemDiv(returnList[i]);
        }
    }

    private void putRecentApts()
    {
        List<Listing> returnList = new List<Listing>();

        /* get recently posted appartments and rooms from database */
        string[] tagslist = {"apt"};
        foreach (string tag in tagslist)
            returnList.AddRange(searchWithTag(tag));

        featured2.InnerHtml = "";
        for (int i = returnList.Count - 1; i >= 0; i--)
        {
            featured2.InnerHtml += createFeaturedItemDiv(returnList[i]);
        }
    }

    private void putHighlights()
    {
        List<Listing> returnList = new List<Listing>();

        /* defaults to showing listings around boston */
        String location = "boston";
        if (User.Identity.IsAuthenticated)
        {
            MembershipUser user = Membership.GetUser();
            Guid userId = (Guid)user.ProviderUserKey;
            location = UserDataService.getUser(userId).location;
        }
        
        returnList = ListingDataService.getListingsBy("Location", location, 5);

        featured3.InnerHtml = "";
        for (int i = returnList.Count - 1; i >= 0; i--)
        {
            featured3.InnerHtml += createFeaturedItemDiv(returnList[i]);
        }
    }

    private void getFeatured()
    {
        putRecentlyListings();
        putRecentApts();
        if (User.Identity.IsAuthenticated)
        {
            putNetworkListings();
            featured3_header.Text = "In Your Network";
            networks.Visible = true;
        }
        else
        {
            putHighlights();
            networks.Visible = false;
        }
    }

    private void putNetworkListings()
    {
        MembershipUser user = Membership.GetUser();
        Guid userId = (Guid)user.ProviderUserKey;

        List<Network> returnedNetworks = NetworkDataService.getNetworksOfUser(userId.ToString());
        foreach(Network net in returnedNetworks) {
            networks.Items.Add(new ListItem(net.name));
        }
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

    protected void doQuery(String q)
    {
        fr_view.ActiveViewIndex = 2;
        results.InnerHtml = "";

        /* get values from database table */
        List<Listing> all_results = new List<Listing>();
        string[] words = q.Split(' ');
        // subscribe.Text = "Subscribe to search: ";
        foreach (string word in words)
        {
            // subscribe.Text += word + " - ";
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

        objectHTML += "<div class=\"search_item_div\" onclick=\"javascript:preview(" + listing.ListingId + ", '1')\" runat=\"server\">";

        /* object image */
        objectHTML += "<div class=\"search_item_img\"><img width=\"40px\" height=\"40px\" src=\"../Helpers/GetThumbnail.ashx?ID=" + listing.imageId + "\"></img></div>";

        /* object title */
        objectHTML += "<div class=\"search_item_title\">" + listing.title + "</div>";

        /* object price */
        objectHTML += "<div class=\"search_item_price\">" + listing.price + " $</div></br>";


        /* object description */
        objectHTML += "<div class=\"search_item_description\">" + listing.description + "</div>";


        objectHTML += "</div></br>";

        return objectHTML;
    }

    /* featured items will have smaller divisions */
    private string createFeaturedItemDiv(Listing listing)
    {
        string objectHTML = "<div class=\"featured_item_div\" onclick=\"javascript:preview(" + listing.ListingId + ", '2')\" runat=\"server\">";

        /* object image */
        objectHTML += "<div class=\"featured_item_img\"><img width=\"40px\" height=\"40px\" src=\"../Helpers/GetThumbnail.ashx?ID=" + listing.imageId + "\"></img></div>";

        /* object title */
        objectHTML += "<div class=\"featured_item_title\">" + listing.title + "</div>";

        /* object description */
        objectHTML += "<div class=\"featured_item_description\">" + listing.description + "</div>";

        /* object price */
        objectHTML += "<div class=\"featured_item_price\">" + listing.price + "$ </div>";

        objectHTML += "</div></br>";

        return objectHTML;
    }

    protected void networks_SelectedIndexChanged(object sender, EventArgs e)
    {
        String networkName = networks.SelectedItem.Text;
        List<Network> network = NetworkDataService.getNetworkBy("Name", networkName, 1);
        if (network.Count > 0)
        {
            /* get all users from the network */
            List<Guid> guids = NetworkDataService.getUsersOfNetwork(network[0].id.ToString());

            /* for each guid get the listings */
            List<Listing> networkListings = new List<Listing>();
            foreach (Guid guid in guids)
            {
                networkListings.AddRange(ListingDataService.getListingsBy("UserId", guid.ToString()));
            }
            
            /* add the listings to featured3 */
            featured3.InnerHtml = "";
            for (int i = networkListings.Count - 1; i >= 0; i--)
            {
                featured3.InnerHtml += createFeaturedItemDiv(networkListings[i]);
            }
        }

    }
}