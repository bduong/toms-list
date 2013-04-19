using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Notifications : System.Web.UI.Page
{
    private class notification
    {
        public String user;
        public String item;
        public String message;
        public DateTime date;

        public notification(String user, String item, String message, DateTime date)
        {
            this.user = user;
            this.item = item;
            this.message = message;
            this.date = date;
            
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        /* dummy list of notifications for testing display */
        List<notification> notifications = new List<notification>();
        notifications.Add(new notification("Marc", "Speakers", "random message sample ... ", DateTime.Now));
        notifications.Add(new notification("Ben", "Macbook", "sample random message ...", DateTime.Now));
        notifications.Add(new notification("Frank", "Chicken", "message message message ...", DateTime.Now));
        notifications.Add(new notification("Henry", "Door", "sample message sample", DateTime.Now)); 

        /* show results on page */
        foreach (notification n in notifications)
        {
            String objectHTML = createNotificationDiv(n);
            notifications_div.InnerHtml += objectHTML;
        }


    }
    private string createNotificationDiv(notification n)
    {
        string objectHTML = "<div class=\"notification_div\">";

        /* add item thumbnail */
        objectHTML += "<img class=\"notification_image\">" + "" + "</img>";

        /* add person name */
        objectHTML += "<div class=\"notification_user\">" + n.user + "/<div>";

        /* add item title */
        objectHTML += "<div class=\"notification_item\">" + n.item + "</div>";

        /* add last message details */
        objectHTML += "<div class=\"notification_date\">" + n.date + "</div>";

        objectHTML += "</div></br>";
        return objectHTML;
    }


}