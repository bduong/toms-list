<%@ WebHandler Language="C#" Class="GetThumbnail" %>

using System;
using System.Web;
using System.Data.SqlClient;

public class GetThumbnail : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if (!string.IsNullOrEmpty(context.Request.QueryString["ID"]) && context.Request.QueryString["ID"] != "0")
        {
            SqlConnection conn = DBConnector.getSqlConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT Thumbnail FROM Images where ImageId = @ImageId", conn);
            cmd.Parameters.AddWithValue("@ImageId", context.Request.QueryString["ID"]);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                context.Response.ContentType = "image/jpg";
                context.Response.BinaryWrite((byte[])reader["Thumbnail"]);
            }
            else
            {
                context.Response.Write(HttpContext.Current.Server.MapPath("~/public/img/grey_wash_wall.png"));
                context.Response.ContentType = "image/png";
            }
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}