using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userIndex : System.Web.UI.Page
{
    private string _userAccount;
    private Dictionary<String,String> _UserInfoDictionary;
    protected string UserNameInNav = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        _userAccount = Session["UserAccount"].ToString();

        _UserInfoDictionary = DataBaseTools.getInfoByAccount(_userAccount);

        UserNameInNav = _UserInfoDictionary["UserName"];
    }


}