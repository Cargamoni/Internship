using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Web.Configuration;
using System.IO;
using System.Collections.Generic;
using System.Data.SqlClient;

/// <summary>
/// Summary description for systematik
/// </summary>
public class systematik
{
    public systematik()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataSet genelvericekme(string sorgu)
    {
        string baglanti = WebConfigurationManager.ConnectionStrings["InternshipConnection"].ConnectionString;
        SqlConnection yeni = new SqlConnection(baglanti);
        SqlDataAdapter verial = new SqlDataAdapter(sorgu, yeni);
        //OleDbConnection yeni = new OleDbConnection(baglanti);
        //OleDbDataAdapter verial = new OleDbDataAdapter(sorgu, yeni);
        if (yeni.State == ConnectionState.Closed)
            yeni.Open();
        DataSet al = new DataSet();
        verial.Fill(al);
        yeni.Close();
        yeni.Dispose();
        verial.Dispose();
        return al;
    }
    public void genelupdate(string sorgu)
    {
        string baglanti = WebConfigurationManager.ConnectionStrings["InternshipConnection"].ConnectionString;
        SqlConnection yeni = new SqlConnection(baglanti);
        SqlCommand komut = new SqlCommand(sorgu, yeni);
        //OleDbConnection yeni = new OleDbConnection(baglanti);
        //OleDbCommand komut = new OleDbCommand(sorgu, yeni);
        if (yeni.State == ConnectionState.Closed)
            yeni.Open();
        komut.ExecuteNonQuery();
        yeni.Close();
        yeni.Dispose();
    }
    public void genelinsert(string sorgu)
    {
        string baglanti = WebConfigurationManager.ConnectionStrings["InternshipConnection"].ConnectionString;
        SqlConnection yeni = new SqlConnection(baglanti);
        SqlCommand komut = new SqlCommand(sorgu, yeni);
        //oledbconnection yeni = new oledbconnection(baglanti);
        //OleDbCommand komut = new OleDbCommand(sorgu, yeni);
        if (yeni.State == ConnectionState.Closed)
            yeni.Open();
        komut.ExecuteNonQuery();
        yeni.Close();
        yeni.Dispose();
    }
    public void resimboyutdegistir(string orjresim, string param, string yeniDosyaAdi)
    {
        double genislik1 = 0;
        double yukseklik1 = 0;
        if (param == "b")
        {
            System.Drawing.Bitmap myBitmap1 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("uploads//" + orjresim));
            double resim_yukseklik1 = myBitmap1.Height;
            double resim_genislik1 = myBitmap1.Width;
            if (myBitmap1.Height < myBitmap1.Width)
            {
                genislik1 = 800;
                yukseklik1 = 600;
            }
            else
            {
                genislik1 = 600;
                yukseklik1 = 800;
            }

            System.Drawing.Bitmap resim_kucuk1 = new System.Drawing.Bitmap(myBitmap1, Convert.ToInt32(genislik1), Convert.ToInt32(yukseklik1));
            resim_kucuk1.Save(System.Web.HttpContext.Current.Server.MapPath("..//images//bresim//" + yeniDosyaAdi));
            resim_kucuk1.Dispose();
            myBitmap1.Dispose();
        }
        else if (param == "t")
        {
            System.Drawing.Bitmap myBitmap1 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("uploads//" + orjresim));
            double resim_yukseklik1 = myBitmap1.Height;
            double resim_genislik1 = myBitmap1.Width;

