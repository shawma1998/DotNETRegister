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

    <nav class="navbar navbar-default">
        <div class="container-fluid">

            <div class="navbar-header">

                <a class="navbar-brand left" href="index.html">烧卖网</a>
            </div>

            <ul class="nav navbar-nav navbar-right">
                <li><a href="index.aspx">首页</a></li>
                <li><a href="">关于</a></li>
                <li class="active"><a href="login.aspx">登录</a></li>
            </ul>
        </div>
    </nav>

    <div id="content" class="container">

        <div id="container_bg" class="col-md-6 col-sm-offset-3">

            <form class="form-horizontal" role="form">
                <div class="form-group">
                    <label for="firstname" class="col-sm-2 col-sm-offset-1 labelTag ">名字</label>
                    <div class="col-sm-8">
                        <input type="text" class="form-control" id="firstname" placeholder="请输入名字">
                    </div>
                </div>
                <div class="form-group">
                    <label for="lastname" class="col-sm-2 col-sm-offset-1  labelTag">密码</label>
                    <div class="col-sm-8">
                        <input type="password" name="" id="input" class="form-control col-sm-8" required="required"
                            placeholder="请输入密码" title="">
                    </div>
                </div>

                <div class="">

                    <button type="button"
                        class="btn btn-large col-sm-4 col-sm-offset-1 btn-success btn_loginPage">登录</button>

                    <button type="button"
                        class="btn btn-large col-sm-4 col-sm-offset-2 btn-default btn_loginPage">注册</button>

                </div>


            </form>

        </div>

    </div>


</body>

</html>