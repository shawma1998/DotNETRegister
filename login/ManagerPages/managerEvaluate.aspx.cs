using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerPages_EvaluateManager : System.Web.UI.Page
{
    string item;
    string orderBy;

    private DataClassesDataContext myContext;
    protected void Page_Load(object sender, EventArgs e)
    {
        //使用linq来对数据库来进行操作
        myContext = new DataClassesDataContext();

        //获得当前地址栏传入的参数，然后获得要点击的栏目
        item = Request.QueryString["item"];
        orderBy = Request.QueryString["orderBy"];
        if (item == null&& orderBy==null)
        {
            item = "Term";
        }
        if (!Page.IsPostBack)
        {
            BindDataByRequest(item);
        }

        //TermBean sa = termBeans[1];
    }

    private void BindDataByRequest(string item)
    {
        switch (item)
        {
            case "Term":
                BindData<TermBean>();
                break;
            case "kc":
                BindData<KcBeam>();
                break;
            case "Teacher":
                BindData<TeacherBean>();
                break;
            case "Class":
                BindData<ClassBean>();
                break;
            case "pingjia":
                BindData<PingjiaBean>();
                break;

        }
    }

    private void BindData<T>()
    {

        //T为传入的数据模型的类

        //选择对应表的内容的查询语句
        string sql = "SELECT * FROM " + item;
        //将查询语句转换成DataTable
        DataTable dt = DataBaseTools.GetDataBySqlString(sql);

        //DataTable转换成List<T>
        List<T> termBeans = ConvertList.ToDataList<T>(dt);
        //将GridView1的数据源设置成List<T>
        GridView1.DataSource = termBeans;
        GridView1.DataBind();
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindDataByRequest(item);

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindDataByRequest(item);
    }



    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {


        try
        {
            UpdateGridview(e,item);
            Response.Write("<script>alert('更新成功')</script>");

            GridView1.SetEditRow(-1);
        }
        catch (Exception _e) {
            Response.Write("<script>alert('更新失败')</script>");
        }



    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        BindDataByRequest(item);

    }


    

    protected void GridView1_RowUpdated(object sender, GridViewUpdatedEventArgs e)
    {

        GridView1.EditIndex = -1;
    }



    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindDataByRequest(item);
    }




    //修改内容的代码

    private void UpdateGridview(GridViewUpdateEventArgs e,string item)
    {

        string id = (string)e.NewValues[0];
        string info = (string)e.NewValues[1];

        //修改数据 id无法修改

        switch (item) {
            case "Term":
                var _q1 = myContext.Term.Where(p => p.ter_no == System.Convert.ToInt32(id));

                if (_q1.Count() > 0)
                {
                    Term term = _q1.First();
                    //改
                    term.ter_info = info;
                }
                break;

            case "kc":
                var _q2 = myContext.Kc.Where(p => p.kc_no == System.Convert.ToInt32(id));

                if (_q2.Count() > 0)
                {
                    Kc kc = _q2.First();
                    //改
                    kc.kc_name = info;
                }
                break;


            case "Teacher":
                var _q3 = myContext.Teacher.Where(p => p.th_no == System.Convert.ToInt32(id));

                if (_q3.Count() > 0)
                {
                    Teacher teacher = _q3.First();
                    //改
                    teacher.th_name = info;
                }
                break;

            case "Class":
                var _q4 = myContext.Class.Where(p => p.class_no == System.Convert.ToInt32(id));

                if (_q4.Count() > 0)
                {
                    Class _class = _q4.First();
                    //改
                    _class.class_name = info;
                }
                break;

        }

        //这段需要重复写qwq
        /*
        var q = myContext.Term.Where(p => p.ter_no == System.Convert.ToInt32(id));

        if (q.Count() > 0)
        {
            Term term = q.First();
            //改
            term.ter_info = info;
        }
        */
        myContext.SubmitChanges();


        //修改数据
        BindDataByRequest(item);
    }
}