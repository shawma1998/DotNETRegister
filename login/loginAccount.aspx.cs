﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class loginAccount :  System.Web.UI.Page
{

    private int login_result;
    private string _userAccount;
    private string  _passWord;
    protected void Page_Load(object sender, EventArgs e)
    {
        /*
        List<String> list = new List<String> ();
        list.Add("");
        list.Add("23343");
        list.Add("大苏打撒");
        list.Add("1998-08-01");
        list.Add("1");
        list.Add("121212");
        */


        // Label1.Text = DataBaseTools.Insert("User", list).ToString();


    }


    protected void loginUser(object sender, EventArgs e)
    {

        _userAccount = Request.Form["input_userAccount"];
        _passWord = Request.Form["input_password"];
        
        login_result = DataBaseTools.LoginForUser(_userAccount, _passWord);

        if (login_result == 1)
        {

            Session["UserAccount"] = _userAccount;
            Response.Redirect("userIndex.aspx");
            return;
        }
        else {
            Response.Write("<script>alert('账号或者密码出错');</script>");
            return;
        }
    }

    protected void registerUser(object sender, EventArgs e) {

        Response.Redirect("register.aspx");
    }
    protected void GoForManaUser(object sender, EventArgs e) {

        Response.Redirect("ManagerPages/managerLogin.aspx");
    }

    
}