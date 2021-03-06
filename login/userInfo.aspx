﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userInfo.aspx.cs" Inherits="userInfo" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>

    <script src="assests\js\jquery-3.3.1.js"></script>
    <script src="assests\js\bootstrap.js"></script>
    <script src="assests\js\UnserIndexScript\userInfo.js"></script>
    <link rel="stylesheet" href="assests\css\bootstrap.css">
    <link rel="stylesheet" href="assests\css\style.css">
    <link href="https://cdn.bootcss.com/awesome-bootstrap-checkbox/v0.2.3/awesome-bootstrap-checkbox.css"
        rel="stylesheet">
    <link href="https://cdn.bootcss.com/awesome-bootstrap-checkbox/v0.2.3/awesome-bootstrap-checkbox.min.css"
        rel="stylesheet">

    <script>


        $(document).ready(function () {

            var sex = $("#hideSexArea").val();
            var radios = document.getElementsByName("sexual");
            if (sex == "True") {
                radios[0].checked = true;
            } else {
                radios[1].checked = true;
            }

            $("#btn_submit").hide();
            $("#btn_modify").click(function () {
                $("#btn_modify").hide();
                $("#btn_submit").show();
                //表单显示可编辑

                $("#fieldset").attr("disabled", false);

            });

            $("#btn_submit").click(function () {
                $("#btn_submit").hide();
                $("#btn_modify").show();


                //表单显示不可编辑
                $("#fieldset").attr("disabled", true);
            });



        });

    </script>
</head>

<body>
    <form class="form-horizontal" role="form" runat="server">
        <nav class="navbar navbar-default">
            <div class="container-fluid">

                <div class="navbar-header">

                    <a class="navbar-brand left" href="index.aspx">烧卖网</a>
                </div>

                <ul class="nav navbar-nav navbar-right">
                    <li><a href="userIndex.aspx">首页</a></li>
                    <li><a href="">关于</a></li>
                    <li><a href="">早上好，<span id="userNameNav"><%=UserNameInNav%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></li>
                    <li class="icon-white active">
                        <a href="#">

                            <span class="glyphicon glyphicon-user userInfo"></span>
                        </a>
                    </li>
                    <li class="icon-white">
                        <a href="loginAccount.aspx">
                            <span class="glyphicon glyphicon-log-out userInfo"></span>
                            &nbsp;&nbsp;
                        </a>
                    </li>
                </ul>
            </div>
        </nav>

        <div class="col-md-12 userInfo_btnArea navbar navbar-default ">
            <button type="button" id="btn_modify" class="btn btn-large col-sm-1 pull-right btn-primary btn_info_nav">修改</button>
            <button type="button" id="btn_submit" class="btn btn-large col-sm-1 pull-right btn-primary btn_info_nav" runat="server" onserverclick="submitToServer">提交</button>

        </div>
        <div id="content" class="container ">
            <div id="container_user_modify" class="col-md-6 col-sm-offset-3">
                <fieldset id="fieldset" disabled>
                    <div class="form-group ">
                        <label for="name" class="col-sm-2 col-sm-offset-1 labelTag ">名字</label>
                        <div class="col-sm-8">
                            <input type="text" class="form-control " id="Name" placeholder="请输入名字" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-sm-2 col-sm-offset-1  labelTag">密码</label>
                        <div class="col-sm-8">
                            <input type="password" name="PassWord" id="Password" class="form-control col-sm-8" required="required"
                                placeholder="请输入密码" title="" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-sm-2 col-sm-offset-1  labelTag">确认密码</label>
                        <div class="col-sm-8">
                            <input type="password" name="ConfirmPassWord" id="ConfirmPassWord" class="form-control col-sm-8" required="required"
                                placeholder="确认密码" title="" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="name" class="col-sm-2 col-sm-offset-1 labelTag ">生日</label>
                        <div class="col-sm-8">
                            <input type="date" class="form-control" id="birthday" runat="server" name="birthday" runat="server">
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="password" class="col-sm-2 col-sm-offset-1  labelTag">选择性别</label>
                        <div class="col-sm-8">
                            <div class="radio radio-inline radio-primary">
                                <input class="radio-primary" type="radio" name="sexual" id="inlineRadio1"
                                    value="True" checked runat="server">
                                <label class="form-check-label" for="inlineRadio1">男</label>
                            </div>
                            <div class="radio radio-inline radio-primary">
                                <input class="radio-primary" type="radio" name="sexual" id="inlineRadio2"
                                    value="False" runat="server">
                                <label class="form-check-label" for="inlineRadio2">女</label>
                            </div>
                            <input type="hidden" id="hideSexArea" value="<%= UserSex %>" />
                        </div>
                    </div>
                </fieldset>

            </div>
        </div>
    </form>
</body>

</html>
