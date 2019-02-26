using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_sirketEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        baslik.Text = "Şirket İşlemleri";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        systematik degisken = new systematik();
        string sorgu = "insert into sirket(sirket_adi,adresi,iletisim) values ('" + sirketAd.Value + "','" + sirketAdres.Value + "','" + sirketIletisim.Value + "')";
        degisken.genelinsert(sorgu);
        Response.Redirect("statusReport.aspx?g=sirketInsert");
    }
}