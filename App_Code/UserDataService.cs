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
        SqlCommand cmd = new SqlCommand("SELECT * FROM Users where name='" + name + "'", conn);
        SqlDataReader reader = cmd.ExecuteReader();

        string userName = (string) reader["name"];
        string password = (string) reader["password"];        
        return new User(userName, password);
    }


    public static void getUser(char p)
    {
        throw new NotImplementedException();
    }
}