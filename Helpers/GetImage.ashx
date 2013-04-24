<%@ WebHandler Language="C#" Class="GetImage" %>

using System;
using System.Web;
using System.Data.SqlClient;

public class GetImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        if(string.IsNullOrEmpty(context.Request.QueryString["ID"])) throw new HttpException(400, "Bad Request: Missing ID");
        SqlConnection conn = DBConnector.getSqlConnection();
        conn.Open();
        SqlCommand cmd = new SqlCommand("SELECT ContentType, Data FROM Images where ImageId = @ImageId",conn);
        cmd.Parameters.AddWithValue("@ImageId", context.Request.QueryString["ID"]);
        SqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read()) {
            context.Response.ContentType = (string) reader["ContentType"];
            context.Response.BinaryWrite((byte[])reader["Data"]) ;
        } else {
            context.Response.Write(HttpContext.Current.Server.MapPath("~/public/img/grey_wash_wall.png"));
            context.Response.ContentType = "image/png";
        }                
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}