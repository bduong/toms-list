using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Notification
/// </summary>
public class Notification
{
    public int id { get; set; }
    public string message { get; set; }
    public Guid senderId { get; set; }
    public Guid recieverId { get; set; }
    public DateTime sentDate { get; set; }

	public Notification(string message, Guid senderId, Guid recieverId, DateTime date) 
	{
        this.message = message;
        this.senderId = senderId;
        this.recieverId = recieverId;
        this.sentDate = date;
        
	}
    public Notification(int id, string message, Guid senderId, Guid recieverId, DateTime date)
    {
        this.id = id;
        this.message = message;
        this.senderId = senderId;
        this.recieverId = recieverId;
        this.sentDate = date;

    }

    public static Notification createNewNotification(Guid sender, Guid reciever) {
        return new Notification("", sender, reciever, DateTime.Now);
    }
}