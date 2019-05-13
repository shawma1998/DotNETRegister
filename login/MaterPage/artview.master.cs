using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class artview : System.Web.UI.MasterPage
{
    public static string _menuNavitems = string.Empty;
    public static string _subMenu = string.Empty;
    public static string _artlist = string.Empty;
    public static string mid;
    public static string index;
    public static string rootid;
    private const int MaxInShow = 5;
    protected void Page_Load(object sender, EventArgs e)
    {
        mid = Request.QueryString["mid"];
        rootid = Request.QueryString["rootid"];
        index = Request.QueryString["index"];

        if (mid == null)
        {
            mid = "1";
        }
        if (rootid == null)
        {
            rootid = "1";
        }
        if (index == null)
        {
            index = "1";
        }

        if (!IsPostBack)
        {
            showRootMenu();
            ListMenu();
        }
    }

    //生成导航栏的根节点
    private void showRootMenu()
    {
        StringBuilder sb = new StringBuilder();
        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();

            //SELECT * FROM artical  WHERE visable = 1 AND MID = 1 ORDER BY id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY

            string Sql = "SELECT * FROM MenuList WHere pid = 0";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }
        sb.Append("\r\n");
        foreach (DataRow tr in _list.Rows)
        {
            string title = tr["title"].ToString();
            string id = tr["id"].ToString();
            sb.AppendFormat("<a class=\"navbar-brand\" href=\"userArtical.aspx?rootid={0}&mid={0}\">{1}</a>", id, title);
            sb.Append("\r\n");
        }

        sb.Append("\r\n");
        _menuNavitems = sb.ToString();
    }

    public void ListMenu()
    {
        StringBuilder sb = new StringBuilder();
        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            string Sql = "SELECT * FROM MenuList WHERE visable = 1";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }
        DataRow[] rows = _list.Select("pid=" + rootid);
        sb.Append("<ul class=\"list-group\">\r\n");
        foreach (DataRow dr in rows)
        {
            string id = dr["id"].ToString();
            string title = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "<a href=userArtical.aspx?mid={0}&rootid=" + rootid + ">{1}</a>" +
                "\r\n", id, title);//href可以写需要的链接地址
            sb.Append(GetSubMenu(id, _list));
            sb.Append("</li>\r\n");
        }

        sb.Append("</ul>\r\n");
        _subMenu = sb.ToString();

    }

    private string GetSubMenu(string pid, DataTable dt)
    {
        StringBuilder sb = new StringBuilder();
        DataRow[] rows = dt.Select("pid= '" + pid + "'");
        sb.Append("<ul class=\"list-group\">\r\n");
        foreach (DataRow dr in rows)
        {
            string id = dr["ID"].ToString();
            string name = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "<a href=userArtical.aspx?mid={0}&rootid=" + rootid + ">{1}</a>" +
                "\r\n", id, name);//href可以写需要的链接地址
            sb.Append(GetSubMenu(id, dt));  //递归
            sb.Append("</li>\r\n");
        }
        sb.Append("</ul>\r\n");
        return sb.ToString();
    }
}
