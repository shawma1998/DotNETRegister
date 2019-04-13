$(document).ready(function () {
    $("#btn-modify").click(function () {
        $("#btn-submit").toggle();
        $("#btn-modify").toggle();


        //表单显示可编辑
       
        $("#fieldset").attr("disabled",false);
      
    });

    $("#btn-submit").click(function () {
        $("#btn-submit").toggle();
        $("#btn-modify").toggle();


        //表单显示不可编辑
    $("#fieldset").attr("disabled",true);
    });


    
});