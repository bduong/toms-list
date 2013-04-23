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
        reader.Read();
        Guid uid = (Guid) reader["UserId"];
        string userName = (string) reader["Name"];
        string email = (string) reader["Email"];
        int imageId = (int)reader["ImageId"];
        string location = (string) reader["Location"];
        conn.Close();
        return new User(uid, userName, email, location, imageId);
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
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Users where UserId = @IdDelete", conn);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static bool updateUser(Guid idToUpdate, User newUser)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update Users SET Name = @Name, Email = @Email, Photo = @Photo, Location = @Location where UserId = @UserId", conn);
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

}