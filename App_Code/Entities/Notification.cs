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
    public int parentId { get; set; }

	public Notification(string message, Guid senderId, Guid recieverId, DateTime date, int parentId) 
	{
        this.message = message;
        this.senderId = senderId;
        this.recieverId = recieverId;
        this.sentDate = date;
        this.parentId = parentId;
	}

    public static Notification createNewNotification(Guid sender, Guid reciever) {
        return new Notification("", sender, reciever, DateTime.Now, 0);
    }
}