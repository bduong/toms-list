using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for GarageDataServices
/// </summary>
public class GarageDataService
{
	public GarageDataService()
	{
	
	}

    public static Garage getGarageSale(string id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT * FROM GarageSale where GarageID = @GarageId", conn);
        cmd.Parameters.AddWithValue("@GarageId", id);

        SqlDataReader reader = cmd.ExecuteReader();
        reader.Read();
        Garage returnGarage = extractGS(reader);
        conn.Close();

        return returnGarage;
    }

    public static Garage addGarageSale(Garage gs)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO GarageSale (UserID, DateBegin, DateEnd, Address, Description, Image) VALUES (@UserId, @DateBegin, @DateEnd, @Address, @Description, @Image); SELECT SCOPE_IDENTITY()", conn);
        cmd.Parameters.AddWithValue("@UserId", gs.userID);
        cmd.Parameters.AddWithValue("@DateBegin", gs.DateBegin);
        cmd.Parameters.AddWithValue("@DateEnd", gs.DateEnd);
        cmd.Parameters.AddWithValue("@Address", gs.Address);
        cmd.Parameters.AddWithValue("@Description", gs.Description);
        cmd.Parameters.AddWithValue("@Image", gs.imageId);
        int uid = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        gs.GarageID = uid;

        return gs;
    }

    public static Boolean deleteGarageSale(String id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM GarageSale WHERE GarageID = @gid", conn);
        cmd.Parameters.AddWithValue("@gid", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static Boolean updateGarageSale(String id, Garage newGarage)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("UPDATE GarageSale SET UserID = @userID, DateBegin = @DateBegin, DateEnd = @DateEnd, Address = @Address, Description = @Description", conn);
        cmd.Parameters.AddWithValue("@userID", newGarage.userID);
        cmd.Parameters.AddWithValue("@DateBegin", newGarage.DateBegin);
        cmd.Parameters.AddWithValue("@DateEnd", newGarage.DateEnd);
        cmd.Parameters.AddWithValue("@Address", newGarage.Address);
        cmd.Parameters.AddWithValue("@Description", newGarage.Description);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();

        return (rowsAffected > 0);
    }

    public static class ColumnNames
    {
        public static string GarageId = "GarageID";
        public static string UserId = "UserID";
        public static string DateBegin = "DateBegin";
        public static string DateEnd = "DateEnd";
        public static string Address = "Address";
        public static string Description = "Description";
    }
    private static Garage extractGS(SqlDataReader reader)
    {

        int uid = (int)reader[ColumnNames.GarageId];
        Guid userId = (Guid)reader[ColumnNames.UserId];
        DateTime dateb = (DateTime)reader[ColumnNames.DateBegin];
        DateTime datee = (DateTime)reader[ColumnNames.DateEnd];
        string address = (string)reader[ColumnNames.Address];
        string description = (string)reader[ColumnNames.Description];
        return new Garage(userId, dateb, datee, address, description);
    }
}