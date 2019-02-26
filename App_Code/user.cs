using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

/// <summary>
/// Summary description for user
/// </summary>
///         

public class user
{
    public string ascxtip;
    public string sagascxtip;
    systematik degisken = new systematik();
    public user(string args)
    {
        FormsIdentity id = (FormsIdentity)HttpContext.Current.User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;
        if (!ticket.Expired)
        {
            switch (args)
            {
                case "":
                    ascxtip = "main.ascx";
                    break;
                case "anasayfa":
                    ascxtip = "main.ascx";
                    break;
                case "ogrenciler":
                    ascxtip = "ogrenciler.ascx";
                        break;
                case "kurul":
                    ascxtip = "uyeler.ascx";
                    break;
            }
        }
    }
}