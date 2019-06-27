<%@ Page Language="C#" AutoEventWireup="true" CodeFile="managerUpLoad.aspx.cs" Inherits="ManagerPages_managerUpLoad" %>

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

        alert("此功能还未完善！！！！！！！！！！！！！！！！！！！！");

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
                <br />
                <br />
                <br />
                <br />
                <asp:FileUpload ID="fileSelect" CssClass="col-sm-5 " runat="server" Height="33px" Width="380px" />
                <br />
                <br />
                <br />
                <br />
                <button type="button" class="btn btn-large col-sm-1 pull-left btn-primary" runat="server" onserverclick="submitExcel">上传</button>
                
            </div>

        </form>

    </div>






</body>

</html>
