using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// MyGridview 的摘要说明
/// </summary>
public class MyGridview
{
    GridView gv;
    IList list;
    Type t;
    object obj;
    public MyGridview()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    public MyGridview(GridView gv, IList list, object obj)
    {
        this.gv = gv;
        this.list = list;
        this.obj = obj;
        if (list.Count > 0)
        {
            t = list[0].GetType();
        }
    }


    void gv_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        int i = 0;
        PropertyInfo[] proInfo = t.GetProperties();
        foreach (TableCell cell in gv.Rows[e.RowIndex].Cells)
        {
            TextBox txtBox = cell.Controls[0] as TextBox;
            if (txtBox != null)
            {
                proInfo[i].SetValue(list[e.RowIndex], txtBox.Text, null);
            }

            i++;
        }
        obj.GetType().GetMethod("Save").Invoke(obj, null);

        gv.EditIndex = -1;
    }

    void gv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        list.RemoveAt(e.RowIndex);
    }

    void gv_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv.EditIndex = -1;
    }

    void gv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv.EditIndex = e.NewEditIndex;
    }

    public void BindData()
    {
        gv.DataSource = list;
        gv.DataBind();
    }

}