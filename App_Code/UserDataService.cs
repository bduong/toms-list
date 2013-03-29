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

    public static User getUser(string name)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where Name = @Name", conn);
        cmd.Parameters.AddWithValue("@Name", name);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        string userName = (string) reader["Name"];
        string password = (string) reader["Password"];
        conn.Close();
        return new User(userName, password);
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