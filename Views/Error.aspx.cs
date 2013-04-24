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
            case "403":
                error_image.ImageUrl = "~/public/img/errors/forbidden.jpg";
                error_caption.Text = " Where do you think you're going? ";                
                error_description.Text = "403: You are forbidden from accessing this page";
                error_description.Text += "<br />Try logging in";
                break;
            default:
                break;
        }

    }
}