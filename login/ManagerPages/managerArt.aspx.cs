using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerPages_managerArt : System.Web.UI.Page
{
    protected static string _menu = string.Empty;
    protected static string _artialList = string.Empty;
    private static string mid;
    private static string index;
    private static int pageIndex;
    protected void Page_Load(object sender, EventArgs e)
    {

        mid = Request.QueryString["mid"];
        index = Request.QueryString["index"];
        
        if (!IsPostBack)
        {
            ShowAtriaclList(mid, index);
            ListMenu();
        }
    }


    [WebMethod]
    public static void ShowAtriaclList(string mid, string index)
    {
        _artialList = "";
        if (index == null) {
            index = "1";
        }

        if (mid == null) {
            mid = "1";
        }


        StringBuilder sb = new StringBuilder();
        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            //select* from student limit 2,8;
            int offset = (int.Parse(index)-1) * 5;

            string Sql = "SELECT * FROM artical  WHERE visable = 1 AND MID = "+mid+" ORDER BY id OFFSET "+ offset + " ROWS;";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }
        sb.Append("<ul class=\"list-group\">\r\n");
        foreach (DataRow dr in _list.Rows)
        {
            string _id = dr["id"].ToString();
            string _title = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "<a href=managerArt.aspx?id={0}>{1}</a>" +
                "\r\n", _id, _title);//href可以写需要的链接地址
            sb.Append("</li>\r\n");
        }
        sb.Append("</ul>\r\n");
        _artialList = sb.ToString();


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
        DataRow[] rows = _list.Select("pid=0");
        sb.Append("<ul class=\"list-group\">\r\n");
        foreach (DataRow dr in rows)
        {
            string id = dr["id"].ToString();
            string title = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "<a href=managerArt.aspx?mid={0} onclick = \" SaveMid({0}) \">{1}</a>" +
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
                "<a href=managerArt.aspx?mid={0} onclick = \" SaveMid({0}) \">{1}</a>" +
                "\r\n", id, name);//href可以写需要的链接地址
            sb.Append(GetSubMenu(id, dt));  //递归
            sb.Append("</li>\r\n");
        }
        sb.Append("</ul>\r\n");
        return sb.ToString();
    }


}