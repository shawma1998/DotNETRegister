<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/MasterPage.master" AutoEventWireup="true" CodeFile="managerEvaluate.aspx.cs" Inherits="ManagerPages_EvaluateManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <div class="col-sm-3">

        <div class="list-group">
            <a href="managerEvaluate.aspx?item=Term" class="list-group-item list-group-item-action">学期数据管理</a>
            <a href="managerEvaluate.aspx?item=kc" class="list-group-item list-group-item-action">课程数据管理</a>
            <a href="managerEvaluate.aspx?item=Teacher" class="list-group-item list-group-item-action">教师数据管理</a>
            <a href="managerEvaluate.aspx?item=Class" class="list-group-item list-group-item-action">班级管理</a>
            <%--<a href="managerEvaluate.aspx?item=pingjia" class="list-group-item list-group-item-action">评价项目管理</a>--%>
        </div>

        <div class="list-group">
            <a href="managerEvaluate.aspx?orderBy=Term" class="list-group-item list-group-item-action">按学期统计</a>
            <a href="managerEvaluate.aspx?orderBy=kc" class="list-group-item list-group-item-action">按课程统计</a>
            <a href="managerEvaluate.aspx?orderBy=Teacher" class="list-group-item list-group-item-action">按教师统计</a>
            <a href="managerEvaluate.aspx?orderBy=Class" class="list-group-item list-group-item-action">按班级统计</a>
            <%--<a href="managerEvaluate.aspx?item=pingjia" class="list-group-item list-group-item-action">评价项目管理</a>--%>
        </div>

    </div>
    <div class="col-sm-9">

        <asp:DropDownList Visible="false" ID="DropDownList1" runat="server" CssClass="form-control" OnSelectedIndexChanged="selectedList1_Changed"></asp:DropDownList>

        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped" BorderStyle="None" BorderWidth="0px" GridLines="None" 
            OnRowEditing="GridView1_RowEditing" 
            OnRowCancelingEdit="GridView1_RowCancelingEdit"
            OnRowDeleting="GridView1_RowDeleting" 
            OnRowUpdating="GridView1_RowUpdating" 
            OnRowUpdated="GridView1_RowUpdated" 
            AllowPaging="true" 
            OnPageIndexChanging="GridView1_PageIndexChanging"
             PageSize ="3"
            >
            <AlternatingRowStyle BorderStyle="None" />
            <PagerStyle CssClass="pagination" />
            <RowStyle BorderStyle="None" />

            <Columns>
                    <%--<asp:ButtonField ButtonType="Button" CommandName="MyBtnClicked" Text="删除"/>--%>

                <asp:CommandField ShowEditButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>

    </div>

    <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal" data-whatever="@getbootstrap">新增<%=itemString%>数据</button>


    <%-- 模态框用来append数据 --%>


    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">New message</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label for="recipient-name" class="col-form-label">新增<%=itemString %>内容:</label>
                        <input type="text" class="form-control" id="recipient-name">
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">取消</button>
                    <button id="addbtn" type="button" runat="server" class="btn btn-primary" onclick="AppendItems()">新增</button>
                </div>
            </div>
        </div>
    </div>

    <script>

        
        function AppendItems() {
            var addpendName= $("#recipient-name").val()
            //alert("dddd")
            $.ajax({
                type: "Post",
                url: "managerEvaluate.aspx/AddData",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'name':'"+addpendName+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    alert("插入成功")
                    $('#exampleModal').modal('toggle')
                    location.reload();
                        
                },
                error: function (err) {
                    alert("error");
                }
            });
        }

    </script>

</asp:Content>

