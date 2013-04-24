using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string error_code = Request.QueryString["e_code"];

        switch (error_code)
        {
            case "400":
            case "401":
            case "404":
            case "403":
                error_image.ImageUrl = "~/public/img/errors/forbidden.jpg";
                error_caption.Text = " Where do you think you're going? ";                
                error_description.Text = "403: You are forbidden from accessing this page";
                error_description.Text += "<br />Try logging in";
                break;
            case "500":
                error_image.ImageUrl = "~/public/img/errors/server_error_500.jpg";
                error_caption.Text = " Well this is embarrassing.....  We dun goof";
                error_description.Text = "500: Internal Server Error";
                error_description.Text += "<br /> ... our bad";
                break;
            default:
                break;
        }

    }
}