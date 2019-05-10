using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManagerPages_managerUpLoad : System.Web.UI.Page
{


    string currFilePath = string.Empty; //待读取文件的全路径 
    string currFileExtension = string.Empty;  //文件的扩展名

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void submitExcel(object sender, EventArgs e)
    {
        Upload();  //上传文件方法
        if (this.currFileExtension == ".xlsx" || this.currFileExtension == ".xls")
        {
            DataSet ds = ReadExcelToTable(currFilePath);  //读取Excel文件（.xls和.xlsx格式）
        }

        




    }


    private void Upload()
    {

        /*
         * 1.获取控件中的文件类
         * 2.从获取的file类中来拿到文件的名字--->fileName
         * 3.返回系统临时文件夹的路径
         * 4.获取fileName 的后缀名currFileExtension
         * 5.回去文件名的完整路径 tempPath + fileName
         * 6.
         * **/

        /*
        HttpPostedFile file = this.fileSelect.PostedFile;
        string fileName = file.FileName; //文件名
        string tempPath = System.IO.Path.GetTempPath(); //获取系统临时文件路径
        fileName = System.IO.Path.GetFileName(fileName); //获取文件名（不带路径）
        this.currFileExtension = System.IO.Path.GetExtension(fileName); //获取文件的扩展名
        this.currFilePath = tempPath + fileName; //获取上传后的文件路径 记录到前面声明的全局变量
        file.SaveAs(this.currFilePath); //上传
        */

    }


    private DataSet ReadExcelToTable(string path)
    {
        //连接字符串
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + path + "; Extended Properties='Excel 8.0;HDR=No;IMEX=1;'";
        OleDbConnection connxls = new OleDbConnection(connStr);
        connxls.Open();
        //DataTable sheetsName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" }); //得到所有sheet的名字
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", connxls);

        DataSet dataSet = new DataSet();

        dataAdapter.Fill(dataSet);

        return dataSet;



    }


}