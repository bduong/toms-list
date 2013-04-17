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
    private const string LISTING_TABLE_NAME = "Network"; 
    private static string connectionString = DBConnector.getConnectionString();
    private static SqlConnection conn = new SqlConnection(connectionString);

	public NetworkDataService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Network createNewNetwork(Network newNetwork)
    {
        return new Network();
    }

    public static Boolean deleteNetwork(int id)
    {
        return false;
    }

    public static Network getNetwork(int id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Network where NetworkId = @NetworkId", conn);
        cmd.Parameters.AddWithValue("@NetworkId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();

        Guid networkId = (Guid)reader[ColumnNames.Id];
        string name = (string)reader[ColumnNames.Name];
        string pattern = (string)reader[ColumnNames.Pattern];
        conn.Close();

        return new Network(networkId, name, pattern);
    }

    public static List<Network> getNetworkBy(String columnName, String value, int limit)
    {
        conn.Open();
        SqlCommand cmd;
        if (limit > 0)
        {
            cmd = new SqlCommand("SELECT * FROM Network where " + columnName + " = @Value LIMIT 0, @Limit", conn);
            cmd.Parameters.AddWithValue("@Limit", limit);
        }
        else
        {
            cmd = new SqlCommand("SELECT * FROM Network where " + columnName + " = @Value", conn);
        }
        cmd.Parameters.AddWithValue("@Value", value);
        SqlDataReader reader = cmd.ExecuteReader();
        List<Network> networks = new List<Network>();
        while (reader.Read())
        {
            Guid id = (Guid)reader[ColumnNames.Id];
            string name = (string)reader[ColumnNames.Name];
            string pattern = (string)reader[ColumnNames.Pattern];
            networks.Add(new Network(id, name, pattern));
        }
        conn.Close();

        return networks;
    }

    public static Network addListing(Network network)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Network (name, pattern) VALUES (@name, @pattern); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@name", network.name);
        cmd.Parameters.AddWithValue("@pattern", network.pattern);
        int id = (int)cmd.ExecuteScalar();
        conn.Close();
        network.id = id;

        return network;
    }

    public static Boolean deleteNetwork(String id)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Network where id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static Boolean updateListing(String idToUpdate, Network newNetwork)
    {
        conn.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Network SET name = @name, pattern = @pattern WHERE id = @id");
        cmd.Parameters.AddWithValue("@name", newNetwork.name);
        cmd.Parameters.AddWithValue("@pattern", newNetwork.pattern);
        cmd.Parameters.AddWithValue("@id", idToUpdate);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }


    public class ColumnNames
    {
        public static String Id = "id";
        public static String Name = "name";
        public static String Pattern = "pattern";

    }
}