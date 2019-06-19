using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// TermBean 的摘要说明
/// </summary>
public class TermBean: ModelObject
{
    public int ter_no { get; set; }

    public string ter_info { get; set; }

    public TermBean(int term_id, string term_info)
    {
        ter_no = term_id;
        ter_info = term_info;
    }

    public TermBean()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

}