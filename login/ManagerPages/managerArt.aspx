﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="managerArt.aspx.cs" Inherits="ManagerPages_managerArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>

        #div1 {
        }
        li{
            margin-top:10px;
        }
        #art_list ul li {
            padding : 30px;
            margin-bottom:20px;
            
        }
        #art_list ul li button {
            display: inline-block;
            vertical-align:central;
            float:right;
            margin-top:-5px;
            margin-left:20px;

        }

        #previewModel h4 {

            margin-left:20px;
        }

    </style>

    <input type="text" hidden id="indexText"/>
    <input type="text" hidden id="midText" runat="server" />
    <div id="div1" class="col-sm-3">
        <%= _menu %>
    </div>
    <div id="div2" class="col-sm-9">
        <div id="art_list">

            
        <%= _artialList %>

        </div>

        <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center">
                <li class="page-item">
                    
                    <button type="button" class="btn btn-secondary "  runat="server" onclick="pervious()" >上一页</button>
                </li>
                <li class="page-item">
                    <button type="button" class="btn btn-primary" runat="server" onclick="Next()" >下一页</button>
                   
                </li>
            </ul>
        </nav>
    </div>



    <!--
        删除模态框
        -->
    <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    是否要删除该文章？
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">不了</button>
                    <button type="button" onclick="ModelDelete()" class="btn btn-danger">删除</button>
                </div>
            </div>
        </div>
    </div>

    <!--
        预览模态框
        -->
    <div class="modal fade" id="previewModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog " role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">预览文章</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div id="previewModel" class="modal-body">
                    <span class="badge badge-primary">文章标题</span>
                    <h4 id="title">fasddsfsdfsdf</h4>
                    <hr />

                    <span class="badge badge-primary">发布者</span>
                    <h4 id="publisher">fasddsfsdfsdf</h4>
                    <hr />
                    
                    <span class="badge badge-primary">发布日期</span>
                    <h4 id="date">fasddsfsdfsdf</h4>
                    <hr />

                    <span class="badge badge-primary">具体内容</span>
                    <h4 id="content">fasddsfsdfsdf</h4>
                    <hr />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">关闭</button>
                </div>
            </div>
        </div>
    </div>

    <!--
        编辑模态框
        -->
    <div class="modal fade" id="modifyModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog " role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title">修改文章</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div id="modifyModel" class="modal-body">
                    <br/><span class="badge badge-primary">文章标题</span><br/><br/>
                    <input class="form-control" type="text" id="ed_title" value="标题" />
                    <br/><span class="badge badge-primary">日期</span><br/><br/>
                    <input class="form-control" type="text" id="ed_date" value="标题" />
                    <br/><span class="badge badge-primary">发布者</span><br/><br/>
                    <input class="form-control" type="text" id="ed_publisher" value="标题" />
                    <br/><span class="badge badge-primary">内容</span><br/><br/>
                    <input class="form-control" type="text" id="ed_content" value="标题" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-primary" data-dismiss="modal">关闭</button>
                    <button type="button" class="btn btn-submit" onclick="Submit()">提交</button>
                </div>
            </div>
        </div>
    </div>

    <script>
        //获得当前页面的index和mid的值

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
        
        /**
         * index :当前页面的index数
         * mid : 当前 menu
         * currentId ：当前点选的文章id
         * */
        var index;
        var mid;
        var currentId;

        //初始化
        if (getParam('index') == null) {
            index = 1;
        } else {
            index = getParam('index')
        }

        if (getParam('mid') == null) {
            mid = 1;
        } else {
            mid = getParam('mid')
        }




        function Submit() {

            var title = $("#ed_title").val();
            var content =$("#ed_content").val();
            var date =$("#ed_date").val();
            var publisher =$("#ed_publisher").val();

            $.ajax({
                type: "Post",
                url: "managerArt.aspx/ModifyArtical",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'id':'"+currentId+"','title':'" + title + "','content':'"+content+"','date':'"+date+"','publisher':'"+publisher+"'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容   
                    //alert(data.d)
                    //alert("OK");
                    //alert(artobject["title"])
                    if (data.d != 0) {
                        //alert("更新成功");
                        $('#modifyModal').modal('toggle')
                        window.location.replace('managerArt.aspx?index=' + index + '&mid=' + mid);
                    }


                },
                error: function (err) {
                    
                }
            });


        }

     



        function pervious() {
            index--;
            if (index < 1) {
                index = 1

            }
            ReflashList()
            //alert("mid" + mid + "   " + "index" + index)
        }
        function Next() {
            index++;
            ReflashList()
        }

        function SaveMid(_mid) {
            mid = _mid;
            console.log(mid);
            index = 1;
            ReflashList();
        }

        function ReflashList() {
            console.log(mid);
            $.ajax({
                type: "Post",
                url: "managerArt.aspx/ShowAtriaclList",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'mid':'" + mid + "','index':'" + index + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容   
                    console.log(data.d);
                    if (data.d.indexOf("END") == -1) {
                        console.log(data.d);
                        $("#art_list").html(data.d);
                    } else {
                        //alert("mowei ");
                        //alert(data.d.substring(3));
                        index = data.d.substring(3)-1;
                        //location.reload();
                    }
                    
                },
                error: function (err) {
                    console.log(err);
                }
            });

            
        }

        function ModelDelete() {
            //alert("删除" + currentId);
            $('#deleteModal').modal('toggle')
            /*
             * 通过Ajax 传递数据到后台
             * 检验后 对应id的文章visuable设置false
             * 
             * **/
            $.ajax({
                type: "Post",
                url: "managerArt.aspx/DeleteArt",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'_id':'" + currentId + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容   
                    console.log(data.d);
                    if (data.d > 0) {
                        //alert(index +"  "+ mid)
                        
                        window.location.replace('managerArt.aspx?index=' + index + '&mid=' + mid);
                    } 
                    
                },
                error: function (err) {
                    alert(err);
                }
            });


        }

        function Preview(aid) {
            
            

            $.ajax({
                type: "Post",
                url: "managerArt.aspx/PreviewArti",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'_aid':'" + aid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容   
                    //alert(data.d)
                    var artobject = JSON.parse(data.d);

                    //alert(artobject["title"])
                    $("#title").text(artobject["title"]);
                    $("#content").text(artobject["articalcontent"]);
                    $("#date").text(artobject["date"]);
                    $("#publisher").text(artobject["publisher"]);


                },
                error: function (err) {
                    
                }
            });

            
        }
        function Delete(aid) {
            
            currentId = aid;

        }
        function Modify(aid) {
            
            currentId = aid;
            /*
             * 弹出模态框
             * 点击模态框中的确定后
             * 通过js 获得模态框的数据
             * 检验后
             * **/

            $.ajax({
                type: "Post",
                url: "managerArt.aspx/PreviewArti",
                //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                data: "{'_aid':'" + aid + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    //返回的数据用data.d获取内容   
                    //alert(data.d)
                    var artobject = JSON.parse(data.d);

                    //alert(artobject["title"])
                    $("#ed_title").val(artobject["title"]);
                    $("#ed_content").val(artobject["articalcontent"]);
                    $("#ed_date").val(artobject["date"]);
                    $("#ed_publisher").val(artobject["publisher"]);


                },
                error: function (err) {
                    
                }
            });


        }
    </script>
</asp:Content>


