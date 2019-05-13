<%@ Page Title="" Language="C#" MasterPageFile="~/MaterPage/artview.master" AutoEventWireup="true" CodeFile="articalDetials.aspx.cs" Inherits="articalDetials" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <span class="badge badge-primary">文章标题</span>
    <h4 id="title"><%=_title %></h4>
    <hr />

    <span class="badge badge-primary">发布者</span>
    <h4 id="publisher"><%=_publisher %></h4>
    <hr />

    <span class="badge badge-primary">发布日期</span>
    <h4 id="date"><%=_date %></h4>
    <hr />

    <span class="badge badge-primary">具体内容</span>
    <h4 id="content"><%=_content %></h4>

</asp:Content>

