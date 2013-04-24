using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.IO;
using System.Web.Security;

public partial class Views_Private_Networks : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (User.Identity.IsAuthenticated)
        {

            MembershipUser user = Membership.GetUser();
            Guid userId = (Guid)user.ProviderUserKey;

            String username = (UserDataService.getUser(userId)).name;
            if (username == "admin")
            {
                addnetwork_name.Visible = true;
                addnetwork_pattern.Visible = true;
                addnetwork_button.Visible = true;
            }
        }
    }

    protected void Do_Search_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        string searchPattern = Network_Search.Text;
        Network_Search.Text = "";
        List<Network> networks = NetworkDataService.searchForNetworksByName(searchPattern);        
        Results.Items.Clear();
        foreach (Network n in networks)
        {
            Results.Items.Add(new ListItem(n.name, n.id.ToString()));
        }
        if (networks.Count > 0)
        {
            Join.Visible = true;
        }
        else
        {
            Join.Visible = false;
        }
    }

    protected void Join_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        if(Results.SelectedIndex >= 0) {
            int networkId = Convert.ToInt32(Results.SelectedValue);
            Network network = NetworkDataService.getNetwork(networkId);
            Domain.Text = "Email Domain Required: " + network.pattern;
            Email.Text = "";
            toggleVisibilityOfJoinControls(true);            
        }

    }

    private void toggleVisibilityOfJoinControls(Boolean visible)
    {        
        Results.Enabled = !visible;        
        Domain.Visible = visible;
        Info.Visible = visible;
        Email.Visible = visible;
        Send.Visible = visible;
        Cancel.Visible = visible;
    }

    protected void Send_Click(object sender, EventArgs e)
    {
        int networkId = Convert.ToInt32(Results.SelectedValue);
        Network network = NetworkDataService.getNetwork(networkId);

        string email = Email.Text;
        try
        {
            new MailAddress(email);
        }
        catch
        {
            ErrorMessage.Text = "Not a valid email address";
            return;
        }

        if (email.EndsWith("@" + network.pattern, false, null))
        {
            ErrorMessage.Text = "Verification Email Sent!";
            sendMail(email, network);
        }
        else
        {
            ErrorMessage.Text = "Email does belong to the correct domain";
        }
    }

    protected void Cancel_Click(object sender, EventArgs e)
    {
        ErrorMessage.Text = "";
        toggleVisibilityOfJoinControls(false);
    }

    private void sendMail(string email, Network network)
    {
        MailMessage mailMessage = new MailMessage();
        mailMessage.From = new MailAddress("toms.list.verify@gmail.com");
        mailMessage.Subject = "Network Verification";
        mailMessage.To.Add(new MailAddress(email));
        string body = "";
        using (StreamReader reader = new StreamReader(Server.MapPath("~/Templates/AddNetworkTemplate.html")))
        {
            body = reader.ReadToEnd();
        }

        MembershipUser user = Membership.GetUser();
        Guid userId = (Guid) user.ProviderUserKey;
        body = body.Replace("<%UserName%>", user.UserName);
        body = body.Replace("<%NetworkName%>", network.name);

        string baseUrl =  Request.Url.GetLeftPart(UriPartial.Authority) + (Request.ApplicationPath.Equals("/") ? "" : Request.ApplicationPath);
        string verifyUrl = "/Views/Private/NetworkVerify.aspx?ID="+ userId.ToString() + "&N="+network.id.ToString();

        body = body.Replace("<%VerifyUrl%>", baseUrl+verifyUrl);
        mailMessage.Body = body;
        mailMessage.IsBodyHtml = true;

        new SmtpClient().Send(mailMessage);
    }
    protected void addnetwork_button_Click(object sender, EventArgs e)
    {
        if (addnetwork_name.Text != "" && addnetwork_pattern.Text != "")
        {
            String name = addnetwork_name.Text;
            bool exists = false;
            for (int i = 0; i < Results.Items.Count; i++)
            {
                if(Results.Items[i].Text.Equals(name) ){
                    exists = true;
                    break;
                }
            }
            if(exists) {
                addnetwork_label.Text = "Network already exists!";
            }
            else {
                Network network = new Network(addnetwork_name.Text.ToString(), addnetwork_pattern.Text.ToString());
                Network savedNetwork = NetworkDataService.addNetwork(network);
                // Results.Items.Add(new ListItem(savedNetwork.name, savedNetwork.id.ToString()));
                addnetwork_label.Text = "Network Added Successfully!";
            }
            
        }
        else
        {
            addnetwork_label.Text = "Please fill in both fields";
        }
    }
}