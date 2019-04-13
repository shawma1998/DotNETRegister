using System;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public static bool Insert(string tableName, Hashtable hashtable)
        {

            SqlConnection sqlConnection = new SqlConnection("Data Source=DESKTOP-KR8A64M;Initial Catalog=ShowmarkNET;User ID=sa;Password=123456;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            StringBuilder InsertCommandString = new StringBuilder("INSERT INTO " + tableName + "VALUES (");
            SqlCommand sqlCommand;
            try
            {

                //1.根据键来拿值
                foreach (string key in hashtable.Keys)
                {
                    InsertCommandString.Append("'" + hashtable[key] + "',");
                }
                InsertCommandString.Remove(InsertCommandString.Length - 1, 1);
                InsertCommandString.Append(");");

                sqlCommand = new SqlCommand(InsertCommandString.ToString(), sqlConnection);
                Console.WriteLine(sqlCommand);

                return true;


            }
            catch (Exception e)
            {

                return false;
            }


        }
    }
}
