<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="managerMenuManager.aspx.cs" Inherits="ManagerPages_managerAddArtical" %>


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

    <!--<input type="text" id="raa" runat="server" />-->
    <div class="list-group col-sm-5">
        <%= _menu %>
        <br />
        
    </div>

    

    <!-- 弹框输入 -->
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <div id="ModifyFrom" class="col-sm-12 ">

                        <div class="input-group col-sm-12">
                            <input id="title_add" type="text" class="form-control" placeholder="输入菜单名" />
                        </div>
                        <br />
                        <div class="input-group col-sm-12">
                            <input id="urls_add" type="text" class="form-control" placeholder="输入分类链接" />
                        </div>
                        <br />
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <button class="btn btn-primary" id="addMenu" type="button" data-dismiss="modal">添加节点</button>
                </div>
            </div>
        </div>
    </div>


    

    <script>
        var pid;

        $("#addMenu").click(function () {

            console.log($("#title_add"))

            var title = $("#title_add").val();
            console.log(title)

            //alert(title);
            if (title != null) {
                $.ajax({
                    type: "Post",
                    url: "managerMenuManager.aspx/SetTempPid",
                    //方法传参的写法一定要对，str为形参的名字,str2为第二个形参的名字   
                    data: "{'pid':'" + pid + "','title':'" + title + "'}",
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
        });




        function Modify(param1) {


            pid = param1;

            //$("#ModifyFrom").show(1000);
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

        function DeleteMenu(id) {
            if (id != null) {
                $.ajax({
                    type: "Post",
                    url: "managerMenuManager.aspx/DeleteMenu",
                    data: "{'id':'" + id + "'}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (data) {
                        //返回的数据用data.d获取内容   
                        console.log(data.d);
                        if (data.d != 0) {
                            alert("删除节点成功");
                            location.reload();
                        } else {
                            alert("删除节点失败,请确认该节点下面是否还有节点");
                            location.reload();
                        }
                    },
                    error: function (err) {
                        alert("cuole");
                    }
                });

            }
        }
        

    </script>

</asp:Content>

