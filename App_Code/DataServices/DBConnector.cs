using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for DBConnector
/// </summary>
public class DBConnector
{


    public static SqlConnection getSqlConnection()
    {
        return new SqlConnection(ConfigurationManager.ConnectionStrings["TomsListConnString"].ConnectionString);	

    }    
    
}