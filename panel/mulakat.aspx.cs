using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_mulakat : System.Web.UI.Page
{
    string gelen;
    protected void Page_Load(object sender, EventArgs e)
    {
        baslik.Text = "Mülakat İşlemleri";

        if (Request.QueryString["mulSil"] != null)
        {

        }
        else
        {
            systematik degisken = new systematik();
            gelen = Request.QueryString["sno"];
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        systematik degisken = new systematik();
        DateTime mulTarih = Convert.ToDateTime(baslangicTarihi.Value);
        string baslangicSaat = "", baslangicDakika = "";
        baslangicSaat += baslangicSaati.Value.ToString()[0];
        baslangicSaat += baslangicSaati.Value.ToString()[1];
        baslangicDakika += baslangicSaati.Value.ToString()[3];
        baslangicDakika += baslangicSaati.Value.ToString()[4];
        mulTarih.AddHours(Convert.ToDouble(baslangicSaat));
        mulTarih.AddMinutes(Convert.ToDouble(baslangicDakika));
        string sorgu = "insert into mulakat(sno,tarihi) values(" + gelen + ",convert(datetime,'" + mulTarih.ToShortDateString() + "',103))";
        degisken.genelinsert(sorgu);
        Response.Redirect("statusReport.aspx?g=mulakatInsert");
    }
}