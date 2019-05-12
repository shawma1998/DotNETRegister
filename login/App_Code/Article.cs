using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Article 的摘要说明
/// </summary>
public class Article
{
    public string title;
    public string articalcontent;
    public string date;
    public string publisher;

    public Article()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //

    }

    public Article(string title, string articalcontent, string date, string publisher)
    {
        this.title = title;
        this.articalcontent = articalcontent;
        this.date = date;
        this.publisher = publisher;
    }

}