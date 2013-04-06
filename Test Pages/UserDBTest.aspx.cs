using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Pages_UserDBTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        User user = UserDataService.getUser("Ben");
        info.Text = user.name + " " + user.password;

        UserController user_controller = new UserController();
        User new_user = user_controller.getUser("hello");
        test.Text = new_user.name + " " + new_user.password;



    }
}