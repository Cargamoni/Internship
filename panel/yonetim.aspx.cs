using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_yonetim : System.Web.UI.Page
{
    private void ascxtipgonder(string p)
    {
        Control adminpage = (Control)LoadControl(p);
        PlaceHoldericerik.Controls.Clear();
        PlaceHoldericerik.Controls.Add(adminpage);
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Contents.Abandon();
        string args = Request.QueryString["user"];
        if (args == null)
        {
            args = "";
        }
        //Ascx bir kontroldür. Üzerinde çeşitli kontroller tutabilir.
        user yeni = new user(args);
        this.ascxtipgonder(yeni.ascxtip);
        if(args == "")
        {
            baslik.Text = "Ana Sayfa";
        }
        else if(args == "ogrenciler")
        {
            baslik.Text = "Öğrenci İşlemleri";
        }
        else if(args == "kurul")
        {
            baslik.Text = "Kurul Üye İşlemleri";
        }

    }
}