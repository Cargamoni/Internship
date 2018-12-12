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

        sorgu = "select ino, sirket_adi from dbo.sirket";
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
        ogrenciNo.Attributes.Add("placeholder", "Öğrenci Numarası");
        yeniKonu.Attributes.Add("placeholder", "Yeni Konu Giriniz");

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
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;
        if (!CheckBox1.Checked && !CheckBox1.Visible)
        {
            //if (question.Text.Length != 0 && questionHeader.Text.Length != 0)
            //{
            if (yeniKonu.Text.Length != 0)
            {
                if (yeniKonu.Text.Length < 50)
                {
                    string sorgu = "select topic from Topics where topic like '%" + yeniKonu.Text + "%'";
                    DataSet al = degisken.genelvericekme(sorgu);
                    if (al.Tables[0].Rows.Count == 0)
                    {
                        sorgu = "insert into Topics(topic) values('" + yeniKonu.Text.TrimEnd().TrimStart().ToString() + "')";
                        degisken.genelinsert(sorgu);
                        sorgu = "select tID from Topics where topic = '" + yeniKonu.Text.TrimEnd().TrimStart() + "'";
                        al = degisken.genelvericekme(sorgu);
                        sorgu = "INSERT INTO dbo.Questions ([pID],[tID],[qHeader],[question],[qDate])"
                               + "VALUES(" + id.Name + "," + al.Tables[0].Rows[0][0].ToString() + ",'" + yeniKonu.Text + "','" + yeniKonu.Text + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "')";
                        degisken.genelinsert(sorgu);
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
        else
        {
            System.GC.SuppressFinalize(degisken);
            Response.Redirect("statusReport.aspx?g=questionInsertFail");
        }
        //}
        //else
        //{
        //if (question.Text.Length != 0 && questionHeader.Text.Length != 0)
        //{
        //    int topicID = Convert.ToInt32(DropDownList1.SelectedItem.Value);
        //    string sorgu = "select tID from Topics where topic = '" + DropDownList1.SelectedItem.Text.TrimEnd().TrimStart().ToString() + "'";
        //    DataSet al = degisken.genelvericekme(sorgu);
        //    sorgu = "INSERT INTO dbo.Questions ([pID],[tID],[qHeader],[question],[qDate])"
        //                   + "VALUES(" + id.Name + "," + al.Tables[0].Rows[0][0].ToString() + ",'" + questionHeader.Text + "','" + question.Text + "','" + DateTime.Now.ToString("MM-dd-yyyy") + "')";
        //    degisken.genelinsert(sorgu);
        //    System.GC.SuppressFinalize(degisken);
        //    Response.Redirect("statusReport.aspx?g=questionInsert");
        //}
        //else
        //{
        //    System.GC.SuppressFinalize(degisken);
        //    Response.Redirect("statusReport.aspx?g=questionInsertFail");
        //}
    }
}
