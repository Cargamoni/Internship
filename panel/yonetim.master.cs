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
            yeniKonuLabel.Text = "<h2>Yeni Konu Ekle</h2>";
            //<h6 class="pull-right" id="counter50">50 karakter kaldı.</h6>
            sayici.Text = "<h6 class=\"pull-right\" id=\"counter50\">50 karakter kaldı.</h6>";
            yeniKonu.Visible = false;
            yeniKonuLabel.Visible = false;
            sayici.Visible = false;
            CheckBox1.Text = "Yeni Konu Ekle";
            yeniKonu.Text = "Bir konu ismi giriniz.";

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {
    }

}
