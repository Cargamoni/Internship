using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_yonetim : System.Web.UI.MasterPage
{
    systematik degisken;
    protected void Page_Load(object sender, EventArgs e)
    {
        degisken = new systematik();
        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;

        string sorgu = "select ad, soyad, unvan from dbo.kurul where uno = '" + ticket.Name + "'";
        DataSet al = degisken.genelvericekme(sorgu);
        kuruluyeadisoyadi.Text = al.Tables[0].Rows[0][2].ToString();
        kurulyetkisi.Text = al.Tables[0].Rows[0][0].ToString() + " " + al.Tables[0].Rows[0][1].ToString();

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
        kabulEdilen.Attributes.Add("placeholder", "Kabul Edilen Günü Giriniz");
        degerlendirme.Attributes.Add("placeholder", "Mülakat Sonucu Güncellenecek Değerlendirme");
        sinif.Attributes.Add("placeholder", "Öğrencinin Sınıfını Giriniz");

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
        if ( CheckBox1.Checked || DropDownList1.Items.Count == 0)
        {
            //if (question.Text.Length != 0 && questionHeader.Text.Length != 0)
            //{
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



                        //sorgu = "INSERT INTO dbo.Questions ([pID],[tID],[qHeader],[question],[qDate])"
                        //       + "VALUES(" + id.Name + "," + al.Tables[0].Rows[0][0].ToString() + ",'" + yeniKonu.Text + "','" + yeniKonu.Text + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "')";
                        //degisken.genelinsert(sorgu);
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
            //if (question.Text.Length != 0 && questionHeader.Text.Length != 0)
            //{
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


                        //sorgu = "INSERT INTO dbo.Questions ([pID],[tID],[qHeader],[question],[qDate])"
                        //       + "VALUES(" + id.Name + "," + al.Tables[0].Rows[0][0].ToString() + ",'" + yeniKonu.Text + "','" + yeniKonu.Text + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "')";
                        //degisken.genelinsert(sorgu);
                        System.GC.SuppressFinalize(degisken);
                        Response.Redirect("statusReport.aspx?g=questionInsert");
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
                    string sorgu = "select departman from departman where departman like '%" + yeniDepartman.Text + "%'";
                    DataSet al = degisken.genelvericekme(sorgu);
                    if (al.Tables[0].Rows.Count == 0)
                    {
                        //Konu ekleme
                        sorgu = "insert into departman(departman) values('" + yeniDepartman.Text.TrimEnd().TrimStart().ToString() + "')";
                        degisken.genelinsert(sorgu);

                        //Eklenen konunun id'si
                        sorgu = "select did from departman where departman = '" + yeniDepartman.Text.TrimEnd().TrimStart() + "'";
                        al = degisken.genelvericekme(sorgu);
                        stajInsert[0] = System.Convert.ToInt32(al.Tables[0].Rows[0][0]);



                        //sorgu = "INSERT INTO dbo.Questions ([pID],[tID],[qHeader],[question],[qDate])"
                        //       + "VALUES(" + id.Name + "," + al.Tables[0].Rows[0][0].ToString() + ",'" + yeniKonu.Text + "','" + yeniKonu.Text + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "')";
                        //degisken.genelinsert(sorgu);
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
    }
}
