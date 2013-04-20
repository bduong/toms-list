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
    private const string NETWORKS_TABLE_NAME = "Networks"; 

	public NetworkDataService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static Network getNetwork(int id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM Networks where NetworkId = @NetworkId", conn);
        cmd.Parameters.AddWithValue("@NetworkId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();

        int networkId = (int)reader[ColumnNames.Id];
        string name = (string)reader[ColumnNames.Name];
        string pattern = (string)reader[ColumnNames.Pattern];
        conn.Close();

        return new Network(networkId, name, pattern);
    }

    public static List<Network> getNetworkBy(String columnName, String value, int limit)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd;
        if (limit > 0)
        {
            cmd = new SqlCommand("SELECT * FROM Networks where " + columnName + " = @Value LIMIT 0, @Limit", conn);
            cmd.Parameters.AddWithValue("@Limit", limit);
        }
        else
        {
            cmd = new SqlCommand("SELECT * FROM Networks where " + columnName + " = @Value", conn);
        }
        cmd.Parameters.AddWithValue("@Value", value);
        SqlDataReader reader = cmd.ExecuteReader();
        List<Network> networks = new List<Network>();
        while (reader.Read())
        {
            int id = (int)reader[ColumnNames.Id];
            string name = (string)reader[ColumnNames.Name];
            string pattern = (string)reader[ColumnNames.Pattern];
            networks.Add(new Network(id, name, pattern));
        }
        conn.Close();

        return networks;
    }

    public static Network addNetwork(Network network)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Networks (Name, Match_Pattern) VALUES (@name, @pattern); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@name", network.name);
        cmd.Parameters.AddWithValue("@pattern", network.pattern);
        int id = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        network.id = id;

        return network;
    }

    public static Boolean deleteNetwork(String id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Networks where NetworkId = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static Boolean updateNetwork(String idToUpdate, Network newNetwork)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("UPDATE Networks SET Name = @name, Match_Pattern = @pattern WHERE NetworkId = @id");
        cmd.Parameters.AddWithValue("@name", newNetwork.name);
        cmd.Parameters.AddWithValue("@pattern", newNetwork.pattern);
        cmd.Parameters.AddWithValue("@id", idToUpdate);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }

    public class ColumnNames
    {
        public static String Id = "NetworkId";
        public static String Name = "Name";
        public static String Pattern = "Match_Pattern";

    }
}