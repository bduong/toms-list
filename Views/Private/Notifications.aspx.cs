using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Notifications : System.Web.UI.Page
{
    // public Notification(string message, Guid senderId, Guid recieverId, DateTime date, int parentId) 
    protected void Page_Load(object sender, EventArgs e)
    {
        string parameter = Request["__EVENTARGUMENT"];
        if (parameter != null && parameter != "")
        {
            notifications_multiview.ActiveViewIndex = 0;
            conversation_div.InnerHtml = "";
            showConversation(parameter);
        }
        else
        {
            if (User.Identity.IsAuthenticated)
            {
                notifications_multiview.ActiveViewIndex = 1;
                /* dummy list of notifications for testing display */
                List<Notification> notifications = new List<Notification>();

                MembershipUser user = Membership.GetUser();
                Guid userId = (Guid)user.ProviderUserKey;

                notifications = NotificationDataService.getNotifications(userId.ToString());
                // notifications = NotificationDataService.getNotifications("70d833c6-83e3-419d-b4e2-d61ce2bb668f");
                notifications.Add(new Notification("random message sample", new Guid("70d833c6-83e3-419d-b4e2-d61ce2bb668f"), new Guid("70d833c6-83e3-419d-b4e2-d61ce2bb668f"), DateTime.Now, 2));


                /* show results on page */
                notifications_div.InnerHtml = "";
                foreach (Notification n in notifications)
                {
                    String objectHTML = createNotificationDiv(n);
                    notifications_div.InnerHtml += objectHTML;
                }
            }
        }

    }

    private void showConversation(String senderId)
    {
        List<Notification> notifications_1 = new List<Notification>();
        List<Notification> notifications_2 = new List<Notification>();

        /* sender notifications */
        notifications_1 = NotificationDataService.getConversation(senderId, "70d833c6-83e3-419d-b4e2-d61ce2bb668f");
        /* receiver notifications */
        notifications_2 = NotificationDataService.getConversation("70d833c6-83e3-419d-b4e2-d61ce2bb668f", senderId);

        int i1 = 0;
        int i2 = 0;
        while (i1 < notifications_1.Count || i2 < notifications_2.Count)
        {
            if (i1 < notifications_1.Count && i2 < notifications_2.Count)
            {
                if (notifications_1[i1].sentDate < notifications_2[i2].sentDate)
                {
                    conversation_div.InnerHtml += createSenderDiv(notifications_1[i1]);
                    i1++;
                }
                else
                {
                    conversation_div.InnerHtml += createReceiverDiv(notifications_2[i2]);
                    i2++;
                }
            }
            else if (i1 < notifications_1.Count)
            {
                conversation_div.InnerHtml += createSenderDiv(notifications_1[i1]);
                i1++;
            }
            else if (i2 < notifications_2.Count)
            {
                conversation_div.InnerHtml += createReceiverDiv(notifications_2[i2]);
                i2++;
            }
        }
    }

    private string createReceiverDiv(Notification n)
    {
        string objectHTML = "";
        objectHTML += "<div class=\"message_receiver_div\">";

        /* add item thumbnail */
        objectHTML += "<img class=\"message_receiver_image\" align=\"left\">" + "" + "</img>";

        /* add person name */
        objectHTML += "<div class=\"message_receiver_user\">" + UserDataService.getUser(n.senderId).name + "</div>";

        /* add item title */
        objectHTML += "<div class=\"message_receiver_message\">" + n.message + "</div>";

        /* add last message details */
        objectHTML += "<div class=\"message_receiver_date\">" + n.sentDate + "</div>";

        objectHTML += "</div></br>";
        return objectHTML;
    }

    private string createSenderDiv(Notification n)
    {
        string objectHTML = "";
        objectHTML += "<div class=\"message_sender_div\">";

        /* add item thumbnail */
        objectHTML += "<img class=\"message_sender_image\">" + "" + "</img>";

        /* add person name */
        objectHTML += "<div class=\"message_sender_user\">" + UserDataService.getUser(n.recieverId).name + "</div>";

        /* add item title */
        objectHTML += "<div class=\"message_sender_message\">" + n.message + "</div>";

        /* add last message details */
        objectHTML += "<div class=\"message_sender_date\">" + n.sentDate + "</div>";

        objectHTML += "</div></br>";
        return objectHTML;
    }

    private string createNotificationDiv(Notification n)
    {
        string objectHTML = "";
        objectHTML += "<div class=\"notification_div\" onclick=\"javascript:previewchat('" + n.senderId + "')\" runat=\"server\">";
        
        /* add item thumbnail */
        objectHTML += "<img class=\"notification_image\" align=\"left\">" + "" + "</img>";

        /* add person name */
        objectHTML += "<div class=\"notification_user\">" + UserDataService.getUser(n.senderId).name + "</div>";

        /* add item title */
        objectHTML += "<div class=\"notification_message\">" + n.message + "</div>";

        /* add last message details */
        objectHTML += "<div class=\"notification_date\">" + n.sentDate + "</div>";

        objectHTML += "</div></br>";
        return objectHTML;
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        notifications_multiview.ActiveViewIndex = 1;
        
        
    }
}