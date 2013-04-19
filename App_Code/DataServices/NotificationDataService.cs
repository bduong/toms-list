using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

/// <summary>
/// Summary description for NotificationDataService
/// </summary>
public class NotificationDataService
{

    private const string LISTING_TABLE_NAME = "Notification";    

	public NotificationDataService()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public static List<Notification> getNotifications(String ReceiverId)
    {
        List<Notification> returnList = new List<Notification>();

        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Notifications where ReceiverId = @ReceiverId ORDER By Date", conn);
        cmd.Parameters.AddWithValue("@ReceiverId", ReceiverId);
        SqlDataReader reader = cmd.ExecuteReader();
        List<Listing> listings = new List<Listing>();
        Guid receiverId = new Guid(ReceiverId);
        HashSet<Guid> ids = new HashSet<Guid>();
        while (reader.Read())
        {
            Guid SenderId = (Guid)reader[ColumnNames.SenderId];
            if (!ids.Contains(SenderId))
            {
                int NotificationId = (int)reader[ColumnNames.NotificationId];
                
                string Message = (string)reader[ColumnNames.Message];
                DateTime date = (DateTime)reader[ColumnNames.Date];
                int ParentId = (int)reader[ColumnNames.ParentId];
                returnList.Add(new Notification(Message, SenderId, receiverId, date, ParentId));
                ids.Add(SenderId);
            }
        }
        conn.Close();

        return returnList;
    }

    public static List<Notification> getConversation(String SenderId, String ReceiverId)
    {
        List<Notification> returnList = new List<Notification>();

        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Notifications where senderId = @SenderId and ReceiverId = @ReceiverId", conn);
        cmd.Parameters.AddWithValue("@SenderId", SenderId);
        cmd.Parameters.AddWithValue("@ReceiverId", ReceiverId);
        SqlDataReader reader = cmd.ExecuteReader();
        List<Listing> listings = new List<Listing>();
        Guid senderId = new Guid(SenderId);
        Guid receiverId = new Guid(ReceiverId);
        while (reader.Read())
        {
            int NotificationId = (int)reader[ColumnNames.NotificationId];
            string Message = (string)reader[ColumnNames.Message];
            DateTime date = (DateTime)reader[ColumnNames.Date];
            int ParentId = (int)reader[ColumnNames.ParentId];
            returnList.Add(new Notification(Message, senderId, receiverId, date, ParentId));
        }
        conn.Close();

        return returnList;
    }

    private static class ColumnNames
    {
        public static string NotificationId = "NotificationId";
        public static string Message = "Message";
        public static string SenderId = "SenderId";
        public static string ReceiverId = "ReceiverId";
        public static string Date = "Date";
        public static string ParentId = "ParentId";
    }
}