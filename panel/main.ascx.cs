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
        string sorgu = "select staj.sno, staj.ono, CAST(dbo.ogrenciAdiDondur(staj.ono) as varchar(50)) as ogrenciAdi, CAST(dbo.cokluDondur(staj.ino, 'sirket') as varchar(50)) as sirketAdi , staj.baslama, staj.bitis, CAST(dbo.cokluDondur(staj.departman,'departman') as varchar(50)) as departmanAdi, degerlendirme from dbo.staj";
        al = degisken.genelvericekme(sorgu);
        string degerlendirme = al.Tables[0].Rows[0][7].ToString() == "" ? "unread" : "";
        DateTime baslama = (DateTime)al.Tables[0].Rows[0][4];
        DateTime bitis = (DateTime)al.Tables[0].Rows[0][5];
        string forLiteral = "<tr class=\"" + degerlendirme + " searchThese\">"
                           + "    <td class=\"inbox-small-cells\">"
                           //+ "         <input type = \"checkbox\" class=\"mail-checkbox\">"
                           + "          <a data-toggle=\"collapse\" data-parent=\"#accordion\" href=\"#" + al.Tables[0].Rows[0][0] + "\" class=\"mail-checkbox\" ><i class=\"fa fa-plus fa fa-white\"></i></a>"
                           + "     </td>"
                           + "     <td class=\"inbox-small-cells\"><i class=\"fa fa-star\" > " + al.Tables[0].Rows[0][1] + "</i></td>"
                           + "     <td class=\"view-message  dont-show\" >" + al.Tables[0].Rows[0][2] + "</td>"
                           + "     <td class=\"view-message \" > " + al.Tables[0].Rows[0][3] + " </td>"
                           + "     <td class=\"view-message  inbox-small-cells\" > " + al.Tables[0].Rows[0][6] + " </td>"
                           + "     <td class=\"view-message  text-right\" > " + baslama.ToShortDateString() + " - " + bitis.ToShortDateString() + "</td>"
                           + " </tr> "

                           + "<tr class=\"collapse\" id=\"" + al.Tables[0].Rows[0][0] + "\">"
                           + " <td class=\"inbox-small-cells\"></td>"
                                                      + " <td class=\"inbox-small-cells\"></td>"
                                                                                 + " <td class=\"inbox-small-cells\"></td>"
                                                                                                            + " <td class=\"inbox-small-cells\"></td>"
                           + " <td class=\"inbox-small-cells\"><a href=\"mulakat.aspx?sno="+ al.Tables[0].Rows[0][0] +"\"><input type=\"button\" class=\"btn btn-block btn-primary\" value=\"Mülakat Oluştur\"></a></td>"
                           + " <td class=\"inbox-small-cells\"><a href=\"staj.aspx?sno=" + al.Tables[0].Rows[0][0] + "\"><input type=\"button\" class=\"btn btn-block btn-info\" value=\"Stajı Düzenle\"></a></td>"
                           + "</tr>";
         

        Literal1.Text = forLiteral;
        al.Dispose();
    }
}