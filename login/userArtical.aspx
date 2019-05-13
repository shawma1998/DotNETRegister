<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userArtical.aspx.cs" Inherits="userArtical" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>

    <script src="assests\js\utils.js"></script>
    <script src="assests\js\tether.js"></script>
    <script src="assests\js\jquery-3.3.1.js"></script>
    <script src="assests\js\bootstrap.js"></script>
    <script src="assests\js\UnserIndexScript\userInfo.js"></script>
    <link rel="stylesheet" href="assests\css\bootstrap.css"/>
    <link rel="stylesheet" href="assests\css\style.css"/>

    <style>

        #haha {
            background-color:black;
        }
        #artical ul li {
            padding : 30px;
            margin-bottom:20px;
            
        }
        #artical ul li button {
            display: inline-block;
            vertical-align:central;
            float:right;
            margin-top:-5px;
            margin-left:20px;

        }
        #submenu {
            height:800px;
        }

    </style>
</head>
<body>
    <nav class="navbar navbar-default">
        <div class="container-fluid">

            <div class="navbar-header">

                <a class="navbar-brand left" href="index.aspx">烧卖网</a>
            </div>

            <ul class="nav navbar-nav navbar-right">

                <li class="icon-white">
                    <a href="userInfo.aspx">

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

    <nav class="navbar navbar-default" role="navigation">
        <div class="container-fluid">
            <div class="navbar-header">
                <%=_menuNavitems %>
            </div>


            <div>
                <form class="navbar-form navbar-right" role="search">
                        <input type="text" class="form-control" placeholder="Search"/>
                        <button type="submit" class="btn btn-default" onclick="searchArtical">搜索文章</button>
                </form>
            </div>
        </div>
    </nav>

    <div id="submenu" class="col-lg-3">
        <%=_subMenu %>
    </div>
    <div id="artical" class="col-lg-9">
        <%=_artlist %>
    </div>
    <button type="button" class="btn btn-secondary " runat="server" onclick="goPrevious()">上一页</button>

    <button type="button" class="btn btn-primary" runat="server" onclick="goNext()">下一页</button>








    <script>

        function getParam(name) {
            var search = document.location.search;
            var pattern = new RegExp("[?&]" + name + "\=([^&]+)", "g");
            var matcher = pattern.exec(search);
            var items = null;
            if (null != matcher) {
                try {
                    items = decodeURIComponent(decodeURIComponent(matcher[1]));
                } catch (e) {
                    try {
                        items = decodeURIComponent(matcher[1]);
                    } catch (e) {
                        items = matcher[1];
                    }
                }
            }
            return items;
        }



        var index = 1;


        function goNext() {
            index++;
            getList();
        }

        function goPrevious() {
            index--;
            if (index < 1) {
                index = 1;
            }
            getList();
        }

        function getList() {
            var mid = getParam('mid');
            $.ajax({
                type: "Post",
                url: "userArtical.aspx/ShowAtriaclList",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'mid':'" + mid + "','index':'" + index + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    
                    if (data.d.indexOf("END") == -1) {
                        console.log(data.d);
                        $("#artical").html(data.d);
                    } else {
                        //alert("mowei ");
                        //alert(data.d.substring(3));
                        index = data.d.substring(3)-1;
                        //location.reload();
                    }


                },
                error: function (err) {

                }
            });
        }

        function Detials(_aid) {
            
            var aid = _aid;
            //alert(aid);
            window.location.href = 'articalDetials.aspx?aid=' + aid;
        }



    </script>
</body>

    
</html>
