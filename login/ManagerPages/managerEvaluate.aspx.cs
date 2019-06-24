using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerPages_EvaluateManager : System.Web.UI.Page
{
    public static string item;
    public static string itemString;
    string orderBy;
    //
    public DataClassesDataContext myContext;

    protected void Page_Load(object sender, EventArgs e)
    {


        addbtn.Visible = true;
        DropDownList1.AutoPostBack = true;
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
            if (item != null) {
                BindDataByRequest(item);
            }
            if (orderBy != null) {
                BindDataByRequestOrder(orderBy);
            }
        }

        //TermBean sa = termBeans[1];
    }
    

    private void BindDataByRequestOrder(string orderBy)
    {
        //下拉框可见

        DropDownList1.Visible = true;

        SqlDataSource sqlDataSource = new SqlDataSource();
        sqlDataSource.ConnectionString = DataBaseTools.connectionString;
        sqlDataSource.SelectCommand = "SELECT * FROM pj_final";
        GridView1.DataSource = sqlDataSource;
        GridView1.DataBind();



        //DropDownList1.DataSource = new SqlDataSource(DataBaseTools.connectionString,"SELECT kc_no FROM "+orderBy);
        //DropDownList1.DataBind();
        sqlDataSource.Dispose();

        

        //将下拉栏的数据绑定到dropdownlist
        DataTable dataTable = DataBaseTools.GetDataBySqlString("SELECT * FROM " + orderBy);

        DropDownList1.DataTextField = dataTable.Columns[1].ToString();
        DropDownList1.DataValueField = dataTable.Columns[0].ToString();

        DropDownList1.DataSource = dataTable.DefaultView;

        DropDownList1.DataBind();
        DropDownList1.Items.Insert(0, new ListItem("-----选择选项-----", ""));



    }

    private void BindDataByRequest(string item)
    {
        switch (item)
        {
            case "Term":
                BindData<TermBean>();
                itemString = "学期";
                break;
            case "kc":
                BindData<KcBeam>();
                itemString = "课程";
                break;
            case "Teacher":
                BindData<TeacherBean>();
                itemString = "教师";
                break;
            case "Class":
                BindData<ClassBean>();
                itemString = "班级";
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
        if (orderBy == null)
        {
            Response.Write("<script>alert('111')</script>");
            GridView1.EditIndex = e.NewEditIndex;
            BindDataByRequest(item);

        }
        else
        {
            //Response.Write("<script>alert('ddd')</script>");
            GridView1.EditIndex = -1;
            GridView1.Enabled = false;
        }

    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindDataByRequest(item);
    }



    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        

        if (orderBy == null)
        {
            try
            {
                LinqUtils.UpdateGridview(myContext, e, item);
                Response.Write("<script>alert('更新成功')</script>");

                GridView1.SetEditRow(-1);
            }
            catch (Exception _e)
            {
                Response.Write("<script>alert('更新失败')</script>");
            }
        }



    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        LinqUtils.DeleteGridview(myContext, e, item);
        myContext.SubmitChanges();

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




    protected void selectedList1_Changed(object sender, EventArgs e)
    {
        DataTable resultTable = null;
        string selectedValue = DropDownList1.SelectedItem.Text;
        //根据地址的ordertype来判断那个字段的搜索
        switch (orderBy) {
            //从pj_final来搜寻
            case "Term":
                resultTable = DataBaseTools.GetOrderTypeItem("ter_info", selectedValue);
                break;
            case "kc":
                resultTable = DataBaseTools.GetOrderTypeItem("kc_name", selectedValue);
                break;
            case "Teacher":
                resultTable = DataBaseTools.GetOrderTypeItem("th_name", selectedValue);
                break;
            case "Class":
                resultTable = DataBaseTools.GetOrderTypeItem("class_name", selectedValue);
                break;
        }

        //string a=  resultTable.Columns[0].ToString();

        GridView1.DataSource = resultTable;
        GridView1.DataBind();

        
    }

    [WebMethod]
    public static void AddData(string name) {
        switch (item)
        {
            case "Term":
                DataBaseTools.AddItem("Term", name);
                break;
            case "kc":
                DataBaseTools.AddItem("kc", name);
                break;
            case "Teacher":
                DataBaseTools.AddItem("Teacher", name);
                break;
            case "Class":
                DataBaseTools.AddItem("Class", name);

                break;
            case "pingjia":
                //qitacaozuo- -
                break;

        }
    }
}