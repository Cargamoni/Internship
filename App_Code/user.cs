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
                    ascxtip = "ana.ascx";
                    break;
                case "ana":
                    ascxtip = "ana.ascx";
                    break;
                case "askquestion":
                    ascxtip = "askQuestion.aspx";
                    break;
                case "userInfo":
                    ascxtip = "userInfo.ascx";
                    break;
                case "topics":
                    ascxtip = "allTopics.ascx";
                    break;
                case "anaSearch":
                    ascxtip = "ana.ascx";
                    break;
                case "topicSearch":
                    ascxtip = "allTopics.ascx";
                    break;
            }
        }
    }
}