using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userInfo : System.Web.UI.Page
{

    private string _UserAccount;
    private Dictionary<String,String> _UserInfoDictionary;
    protected string UserNameInNav = "";
    protected string UserSex = "";



    protected void Page_Load(object sender, EventArgs e)
    {
        _UserAccount = Session["UserAccount"].ToString();

        _UserInfoDictionary = DataBaseTools.getInfoByAccount(_UserAccount);

        setInfoToForm(_UserInfoDictionary);


    }

    private void setInfoToForm(Dictionary<string, string> userInfoDictionary)
    {
        Name.Value = userInfoDictionary["UserName"];
        Password.Value = userInfoDictionary["UserPassWord"];
        ConfirmPassWord.Value = userInfoDictionary["UserPassWord"];
        birthday.Value = userInfoDictionary["UserBirth"];
        UserSex = userInfoDictionary["UserSex"];
        UserNameInNav = userInfoDictionary["UserName"];


    }

    protected void submitToServer(object sender, EventArgs e) {

        if (Request.Form["ConfirmPassWord"].ToString() == Request.Form["PassWord"].ToString())
        {
            _UserInfoDictionary = null;
            _UserInfoDictionary = new Dictionary<string, string>();
            _UserInfoDictionary.Add("UserAccount", _UserAccount);
            _UserInfoDictionary.Add("UserName", Name.Value);
            _UserInfoDictionary.Add("UserPassWord", Request.Form["ConfirmPassWord"].ToString());
            _UserInfoDictionary.Add("UserBirth", Request.Form["birthday"].ToString());
            _UserInfoDictionary.Add("UserSex", Request.Form["sexual"].ToString());
            DataBaseTools.SubmitData(_UserInfoDictionary);
            Response.Write("<script>alert('修改成功')</script>");
        }
        else {
            Response.Write("<script>alert('两次输入密码不一致')</script>");
        }
       

    }
}