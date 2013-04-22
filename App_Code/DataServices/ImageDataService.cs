using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

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
        SqlCommand cmd = new SqlCommand("SELECT ContentType, ThumbnailData, ThumbnailHeight, ThumbnailWidth FROM Images WHERE ImageId = @ImageId", conn);
        cmd.Parameters.AddWithValue("@ImageId", imageId);
        SqlDataReader reader = cmd.ExecuteReader();
        Image image = null;
        if (reader.Read())
        {
            string contentType = (string)reader["ContentType"];
            byte[] data = (byte[])reader["ThumbnailData"];
            int height = (int)reader["ThumbnailHeight"];
            int width = (int)reader["ThumbnailWidth"];
            image = new Image(imageId, data, contentType, height, width);
        }
        conn.Close();
        return image;
    }
}