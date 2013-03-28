using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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

    
}