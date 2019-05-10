var pid;
$(document).ready(function () {
    $("#addMenu").click(function () {
        alert("sdsadasdasdas");
        var titleObject = document.getElementById("title_add");
        var title = titleObject.value;
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
})



function Modify(param1) {

    pid = param1;

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

function AppendTitle() {
    //var title = $("#title_add").val;

}
