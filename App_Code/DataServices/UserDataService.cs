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
    private static string connectionString = DBConnector.getConnectionString();
    private static SqlConnection conn = new SqlConnection(connectionString);	

    public static User getUser(Guid id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where UserId = @GUID", conn);
        cmd.Parameters.AddWithValue("@GUID", id);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        Guid uid = (Guid) reader["UserId"];
        string userName = (string) reader["Name"];
        string email = (string) reader["Email"];
        conn.Close();
        return new User(uid, userName, email);
    }

    public static bool addUser(User user)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Users (UserId, Name, Email, Photo, Location) VALUES(@UserId, @Name, @Email, @Photo, @Location)", conn);
        cmd.Parameters.AddWithValue("@UserId", user.uid);
        cmd.Parameters.AddWithValue("@Name", user.name);
        cmd.Parameters.AddWithValue("@Email", user.email);
        cmd.Parameters.AddWithValue("@Photo", user.photo);
        cmd.Parameters.AddWithValue("@Location", user.location);
        try
        {
            cmd.ExecuteNonQuery();
        }
        catch (Exception)
        {
            conn.Close(); 
            return false;
        }
        conn.Close();
        return true;            
    }

    public static bool deleteUser(Guid idToDelete)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Users where UserId = @IdDelete", conn);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static bool updateUser(Guid idToUpdate, User newUser)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("Update Users SET Name = @Name, Email = @Email, Photo = @Photo, Location = @Location where UserId = @UserId", conn);
        cmd.Parameters.AddWithValue("@Name", newUser.name);
        cmd.Parameters.AddWithValue("@Email", newUser.email);
        cmd.Parameters.AddWithValue("@Photo", newUser.photo);
        cmd.Parameters.AddWithValue("@Location", newUser.location);
        cmd.Parameters.AddWithValue("@UserId", idToUpdate);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }

    public static bool addUserToNetwork(User user, Network network)
    {
        return false;
    }

    public static bool removeUserFromNetwork(User user, Network network)
    {
        return false;
    }

}