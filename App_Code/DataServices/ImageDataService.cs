using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ImageDataService
/// </summary>
public class ImageDataService
{

    public static Image getFullImage(int imageId)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ContentType, Data, ImageHeight, ImageWidth FROM Images WHERE ImageId = @ImageId", conn);
        cmd.Parameters.AddWithValue("@ImageId", imageId);
        SqlDataReader reader = cmd.ExecuteReader();
        Image image = null;
        if (reader.Read())
        {
            string contentType = (string)reader["ContentType"];
            byte[] data = (byte[])reader["Data"];
            int height = (int)reader["ImageHeight"];
            int width = (int)reader["ImageWidth"];
            image = new Image(imageId, data, contentType, height, width);
        }
        conn.Close();
        return image;
    }


    public static Image getThumbnail(int imageId)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ThumbnailData, ThumbnailHeight, ThumbnailWidth FROM Images WHERE ImageId = @ImageId", conn);
        cmd.Parameters.AddWithValue("@ImageId", imageId);
        SqlDataReader reader = cmd.ExecuteReader();
        Image image = null;
        if (reader.Read())
        {
//            string contentType = (string)reader["ContentType"];
            byte[] data = (byte[])reader["ThumbnailData"];
            int height = (int)reader["ThumbnailHeight"];
            int width = (int)reader["ThumbnailWidth"];
            image = new Image(imageId, data, "image/jpg", height, width);
        }
        conn.Close();
        return image;
    }

    public static int addImage(Image fullImage, Image thumb)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("INSERT INTO Images (ContentType, Data, ImageHeight, ImageWidth, Thumbnail, ThumbnailHeight, ThumbnailWidth)" +
        "VALUES (@ContentType, @Data, @ImageHeight, @ImageWidth, @Thumbnail, @ThumbnailHeight, @ThumbnailWidth); SELECT CONVERT(int, SCOPE_IDENTITY())", conn);
        cmd.Parameters.AddWithValue("@ContentType", fullImage.contentType);
        cmd.Parameters.Add("@Data", SqlDbType.Binary).Value = fullImage.data;
        cmd.Parameters.AddWithValue("@ImageHeight", fullImage.height);
        cmd.Parameters.AddWithValue("@ImageWidth", fullImage.width);
        cmd.Parameters.Add("@Thumbnail", SqlDbType.Binary).Value = thumb.data;
        cmd.Parameters.AddWithValue("@ThumbnailHeight", thumb.height);
        cmd.Parameters.AddWithValue("@ThumbnailWidth", thumb.width);

        int id = Convert.ToInt32(cmd.ExecuteScalar());
        conn.Close();
        return id;
    }

    public static Boolean deleteImage(int imageid)
    {
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("DELETE FROM Images WHERE ImageId = @ImageId", conn);
        cmd.Parameters.AddWithValue("@ImageId", imageid);
        int rowsAffected = cmd.ExecuteNonQuery();
        conn.Close();
        return (rowsAffected > 0);
    }
}