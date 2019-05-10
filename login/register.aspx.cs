using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class register : System.Web.UI.Page
{



    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitAccount(object sender, EventArgs e)
    {
        string _account = UserAccount.Value;
        string _name = UserName.Value;
        string _pass = password.Value;
        string _confirPass = comfirnPassword.Value;
        string _birthday = birthday.Value;
        string _sex = Request.Form["sexual"].ToString();
        List<String> UserInfo = new List<string>();
        UserInfo.Add("");
        UserInfo.Add(_account);
        UserInfo.Add(_name);
        UserInfo.Add(_birthday);
        UserInfo.Add(_sex);
        UserInfo.Add(_pass);
        if (_pass != _confirPass)
        {
            Response.Write("<script>alert('请确认两次密码一致')</script>");
            return;
        }
        else {
            int lifluCount = DataBaseTools.Insert("User", UserInfo);
            if (lifluCount == 1) {
                Session["UserAccount"] = _account;

                Response.Write("<script>alert('注册成功')</script>");
                Response.Redirect("userIndex.aspx");
            }
            if (lifluCount == -1) {
                Response.Write("<script>alert('用户名已存在')</script>");
            }
        }
        
    }
}