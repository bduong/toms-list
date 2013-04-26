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

    public static List<Notification> getNotifications(String userId)
    {
        List<Notification> returnList = new List<Notification>();

        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();

        SqlCommand cmd = new SqlCommand("SELECT * FROM Notifications where ReceiverId = @ReceiverId OR SenderId = @SenderId ORDER By Date", conn);
        cmd.Parameters.AddWithValue("@ReceiverId", userId);
        cmd.Parameters.AddWithValue("@SenderId", userId);
        SqlDataReader reader = cmd.ExecuteReader();
        List<Listing> listings = new List<Listing>();


        /* pick one notification out of every conversation */
        HashSet<Guid> ids = new HashSet<Guid>();

        while (reader.Read())
        {
            Guid SenderId = (Guid)reader[ColumnNames.SenderId];
            Guid ReceiverId = (Guid)reader[ColumnNames.ReceiverId];
            if (SenderId.ToString().Equals(userId))
            {
                if (!ids.Contains(ReceiverId))
                {
                    int uid = (int)reader[ColumnNames.NotificationId];
                    string Message = (string)reader[ColumnNames.Message];
                    int NotificationId = (int)reader[ColumnNames.NotificationId];
                    DateTime Date = (DateTime)reader[ColumnNames.Date];
                    returnList.Add(new Notification(uid, Message, SenderId, ReceiverId, Date));
                    ids.Add(ReceiverId);
                }
            } else if(ReceiverId.ToString().Equals(userId)) {
                if(!ids.Contains(SenderId)) {
                    int uid = (int)reader[ColumnNames.NotificationId];
                    string Message = (string)reader[ColumnNames.Message];
                    int NotificationId = (int)reader[ColumnNames.NotificationId];
                    DateTime Date = (DateTime)reader[ColumnNames.Date];
                    returnList.Add(new Notification(uid, Message, SenderId, ReceiverId, Date));
                    ids.Add(SenderId);
                }
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
            returnList.Add(new Notification(NotificationId, Message, senderId, receiverId, date));
        }
        conn.Close();

        return returnList;
    }

    public static Boolean deleteNotification(String id)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Notifications where NotificationId = @NotificationId", conn);
        cmd.Parameters.AddWithValue("@NotificationId", id);

        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }

    public static void saveNotification(Notification notification)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Notifications (Message, SenderId, ReceiverId, Date) VALUES (@Message, @SenderId, @ReceiverId, @Date); SELECT CONVERT(int, SCOPE_IDENTITY())", conn);
        cmd.Parameters.AddWithValue("@Message", notification.message);
        cmd.Parameters.AddWithValue("@SenderId", notification.senderId);
        cmd.Parameters.AddWithValue("@ReceiverId", notification.recieverId);
        cmd.Parameters.AddWithValue("@Date", notification.sentDate);
        
        int uid = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
    }

    private static class ColumnNames
    {
        public static string NotificationId = "NotificationId";
        public static string Message = "Message";
        public static string SenderId = "SenderId";
        public static string ReceiverId = "ReceiverId";
        public static string Date = "Date";
    }
}