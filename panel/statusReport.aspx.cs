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
        if (g == "register" || g == "stajInsert")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/okey.png\"/>";
            Label1.Text = "Kayıdınız Başarılı Bir Şekilde Tamamlanmıştır.";
            baslik.Text = "Kayıt Başarılı";
        }
        else if (g == "sinifFail")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "Hatalı Sınıf Girişi.";
            baslik.Text = "Sınıf Hatalı";
        }
        else if (g == "baslangic-bitis-fail")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "Hatalı Tarih Girişi.";
            baslik.Text = "Tarih Hatalı";
        }
        else if (g == "ogrenciYok")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "Girdiğiniz Öğrenci Bulunamadı !";
            baslik.Text = "Öğrenci Hatalı";
        }
        else if (g == "ogrenciBos")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "Öğrenci Bölümü Boş !";
            baslik.Text = "Öğrenci Hatalı";
        }
        else if (g == "konu-departman-isyeri-fail")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "Konu Departman veya İşyeri Bölümü Bulunamadı !";
            baslik.Text = "Konu Departman veya İşyeri Hatalı";
        }
        else if (g == "toplamGunFail")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "Toplam Gün Girilmedi !";
            baslik.Text = "Toplam Gün Hatalı";
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