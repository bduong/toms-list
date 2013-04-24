using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for UserDataService
/// </summary>
public class UserDataService
{

    public static User getUser(Guid id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where UserId = @GUID", conn);
        cmd.Parameters.AddWithValue("@GUID", id);
        SqlDataReader reader = cmd.ExecuteReader();
        User user = null;
        if (reader.Read())
        {
            user = extractUser(reader);
        }
        conn.Close();
        return user;
    }

    public static bool addUser(User user)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserId, Name, Email, ImageId, Location) VALUES(@UserId, @Name, @Email, @ImageId, @Location)", conn);
        
        cmd.Parameters.AddWithValue("@UserId", user.uid);
        cmd.Parameters.AddWithValue("@Name", user.name);
        cmd.Parameters.AddWithValue("@Email", user.email);
        cmd.Parameters.AddWithValue("@ImageId", user.imageId);
        cmd.Parameters.AddWithValue("@Location", user.location);
        int rowsAffected = cmd.ExecuteNonQuery();     
        conn.Close();
        return (rowsAffected > 0);            
    }

    public static bool deleteUser(Guid idToDelete)
    {
        User thisUser = getUser(idToDelete);
        List<Network> networks = NetworkDataService.getNetworksOfUser(thisUser.uid.ToString());
        foreach (Network network in networks) {
            removeUserFromNetwork(thisUser, network);
        }

        List<Listing> listings = ListingDataService.getListingsBy(ListingDataService.ColumnNames.UserId, thisUser.uid.ToString());
        foreach (Listing listing in listings)
        {
            ListingDataService.deleteListing(listing.ListingId.ToString());
        }

        List<Garage> garageSales = GarageDataService.getGarageSalesBy(GarageDataService.ColumnNames.UserId, thisUser.uid.ToString());
        foreach (Garage garageSale in garageSales)
        {
            GarageDataService.deleteGarageSale(garageSale.GarageID.ToString());
        }

        //@ToDo Delete Notifications
        ImageDataService.deleteImage(thisUser.imageId);

        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserId=@deleteId", conn);
        cmd.Parameters.AddWithValue("@deleteId", idToDelete);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static bool updateUser(Guid idToUpdate, User newUser)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update Users SET Name = @Name, Email = @Email, ImageId = @ImageId, Location = @Location where UserId = @UserId", conn);
        cmd.Parameters.AddWithValue("@Name", newUser.name);
        cmd.Parameters.AddWithValue("@Email", newUser.email);
        cmd.Parameters.AddWithValue("@ImageId", newUser.imageId);
        cmd.Parameters.AddWithValue("@Location", newUser.location);
        cmd.Parameters.AddWithValue("@UserId", idToUpdate);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }

    public static bool addUserToNetwork(User user, Network network)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO UserNetworks (UserId, NetworkId) VALUES (@UserId, @NetworkId)", conn);
        cmd.Parameters.AddWithValue("@UserId", user.uid);
        cmd.Parameters.AddWithValue("@NetworkId", network.id);
        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
            
    }

    public static bool removeUserFromNetwork(User user, Network network)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM UserNetworks where UserId = @UserId AND NetworkId = @NetworkId", conn);
        cmd.Parameters.AddWithValue("@UserId", user.uid);
        cmd.Parameters.AddWithValue("@NetworkId", network.id);
        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static List<User> searchForUserByName(string pattern)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where Name LIKE @Pattern", conn);
        cmd.Parameters.AddWithValue("@Pattern", "%" + pattern + "%");
        SqlDataReader reader = cmd.ExecuteReader();
        List<User> users = new List<User>();
        while (reader.Read())
        {
            users.Add(extractUser(reader));
        }
        conn.Close();
        return users;
    }

    private static User extractUser(SqlDataReader reader)
    {
        Guid uid = (Guid)reader["UserId"];
        string userName = (string)reader["Name"];
        string email = (string)reader["Email"];
        int imageId = (int)reader["ImageId"];
        string location = (string)reader["Location"];

        return new User(uid, userName, email, location, imageId); ;
    }
}