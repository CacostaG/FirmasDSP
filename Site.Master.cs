using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListadoDeFirmasDSP
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

          if (Session["token"] == null)
            {
                Response.Redirect("~/InicioSesion.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    string rolSession = Session["rol"]  as string;
                    rol.Text = rolSession;

                    string nombreUsuarioSession = Session["nombre"] as string;
                    nombreUsuario2.Text = nombreUsuarioSession;

                    string jurisdiccion_idSession = Session["jurisdiccion_id"] as string;
                    jurisid.Text = jurisdiccion_idSession;

                    
                    string Rol = (string)Session["rol"];
                    switch (Rol)
                    {
                        case "Administrador":
                            impresion.Visible = false;
                            break;
                        case "Validador":
                            admin.Visible = false;
                            impresion.Visible = false;
                            impAdmin.Visible = false;
                            break;

                        case "Operador del sistema":
                            admin.Visible = false;
                            consulta.Visible = false;
                            impAdmin.Visible = false;
                            break;
                    }
                }



            } 


            
      

        }


        ///ejemplo de modal de prueba
        protected void algunProceso(object sender, EventArgs e)
        {
            LinkButton linkB = (LinkButton)sender;
            muestraModal("Titulo del modal", "Contenido bla bla bla", "");
        }
        protected void muestraModal(string titulo, string mensaje, string ruta)
        {
            Button bt = new Button();
            bt.Text = "Cerrar";
            bt.CssClass = "btn btn-info";
            bt.Attributes.Add("data-dismiss", "modal");
            bt.Attributes.Add("aria-hidden", "true");
            if (ruta != "")
            {
                bt.Attributes.Add("onclick", "location.href ='" + ruta + "'");
            }

            PlaceHolder1.Controls.Add(bt);
            lblModalTitle.Text = titulo;
            lblModalBody.Text = mensaje;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModalMaster", "$('#myModalMaster').modal();", true);
            upModal.Update();
        }

        /// Modal Datos Usuaario
        protected void clickDatosUser(object sender, EventArgs e)
        {

            LoadData("", "", "");
        }
        
        protected void datosdeUser(string datoUsuario, string datoNombre, string datoCorreo)
        {
            Button buton = new Button();
            buton.Text = "Cerrar";
            buton.CssClass = "btn btn-info";
            buton.Attributes.Add("data-dismiss", "modal");
            buton.Attributes.Add("aria-hidden", "true");
            PlaceHolder1.Controls.Add(buton);


            lblModalDatoNombre.Text = Session["nombre"].ToString();
            lblModalDatoUsuario.Text = Session["Usuario"].ToString();
            lblModalDatoCorreo.Text = Session["email"].ToString();
            lblJur.Text = Session["nombreJuris"].ToString();

            /*
            string nombreUsuarioSessionData = Session["nombre"] as string;
            string usuarioSessionData = Session["usuario"] as string;
            lblModalDatoNombre.Text = nombreUsuarioSessionData;
            lblModalDatoUsuario.Text = usuarioSessionData;*/



            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "datosUser", "$('#datosUser').modal('show');", true);
            upModalUsers.Update();
        }

  

        protected void LoadData(string datoUsuario, string datoNombre, string datoCorreo)
        {
            Button buton = new Button();
            buton.Text = "Cerrar";
            buton.CssClass = "btn btn-info";
            buton.Attributes.Add("data-dismiss", "modal");
            buton.Attributes.Add("aria-hidden", "true");
            PlaceHolder1.Controls.Add(buton);


            lblModalDatoNombre.Text = Session["nombre"].ToString();
            lblModalDatoUsuario.Text = Session["user"].ToString();
            lblModalDatoCorreo.Text = Session["rol"].ToString();
            lblJur.Text = Session["nombreJuris"].ToString();

         

            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "datosUser", "$('#datosUser').modal('show');", true);
            upModalUsers.Update();
        }

       

    }
}