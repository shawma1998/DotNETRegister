using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public static class DataBaseTools
{

    //后期需要写入连接字符串
    public static readonly string connectionString = "Data Source=shawma;Initial Catalog=ShowmarkNET;User ID=sa;Password=123456";




    /*
     * 插入数据
     * 返回值成功失败
     * 输入参数
     * 
     * string 表名
     * hashtable 存放插入数值哈希表
     * **/
    public static int Insert(string tableName, List<String> list) {

        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        StringBuilder InsertCommandString = new StringBuilder("INSERT INTO [" + tableName + "] VALUES (");
        SqlCommand sqlCommand;
        //1.根据键来拿值
        for (int i = 0; i < list.Count; i++)
        {

            string temptest = list[i];

            if (i == 4)
            {
                InsertCommandString.Append("" + int.Parse(list[4]) + ",");
            }
            else if (i == 0) {
                InsertCommandString.Append("");
            }
            else
            {
                InsertCommandString.Append("'" + list[i] + "',");
            }

        }
        InsertCommandString.Remove(InsertCommandString.Length - 1, 1);
        InsertCommandString.Append(")");

        sqlCommand = new SqlCommand(InsertCommandString.ToString(), sqlConnection);

        try
        {

            int lineCount = sqlCommand.ExecuteNonQuery();
            return lineCount;
        }
        catch (Exception)
        {
            return -1;
        }
        finally
        {
            sqlConnection.Close();
        }







    }



    public static int LoginForUser(string UserAccount, string PassWord) {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        string SearchSql_str = "SELECT * FROM [User] WHERE UserAccount = '" + UserAccount + "' AND Password = '" + PassWord + "'";
        SqlCommand sqlCommand = new SqlCommand(SearchSql_str, sqlConnection);

        int influenceLine = getResultCount(sqlCommand);

        sqlConnection.Close();
        return influenceLine;

    }

    public static int LoginForManager(string UserAccount, string PassWord)
    {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        string SearchSql_str = "SELECT * FROM [ManagerUser] WHERE UserAccount = '" + UserAccount + "' AND Password = '" + PassWord + "'";
        SqlCommand sqlCommand = new SqlCommand(SearchSql_str, sqlConnection);

        int influenceLine = getResultCount(sqlCommand);

        sqlConnection.Close();
        return influenceLine;

    }


    public static int getResultCount(SqlCommand sqlCommand) {
        int result = 0;
        SqlDataReader sqlData = sqlCommand.ExecuteReader();
        try
        {
            while (sqlData.Read())
            {

                if (sqlData.HasRows)
                {
                    result = result + 1;
                }

            }
        }
        catch (Exception)
        {
            sqlData.Close();
        }

        return result;
    }


    public static Dictionary<String, String> getInfoByAccount(string UserAccount)
    {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        Dictionary<String, String> infoDictioary = new Dictionary<String, String>();
        string sqlSelectString;
        sqlConnection.Open();

        sqlSelectString = "SELECT * FROM [User] WHERE UserAccount = '" + UserAccount + "'";

        SqlCommand sqlCommand = new SqlCommand(sqlSelectString, sqlConnection);

        SqlDataReader dataReader = sqlCommand.ExecuteReader();
        while (dataReader.Read())
        {
            string _userAccount = dataReader.GetString(1);
            string _userName = dataReader.GetString(2);
            DateTime _dateTime = dataReader.GetDateTime(3);
            bool _sex = dataReader.GetBoolean(4);
            string _password = dataReader.GetString(5);


            infoDictioary.Add("UserAccount", _userAccount);
            infoDictioary.Add("UserName", _userName);
            infoDictioary.Add("UserBirth", _dateTime.ToString());
            infoDictioary.Add("UserSex", _sex.ToString());
            infoDictioary.Add("UserPassWord", _password);

        }



        sqlConnection.Close();
        //dataReader.get
        return infoDictioary;

    }

    public static void SubmitData(Dictionary<String, String> userInfo)
    {
        //string tempsex;


        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        string UpdateStr = "UPDATE [User] SET Name = '" + userInfo["UserName"] + "',Birthday = '" + userInfo["UserBirth"] + "', Sex = '" + userInfo["UserSex"] + "',  " +
            "PassWord = '" + userInfo["UserPassWord"] + "' WHERE UserAccount = '" + userInfo["UserAccount"] + "'";

        SqlCommand sqlCommand = new SqlCommand(UpdateStr, sqlConnection);

        sqlCommand.ExecuteNonQuery();

        sqlConnection.Close();

    }


    public static int AddTitle(string titleName, string pid) {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        string InsertCommandString = "INSERT INTO MenuList VALUES (" + pid + " , '" + titleName + "' , 1)";
        SqlCommand sqlCommand = new SqlCommand(InsertCommandString.ToString(), sqlConnection);
        int lineCount = sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return lineCount;
    }

    public static int DeleteTitle(string id)
    {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        string InsertCommandString = "UPDATE MenuList SET visable = 0 WHERE id = '" + id + "' ";
        SqlCommand sqlCommand = new SqlCommand(InsertCommandString.ToString(), sqlConnection);
        int lineCount = sqlCommand.ExecuteNonQuery();
        sqlConnection.Close();
        return lineCount;
    }

    public static bool IsSubMenu (string id){
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
        string InsertCommandString = "SELECT * FROM MenuList WHERE pid = '"+id+"'";
        SqlCommand sqlCommand = new SqlCommand(InsertCommandString.ToString(), sqlConnection);
        SqlDataReader nwReader = sqlCommand.ExecuteReader();
        while (nwReader.Read())
        {
            sqlConnection.Close();
            return false;

        }

        sqlConnection.Close();
        return true;
    }


    /// <summary>
    /// 获取sql链接
    /// </summary>
    /// <returns></returns>
    public static SqlConnection GetSqlConnection()
    {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        return sqlConnection;
    }

    /// <summary>
    /// 通过传入查询语句返回对应内容的list
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static DataTable GetDataBySqlString(string sql)
    {

        SqlConnection sqlConnection = GetSqlConnection();
        sqlConnection.Open();
        DataTable list = new DataTable();
        SqlCommand Com = new SqlCommand(sql, sqlConnection);
        SqlDataAdapter Adaper = new SqlDataAdapter(Com);
        Adaper.Fill(list);
        Adaper.Dispose();
        sqlConnection.Close();
        return list;
    }


    public static DataTable GetOrderTypeItem(string KeyProperty, string SearchKey) {
        SqlConnection sqlConnection = GetSqlConnection();
        sqlConnection.Open();
        DataTable list = new DataTable();
        string sql = "SELECT * FROM pj_final WHERE " + KeyProperty + " = '" + SearchKey+"'";
        SqlCommand Com = new SqlCommand(sql, sqlConnection);
        SqlDataAdapter Adaper = new SqlDataAdapter(Com);
        Adaper.Fill(list);
        Adaper.Dispose();
        sqlConnection.Close();
        return list;
    }
    public static void AddItem(string tableName, string value)
    {
        SqlConnection sqlConnection = GetSqlConnection();
        sqlConnection.Open();
        DataTable list = new DataTable();
        string sql = "INSERT INTO "+ tableName + " VALUES('"+value+"')";
        SqlCommand Com = new SqlCommand(sql, sqlConnection);
        SqlDataAdapter Adaper = new SqlDataAdapter(Com);
        Adaper.Fill(list);
        Adaper.Dispose();
        sqlConnection.Close();
    }

    public static void BindDataToDropDown(DropDownList dropDownList, string TableName) {

        DataTable dataTable = null;
        dataTable = DataBaseTools.GetDataBySqlString("SELECT * FROM "+TableName);
        dropDownList.DataTextField = dataTable.Columns[1].ToString();
        dropDownList.DataValueField = dataTable.Columns[0].ToString();

        dropDownList.DataSource = dataTable.DefaultView;
        dropDownList.DataBind();
        dropDownList.Items.Insert(0, new ListItem("-----选择选项-----", ""));

        //sqlDataSource.Dispose();
    }


    public static void CommandSqlNoReturn(string sql)
    {
        SqlConnection sqlConnection = GetSqlConnection();
        sqlConnection.Open();
        SqlCommand Com = new SqlCommand(sql, sqlConnection);
        Com.ExecuteNonQuery();
        Com.Dispose();
        sqlConnection.Dispose();
    }

   

}