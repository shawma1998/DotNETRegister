using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managerUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.bind();
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        this.bind();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int U_Id = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value.ToString());
        string UserAccount = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[1].Controls[0])).Text.ToString();
        string UserName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString();
        string Birthday = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString();
        string Password = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString();
        int Gdel = 0;
        CheckBox cbox = (CheckBox)GridView1.Rows[e.RowIndex].Cells[5].FindControl("CheckBox1");

        if (cbox.Checked == true)
        {
            Gdel = 1;
        }
        else
        {
            Gdel = 0;
        }


        string sql_Str = "UPDATE [User] set UserAccount='" + UserAccount + "' , Name='" + UserName + "' , Birthday='" + Birthday + "' , Sex=" + Gdel + " , Password = '"+ Password + "' where Id=" + U_Id;
        //Response.Write(sql_Str);

        SqlConnection con = new SqlConnection(DataBaseTools.connectionString);
        con.Open();
        SqlCommand myCmd = new SqlCommand(sql_Str, con);
        myCmd.ExecuteNonQuery();
        myCmd.Dispose();
        con.Close();
        GridView1.EditIndex = -1;
        this.bind();
    }

    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        this.bind();
    }
    protected void bind()
    {
        SqlConnection con = new SqlConnection(DataBaseTools.connectionString); 
        con.Open();
        string sql_Str = "select * from [User] ";
        SqlDataAdapter myDa = new SqlDataAdapter(sql_Str, con);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataSource = myDs;
        GridView1.DataKeyNames = new string[] { "Id" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        con.Close();
    }


    protected void searchUser(object sender, EventArgs e)
    {
        string search = input_managerSearch.Value;
        SqlConnection con = new SqlConnection(DataBaseTools.connectionString);
        con.Open();
        string sql_Str = "select * from [User]  WHERE Name LIKE '%"+search+"%'";
        SqlDataAdapter myDa = new SqlDataAdapter(sql_Str, con);
        DataSet myDs = new DataSet();
        myDa.Fill(myDs);
        GridView1.DataSource = myDs;
        GridView1.DataKeyNames = new string[] { "Id" };
        GridView1.DataBind();
        myDa.Dispose();
        myDs.Dispose();
        con.Close();
    }

    protected void reflash(object sender, EventArgs e)
    {
        this.bind();
    }
}