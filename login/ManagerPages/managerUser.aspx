<%@ Page Language="C#" AutoEventWireup="true" CodeFile="managerUser.aspx.cs" Inherits="managerUser" %>

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

    <script>

    

    </script>

</head>

<body>
    <nav class="navbar navbar-default">
        <div class="container-fluid">

            <div class="navbar-header">

                <a class="navbar-brand left" href="index.aspx">烧卖网</a>
            </div>

            <ul class="nav navbar-nav navbar-right">
                <li><a href="index.aspx">首页</a></li>

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
                    <li class="active"><a href="managerUser.aspx">用户管理</a></li>
                    <li><a href="managerRegister.aspx">用户注册</a></li>
                    <li><a href="managerUpLoad.aspx">批量注册</a></li>
                    <li><a href="#">功能真的还没开发</a></li>
                    <li><a href="#">个人信息</a></li>
                </ul>
            </div>
        </div>
    </div>
    <div class="container col-md-10">

        <form id="form1" runat="server">
            <div>
                
                <br />
                 <div class="col-sm-3">
                     <input type="text" class="form-control" id="input_managerSearch" name="input_managerSearch" placeholder="输入昵称查找" runat="server">
                    </div>
                <div class="col-sm-2">
                        <button type="button"
                        class="btn btn-large col-sm-4  btn-primary btn_loginPage"  runat="server"  onserverclick="searchUser">
                        查找</button>
                    </div>
                <div class="col-sm-2">
                        <button type="button"
                        class="btn btn-large col-sm-4  btn-primary btn_loginPage"  runat="server"  onserverclick="reflash">
                        刷新</button>
                    </div>
                <br />
                <br />
                <br />
                 <div class="col-sm-9">
                <asp:GridView ID="GridView1" runat="server"
                    AutoGenerateColumns="False"
                    AutoGenerateEditButton="True"
                    OnRowCancelingEdit="GridView1_RowCancelingEdit"
                    OnRowEditing="GridView1_RowEditing"
                    OnRowUpdating="GridView1_RowUpdating" CellPadding="4" ForeColor="#333333" GridLines="None" Height="302px" Width="1040px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="UserAccount" HeaderText="登陆账号" />
                        <asp:BoundField DataField="Name" HeaderText="昵称" />
                        <asp:BoundField DataField="Birthday" HeaderText="生日" />
                        <asp:BoundField DataField="Password" HeaderText="密码" />
                        <asp:TemplateField HeaderText="性别">
                            <EditItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Sex") %>' />
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("Sex") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                    <EditRowStyle BackColor="#2461BF" />
                    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EFF3FB" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <SortedAscendingCellStyle BackColor="#F5F7FB" />
                    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                    <SortedDescendingCellStyle BackColor="#E9EBEF" />
                    <SortedDescendingHeaderStyle BackColor="#4870BE" />

                </asp:GridView>
                </div>
            </div>

        </form>

    </div>






</body>

</html>