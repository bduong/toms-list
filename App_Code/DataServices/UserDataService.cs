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

    public static User getUser(string id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where UserId = @GUID", conn);
        cmd.Parameters.AddWithValue("@GUID", id);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        Guid uid = (Guid) reader["UserId"];
        string userName = (string) reader["Name"];
        string password = (string) reader["Password"];
        conn.Close();
        return new User(uid, userName, password);
    }

    public static bool addUser(User user)
    {
        return false;
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