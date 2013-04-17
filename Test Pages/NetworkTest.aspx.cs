using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Test_Pages_NetworkTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Network network = new Network("Boston", "Pattern");
        Network newNetwork = NetworkDataService.addNetwork(network);
        network_id.Text = newNetwork.id.ToString();
        
    }
}