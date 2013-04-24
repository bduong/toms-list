using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for ListingDataService
/// </summary>
public class ListingDataService
{

    private const string LISTING_TABLE_NAME = "Listing";    

    public static Listing getListing(String id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Listing where ListingId = @ListingId", conn);
        cmd.Parameters.AddWithValue("@ListingId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        Listing returnListing = extractListing(reader);
        conn.Close();
        return returnListing;
    }

    
    public static List<Listing> getListingsBy(String columnName, String value, int limit = 0)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd;
        if (limit > 0)
        {
            cmd = new SqlCommand("SELECT * FROM Listing where " + columnName + " = @Value LIMIT 0, @Limit", conn);
            cmd.Parameters.AddWithValue("@Limit", limit);
        }
        else
        {
            cmd = new SqlCommand("SELECT * FROM Listing where " + columnName + " = @Value", conn);
        }
        cmd.Parameters.AddWithValue("@Value", value);
        SqlDataReader reader = cmd.ExecuteReader();
        List<Listing> listings = new List<Listing>();
        while (reader.Read())
        {
            Listing listing = extractListing(reader);
            listings.Add(listing);
        }
        conn.Close();

        return listings;
    }



    public static List<Listing> getRecentListings(int limit = 0)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd;
        if (limit > 0)
        {
            cmd = new SqlCommand("SELECT TOP " + limit + " * FROM Listing ORDER BY Date", conn);
            //cmd.Parameters.AddWithValue("@Limit", limit);
        }
        else
        {
            cmd = new SqlCommand("SELECT * FROM Listing ORDER BY Date", conn);
        }
        SqlDataReader reader = cmd.ExecuteReader();
        List<Listing> listings = new List<Listing>();
        while (reader.Read())
        {
            listings.Add(extractListing(reader));
        }
        conn.Close();

        return listings;
    }

    public static Listing addListing(Listing listing)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Listing (UserId, Title, Description, Price, Location, Date, Image) VALUES (@UserId, @Title, @Description, @Price, @Location, @Date, @Image); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@UserId", listing.userId);
        cmd.Parameters.AddWithValue("@Title", listing.title);
        cmd.Parameters.AddWithValue("@Description", listing.description);
        cmd.Parameters.AddWithValue("@Price", listing.price);
        cmd.Parameters.AddWithValue("@Image", listing.imageId);
        cmd.Parameters.AddWithValue("@Location", listing.location);
        cmd.Parameters.AddWithValue("@Date", listing.date);
        int uid = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        listing.ListingId = uid;

        return listing;
    }

    public static Boolean deleteListing(String id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Listing where ListingId = @ListingId", conn);
        cmd.Parameters.AddWithValue("@ListingId", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static Boolean updateListing(String idToUpdate, Listing newListing)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Listing SET UserId = @UserId, Title = @Title, Description = @Description, Price = @Price, Location = @Location, Date = @Date WHERE ListingId = @ListingId");
        cmd.Parameters.AddWithValue("@UserId", newListing.userId);
        cmd.Parameters.AddWithValue("@Title", newListing.title);
        cmd.Parameters.AddWithValue("@Description", newListing.description);
        cmd.Parameters.AddWithValue("@Price", newListing.price);
        cmd.Parameters.AddWithValue("@Location", newListing.location);
        cmd.Parameters.AddWithValue("@Date", newListing.date);
        cmd.Parameters.AddWithValue("@ListingId", idToUpdate);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }

    public static List<int> getListingOfTag(String id)
    {
        List<int> returnList = new List<int>();
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM ListingTags where TagId = @TagId", conn);
        cmd.Parameters.AddWithValue("@TagId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            int listingId = (int)reader["ListingId"];
            returnList.Add(listingId);
        }
        conn.Close();

        return returnList;
    }
    public static void addListingTag(Listing listing, Tag tag)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO ListingTags (ListingId, TagId) VALUES (@ListingId, @TagId); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@ListingId", listing.ListingId);
        cmd.Parameters.AddWithValue("@TagId", tag.id);
        cmd.ExecuteNonQuery();
        conn.Close();
    }




    public static List<Listing> getAllListingsInNetwork(Network network)
    {
        List<Listing> listings = new List<Listing>();
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand findUsers = new SqlCommand("SELECT UserId FROM UserNetworks where NetworkId = @NetworkId", conn);
        findUsers.Parameters.AddWithValue("@NetworkId", network.id);
        SqlDataReader userReader = findUsers.ExecuteReader();
        List<string> usersInNetwork = new List<string>();
        while (userReader.Read())
        {
            usersInNetwork.Add("'" + (Guid)userReader["UserId"] + "'");
        }
        userReader.Close();
        findUsers.Dispose();
        SqlCommand findListings = new SqlCommand("SELECT * FROM Listing where UserId in (" +  String.Join(", ", usersInNetwork.ToArray()) + ") ORDER BY Date DESC", conn);        
        SqlDataReader listingReader = findListings.ExecuteReader();
        while (listingReader.Read())
        {
            listings.Add(extractListing(listingReader));
        }
        conn.Close();
        return listings;
    }

    public static class ColumnNames
    {
        public static string ListingId = "ListingId";
        public static string UserId = "UserId";
        public static string Title = "Title";
        public static string Description = "Description";
        public static string Price = "Price";
        public static string Location = "Location";
        public static string Date = "Date";
        public static string ImageId = "Image";
    }

    private static Listing extractListing(SqlDataReader reader)
    {

        int uid = (int)reader[ColumnNames.ListingId];
        Guid userId = (Guid)reader[ColumnNames.UserId];
        string title = (string)reader[ColumnNames.Title];
        string description = (string)reader[ColumnNames.Description];
        decimal price = (decimal)reader[ColumnNames.Price];
        string location = (string)reader[ColumnNames.Location];
        DateTime date = (DateTime)reader[ColumnNames.Date];
        int imageId = (int)reader[ColumnNames.ImageId];
        return new Listing(uid, userId, title, description, price, location, date, imageId);        
    }
}