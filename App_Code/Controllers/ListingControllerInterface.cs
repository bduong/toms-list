using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// interface class for ListingController
/// </summary>
public interface ListingControllerInterface
{

    #region get_functions
    /// <summary>
    /// fetch listing from database
    /// </summary>
    /// <param name="id">id of the listing</param>
    /// <returns>listing object</returns>
    Listing getListing(String id);

    /// <summary>
    /// get the recently posted listings in a given area
    /// </summary>
    /// <param name="location">location or neighborhood of the listings</param>
    /// <param name="limit">limit on the size of the result set</param>
    /// <returns>list of listings</returns>
    ArrayList getLocationListings(String location, int limit);

    /// <summary>
    /// get the recently posted listings for a specific type (furniture/electronics/...) in a given location
    /// </summary>
    /// <param name="type">type of the listings</param>
    /// <param name="location">location of the listings</param>
    /// <param name="limit">limit on the size of the result set</param>
    /// <returns>list of listings</returns>
    ArrayList getTypeAndLocationListings(String type, String location, int limit);
    #endregion

    #region post_functions
    
    /// <summary>
    /// post listing to database
    /// </summary>
    /// <param name="listing">listing object to be posted</param>
    /// <returns>listing posted successfully</returns>
    Listing postListing(Listing listing);

    #endregion

    #region delete_functions

    /// <summary>
    /// delete listing from database
    /// </summary>
    /// <param name="id">id of the listing to be deleted</param>
    /// <returns>listing deleted successfully</returns>
    bool deleteListing(String id);

    #endregion

    #region update_functions

    /// <summary>
    /// update listing info in database
    /// </summary>
    /// <param name="id">id of the listing to be updated</param>
    /// <param name="listing">listing object to be updated to</param>
    /// <returns>listing updated successfully</returns>
    bool updateListing(String id, Listing listing);

    #endregion
}