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
            /*
            
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/InicioSesion.aspx");
            */

            UserData.token = 0;
            UserData.Usuario = "Usuario";
            UserData.clave = "Password";
            
            Response.Redirect("~/InicioSesion.aspx");

        }


     

    }
}