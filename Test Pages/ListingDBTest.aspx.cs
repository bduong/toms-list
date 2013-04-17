using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Pages_ListingDBTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Listing> listing = ListingDataService.getListingsBy(ListingDataService.ColumnNames.ListingId, "4");
        for (int i = 0; i < listing.Count; i++)
        {
            OUT.Text += listing[i].title;
        }

        Guid guid = new Guid();
        guid = Guid.NewGuid();
        Listing newListing = new Listing(guid, "Chair", "Fenway", DateTime.Now);
        ListingDataService.addListing(newListing);

       
    }
}