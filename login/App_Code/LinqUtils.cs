using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// LinqUtils 的摘要说明
/// </summary>
public class LinqUtils
{
    public static void UpdateGridview(DataClassesDataContext myContext, GridViewUpdateEventArgs e, string item)
    {

        string id = (string)e.NewValues[0];
        string info = (string)e.NewValues[1];

        //修改数据 id无法修改

        switch (item)
        {
            case "Term":
                var _q1 = myContext.Term.Where(p => p.ter_no == System.Convert.ToInt32(id));

                if (_q1.Count() > 0)
                {
                    Term term = _q1.First();
                    //改
                    term.ter_info = info;
                }
                break;

            case "kc":
                var _q2 = myContext.Kc.Where(p => p.kc_no == System.Convert.ToInt32(id));

                if (_q2.Count() > 0)
                {
                    Kc kc = _q2.First();
                    //改
                    kc.kc_name = info;
                }
                break;


            case "Teacher":
                var _q3 = myContext.Teacher.Where(p => p.th_no == System.Convert.ToInt32(id));

                if (_q3.Count() > 0)
                {
                    Teacher teacher = _q3.First();
                    //改
                    teacher.th_name = info;
                }
                break;

            case "Class":
                var _q4 = myContext.Class.Where(p => p.class_no == System.Convert.ToInt32(id));

                if (_q4.Count() > 0)
                {
                    Class _class = _q4.First();
                    //改
                    _class.class_name = info;
                }
                break;

        }

        //这段需要重复写qwq
        /*
        var q = myContext.Term.Where(p => p.ter_no == System.Convert.ToInt32(id));

        if (q.Count() > 0)
        {
            Term term = q.First();
            //改
            term.ter_info = info;
        }
        */
        myContext.SubmitChanges();


    }

    public static void DeleteGridview(DataClassesDataContext myContext, GridViewDeleteEventArgs e, string item)
    {

        string id = (string)e.Values[0];

        //修改数据 id无法修改

        switch (item)
        {
            case "Term":
                var q1 = myContext.Term.Where(p => p.ter_no == System.Convert.ToInt32(id));

                if (q1.Count() > 0)
                {
                    Term term = q1.First();
                    myContext.Term.DeleteOnSubmit(term);
                    //改
                }
                break;
            case "kc":
                var q2 = myContext.Kc.Where(p => p.kc_no == System.Convert.ToInt32(id));

                if (q2.Count() > 0)
                {
                    Kc kc = q2.First();
                    myContext.Kc.DeleteOnSubmit(kc);
                    //改
                }
                break;
            case "Teacher":
                var q3 = myContext.Teacher.Where(p => p.th_no == System.Convert.ToInt32(id));

                if (q3.Count() > 0)
                {
                    Teacher teacher = q3.First();
                    myContext.Teacher.DeleteOnSubmit(teacher);
                    //改
                }
                break;
            case "Class":
                var q4 = myContext.Class.Where(p => p.class_no == System.Convert.ToInt32(id));

                if (q4.Count() > 0)
                {
                    Class @class = q4.First();
                    myContext.Class.DeleteOnSubmit(@class);
                    //改
                }
                break;



        }

        //这段需要重复写qwq
        /*
        var q = myContext.Term.Where(p => p.ter_no == System.Convert.ToInt32(id));

        if (q.Count() > 0)
        {
            Term term = q.First();
            //改
            term.ter_info = info;
        }
        */
        myContext.SubmitChanges();


    }
}