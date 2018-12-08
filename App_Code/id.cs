using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.IO;

/// <summary>
/// Summary description for id
/// </summary>
public class id
{
    public string ascxtip;
    public string sagascxtip;
    systematik degisken = new systematik();

    public id(string args)
    {
            switch (args)
            {
                case "":
                    ascxtip = "page/ana.ascx";
                    break;
                case "ana":
                    ascxtip = "page/ana.ascx";
                    break;
                case "login":
                    ascxtip = "page/login.aspx";
                    break;
                case "register":
                    ascxtip = "page/register.ascx";
                    break;
                case "answer":
                    ascxtip = "page/answer.ascx";
                    break;
                case "profile":
                    ascxtip = "page/profile.ascx";
                    break;
                case "profileInfo":
                    ascxtip = "page/profileInfo.ascx";
                    break;
                case "topics":
                    ascxtip = "page/topics.ascx";
                    break;
                case "question":
                    ascxtip = "page/question.ascx";
                    break;
                case "islemSonuc":
                    ascxtip = "page/islemSonuc.ascx";
                    break;
                case "userInfo":
                    ascxtip = "panel/userInfoi.ascx";
                    break;
        }
    }
}
