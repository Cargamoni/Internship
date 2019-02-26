using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_kurulUyeEkle : System.Web.UI.Page
{
    string gelen;
    protected void Page_Load(object sender, EventArgs e)
    {
        baslik.Text = "Kurul İşlemleri";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        systematik degisken = new systematik();
        string sorgu = "insert into kurul(ad,soyad,unvan,yetki,parola) values ('" + uyeAd.Value + "','" + uyeSoyad.Value + "','" + uyeUnvan.Value + "',0,'" + uyeParola.Value + "')";
        degisken.genelinsert(sorgu);
        Response.Redirect("statusReport.aspx?g=kurulInsert");
    }
}