            if (myBitmap1.Height < myBitmap1.Width)
            {
                genislik1 = 600;
                yukseklik1 = 450;
            }
            System.Drawing.Bitmap resim_kucuk1 = new System.Drawing.Bitmap(myBitmap1, Convert.ToInt32(genislik1), Convert.ToInt32(yukseklik1));
            resim_kucuk1.Save(System.Web.HttpContext.Current.Server.MapPath("..//images//tresim//" + yeniDosyaAdi));
            resim_kucuk1.Dispose();
            myBitmap1.Dispose();
        }
        else if (param == "k")
        {
            System.Drawing.Bitmap myBitmap1 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("uploads//" + orjresim));
            double resim_yukseklik1 = myBitmap1.Height;
            double resim_genislik1 = myBitmap1.Width;
            genislik1 = 380;
            yukseklik1 = 285;
            System.Drawing.Bitmap resim_kucuk1 = new System.Drawing.Bitmap(myBitmap1, Convert.ToInt32(genislik1), Convert.ToInt32(yukseklik1));
            resim_kucuk1.Save(System.Web.HttpContext.Current.Server.MapPath("..//images//kresim//" + yeniDosyaAdi));
            resim_kucuk1.Dispose();
            myBitmap1.Dispose();
        }
        else if (param == "f")
        {
            System.Drawing.Bitmap myBitmap1 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("uploads//" + orjresim));
            double resim_yukseklik1 = myBitmap1.Height;
            double resim_genislik1 = myBitmap1.Width;
            genislik1 = 380;
            yukseklik1 = 250;
            System.Drawing.Bitmap resim_kucuk1 = new System.Drawing.Bitmap(myBitmap1, Convert.ToInt32(genislik1), Convert.ToInt32(yukseklik1));
            resim_kucuk1.Save(System.Web.HttpContext.Current.Server.MapPath("..//images//firstpage//" + yeniDosyaAdi));
            resim_kucuk1.Dispose();
            myBitmap1.Dispose();
        }
        else if (param == "sayi")
        {
            System.Drawing.Bitmap myBitmap1 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("uploads//" + orjresim));
            double resim_yukseklik1 = myBitmap1.Height;
            double resim_genislik1 = myBitmap1.Width;
            genislik1 = 1024;
            yukseklik1 = 1507;
            System.Drawing.Bitmap resim_kucuk1 = new System.Drawing.Bitmap(myBitmap1, Convert.ToInt32(genislik1), Convert.ToInt32(yukseklik1));
            resim_kucuk1.Save(System.Web.HttpContext.Current.Server.MapPath("..//images//sayilar//" + orjresim));
            resim_kucuk1.Dispose();
            myBitmap1.Dispose();
        }
    }

    public void resimkes(string orjresim, int genislik, int yukseklik)
    {
        System.Drawing.Bitmap myBitmap1 = new System.Drawing.Bitmap(System.Web.HttpContext.Current.Server.MapPath("..//images//tresim//" + orjresim));
        System.Drawing.Rectangle kesimalani = new System.Drawing.Rectangle(0, 0, genislik, yukseklik);
        System.Drawing.Bitmap kesilmisimage = myBitmap1.Clone(kesimalani, myBitmap1.PixelFormat);
        kesilmisimage.Save(System.Web.HttpContext.Current.Server.MapPath("..//images//aresim//" + orjresim));
        myBitmap1.Dispose();
        kesilmisimage.Dispose();
    }
    public int idal(string sorgu)
    {
        int sayi = 0;
        string baglanti = WebConfigurationManager.ConnectionStrings["InternshipConnection"].ConnectionString;
        SqlConnection yeni = new SqlConnection(baglanti);
        SqlCommand komut = new SqlCommand(sorgu, yeni);
        //OleDbConnection yeni = new OleDbConnection(baglanti);
        //OleDbCommand komut = new OleDbCommand(sorgu, yeni);
        if (yeni.State == ConnectionState.Closed)
            yeni.Open();
        SqlDataReader oku = komut.ExecuteReader();
        if (oku.Read())
        {
            if (oku[0].ToString() != "")
            {
                sayi = Convert.ToInt32(oku[0].ToString());
            }
            else
                sayi = 0;
        }
        return sayi;
    }

    public string karakterbol(string metin, int charsayi)
    {
        string sayilimetin = "";
        char[] gelenkarakterler = metin.ToCharArray();
        for (int i = 0; i <= charsayi; i++)
        {
            if (i != gelenkarakterler.Length)
            {
                sayilimetin += gelenkarakterler[i].ToString();
            }
            else
                break;
        }
        return sayilimetin;
    }

    public string tagsil(string metin)
    {
        string kalanmetin = "";
        char[] gelenkarakterler = metin.ToCharArray();
        for (int i = 0; i <= gelenkarakterler.Length - 1; i++)
        {
            if (i < gelenkarakterler.Length - 6 && i > 5)
            {
                kalanmetin += gelenkarakterler[i].ToString();
            }
            else if (gelenkarakterler[i] != '<' && gelenkarakterler[i] != '/' &&
                gelenkarakterler[i] != '\r' && gelenkarakterler[i] != '\t' && gelenkarakterler[i] != '\n' && i > 5)
            {
                kalanmetin += gelenkarakterler[i].ToString();
            }
            else if (i == gelenkarakterler.Length - 6)
                break;
        }
        return kalanmetin;
    }
    public List<List<string>> paging(string sorgu, int habersayisi)
    {
        List<List<string>> sayfahaber = new List<List<string>>();
        DataSet al = new DataSet();
        al = this.genelvericekme(sorgu);
        int sayfasayisi = (al.Tables[0].Rows.Count % habersayisi == 0 ? (al.Tables[0].Rows.Count / habersayisi) : (al.Tables[0].Rows.Count / habersayisi) + 1);
        int indis = 0;
        int donecek = al.Tables[0].Rows.Count;
        for (int i = 0; i <= sayfasayisi - 1; i++)
        {
            sayfahaber.Add(new List<string>());
            for (int j = 0; j <= habersayisi - 1; j++)
            {
                if (i == 0 && donecek >= habersayisi)
                {
                    sayfahaber[i].Add(al.Tables[0].Rows[indis][0].ToString());
                    indis++;
                }
                else if (indis <= donecek - 1)
                {
                    sayfahaber[i].Add(al.Tables[0].Rows[indis][0].ToString());
                    indis++;
                }
                else
                    break;
            }
        }
        return sayfahaber;
    }
}
public static class statikdeger
{
    public static int pid;
    public static int pdid;
    public static string idno, param;
}
