<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="managerArt.aspx.cs" Inherits="ManagerPages_managerArt" %>

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

    <script>
        var index = 1;
        var mid = 1;
        function pervious() {
            index--;
            if (index < 1) {
                index = 1
                
            }
            ReflashList()

        }
        function Next() {
            index++;
            ReflashList()
        }

        function SaveMid(_mid) {
            mid = _mid;
            console.log(mid);
        }

        function ReflashList() {

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
                    alert(err);
                }
            });

            
        }


        function Preview(aid) {
            alert(aid);
        }
        function Delete(aid) {
            alert(aid);
        }
        function Modify(aid) {
            alert(aid);
        }
    </script>
</asp:Content>


