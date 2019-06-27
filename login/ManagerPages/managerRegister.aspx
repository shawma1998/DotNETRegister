<%@ Page Language="C#" AutoEventWireup="true" CodeFile="managerRegister.aspx.cs" Inherits="ManagerPages_managerRegister" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>

    <script src="..\assests\js\utils.js"></script>
    <script src="..\assests\js\tether.js"></script>
    <script src="..\assests\js\jquery-3.3.1.js"></script>
    <script src="..\assests\js\bootstrap.js"></script>
    <script src="..\assests\js\UnserIndexScript\userInfo.js"></script>
    <link rel="stylesheet" href="..\assests\css\bootstrap.css">
    <link rel="stylesheet" href="..\assests\css\style.css">
    <link href="..\assests\css\awsome-checkbox.css" rel="stylesheet" />
    <script>

    

    </script>

</head>

<body>
    <nav class="navbar navbar-default">
        <div class="container-fluid">

            <div class="navbar-header">

                <a class="navbar-brand left" href="../index.aspx">烧卖网</a>
            </div>

            <ul class="nav navbar-nav navbar-right">
                <li><a href="../index.aspx">首页</a></li>

                <li class="icon-white" >
                    <a href="managerLogin.aspx"  onclick="logout">
                        <span class="glyphicon glyphicon-log-out userInfo"></span>
                        &nbsp;&nbsp;
                    </a>
                </li>
            </ul>
        </div>
    </nav>



    <div class="container col-md-2   ">
        <div class="row">
            <div class="span2">
                <ul class="nav nav-pills nav-stacked">
                    <li><a href="managerUser.aspx">用户管理</a></li>
                    <li><a href="managerRegister.aspx">用户注册</a></li>
                    <li><a href="managerUpLoad.aspx">批量注册</a></li>
                    <li><a href="managerMenuManager.aspx">分类管理</a></li>
                    <li><a href="managerArt.aspx">文章管理</a></li>
                    <li><a href="managerEvaluate.aspx">评价管理</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container col-md-10">

        <form id="form1" runat="server">
            <div>
                 <fieldset id="fieldset">
                     
                     <br />
                    <div class="form-group " class="col-sm-6">
                        <label for="name" class="col-sm-2  labelTag ">账号</label>
                        <div class="col-sm-4">
                            <input type="text" class="form-control " id="UserAccount" placeholder="请输入账号" runat="server" name="userAccount">
                        </div>
                    </div>
                     <br />
                     <br />
                    <div class="form-group ">
                        <label for="name" class="col-sm-2 labelTag ">名字</label>
                        <div class="col-sm-4">
                            <input type="text" class="form-control " id="UserName" placeholder="请输入名字" runat="server" name="username">
                        </div>
                    </div>
                     <br />
                     <br />
                    <div class="form-group">
                        <label for="password" class="col-sm-2  labelTag">密码</label>
                        <div class="col-sm-4">
                            <input type="password" name="password" id="password" class="form-control col-sm-8" required="required"
                                placeholder="请输入密码" title="" runat="server">
                        </div>
                    </div>
                     <br />
                     <br />
                    <div class="form-group">
                        <label for="password" class="col-sm-2  labelTag">确认密码</label>
                        <div class="col-sm-4">
                            <input type="password" name="comfirnPassword" id="comfirnPassword" class="form-control col-sm-8" required="required"
                                placeholder="确认密码" title="" runat="server">
                        </div>
                    </div>
                     <br />
                     <br />
                    <div class="form-group">
                        <label for="name" class="col-sm-2  labelTag ">生日</label>
                        <div class="col-sm-4">

                            <input type="Date" class="form-control" id="birthday" name="birthdatDate" required="required" runat="server">
                        </div>
                    </div>
                     
                     <br />
                     <br />
                    <div class="form-group">
                        <label for="password" class="col-sm-2 labelTag">选择性别</label>
                        <div class="col-sm-4">
                            <div class="radio radio-inline radio-primary">
                                <input class="radio-primary" type="radio" name="sexual" id="inlineRadio1"
                                    value="1" checked runat="server">
                                <label class="form-check-label" for="inlineRadio1">男</label>
                            </div>
                            <div class="radio radio-inline radio-primary">
                                <input class="radio-primary" type="radio" name="sexual" id="inlineRadio2"
                                    value="0" runat="server">
                                <label class="form-check-label" for="inlineRadio2">女</label>
                            </div>
                        </div>
                    </div>
                     
                     <br />
                     <br />
                     <br />
                     <input type="button" id="btn_submit" class="btn btn-primary btn-lg col-sm-5 col-sm-offset-1"  OnServerClick ="submitManaAccount"  value="注册" runat="server"/>
                </fieldset>
               
            </div>

        </form>

    </div>






</body>

</html>
