using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managerLogin : System.Web.UI.Page
{
    private int login_result;
    private string _userAccount;
    private string _passWord;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack) {
            Session.Abandon();
            Session.Clear();
            Response.Write("ddddd");
        }
        
    }

    protected void loginManager(object sender, EventArgs e)
    {
        _userAccount = Request.Form["input_userAccount"];
        _passWord = Request.Form["input_password"];

        login_result = DataBaseTools.LoginForManager(_userAccount, _passWord);


        if (login_result == 1)
        {
            Response.Redirect("managerUser.aspx");

        }
        else {

            Response.Write("<script>alert('账户密码错误')</script>");
        }
    }

}