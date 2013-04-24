using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Drawing;

public partial class Views_Private_GarageSale : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        int[] hours = {12, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
        if (!IsPostBack)
        {
            foreach (int i in hours) {
                for (int j = 0; j < 4; j++)
                {
                    begin_time_list.Items.Add(i + ":" + (j*15).ToString().PadLeft(2,'0') + " AM");
                    end_time_list.Items.Add(i + ":" + (j * 15).ToString().PadLeft(2, '0') + " AM");
                }
            }
            foreach (int i in hours)
            {
                for (int j = 0; j < 4; j++)
                {
                    begin_time_list.Items.Add(i + ":" + (j * 15).ToString().PadLeft(2, '0') + " PM");
                    end_time_list.Items.Add(i + ":" + (j * 15).ToString().PadLeft(2, '0') + " PM");
                }
            }
            date_cal.SelectedDate = DateTime.Now;
            begin_time_list.SelectedIndex = 0;
            end_time_list.SelectedIndex = 0;

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (begin_time_list.SelectedIndex >= 0
            && date_cal.SelectedDate != null
            && end_time_list.SelectedIndex >= 0
            && textbox_location.Value != "" 
            && textbox_description.Value != "")
        {
            try
            {                
                string address = textbox_location.Value.ToString();
                string description = textbox_description.Value.ToString();
                

                DateTime begintime = date_cal.SelectedDate.Date + DateTime.Parse(begin_time_list.SelectedValue).TimeOfDay;
                DateTime endtime = date_cal.SelectedDate.Date + DateTime.Parse(end_time_list.SelectedValue).TimeOfDay;

                if (date_cal.SelectedDate.CompareTo(DateTime.Now) < 0) throw new InvalidDataException("You cannot create a garage sale in the past");
                if (endtime.CompareTo(begintime) <= 0) throw new InvalidDataException("End Time is before start time");
                MembershipUser user = Membership.GetUser();
                Guid userId = (Guid)user.ProviderUserKey;

                Garage garageSale = new Garage(userId, begintime, endtime, address, description);

                if (imageUpload.HasFile)
                {
                    int imageId = saveImageFile();
                    garageSale.imageId = imageId;
                }

                garageSale = GarageDataService.addGarageSale(garageSale);

                textbox_description.Value = "";
                textbox_location.Value = "";
                begin_time_list.SelectedIndex = 0;
                end_time_list.SelectedIndex = 0;
                date_cal.SelectedDate = DateTime.Now;

                creategarage_output.Text = "Garage Sale created successfully!";
                creategarage_output.Style.Add("color", "#00ff00");
            }
            catch (Exception ex)
            {
                creategarage_output.Text = ex.Message;
            }


        }
         else
        {
            bool b1 = begin_time_list.SelectedIndex > 0;
            bool b2 = (date_cal.SelectedDate != null);
            bool b3 = (end_time_list.SelectedIndex > 0);
            bool b4 = (textbox_location.Value != ""); 
            bool b5 = (textbox_description.Value != "");
            /* Please fill all fields */
            creategarage_output.Text = "Please fill all of the fields.";
            creategarage_output.Style.Add("color", "#ff0000");

        }
    }
    private int saveImageFile()
    {
        string ext = Path.GetExtension(imageUpload.PostedFile.FileName).ToLower();
        string contentType = "";
        switch (ext)
        {
            case ".jpg":
            case ".jpeg":
                contentType = "image/jpg";
                break;
            case ".png":
                contentType = "image/png";
                break;
            case ".gif":
                contentType = "image/gif";
                break;
            case ".bmp":
                contentType = "image/bmp";
                break;
        }

        Stream stream = imageUpload.PostedFile.InputStream;
        BinaryReader binReader = new BinaryReader(stream);
        byte[] data = binReader.ReadBytes(Convert.ToInt32(stream.Length));
        System.Drawing.Image temp = System.Drawing.Image.FromStream(stream);
        int width = (int)temp.Width;
        int height = (int)temp.Height;
        temp.Dispose();

        int thumbWidth = 100;
        int thumbHeight = thumbWidth * (int)((double)width / (double)height);

        System.Drawing.Image thumb = System.Drawing.Image.FromStream(stream);
        Bitmap tempThumb = new Bitmap(thumb, thumbWidth, thumbHeight);
        Graphics g = Graphics.FromImage(tempThumb);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        g.DrawImage(thumb, 0, 0, tempThumb.Width, tempThumb.Height);
        MemoryStream memStream = new MemoryStream();
        tempThumb.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
        byte[] thumbData = memStream.ToArray();

        thumb.Dispose();
        tempThumb.Dispose();
        g.Dispose();
        Image fullImage = new Image(data, contentType, height, width);
        Image thumbImage = new Image(thumbData, "image/jpg", thumbHeight, thumbWidth);
        return ImageDataService.addImage(fullImage, thumbImage);
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        
        garagesale_view.ActiveViewIndex = 0;
        loadGarageSales();

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        garagesale_view.ActiveViewIndex = 1;
    }

    private void loadGarageSales()
    {
        List<Garage> garages = GarageDataService.getGarageSales();
        String objectHTML = garages.Count + " Found In Your Area";
        foreach(Garage garage in garages)
        {
            objectHTML += createGarageDiv(garage);
        }
        garagesales.InnerHtml = objectHTML;
    }
    private String createGarageDiv(Garage garage)
    {
        string objectHTML = "</br></br><div class=\"garage_item_div\">";
        
        objectHTML += "<div class=\"garage_item_img\"><img width=\"200px\" height=\"200px\" src=\"../../Helpers/GetImage.ashx?ID=" + garage.imageId + "\"></img></div>";
        objectHTML += "<div class=\"garage_item_desc\"><div class=\"garage_item_user\">" + UserDataService.getUser(garage.userID).name + "</div>";
        objectHTML += "<div class=\"garage_item_description\">" + garage.Description + "</div>";
        objectHTML += "<div class=\"garage_item_datebegin\">From: " + garage.DateBegin + "</div>";
        objectHTML += "<div class=\"garage_item_dateend\">To: " + garage.DateEnd + "</div>";
        objectHTML += "<div class=\"garage_item_address\">Address: " + garage.Address + "</div>";

        objectHTML += "</div></div></br></br>";

        return objectHTML;

    }
}