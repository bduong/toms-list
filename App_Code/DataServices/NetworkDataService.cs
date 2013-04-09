using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Class1
/// </summary>
public class NetworkDataService
{
    private static string connectionString = DBConnector.getConnectionString();
    private static SqlConnection conn = new SqlConnection(connectionString);

	public NetworkDataService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Boolean createNewNetwork(Network newNetwork)
    {
        return false;
    }
}