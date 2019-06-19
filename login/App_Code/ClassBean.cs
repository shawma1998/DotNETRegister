using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ClassBean 的摘要说明
/// </summary>
public class ClassBean: ModelObject
{
    public ClassBean()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public ClassBean(int class_no, string class_name)
    {
        this.class_no = class_no;
        this.class_name = class_name;
    }

    public int class_no { get; set; }

    public string class_name { get; set; }
}