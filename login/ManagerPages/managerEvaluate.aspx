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
</asp:Content>


