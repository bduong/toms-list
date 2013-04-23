using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Drawing;

public partial class Views_UpdateProfile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                Guid AspUserId = (Guid)Membership.GetUser().ProviderUserKey;
                User user = UserDataService.getUser(AspUserId);

                NameLabel.Text = user.name;
                LocationTextBox.Text = user.location;
                EmailTextBox.Text = user.email;
                user_photo.ImageUrl = "~/Helpers/GetImage.ashx?ID=" + user.imageId;
            }
            catch (Exception)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
        }

    }
    protected void ChangeInfo_Click(object sender, EventArgs e)
    {
        try
        {
            MembershipUser AspUser = Membership.GetUser();
            Guid AspUserId = (Guid)Membership.GetUser().ProviderUserKey;
            User user = UserDataService.getUser(AspUserId);

            user.location = LocationTextBox.Text;
            user.email = EmailTextBox.Text.ToString();
            AspUser.Email = user.email.ToString();
            if (imageUpload.HasFile)
            {
                int oldImageId = user.imageId;                
                user.imageId = saveImageFile();
                ImageDataService.deleteImage(oldImageId);
            }
            Membership.UpdateUser(AspUser);
            UserDataService.updateUser(user.uid, user);
            string url = ResolveUrl("~/Views/Private/Profile.aspx");
            Response.Redirect(url);
        }
        catch (System.NullReferenceException)
        {
            Response.Redirect("~/Views/Login.aspx");
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
}