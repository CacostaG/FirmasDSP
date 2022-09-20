using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ListadoDeFirmasDSP
{
    public partial class CierraSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            Session.Clear();
            Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect("~/InicioSesion.aspx");
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));

           
            
            Response.Redirect("~/InicioSesion.aspx");

        }


     

    }
}