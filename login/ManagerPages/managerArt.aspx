<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="managerArt.aspx.cs" Inherits="ManagerPages_managerArt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <style>

        #div1 {
        }
        li{
            margin-top:10px;
        }

    </style>

    <input type="text" id="indexText"/>
    <input type="text" id="midText" runat="server" />
    <div id="div1" class="col-sm-3">
        <%= _menu %>
    </div>
    <div id="div2" class="col-sm-9">
        <%= _artialList %>

        <nav aria-label="Page navigation example">
            <ul class="pagination justify-content-center">
                <li class="page-item">
                    <a class="page-link" href="#" tabindex="-1" onclick="pervious()">Previous</a>
                </li>
                <li class="page-item">
                    <a class="page-link" href="#" onclick="Next()">Next</a>
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
            alert(mid);
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
                    if (data.d != 0) {
                        alert("新增节点成功");
                        location.reload();
                    } else {
                        alert("插入失败");
                        location.reload();
                    }
                },
                error: function (err) {
                    alert(err);
                }
            });

            
        }

    </script>
</asp:Content>


