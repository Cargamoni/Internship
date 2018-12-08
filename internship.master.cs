using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class internship : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ad = uyeno.Text;
        string sifre = uyeparola.Text;
        if (ad == "" || sifre == "")
        {
            //Label3.Text = "Lütfen Alanları Boş Geçmeyiniz";
        }
        else
        {
            sqlDataSource1.SelectParameters["email"].DefaultValue = ad;
            sqlDataSource1.SelectParameters["pass"].DefaultValue = sifre;
            DataTable c = ((DataView)sqlDataSource1.Select(DataSourceSelectArguments.Empty)).Table.Copy();
            int g = c.DefaultView.Count;
            if (g > 0)
            {
                string baglanti = WebConfigurationManager.ConnectionStrings["QuestionerConnection"].ConnectionString;
                SqlConnection yeni = new SqlConnection(baglanti);
                SqlCommand komut = new SqlCommand("select pID from Profiles where email='" + ad + "' and pass='" + sifre + "'", yeni);
                string pID = "";
                if (yeni.State == ConnectionState.Closed)
                {
                    yeni.Open();
                }
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    pID = oku[0].ToString();
                }
                if (pID != "")
                {
                    //FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, ad, DateTime.Now, DateTime.Now.AddMinutes(60), false, oku[0].ToString(), FormsAuthentication.FormsCookiePath);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, oku[0].ToString(), DateTime.Now, DateTime.Now.AddMinutes(60), false, "Admin", FormsAuthentication.FormsCookiePath);
                    string encticket = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encticket);
                    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("panel/Default.aspx");
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
    }
}
