using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class panel_mulakat : System.Web.UI.Page
{
    string gelen;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.QueryString["mulSil"] != null)
        {

        }
        else
        {
            systematik degisken = new systematik();
            gelen = Request.QueryString["sno"];
            string sorgu = "insert into mulakat(sno,tarih) values(" + gelen + ",";
            
        }
    }
}