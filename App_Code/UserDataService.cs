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
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where Name='" + name + "'", conn);
        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        string userName = (string) reader["Name"];
        string password = (string) reader["Password"];
        conn.Close();
        return new User(userName, password);
    }

}