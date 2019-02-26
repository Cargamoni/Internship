using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_ogrenciEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        baslik.Text = "Öğrenci İşlemleri";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        systematik degisken = new systematik();
        string ogretim = ogrOgretim.Value == "1" ? "0" : "1";
        string sorgu = "insert into ogrenci(adi,soyadi,ono,ogretim,dgs) values ('" + ogrAd.Value + "','" + ogrSoyad.Value + "','" + ogrNo.Value + "'," + ogretim + ",0)";
        degisken.genelinsert(sorgu);
        Response.Redirect("statusReport.aspx?g=ogrenciInsert");
    }
}