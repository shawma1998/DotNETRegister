using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userInfo : System.Web.UI.Page
{

    private string _UserAccount;
    private Dictionary<String,String> _UserInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        _UserAccount = Session["UserAccount"].ToString();
        
    }
}