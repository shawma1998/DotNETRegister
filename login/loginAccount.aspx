﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginAccount.aspx.cs" Inherits="loginAccount" %>

<!DOCTYPE html>

<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>

    <script src="assests\js\bootstrap.js"></script>
    <link rel="stylesheet" href="assests\css\bootstrap.css">
    <link rel="stylesheet" href="assests\css\style.css">
</head>

<body>

    <nav class="navbar navbar-default" runat="server">
        <div class="container-fluid" runat="server">

            <div class="navbar-header" runat="server">

                <a class="navbar-brand left" href="index.html" runat="server">烧卖网</a>
            </div>

            <ul class="nav navbar-nav navbar-right">
                <li><a href="index.aspx" runat="server">首页</a></li>
                <li><a href="#">关于</a></li>
                <li class="active"><a href="loginAccount.aspx" runat="server">登录</a></li>
            </ul>
        </div>
    </nav>

    <div id="content" class="container">

        <div id="container_bg" class="col-md-6 col-sm-offset-3">

            <form class="form-horizontal" role="form" runat="server">
                <div class="form-group">
                    <label for="firstname" class="col-sm-2 col-sm-offset-1 labelTag ">账号</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="input_userAccount" name="input_userAccount"  placeholder="请输入账户" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="lastname" class="col-sm-2 col-sm-offset-1  labelTag">密码</label>
                    <div class="col-sm-8">
                        <input type="password" id="input_password" name="input_password" class="form-control col-sm-8" required="required"
                            placeholder="请输入密码" title="" runat="server">
                    </div>
                </div>
                <div class="form-group">
                    <label for="checkCode" class="col-sm-2 col-sm-offset-1  labelTag ">验证码</label>
                    <div class="col-sm-4">
                        <input type="text" name="" id="webValidates" class="form-control" required="required"
                            placeholder="请输入验证码" title="" runat="server" >
                    </div>

                    <div class="col-sm-4  text-center">

                    </div>
                </div>

                <div class="">

                    
                     <button type="button"
                        class="btn btn-large col-sm-4 col-sm-offset-1 btn-primary btn_loginPage" OnServerClick="loginUser" runat="server" >
                        登录</button>
                    
                    <button type="button"
                        class="btn btn-large col-sm-4 col-sm-offset-2 btn-default btn_loginPage" OnServerClick="registerUser" runat="server" >
                        注册</button>
                    <br />
                    <br />
                    <br />
                     <button type="button"
                        class="btn btn-large col-sm-4 col-sm-offset-4 btn-default btn_loginPage" OnServerClick="GoForManaUser" runat="server" >
                        前往管理员登陆</button>
                    
                    
                  

                </div>


            </form>

        </div>

    </div>
    <asp:Label ID="Label1" runat="server" Text="Label" Visible="false"></asp:Label>

</body>

</html>

