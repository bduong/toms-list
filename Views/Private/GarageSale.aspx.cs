using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Views_Private_GarageSale : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (textbox_begin.Text != ""
            && textbox_date.Text != ""
            && textbox_end.Text != ""
            && textbox_location.Text != "")
        {
            try
            {

                string[] dateday = textbox_date.Text.Split('/');
                string[] datetime_begin = textbox_begin.Text.Split(':');
                string[] datetime_end = textbox_end.Text.Split(':');
                
                DateTime begintime = new DateTime(Convert.ToInt32(dateday[0]), Convert.ToInt32(dateday[1]), Convert.ToInt32(dateday[2]), Convert.ToInt32(datetime_begin[0]), Convert.ToInt32(datetime_begin[1]), 0);
                DateTime endtime = new DateTime(Convert.ToInt32(dateday[0]), Convert.ToInt32(dateday[1]), Convert.ToInt32(dateday[2]), Convert.ToInt32(datetime_end[0]), Convert.ToInt32(datetime_end[1]), 0);

                MembershipUser user = Membership.GetUser();
                Guid userId = (Guid)user.ProviderUserKey;

                Garage mygarage = new Garage(userId, begintime, endtime, textbox_location.Text, textbox_description.Value);

                Garage newgarage = GarageDataService.addGarageSale(mygarage);


                textbox_begin.Text = "";
                textbox_date.Text = "";
                textbox_end.Text = "";
                textbox_location.Text = "";
                textbox_description.Value = "";

                creategarage_output.Text = "Garage Sale successfully created!";
                creategarage_output.Style.Add("color", "#00ff00");
            }
            catch (Exception ex)
            {
                creategarage_output.Text = ex.Message;
            }


        }
    }
}