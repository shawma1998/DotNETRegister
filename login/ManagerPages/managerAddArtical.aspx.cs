using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerPages_managerAddArtical : System.Web.UI.Page
{
    protected static string _menu = string.Empty;
    public string _tempPid;

    protected void Page_Load(object sender, EventArgs e)
    {


        _tempPid = Request.QueryString["pid"];
        string MId = Request.QueryString["id"];
        
        if (!IsPostBack)
        {
            ListMenu();
        }
        
    }

    public void ListMenu()
    {
        StringBuilder sb = new StringBuilder();
        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            string Sql = "SELECT * FROM MenuList";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }
        DataRow[] rows = _list.Select("pid=0");
        sb.Append("<ul class=\"list-group\">\r\n");
        foreach (DataRow dr in rows)
        {
            string id = dr["id"].ToString();
            string title = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "<a href=article1.aspx?id={0}>{1}</a>" +
                "<Button class=\"btn_added btn btn-primary\" onclick=\"Modify({0})\" data-target=\"#exampleModal\">新增</Button>" +
                "<Button type=\"button\" class=\"btn btn-danger \" >删除</Button>" +
                "\r\n", id, title);//href可以写需要的链接地址
            sb.Append(GetSubMenu(id, _list));
            sb.Append("</li>\r\n");
        }

        sb.Append("</ul>\r\n");
        _menu = sb.ToString();

    }
    private string GetSubMenu(string pid, DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        DataRow[] rows = dt.Select("pid= '" + pid + "'");
        sb.Append("<ul class=\"list -group\">\r\n");
        foreach (DataRow dr in rows)
        {
            string id = dr["ID"].ToString();
            string name = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "<a href=article1.aspx?id={0}>{1}</a>" +
                "<Button type=\"button\" class=\"btn btn-primary btn_added\"  onclick=\"Modify({0})\">新增</Button>" +
                "<Button  class=\"btn btn-danger \" >删除</Button>" +
                "\r\n", id, name);//href可以写需要的链接地址
            sb.Append(GetSubMenu(id, dt));  //递归
            sb.Append("</li>\r\n");
        }
        sb.Append("</ul>\r\n");
        return sb.ToString();
    }



    [WebMethod]
    public static void SetTempPid(string pid, string title)
    {
        DataBaseTools.AddTitle(title, pid);
        

    }

    

    /*
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Write(_tempPid);

        if (_tempPid != null)
        {
            if (title_add.Value != null && urls_add.Value != null)
            {
                
                //新增pid为_tempPid的新闻栏目
                DataBaseTools.AddTitle(title_add.Value, _tempPid);
                //获得文本框的信息

            }
        }
    }*/
}