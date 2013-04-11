using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// implementation class for ListingControllerInterface
/// </summary>
public class ListingController: ListingControllerInterface
{
    public ListingController()
    {

    }

    public Listing getListing(String id)
    {
        
        // load listing from database

        return ListingDataService.getListing(id);
    }

    public ArrayList getLocationListings(String location, int limit)
    {
        ArrayList listings = new ArrayList();

        // get location listings

        return listings;
    }

    public ArrayList getTypeAndLocationListings(String type, String location, int limit)
    {
        ArrayList listings = new ArrayList();

        // get listings based on a specific type and a location

        return listings;

    }

    public Listing postListing(Listing listing)
    {
        // post listing to database

        return ListingDataService.addListing(listing);
    }

    public bool deleteListing(String id)
    {
        // delete listing from database

        return ListingDataService.deleteListing(id);
    }

    public bool updateListing(String id, Listing listing)
    {
        // update listing in database

        return ListingDataService.updateListing(id, listing);
    }


}