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
    private static class ColumnNames {
    }
    private const string LISTING_TABLE_NAME = "Listings";    
    private static string connectionString = DBConnector.getConnectionString();
    private static SqlConnection conn = new SqlConnection(connectionString);

    public static Listing getListing(String id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM @TableName where @ID = @ListingId", conn);
        cmd.Parameters.AddWithValue("@TableName", LISTING_TABLE_NAME);
        cmd.Parameters.AddWithValue("@Id", ColumnNames.ListingId);
        cmd.Parameters.AddWithValue("@ListingId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        conn.Close();

        int uid = (int) reader[ColumnNames.ListingId];
        int userId = (int)reader[ColumnNames.UserId];
        string title = (string)reader[ColumnNames.Title];
        string location = (string)reader[ColumnNames.Location];
        DateTime date = (DateTime)reader[ColumnNames.Date];
        return new Listing(uid, userId, title, location, date);
    }

    public static Listing addListing(Listing listing)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO @TableName (UserId, Title, Description, Location, Date) VALUES (@UserId, @Title, @Description, @Location, @Date); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@User", listing.userId);
        cmd.Parameters.AddWithValue("@Title", listing.title);
        cmd.Parameters.AddWithValue("@Description", listing.description);
        cmd.Parameters.AddWithValue("@Location", listing.location);
        cmd.Parameters.AddWithValue("@Date", listing.date);
        int uid = (int)cmd.ExecuteScalar();
        conn.Close();
        listing.uid = uid;

        return listing;
    }

    public static Boolean deleteListing(String id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM @TableName where @ID = @ListingId", conn);
        cmd.Parameters.AddWithValue("@TableName", LISTING_TABLE_NAME);
        cmd.Parameters.AddWithValue("@ID", ColumnNames.ListingId);
        cmd.Parameters.AddWithValue("@ListingId", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    private static class ColumnNames
    {
        public static string ListingId = "ListingId";
        public static string UserId = "UserId";
        public static string Title = "Title";
        public static string Description = "Description";
        public static string Location = "Location";
        public static string Date = "Date";
    }


}