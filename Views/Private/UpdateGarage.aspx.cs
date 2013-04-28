using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Drawing;

public partial class Views_Private_UpdateGarage : System.Web.UI.Page
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
            if (string.IsNullOrEmpty(Request.QueryString["G"]))
            {
                Response.Redirect("~/Views/Error.aspx?e_code=404");
                return;
            }


            int garageId = 0;
            try
            {
                garageId = Convert.ToInt32(Request.QueryString["G"]);
            }
            catch
            {
                Response.Redirect("~/Views/Error.aspx?e_code=400");
                return;
            }
            Garage garage = GarageDataService.getGarageSale(garageId.ToString());
            
            if (garage == null)
            {
                Response.Redirect("~/Views/Error.aspx?e_code=404");
                return;
            }
            
            original_imageid.Value = garage.imageId.ToString();
            date_cal.SelectedDate = garage.DateBegin.Date;
            date_cal.VisibleDate = garage.DateBegin.Date;
            begin_time_list.SelectedValue = String.Format("{0:h:mm tt}" ,garage.DateBegin);
            end_time_list.SelectedValue = String.Format("{0:h:mm tt}", garage.DateEnd);
            textbox_location.Value = garage.Address;
            textbox_description.Value = garage.Description;

            image_preview.ImageUrl = "~/Helpers/GetImage.ashx?ID=" + garage.imageId;
        }

    }
    protected void Update_Click(object sender, EventArgs e)
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

                Garage oldGarage = GarageDataService.getGarageSale(Request.QueryString["G"]);

                oldGarage.Address = address;
                oldGarage.DateBegin = begintime;
                oldGarage.DateEnd = endtime;
                oldGarage.Description = description;
                
                if (imageUpload.HasFile)
                {
                    int oldImageId = oldGarage.imageId;
                    oldGarage.imageId = saveImageFile();
                    ImageDataService.deleteImage(oldImageId);
                }
                bool success = GarageDataService.updateGarageSale(oldGarage.GarageID.ToString(), oldGarage);
                

                updategarage_output.Text = "Garage Sale updated successfully!";
                updategarage_output.Style.Add("color", "#00ff00");
                Response.Redirect("~/Views/Private/GarageSale.aspx?View=" + 3);
            }
            catch (Exception ex)
            {
                updategarage_output.Text = ex.Message;
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
            updategarage_output.Text = "Please fill all of the fields.";
            updategarage_output.Style.Add("color", "#ff0000");
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

    protected void do_delete_Click(object sender, EventArgs e)
    {
        Garage garage = GarageDataService.getGarageSale(Request.QueryString["G"]);
        ImageDataService.deleteImage(garage.imageId);
        GarageDataService.deleteGarageSale(garage.GarageID.ToString());
        Response.Redirect("~/Views/Search.aspx");

    }
}