using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.IO;
using System.Drawing;

public partial class Views_Private_UpdatePost : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (string.IsNullOrEmpty(Request.QueryString["L"]))
            {
                Response.Redirect("~/Views/Error.aspx?e_code=404");
                return;
            }

            int listingId = 0;
            try
            {
                listingId = Convert.ToInt32(Request.QueryString["L"]);
            }
            catch
            {
                Response.Redirect("~/Views/Error.aspx?e_code=400");
                return;
            }

            Listing listing = ListingDataService.getListing(listingId.ToString());
            if (listing == null)
            {
                Response.Redirect("~/Views/Error.aspx?e_code=404");
                return;
            }

            original_imageid.Value = listing.imageId.ToString();
            textbox_title.Text = listing.title;
            textbox_description.Value = listing.description;
            textbox_price.Text = listing.price.ToString();
            textbox_location.Text = listing.location;
            List<Tag> tags = TagDataService.getTagsFromListing(listing);
            string tag_string = "";
            foreach (Tag t in tags)
            {
                tag_string += t.name + " ";
            }

            textbox_tags.Text = tag_string;

            image_preview.ImageUrl = "~/Helpers/GetImage.ashx?ID=" + listing.imageId;
        }
               
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        if (textbox_title.Text != ""
            && textbox_price.Text != ""
            && textbox_description.Value != ""
            && textbox_location.Text != ""
            && textbox_tags.Text != "")
        {
            string title = textbox_title.Text;
            decimal price = 0;
            try
            {
                price = Convert.ToDecimal(textbox_price.Text);
                string description = textbox_description.Value.ToString();
                string location = textbox_location.Text;
                string tags = textbox_tags.Text;


                Listing oldListing = ListingDataService.getListing(Request.QueryString["L"]);
                oldListing.title = title;
                oldListing.description = description;
                oldListing.price = price;
                oldListing.location = location;
                
                if (imageUpload.HasFile)
                {
                    int oldImageId = oldListing.imageId;
                    oldListing.imageId = saveImageFile();
                    ImageDataService.deleteImage(oldImageId);
                }

                bool success = ListingDataService.updateListing(oldListing.ListingId.ToString(), oldListing);

                List<Tag> oldTags = TagDataService.getTagsFromListing(oldListing);
                List<String> oldTagNames = oldTags.Select(g => g.name).ToList();
                /* save the tags along with the listing id */
                string[] words = textbox_tags.Text.Trim().Split(' ');
                foreach (string word in words)
                {
                    if(oldTagNames.Contains(word)) {
                        oldTagNames.Remove(word);
                        continue;
                    }
                    Tag newTag = TagDataService.createNewTag(word);
                    ListingDataService.addListingTag(oldListing, newTag);
                }

                foreach (string tagName in oldTagNames)
                {
                    Tag tag = oldTags.First(t => t.name == tagName);
                    ListingDataService.deleteListingTag(oldListing, tag);                    
                }               

                addlisting_output.Text = "Listing updated successfully!";
                addlisting_output.Style.Add("color", "#00ff00");
            }
            catch (Exception ex)
            {

                addlisting_output.Style.Add("color", "#ff0000");
                if (ex is OverflowException)
                {
                    addlisting_output.Text = "Please enter a smaller price value.";
                }
                else if (ex is FormatException)
                {
                    addlisting_output.Text = "Please enter a valid price value.";
                }
                else
                {
                    addlisting_output.Text = ex.Message;
                }
            }

        }
        else
        {
            /* Please fill all fields */
            addlisting_output.Text = "Please fill all of the fields.";
            addlisting_output.Style.Add("color", "#ff0000");

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