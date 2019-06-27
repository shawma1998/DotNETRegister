<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userEvaluation.aspx.cs" Inherits="userEvaluation" %>

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
    <link rel="stylesheet" href="assests\css\bootstrap.css">
    <link rel="stylesheet" href="assests\css\style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-default">
                <div class="container-fluid">

                    <div class="navbar-header">

                        <a class="navbar-brand left" href="index.aspx">烧卖网</a>
                    </div>

                    <ul class="nav navbar-nav navbar-right">
                        <li><a href="index.aspx">首页</a></li>
                        <li><a href="">关于</a></li>


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

            <div class="container col-md-2   ">
                <div class="row">
                    <div class="span2">
                        <ul class="nav nav-pills nav-stacked">
                            <li><a href="userInfo.aspx">用户信息</a></li>
                            <li><a href="userArtical.aspx">查看公告</a></li>
                            <li><a href="managerEvaluate.aspx">投票</a></li>
                        </ul>
                    </div>
                </div>
            </div>

            <div class="col-md-9">
                <asp:GridView ID="GridView1" runat="server" BorderStyle="None" BorderWidth="0px" CssClass="  table table-hover" GridLines="None" AllowPaging="True" OnPageIndexChanging="pageindexchange" PageSize="5" OnRowCommand="RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="button" runat="server" Text="评价" UseSubmitBehavior="false" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Add" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>

                    <AlternatingRowStyle BorderStyle="None" />
                    <HeaderStyle BorderStyle="None" />
                    <RowStyle BorderStyle="None" />

                </asp:GridView>



                <div id="form_pj" visible="false" runat="server" class="col-md-12">

                    <asp:GridView ID="GridView2" BorderStyle="None" BorderWidth="0px" CssClass="  table table-hover" GridLines="None" runat="server"></asp:GridView>


                    <div class="col-md-12 form-control">
                        <label class="radio-inline">对学生负责程度</label>
                        <label class="radio-inline">
                            <input type="radio" name="fuze" value="1" runat="server" />1分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="fuze" value="2" runat="server"  />2分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="fuze" value="3" runat="server"  checked  />3分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="fuze" value="4"  runat="server" />4分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="fuze" value="5" runat="server"  />5分
                        </label>

                    </div>

                    
                    <div class="col-md-12 form-control" >
                        <label class="radio-inline">课堂认真程度&nbsp;&nbsp;</label>
                        <label class="radio-inline">
                            <input type="radio" name="renzhen" value="1" runat="server"  />1分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="renzhen" value="2" runat="server"  />2分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="renzhen" value="3" runat="server"  checked  />3分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="renzhen" value="4" runat="server"  />4分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="renzhen" value="5" runat="server"  />5分
                        </label>

                    </div>

                    
                    <div class="col-md-12 form-control" >
                        <label class="radio-inline">作业认真程度&nbsp;&nbsp;</label>
                        <label class="radio-inline">
                            <input type="radio" name="zuoye" value="1" runat="server"  />1分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="zuoye" value="2" runat="server"  />2分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="zuoye" value="3" runat="server"  checked  />3分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="zuoye" value="4" runat="server"  />4分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="zuoye" value="5" runat="server"  />5分
                        </label>

                    </div>

                    
                    <div class="col-md-12 form-control" >
                        <label class="radio-inline">课堂是否仔细讲授&nbsp;&nbsp;</label>
                        <label class="radio-inline">
                            <input type="radio" name="jiangke" value="1" runat="server"/>1分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="jiangke" value="2" runat="server" />2分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="jiangke" value="3" runat="server" checked />3分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="jiangke" value="4" runat="server" />4分
                        </label>
                        <label class="radio-inline">
                            <input type="radio" name="jiangke" value="5" runat="server" />5分
                        </label>

                    </div>

                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Button" OnClick="Button1_click" />
                </div>
            </div>
        </div>









    </form>
</body>
</html>
