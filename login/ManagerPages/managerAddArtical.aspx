<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="managerAddArtical.aspx.cs" Inherits="ManagerPages_managerAddArtical" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">


    <style>
        p {
            font-size: 100px;
        }

        .btn_added {
            display: inline-block;
            margin: 10px 30px;
        }
    </style>

    <input type="text" id="raa" runat="server" />
    <div class="list-group col-sm-5">
        <%= _menu %>
        <br />
        <div id="ModifyFrom" class="col-sm-12 ">

            <div class="input-group col-sm-8">
                <input id="title_add" type="text" class="form-control" placeholder="输入菜单名" />
            </div>
            <br />
            <div class="input-group col-sm-8">
                <input id="urls_add" type="text" class="form-control" placeholder="输入分类链接" />
            </div>
            <br />

            <button class="btn btn-primary col-sm-2" id="addMenu" type="button">添加节点</button>
        </div>
    </div>


    <script>
        var pid;

        $("#addMenu").click(function () {

            console.log($("#title_add"))

            var title = $("#title_add").val();
            console.log(title)

            alert(title);
            if (title != null) {
                $.ajax({
                    type: "Post",
                    url: "managerAddArtical.aspx/SetTempPid",
                    //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                    data: "{'pid':'" + pid + "','title':'" + title + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //返回的数据用data.d获取内容   
                        alert(data.d);
                    },
                    error: function (err) {
                        alert(err);
                    }
                });

            }
        });




        function Modify(param1) {


            pid = param1;

            $("#ModifyFrom").show(1000);
            //$("#text").val("123");
            /*alert(param1);
            document.getElementById("Text1").innerText = param1;
            alert(document.getElementById("Text1").innerText);*/
            /*
             $.ajax({
                type: 'get',
                url: 'managerAddArtical.aspx?pid=' + param1,
                async: false,
                success: function (result) {
                    alert("dddd")
                },
                error: function () {
                    
                    alert("ccccc")
                }
            });
             */
        }
        

    </script>

</asp:Content>

