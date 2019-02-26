using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_departmanEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        baslik.Text = "Departman İşlemleri";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        systematik degisken = new systematik();
        string sorgu = "insert into departman(departman) values ('" + depAd.Value + "')";
        degisken.genelinsert(sorgu);
        Response.Redirect("statusReport.aspx?g=departmanInsert");
    }
}