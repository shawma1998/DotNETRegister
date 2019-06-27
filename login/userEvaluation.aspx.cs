using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class userEvaluation : System.Web.UI.Page
{
    public static string curr_pj_no = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) {
            BindDataToGridview();
        }
    }

    private void BindDataToGridview()
    {
        /*string sqlCommand = "SELECT class_name,kc_name,th_name,ter_info" +
            "FROM pingjia,Class,Kc,Term,Teacher " +
            "WHERE Class.class_no = pingjia.class_no " +
            "AND Kc.kc_no = pingjia.kc_no " +
            "AND Teacher.th_no = pingjia.th_no " +
            "AND Term.ter_no = pingjia.ter_no ";
            */
        string sqlCommand = "SELECT * FROM pj_user";

        SqlDataSource sqlDataSource = new SqlDataSource(DataBaseTools.connectionString, sqlCommand);

        GridView1.DataSource = sqlDataSource;
        GridView1.DataBind();
    }

    protected void pageindexchange(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        BindDataToGridview();
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void RowCommand(object sender, GridViewCommandEventArgs e)
    {
        
        if (e.CommandName == "Add") {

            //获得页数
            int iPageIndex = GridView1.PageIndex;

            int iPageSize = GridView1.PageSize;      //获取每页显示记录数
            
            //行数

            int index = Convert.ToInt32(e.CommandArgument)- iPageIndex * iPageSize;
            string s = GridView1.Rows[index].Cells[5].Text;
            Response.Write(s);
            curr_pj_no = s;
            //展开评分板

            form_pj.Visible = true;

            string sqlSelect = "SELECT class_name,kc_name,th_name,ter_info FROM pj_user WHERE pj_no= '" + s+"'"; 

            //
            SqlDataSource sqlDataSource  =new SqlDataSource(DataBaseTools.connectionString, sqlSelect);
            GridView2.DataSource = sqlDataSource;
            GridView2.DataBind();
            sqlDataSource.Dispose();


        }
    }

    protected void Button1_click(object sender, EventArgs e)
    {
        int pj_fuze = Convert.ToInt32(Request["fuze"]);
        int pj_renzhen = Convert.ToInt32(Request["renzhen"]);
        int pj_zuoye = Convert.ToInt32(Request["zuoye"]);
        int pj_jiangke = Convert.ToInt32(Request["jiangke"]);

        int total = pj_fuze + pj_renzhen + pj_zuoye + pj_jiangke;
        string user_id = Session["UserAccount"].ToString();

        string sqlCommand = "INSERT INTO EvaluateMain VALUES" +
            " ("+ curr_pj_no + ","+ pj_fuze + ","+ pj_renzhen + ","+ pj_zuoye + ","+ pj_jiangke + ","+ total + ",'"+ user_id + "')";

        DataBaseTools.CommandSqlNoReturn(sqlCommand);

        //在pingjia表对应上加上对应用户的id
        DataTable dataTable = DataBaseTools.GetDataBySqlString("SELECT fuser FROM pingjia WHERE pj_no = '" + curr_pj_no + "'");

        string fuser = dataTable.Rows[0]["fuser"].ToString().Trim();

        StringBuilder sb = new StringBuilder(fuser);

        sb.Append(";" + user_id);

        DataBaseTools.CommandSqlNoReturn("UPDATE pingjia SET fuser = '"+sb.ToString()+"' WHERE pj_no = '"+ curr_pj_no + "'");


        Response.Write("<script>alert('评价成功')</script>");
        form_pj.Visible = false;

    }
}