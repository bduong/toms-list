using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DBConnector
/// </summary>
public class DBConnector
{
    private const string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";

    public static string getConnectionString()
    {
        return connectionString;
    }

    public static SqlConnection getSqlConnection()
    {
        return new SqlConnection(connectionString);	

    }    
}