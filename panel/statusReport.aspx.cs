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
        if (g == "register" || g == "stajInsert" || g == "mulakatInsert" || g == "kurulInsert" || g == "ogrenciInsert" || g == "universiteInsert" || g == "departmanInsert" || g == "konuInsert" || g == "sirketInsert")
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
        else if (g == "sinifFail2")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "2. Sınıf 25 Günden Fazla Staj Yapamaz.";
            baslik.Text = "Gün Fazla";
        }
        else if (g == "sinifGunFail")
        {
            imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
            Label1.Text = "15 Günden Az 40 Günden Fazla Staj Yapamaz.";
            baslik.Text = "Gün Fazla";
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
        //else if (g == "60gun")
        //{
        //    imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
        //    Label1.Text = "Staj Süresi 60 Günden Fazla Olamaz !";
        //    baslik.Text = "Toplam Gün Hatalı";
        //}
        else if (g == "stajSil")
        {
            gid = Request.QueryString["sno"];
            systematik degisken = new systematik();
            string sorgu = "select * from staj where sno = " + gid;
            if (degisken.genelvericekme(sorgu).Tables[0].Rows.Count != 0)
            {
                sorgu = "delete from staj where sno = " + gid;
                degisken.genelupdate(sorgu);
                imageControl.Text = "<img alt=\"\" src=\"../images/okey.png\"/>";
                Label1.Text = "Kayıdınız Başarılı Bir Şekilde Silinmiştir.";
                baslik.Text = "Silme Başarılı";
            }
            else
            {
                imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
                Label1.Text = "Silme işleminde hata oluştu!";
                baslik.Text = "Silme Yapılamadı";
            }
            System.GC.SuppressFinalize(degisken);
        }
        else if (g == "ogrenciSil")
        {
            gid = Request.QueryString["ono"];
            systematik degisken = new systematik();
            string sorgu = "select * from ogrenci where ono = " + gid;
            if (degisken.genelvericekme(sorgu).Tables[0].Rows.Count != 0)
            {
                sorgu = "delete from ogrenci where ono = " + gid;
                degisken.genelupdate(sorgu);
                imageControl.Text = "<img alt=\"\" src=\"../images/okey.png\"/>";
                Label1.Text = "Kayıdınız Başarılı Bir Şekilde Silinmiştir.";
                baslik.Text = "Silme Başarılı";
            }
            else
            {
                imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
                Label1.Text = "Silme işleminde hata oluştu!";
                baslik.Text = "Silme Yapılamadı";
            }
            System.GC.SuppressFinalize(degisken);
        }
        else if (g == "uyeSil")
        {
            gid = Request.QueryString["uno"];
            systematik degisken = new systematik();
            string sorgu = "select * from kurul where uno = " + gid;
            if (degisken.genelvericekme(sorgu).Tables[0].Rows.Count != 0)
            {
                sorgu = "delete from kurul where uno = " + gid;
                degisken.genelupdate(sorgu);
                imageControl.Text = "<img alt=\"\" src=\"../images/okey.png\"/>";
                Label1.Text = "Kayıdınız Başarılı Bir Şekilde Silinmiştir.";
                baslik.Text = "Silme Başarılı";
            }
            else
            {
                imageControl.Text = "<img alt=\"\" src=\"../images/warning.png\"/>";
                Label1.Text = "Silme işleminde hata oluştu!";
                baslik.Text = "Silme Yapılamadı";
            }
            System.GC.SuppressFinalize(degisken);
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