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

                /* get the key of the user from the session */
                MembershipUser user = Membership.GetUser();
                Guid userId = (Guid)user.ProviderUserKey;

                notifications = NotificationDataService.getNotifications(userId.ToString());

                /* show results on page */
                notifications_div.InnerHtml = "";
                foreach (Notification n in notifications)
                {
                    String objectHTML = "";
                    if (n.senderId.ToString().Equals(userId.ToString()))
                    {
                        objectHTML = createNotificationDiv(n, true);
                    }
                    else
                    {
                        objectHTML = createNotificationDiv(n, false);
                    }
                    notifications_div.InnerHtml += objectHTML;
                }
            }
        }

    }

    protected void send_message(object sender, EventArgs e) {

        string message = chat_area.Value.ToString().Trim();
        if (message != null && message != "")
        {
            Guid receiverId = new Guid(otherUserId.Value.ToString());

            MembershipUser user = Membership.GetUser();
            Guid senderId = (Guid)user.ProviderUserKey;

            Notification notification = new Notification(message, senderId, receiverId, DateTime.Now, 0);
            NotificationDataService.saveNotification(notification);
            
            chat_area.Value = "";
            conversation_div.InnerHtml += createReceiverDiv(notification);
            notifications_multiview.ActiveViewIndex = 0;
        }

    }

    private void showConversation(String uid)
    {
        otherUserId.Value = uid;
        conversation_title.Text = "Conversation with " + UserDataService.getUser(new Guid(uid)).name;
        MembershipUser user = Membership.GetUser();
        Guid myId = (Guid)user.ProviderUserKey;

        List<Notification> notifications_1 = new List<Notification>();
        List<Notification> notifications_2 = new List<Notification>();

        /* sender notifications */
        notifications_1 = NotificationDataService.getConversation(uid, myId.ToString());
        /* receiver notifications (i am the receiver) */
        notifications_2 = NotificationDataService.getConversation(myId.ToString(), uid);

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

        objectHTML += "<div class=\"message_receiver_message\">" + n.message + "</div>";

        /* add date */
        objectHTML += "<div class=\"message_receiver_date\">" + n.sentDate + "</div>";

        objectHTML += "</div><div class=\"ver_space\"></div>";
        return objectHTML;
    }

    private string createSenderDiv(Notification n)
    {
        string objectHTML = "";
        objectHTML += "<div class=\"message_sender_div\">";

        /* add item thumbnail */
        objectHTML += "<img class=\"message_sender_image\">" + "" + "</img>";

        /* add person name */
        objectHTML += "<div class=\"message_sender_user\">" + UserDataService.getUser(n.senderId).name + "</div>";

        objectHTML += "<div class=\"message_sender_message\">" + n.message + "</div>";

        /* add date */
        objectHTML += "<div class=\"message_sender_date\">" + n.sentDate + "</div>";

        objectHTML += "</div><div class=\"ver_space\"></div>";
        return objectHTML;
    }

    private string createNotificationDiv(Notification n, bool sender)
    {
        string objectHTML = "";
        if (sender)
        {
            /* if i'm the sender, put information about the receiving user */
            objectHTML += "<div class=\"notification_div\" onclick=\"javascript:previewchat('" + n.recieverId + "')\" runat=\"server\">";

            /* add item thumbnail */
            objectHTML += "<img class=\"notification_image\" align=\"left\">" + "" + "</img>";

            /* add person name */
            objectHTML += "<div class=\"notification_user\">" + UserDataService.getUser(n.recieverId).name + "</div>";

            /* add message */
            String message = n.message;
            if (n.message.Length > 30)
            {
                message = n.message.Substring(0, 32) + "...";
            }
            objectHTML += "<div class=\"notification_message\">" + message + "</div>";

            /* add date */
            objectHTML += "<div class=\"notification_date\">" + n.sentDate + "</div>";

            objectHTML += "</div></br>";

        }
        else
        {
            /* if i'm the receiver, put information about the sending user */
            objectHTML += "<div class=\"notification_div\" onclick=\"javascript:previewchat('" + n.senderId + "')\" runat=\"server\">";

            /* add item thumbnail */
            objectHTML += "<img class=\"notification_image\" align=\"left\">" + "" + "</img>";

            /* add person name */
            objectHTML += "<div class=\"notification_user\">" + UserDataService.getUser(n.senderId).name + "</div>";

            /* add message */
            String message = n.message;
            if (n.message.Length > 30)
            {
                message = n.message.Substring(0, 32) + "...";
            }
            objectHTML += "<div class=\"notification_message\">" + message + "</div>";

            /* add date */
            objectHTML += "<div class=\"notification_date\">" + n.sentDate + "</div>";

            objectHTML += "</div></br>";
        }
        return objectHTML;


    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        notifications_multiview.ActiveViewIndex = 1;
        
        
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        showConversation(otherUserId.Value);
    }
}