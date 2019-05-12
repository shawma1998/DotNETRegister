using Newtonsoft.Json;
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
    protected static string _menuSlect = string.Empty;
    private static string mid;
    private static string index;
    private static int pageIndex;
    private const int MaxInShow = 5;
    protected void Page_Load(object sender, EventArgs e)
    {

        mid = Request.QueryString["mid"];
        index = Request.QueryString["index"];

        
        ListMenu();
        if (!IsPostBack)
        {
            ShowAtriaclList(mid, index);
            
        }
    }


    [WebMethod]
    public static string ShowAtriaclList(string mid, string index)
    {
        _artialList = "";
        if (index == null) {
            index = "1";
        }

        if (mid == "undefined"|| mid == null) {
            mid = "1";
        }


        StringBuilder sb = new StringBuilder();
        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            //select* from student limit 2,8;
            int offset = (int.Parse(index)-1) * MaxInShow;

            //SELECT * FROM artical  WHERE visable = 1 AND MID = 1 ORDER BY id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY
            string Sql = "SELECT * FROM artical WHERE visable = 1 AND MID = "+mid+" ORDER BY id desc OFFSET "+offset+" ROWS FETCH NEXT "+ MaxInShow + " ROWS ONLY";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }
        sb.Append("<ul class=\"list-group\">\r\n");

        if (_list.Rows.Count == 0) {
            return "END"+index;
        }

        foreach (DataRow dr in _list.Rows)
        {
            string _id = dr["id"].ToString();
            string _title = dr["title"].ToString();
            sb.AppendFormat(
                "<li class=\"list-group-item\" ID=\"{0}\">" +
                "{1}" +
                "<button type=\"button\"" +
                " class = \"btn btn-success\"" +
                " onclick = \"Preview({0}) \"" +
                "data-toggle =\"modal\" data-target=\"#previewModal\"" +
                ">预览</button>" +

                "<button type=\"button\"" +
                "class = \"btn btn-primary\" " +
                "onclick = \"Modify({0}) \"" +
                " data-toggle=\"modal\" data-target=\"#modifyModal\"" +
                ">修改</button>" +

                "<button type=\"button\"" +
                "class = \"btn btn-danger\" " +
                "onclick = \"Delete({0}) \"" +
                " data-toggle=\"modal\" data-target=\"#deleteModal\"" +
                ">删除</button>" +
                "\r\n", _id, _title);//href可以写需要的链接地址
            sb.Append("</li>\r\n");
        }
        sb.Append("</ul>\r\n");
        _artialList = sb.ToString();

        return _artialList;
    }

    [WebMethod]
    public static string ShowMenuList() {
        StringBuilder sb = new StringBuilder();
        sb.Append("<select id=\"mselect\" class=\"form-control\" >");
        sb.Append("\r\n");

        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            //select* from student limit 2,8;

            //SELECT * FROM artical  WHERE visable = 1 AND MID = 1 ORDER BY id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY
            string Sql = "SELECT id,title FROM MenuList WHERE visable =1 ";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }

        foreach (DataRow dr in _list.Rows)
        {
            string id = dr["id"].ToString();
            string title = dr["title"].ToString();
            sb.AppendFormat("<option value=\"{0}\">{1}</option>" ,id, title);
            sb.Append("\r\n");
        }
        sb.Append("</select>");
        sb.Append("\r\n");
        //< option > dasdasd </ option ></ select >
        return sb.ToString();
    }

    [WebMethod]
    public static int DeleteArt(string _id) {
        int id = int.Parse(_id);

        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            //select* from student limit 2,8;

            //SELECT * FROM artical  WHERE visable = 1 AND MID = 1 ORDER BY id OFFSET 3 ROWS FETCH NEXT 1 ROWS ONLY
            string sql = "UPDATE artical SET visable = 0 WHERE id = "+id;
            SqlCommand Com = new SqlCommand(sql, con);
            int result = Com.ExecuteNonQuery();
            
            Com.Dispose();
            con.Close();
            return result;
        }
    }

    [WebMethod]
    public static string AppendArt(string mid, string title, string content, string date, string publisher) {
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            //select* from student limit 2,8;

            //UPDATE artical SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'
            string sql = "INSERT INTO artical VALUES ('"+title+"',1,"+mid+",'"+ content + "','"+date+"','"+publisher+"')";
            SqlCommand Com = new SqlCommand(sql, con);
            int result = Com.ExecuteNonQuery();

            Com.Dispose();
            con.Close();
            return mid;
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
                "<a onclick = \" SaveMid({0}) \">{1}</a>" +
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



    [WebMethod]
    public static string PreviewArti(string _aid) {
        int aid = int.Parse(_aid);

        string id;
        string title = null ;
        string articalcontent = null;
        string date = null;
        string publisher = null;

        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            string Sql = "SELECT * FROM artical WHERE visable = 1 AND id = "+ aid + "";
            SqlCommand Com = new SqlCommand(Sql, con);
            SqlDataAdapter Adaper = new SqlDataAdapter(Com);
            Adaper.Fill(_list);
            Adaper.Dispose();
            Com.Dispose();
            con.Close();
        }
        foreach (DataRow dr in _list.Rows)
        {
            id = dr["id"].ToString();
            title = dr["title"].ToString();
            articalcontent = dr["articalcontent"].ToString();
            date = dr["date"].ToString();
            publisher = dr["publisher"].ToString();
        }

        Article article = new Article(title, articalcontent, date, publisher);

        string json1 = JsonConvert.SerializeObject(article);

        return json1;
    }


    [WebMethod]
    public static string ModifyArtical(string id, string title, string content, string date, string publisher) {
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            //select* from student limit 2,8;

            //UPDATE artical SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'
            string sql = "UPDATE artical SET title = '"+ title + "' , articalcontent ='"+ content + "', date = '"+ date + "',publisher ='"+ publisher + "'  WHERE id = " + id;
            SqlCommand Com = new SqlCommand(sql, con);
            int result = Com.ExecuteNonQuery();

            Com.Dispose();
            con.Close();
            return result.ToString();
        }
    }
}