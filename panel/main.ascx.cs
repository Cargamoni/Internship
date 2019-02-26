using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_main : System.Web.UI.UserControl
{
    private string sayfa = null;
    public string Sayfa { get { return sayfa; } }
    int sayfasayisi = 0;
    systematik degisken;
    DataSet al = null;
    #region Sayı Kontrol
    public bool sayikontrol(string gelen)
    {
        bool durum = false;
        string[] rakamlar = new string[10];
        for (int i = 0; i <= rakamlar.Length - 1; i++)
            rakamlar[i] = i.ToString();

        char[] karakterler = gelen.ToCharArray();
        for (int i = 0; i <= karakterler.Length - 1; i++)
        {
            for (int j = 0; j <= rakamlar.Length - 1; j++)
            {
                if (karakterler[i].ToString() == rakamlar[j])
                    break;
                else if (karakterler[i].ToString() != rakamlar[j] && j == rakamlar.Length - 1)
                {
                    durum = true;
                    break;
                }
                else if (karakterler[i].ToString() != rakamlar[j])
                    continue;
            }
            if (durum)
                break;
        }
        return durum;
    }
    #endregion

    protected void Page_Load(object sender, EventArgs e)
    {
        degisken = new systematik();
        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;
        string sorgu = "select staj.sno, staj.ono, CAST(dbo.ogrenciAdiDondur(staj.ono) as varchar(50)) as ogrenciAdi, CAST(dbo.cokluDondur(staj.ino, 'sirket') as varchar(50)) as sirketAdi , staj.baslama, staj.bitis, CAST(dbo.cokluDondur(staj.did,'departman') as varchar(50)) as departmanAdi, degerlendirme from dbo.staj";
        al = degisken.genelvericekme(sorgu);
        string forLiteral = "";
        for (int i = 0; i <= al.Tables[0].Rows.Count - 1; i++)
        {
            string degerlendirmeStatus = al.Tables[0].Rows[i][7].ToString() == "" ? "unread" : "";
            DateTime baslama = (DateTime)al.Tables[0].Rows[i][4];
            DateTime bitis = (DateTime)al.Tables[0].Rows[i][5];
            forLiteral = "<tr class=\"" + degerlendirmeStatus + " searchThese\">"
                               + "    <td class=\"inbox-small-cells\">"
                               //+ "         <input type = \"checkbox\" class=\"mail-checkbox\">"
                               + "          <a data-toggle=\"collapse\" data-parent=\"#accordion\" href=\"#" + al.Tables[0].Rows[i][0] + "\" class=\"mail-checkbox\" ><i class=\"fa fa-plus fa fa-white\"></i></a>"
                               + "     </td>"
                               + "     <td class=\"inbox-small-cells\"><i class=\"fa fa-star\" > " + al.Tables[0].Rows[i][1] + "</i></td>"
                               + "     <td class=\"view-message  dont-show\" >" + al.Tables[0].Rows[i][2] + "</td>"
                               + "     <td class=\"view-message \" > " + al.Tables[0].Rows[i][3] + " </td>"
                               + "     <td class=\"view-message  inbox-small-cells\" > " + al.Tables[0].Rows[i][6] + " </td>"
                               + "     <td class=\"view-message  text-right\" > " + baslama.ToShortDateString() + " - " + bitis.ToShortDateString() + "</td>"
                               + " </tr> "

                               + "<tr class=\"collapse\" id=\"" + al.Tables[0].Rows[i][0] + "\">"
                               + " <td class=\"inbox-small-cells\"></td>"
                               + " <td class=\"inbox-small-cells\"></td>"
                               + " <td class=\"inbox-small-cells\"></td>"
                               + " <td class=\"inbox-small-cells\"><a style=\"text-decoration: none;\" href=\"mulakat.aspx?sno=" + al.Tables[0].Rows[i][0] + "\"><input type=\"button\" class=\"btn btn-block btn-primary\" value=\"Mülakat Oluştur\"></a></td>"
                               + " <td class=\"inbox-small-cells\"><a style=\"text-decoration: none;\" href=\"staj.aspx?sno=" + al.Tables[0].Rows[i][0] + "\"><input type=\"button\" class=\"btn btn-block btn-info\" value=\"Stajı Düzenle\"></a></td>"
                               + " <td class=\"inbox-small-cells\"><a style=\"text-decoration: none;\" href=\"statusReport.aspx?g=stajSil&sno=" + al.Tables[0].Rows[i][0] + "\"><input type=\"button\" class=\"btn btn-block btn-danger\" value=\"Stajı Sil\"></a>"
                               + "</tr>";
            Literal1.Text += forLiteral;
        }
        al.Dispose();

        //Konuların Dropbox'a eklenmesi
        sorgu = "select kno, konu_adi from dbo.konu";
        al = degisken.genelvericekme(sorgu);
        if (DropDownList1.Items.Count == 0)
        {
            for (int i = 0; i <= al.Tables[0].Rows.Count - 1; i++)
            {
                DropDownList1.Items.Add(al.Tables[0].Rows[i][1].ToString());
                DropDownList1.Items[i].Value = al.Tables[0].Rows[i][0].ToString();
            }
            //<h6 class="pull-right" id="counter50">50 karakter kaldı.</h6>
            sayici.Text = "<h6 class=\"pull-right\" id=\"counter50\">50 karakter kaldı.</h6>";
            CheckBox1.Text = "Yeni Konu Ekle";

        }

        //İşyerinin Dropbox'a eklenmesi
        sorgu = "select ino, sirket_adi from dbo.sirket";
        al = degisken.genelvericekme(sorgu);
        if (DropDownList2.Items.Count == 0)
        {
            for (int i = 0; i <= al.Tables[0].Rows.Count - 1; i++)
            {
                DropDownList2.Items.Add(al.Tables[0].Rows[i][1].ToString());
                DropDownList2.Items[i].Value = al.Tables[0].Rows[i][0].ToString();
            }
            //<h6 class="pull-right" id="counter50">50 karakter kaldı.</h6>
            sayici2.Text = "<h6 class=\"pull-right\" id=\"counter50\">50 karakter kaldı.</h6>";
            CheckBox2.Text = "Yeni İşyeri Ekle";

        }

        //Departmanların Dropbox'a eklenmesi
        sorgu = "select did, departman from dbo.departman";
        al = degisken.genelvericekme(sorgu);
        if (DropDownList3.Items.Count == 0)
        {
            for (int i = 0; i <= al.Tables[0].Rows.Count - 1; i++)
            {
                DropDownList3.Items.Add(al.Tables[0].Rows[i][1].ToString());
                DropDownList3.Items[i].Value = al.Tables[0].Rows[i][0].ToString();
            }
            //<h6 class="pull-right" id="counter50">50 karakter kaldı.</h6>
            sayici3.Text = "<h6 class=\"pull-right\" id=\"counter50\">50 karakter kaldı.</h6>";
            CheckBox3.Text = "Yeni Departman Ekle";

        }

        degerlendirme.Enabled = false;
        kabulEdilen.Enabled = false;

        DropDownList1.Attributes.Add("style", "padding-top: 5px;");
        CheckBox1.Attributes.Add("class", "mail-checkbox");
        ogrenciNo.Attributes.Add("placeholder", "Öğrenci Numarası");
        yeniKonu.Attributes.Add("placeholder", "Yeni Konu Giriniz");
        yeniKonu.Attributes.Add("name", "yeniKonu");
        yeniIsyeri.Attributes.Add("placeholder", "Yeni İşyeri Giriniz");
        yeniIsyeri.Attributes.Add("name", "yeniIsyeri");
        yeniIsyeriAdres.Attributes.Add("placeholder", "İşyerinin Adresi");
        yeniIsyeriAdres.Attributes.Add("name", "yeniIsyeriAdres");
        yeniIsyeriIletisim.Attributes.Add("placeholder", "İşyerinin Telefonu");
        yeniIsyeriIletisim.Attributes.Add("name", "yeniIsyeriIletisim");

        yeniDepartman.Attributes.Add("placeholder", "Yeni Departman Giriniz");
        kabulEdilen.Attributes.Add("placeholder", "Değerlendirme Sonucu Oluşturulacak");
        degerlendirme.Attributes.Add("placeholder", "Mülakat Sonucu Güncellenecek Değerlendirme");
        sinif.Attributes.Add("placeholder", "Öğrencinin Sınıfını Giriniz");
        toplam_gun.Attributes.Add("placeholder", "Toplam Günü Giriniz");

        //Konu Visible
        if (DropDownList1.Items.Count == 0)
        {
            yeniKonu.Attributes.Add("style", "display: block;");
            sayici.Attributes.Add("style", "display: block;");
            DropDownList1.Attributes.Add("style", "display: none;");
            CheckBox1.Visible = false;
        }
        else
        {
            yeniKonu.Attributes.Add("style", "display: none;");
            sayici.Attributes.Add("style", "display: none;");
            DropDownList1.Attributes.Add("style", "display: block;");
            CheckBox1.Visible = true;
        }

        //İşyeri Visible
        if (DropDownList2.Items.Count == 0)
        {
            yeniIsyeri.Attributes.Add("style", "display: block;");
            sayici2.Attributes.Add("style", "display: block;");
            yeniIsyeriAdres.Attributes.Add("style", "display: block;");
            yeniIsyeriIletisim.Attributes.Add("style", "display: block;");
            DropDownList2.Attributes.Add("style", "display: none;");
            CheckBox2.Visible = false;
        }
        else
        {
            yeniIsyeri.Attributes.Add("style", "display: none;");
            sayici2.Attributes.Add("style", "display: none;");
            yeniIsyeriAdres.Attributes.Add("style", "display: none;");
            yeniIsyeriIletisim.Attributes.Add("style", "display: none;");
            DropDownList2.Attributes.Add("style", "display: block;");
            CheckBox2.Visible = true;
        }

        //Departman Visible
        if (DropDownList3.Items.Count == 0)
        {
            yeniDepartman.Attributes.Add("style", "display: block;");
            sayici3.Attributes.Add("style", "display: block;");
            DropDownList3.Attributes.Add("style", "display: none;");
            CheckBox3.Visible = false;
        }
        else
        {
            yeniDepartman.Attributes.Add("style", "display: none;");
            sayici3.Attributes.Add("style", "display: none;");
            DropDownList3.Attributes.Add("style", "display: block;");
            CheckBox3.Visible = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;
        int[] stajInsert = new int[3];
        //Konu Ekleme, Listeden Seçme
        if (CheckBox1.Checked || DropDownList1.Items.Count == 0)
        {
            if (yeniKonu.Text.Length != 0)
            {
                if (yeniKonu.Text.Length < 50)
                {
                    string sorgu = "select konu_adi from konu where konu_adi like '%" + yeniKonu.Text + "%'";
                    DataSet al = degisken.genelvericekme(sorgu);
                    if (al.Tables[0].Rows.Count == 0)
                    {
                        //Konu ekleme
                        sorgu = "insert into konu(konu_adi) values('" + yeniKonu.Text.TrimEnd().TrimStart().ToString() + "')";
                        degisken.genelinsert(sorgu);

                        //Eklenen konunun id'si
                        sorgu = "select kno from konu where konu_adi = '" + yeniKonu.Text.TrimEnd().TrimStart() + "'";
                        al = degisken.genelvericekme(sorgu);
                        stajInsert[0] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);


                        System.GC.SuppressFinalize(degisken);
                        //Response.Redirect("statusReport.aspx?g=questionInsert");
                    }
                }
                else
                {
                    System.GC.SuppressFinalize(degisken);
                    Response.Redirect("statusReport.aspx?g=longTopic");
                }
            }
            else
            {
                System.GC.SuppressFinalize(degisken);
                Response.Redirect("statusReport.aspx?g=questionInsertFail");
            }
        }
        //else
        //{
        //    System.GC.SuppressFinalize(degisken);
        //    Response.Redirect("statusReport.aspx?g=questionInsertFail");
        //}
        else
        {
            int topicID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
            //string sorgu = "select kno from konu where konu_adi = '" + DropDownList1.SelectedItem.Text.TrimEnd().TrimStart().ToString() + "'";
            //DataSet al = degisken.genelvericekme(sorgu);
            //stajInsert[0] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);
            stajInsert[0] = topicID;
            //degisken.genelinsert(sorgu);
            System.GC.SuppressFinalize(degisken);
        }

        //İşyeri Ekleme, Listeden Seçme
        if (CheckBox2.Checked || DropDownList2.Items.Count == 0)
        {
            if (yeniIsyeriAdres.Text.Length != 0 && yeniIsyeriIletisim.Text.Length != 0 && yeniIsyeri.Text.Length != 0)
            {
                if (yeniIsyeri.Text.Length < 50 && yeniIsyeriAdres.Text.Length < 200 && yeniIsyeriIletisim.Text.Length < 18)
                {
                    string sorgu = "select sirket_adi from sirket where sirket_adi like '%" + yeniIsyeri.Text + "%'";
                    DataSet al = degisken.genelvericekme(sorgu);
                    if (al.Tables[0].Rows.Count == 0)
                    {
                        //Konu ekleme
                        sorgu = "insert into sirket(sirket_adi, adresi, iletisim) values('" + yeniIsyeri.Text.TrimEnd().TrimStart().ToString() + "' , '" + yeniIsyeriAdres.Text.TrimEnd().TrimStart().ToString() + "' , '" + yeniIsyeriIletisim.Text.TrimEnd().TrimStart().ToString() + "')";
                        degisken.genelinsert(sorgu);

                        //Eklenen konunun id'si
                        sorgu = "select ino from sirket where sirket_adi = '" + yeniIsyeri.Text.TrimEnd().TrimStart() + "'";
                        al = degisken.genelvericekme(sorgu);
                        stajInsert[1] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);

                        System.GC.SuppressFinalize(degisken);
                        //Response.Redirect("statusReport.aspx?g=questionInsert");
                    }
                }
                else
                {
                    System.GC.SuppressFinalize(degisken);
                    //Response.Redirect("statusReport.aspx?g=longTopic");
                }
            }
            else
            {
                System.GC.SuppressFinalize(degisken);
                //.Redirect("statusReport.aspx?g=questionInsertFail");
            }
        }
        else
        {
            int companyID = Convert.ToInt32(DropDownList2.SelectedItem.Value);
            //string sorgu = "select kno from konu where konu_adi = '" + DropDownList1.SelectedItem.Text.TrimEnd().TrimStart().ToString() + "'";
            //DataSet al = degisken.genelvericekme(sorgu);
            //stajInsert[0] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);
            stajInsert[1] = companyID;
            //degisken.genelinsert(sorgu);
            System.GC.SuppressFinalize(degisken);
        }

        //Departman Listeden Seçme Ekleme
        if (CheckBox3.Checked || DropDownList3.Items.Count == 0)
        {
            //if (question.Text.Length != 0 && questionHeader.Text.Length != 0)
            //{
            if (yeniDepartman.Text.Length != 0)
            {
                if (yeniDepartman.Text.Length < 50)
                {
                    string sorgu = "select departman from dbo.departman where departman like '%" + yeniDepartman.Text + "%'";
                    DataSet al = degisken.genelvericekme(sorgu);
                    if (al.Tables[0].Rows.Count == 0)
                    {
                        //Konu ekleme
                        sorgu = "insert into departman(departman) values('" + yeniDepartman.Text.TrimEnd().TrimStart().ToString() + "')";
                        degisken.genelinsert(sorgu);

                        //Eklenen konunun id'si
                        sorgu = "select departman.did from dbo.departman where departman.departman = '" + yeniDepartman.Text.TrimEnd().TrimStart() + "'";
                        al = degisken.genelvericekme(sorgu);
                        stajInsert[2] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);

                        System.GC.SuppressFinalize(degisken);
                        //Response.Redirect("statusReport.aspx?g=questionInsert");
                    }
                    stajInsert[2] = Convert.ToInt32(al.Tables[0].Rows[0][0]);
                }
                else
                {
                    System.GC.SuppressFinalize(degisken);
                    Response.Redirect("statusReport.aspx?g=longTopic");
                }
            }
            else
            {
                System.GC.SuppressFinalize(degisken);
                Response.Redirect("statusReport.aspx?g=questionInsertFail");
            }
        }
        else
        {
            int departmanID = Convert.ToInt32(DropDownList3.SelectedItem.Value);
            //string sorgu = "select kno from konu where konu_adi = '" + DropDownList1.SelectedItem.Text.TrimEnd().TrimStart().ToString() + "'";
            //DataSet al = degisken.genelvericekme(sorgu);
            //stajInsert[0] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);
            stajInsert[2] = departmanID;
            //degisken.genelinsert(sorgu);
            System.GC.SuppressFinalize(degisken);
        }

        if (stajInsert[0].ToString() != null && stajInsert[1].ToString() != null && stajInsert[2].ToString() != null)
        {
            if (ogrenciNo.Text != null)
            {
                string sorgu = "select ono from dbo.ogrenci where ono = " + ogrenciNo.Text;
                DataSet al = degisken.genelvericekme(sorgu);
                if (al.Tables[0].Rows.Count != 0)
                {
                    if (baslangicTarihi.Value != null && bitisTarihi.Value != null)
                    {
                        if (toplam_gun.Text != null)
                        {
                            if (sinif.Text != null)
                            {
                                bool isArge = false;
                                if (stajInsert[2] == 4)
                                    isArge = true;
                                int sinifInt = Convert.ToInt32(sinif.Text);
                                int stajGun = Convert.ToInt32(toplam_gun.Text);
                                if (stajGun < 15)
                                {
                                    Response.Redirect("statusReport.aspx?g=sinifGunFail");
                                }
                                else if (stajGun > 40 && isArge == false)
                                {
                                    Response.Redirect("statusReport.aspx?g=sinifGunFail");
                                }
                                else if (sinifInt <= 2 && stajGun >= 25)
                                {
                                    Response.Redirect("statusReport.aspx?g=sinifFail2");
                                }
                                //else if (stajGun > 60)
                                //{
                                //    Response.Redirect("statusReport.aspx?g=60gun");
                                //}
                                //insert into staj(ono, kno, ino, departman, baslama, bitis, toplam_gun, sinif) values(357405, 1, 1, 1, convert(datetime,'24/12/2018',103), convert(datetime,'27/12/2018',103), 40, 4)
                                sorgu = "insert into staj(ono, kno, ino, did, baslama, bitis, toplam_gun, sinif) " +
                                    "values(" + ogrenciNo.Text + ", " + stajInsert[0].ToString() + ", " + stajInsert[1].ToString() + ", " + stajInsert[2].ToString() +
                                    ",  convert(datetime,'" + baslangicTarihi.Value + "',103),  convert(datetime,'" + bitisTarihi.Value + "',103), " + toplam_gun.Text + ", " + sinif.Text + ")";
                                degisken.genelinsert(sorgu);
                                System.GC.SuppressFinalize(degisken);
                                Response.Redirect("statusReport.aspx?g=stajInsert");
                            }
                            else
                            {
                                Response.Redirect("statusReport.aspx?g=sinifFail");
                            }
                        }
                        else
                        {
                            Response.Redirect("statusReport.aspx?g=toplamGunFail");
                        }
                    }
                    else
                    {
                        Response.Redirect("statusReport.aspx?g=baslangic-bitis-fail");
                    }
                }
                else
                {
                    Response.Redirect("statusReport.aspx?g=ogrenciYok");
                }
            }
            else
            {
                Response.Redirect("statusReport.aspx?g=ogrenciBos");
            }
        }
        else
        {
            Response.Redirect("statusReport.aspx?g=konu-departman-isyeri-fail");
        }
    }
}