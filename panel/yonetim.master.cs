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
    public string degerlendirmeStatus;
    protected void Page_Load(object sender, EventArgs e)
    {
        degisken = new systematik();
        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;

        string sorgu = "select ad, soyad, unvan from dbo.kurul where uno = '" + ticket.Name + "'";
        DataSet al = degisken.genelvericekme(sorgu);
        kuruluyeadisoyadi.Text = al.Tables[0].Rows[0][2].ToString();
        kurulyetkisi.Text = al.Tables[0].Rows[0][0].ToString() + " " + al.Tables[0].Rows[0][1].ToString();

        sorgu = "select count(sno) from staj where degerlendirme is null";
        al = degisken.genelvericekme(sorgu);
        if (al.Tables[0].Rows.Count != 0)
        {
            degerlendirmeStatus = "<span class=\"label label-danger pull-right\">" + al.Tables[0].Rows[0][0].ToString()
                + "</span>";
        }

        al.Dispose();
        System.GC.SuppressFinalize(degisken);
    }
}
