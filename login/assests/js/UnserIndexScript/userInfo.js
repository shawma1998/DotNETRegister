$(document).ready(function () {
    $("#btn_modify").click(function () {
        $("#btn_submit").toggle();
        $("#btn_modify").toggle();
        alert("ddsdasdasdas");
        //表单显示可编辑
       
        $("#fieldset").attr("disabled",false);
      
    });

    $("#btn_submit").click(function () {
        $("#btn_submit").toggle();
        $("#btn_modify").toggle();


        //表单显示不可编辑
        $("#fieldset").attr("disabled", true);
    });

    
    
});