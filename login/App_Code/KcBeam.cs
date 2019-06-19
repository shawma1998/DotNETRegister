using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// KcBeam 的摘要说明
/// </summary>
public class KcBeam: ModelObject
{
    public KcBeam()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    public KcBeam(int kc_no, string kc_name)
    {
        this.kc_no = kc_no;
        this.kc_name = kc_name;
    }

    public int kc_no { get; set; }

    public string kc_name { get; set; }
}