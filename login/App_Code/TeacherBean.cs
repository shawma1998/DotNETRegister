using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// TeacherBean 的摘要说明
/// </summary>
public class TeacherBean: ModelObject
{
    public TeacherBean()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public TeacherBean(int th_no, string th_name)
    {
        this.th_no = th_no;
        this.th_name = th_name;
    }

    public int th_no { get; set; }

    public string th_name { get; set; }
}