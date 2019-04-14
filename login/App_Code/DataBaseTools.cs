using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Class1 的摘要说明
/// </summary>
public static class DataBaseTools
{

    //后期需要写入连接字符串
    private static readonly string connectionString = "Data Source=DESKTOP-KR8A64M;Initial Catalog=ShowmarkNET;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

   


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
            for (int i = 0;i<list.Count;i++)
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



    public static int LoginForUser(string UserName, string PassWord) {
        SqlConnection sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        string SearchSql_str = "SELECT * FROM [User] WHERE UserAccount = '" + UserName + "' AND Password = '" + PassWord + "'";
        SqlCommand sqlCommand = new SqlCommand(SearchSql_str, sqlConnection);

        int influenceLine = getResultCount(sqlCommand);

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

        

        //dataReader.get
        return infoDictioary;

    }
}