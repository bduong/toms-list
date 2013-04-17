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
    private static string connectionString = DBConnector.getConnectionString();
    private static SqlConnection conn = new SqlConnection(connectionString);

    public static Listing getListing(String id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Listing where ListingId = @ListingId", conn);
        cmd.Parameters.AddWithValue("@ListingId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();

        int uid = (int) reader[ColumnNames.ListingId];
        Guid userId = (Guid)reader[ColumnNames.UserId];
        string title = (string)reader[ColumnNames.Title];
        string location = (string)reader[ColumnNames.Location];
        DateTime date = (DateTime)reader[ColumnNames.Date];
        conn.Close();

        return new Listing(uid, userId, title, location, date);
    }

    
    public static List<Listing> getListingsBy(String columnName, String value, int limit = 0)
    {
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

            int uid = (int)reader[ColumnNames.ListingId];
            Guid userId = (Guid)reader[ColumnNames.UserId];
            string title = (string)reader[ColumnNames.Title];
            string location = (string)reader[ColumnNames.Location];
            DateTime date = (DateTime)reader[ColumnNames.Date];
            listings.Add(new Listing(uid, userId, title, location, date));
        }
        conn.Close();

        return listings;
    }

    public static Listing addListing(Listing listing)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Listing (UserId, Title, Description, Location, Date) VALUES (@UserId, @Title, @Description, @Location, @Date); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@UserId", listing.userId);
        cmd.Parameters.AddWithValue("@Title", listing.title);
        cmd.Parameters.AddWithValue("@Description", listing.description);
        cmd.Parameters.AddWithValue("@Location", listing.location);
        cmd.Parameters.AddWithValue("@Date", listing.date);
        int uid = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        listing.uid = uid;

        return listing;
    }

    public static Boolean deleteListing(String id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Listing where ListingId = @ListingId", conn);
        cmd.Parameters.AddWithValue("@ListingId", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static Boolean updateListing(String idToUpdate, Listing newListing)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Listing SET UserId = @UserId, Title = @Title, Description = @Description, Location = @Location, Date = @Date WHERE ListingId = @ListingId");
        cmd.Parameters.AddWithValue("@UserId", newListing.userId);
        cmd.Parameters.AddWithValue("@Title", newListing.title);
        cmd.Parameters.AddWithValue("@Description", newListing.description);
        cmd.Parameters.AddWithValue("@Location", newListing.location);
        cmd.Parameters.AddWithValue("@Date", newListing.date);
        cmd.Parameters.AddWithValue("@ListingId", idToUpdate);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }

    public static class ColumnNames
    {
        public static string ListingId = "ListingId";
        public static string UserId = "UserId";
        public static string Title = "Title";
        public static string Description = "Description";
        public static string Location = "Location";
        public static string Date = "Date";
    }


}