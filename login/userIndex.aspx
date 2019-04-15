﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userIndex.aspx.cs" Inherits="userIndex" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <title>Document</title>

    <script src="assests\js\utils.js"></script>
    <script src="assests\js\tether.js"></script>
    <script src="assests\js\jquery-3.3.1.js"></script>
    <script src="assests\js\bootstrap.js"></script>
    <script src="assests\js\UnserIndexScript\userInfo.js"></script>
    <link rel="stylesheet" href="assests\css\bootstrap.css">
    <link rel="stylesheet" href="assests\css\style.css">

</head>

<body>
    <nav class="navbar navbar-default">
        <div class="container-fluid">

            <div class="navbar-header">

                <a class="navbar-brand left" href="index.aspx">烧卖网</a>
            </div>

            <ul class="nav navbar-nav navbar-right">
                <li><a href="index.aspx">首页</a></li>
                <li><a href="">关于</a></li>
                <li><a href="">早上好，<span id="userNameNav"><%=UserNameInNav%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</a></li>

                <li class="icon-white">
                    <a href="userInfo.aspx">

                        <span class="glyphicon glyphicon-user userInfo"></span>
                    </a>
                </li>
                <li class="icon-white">
                    <a href="#">
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
                    <li class="active"><a href="#">功能真的还没开发</a></li>
                    <li><a href="#">功能真的还没开发</a></li>
                    <li><a href="#">功能真的还没开发</a></li>
                    <li><a href="#">功能真的还没开发</a></li>
                    <li><a href="userInfo.aspx">个人信息</a></li>
                </ul>
            </div>
        </div>
    </div>






</body>

</html>
