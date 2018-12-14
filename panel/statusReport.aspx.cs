using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_statusReport : System.Web.UI.Page
{
    string g = "";
    string gid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        g = Request.QueryString["g"];
        if (g == "register")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/okey.png\"/>";
            Label1.Text = "Kayıdınız Başarılı Bir Şekilde Tamamlanmıştır.";
        }
        else if (g == "logout")
        {
            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
            Response.Redirect("../Default.aspx");
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("yonetim.aspx");
    }
}