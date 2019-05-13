using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class articalDetials : System.Web.UI.Page
{
    public static string aid;
    public static string _content = string.Empty;
    public static string _date = string.Empty;
    public static string _title = string.Empty;
    public static string _publisher = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            aid = Request.QueryString["aid"];
            getArtiDetials(aid);
        }
    }

    private void getArtiDetials(string aid)
    {
        string id;
        string title = null;
        string articalcontent = null;
        string date = null;
        string publisher = null;

        DataTable _list = new DataTable();
        string ConctionStr = ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ToString();
        using (SqlConnection con = new SqlConnection(ConctionStr))
        {
            con.Open();
            string Sql = "SELECT * FROM artical WHERE visable = 1 AND id = " + aid + "";
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

        _title = title.ToString();
        _content = articalcontent.ToString();
        _date = date.ToString();
        _publisher = publisher.ToString();
        
    }
}