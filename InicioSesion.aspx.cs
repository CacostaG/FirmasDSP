using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using ListadoDeFirmasDSP.GauDes;
using System.Data.Sql;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;


namespace ListadoDeFirmasDSP
{
    public partial class InicioSesion : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnFirmasDSP"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             
             
             */


        }

    
        public void ValidateUser(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();



            try
            {
                if (txtUser.Text != "Usuario" || string.IsNullOrEmpty(txtUser.Text))
                {
                    if (Pass.Text != "Contraseña" || string.IsNullOrEmpty(Pass.Text))
                    {
                        UserModel user = new UserModel();
                        var validLogin = user.LoginUser(txtUser.Text, Pass.Text);
                        if (validLogin == true)
                        {
                            
                            Response.Redirect("~/Default");
                            
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Necesitas un USUARIO registrado ' , 'warning');", true);
                        }
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'El formato de la contraseña no es valido.' , 'warning');", true);

                }
                else
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar campos vacíos.' , 'warning');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('!', '" + ex.Message + "' , 'warning');", true);
            }

       


        }


     


        /*

        GAU.GauClient gauClient = new GAU.GauClient();

        GAU.TokenModel tokenModel = null;
        try
        {

            tokenModel = gauClient.Autentica(txtUser.Text, Pass.Text,"FIRMAS");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
            Response.Cache.SetAllowResponseInBrowserHistory(false);
            Response.Cache.SetNoStore();

            if(tokenModel.LoginValido == 0 ) 
            {
                var cError = tokenModel.CodigoError;
                switch (cError)
                {
                    case 1:
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Verifica credenciales.!', 'Datos incorrectos' , 'error');", true);
                        break;
                    case 2:
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Usuario no valido.!', 'Usuario inactivo' , 'error');", true);
                        break;
                    case 3:
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Acceso denegado.!', 'El usuario no ha sido asociado al aplicativo' , 'error');", true);
                        break;
                    case 4:
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Nuevo usuario.!', 'Se ha enviado un correo para cambiar su contraseña' , 'info');", true);
                        gauClient.EnviarCorreoCambioPassword(txtUser.Text);
                        break;
                    case 5:
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Ha alcanzado el límite de intentos permitidos.!', 'Se ha enviado un correo para recuperar su contraseña' ,'warning');", true);
                        gauClient.EnviarCorreoReestablecerPassword(txtUser.Text);
                        break;
                    case 6:
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Contraseña expirada.!', 'Se ha enviado un correo para recuperar su contraseña' , 'warning');", true);
                        gauClient.EnviarCorreoCambioPassword(txtUser.Text);
                        break;
                }
            }
            else
            {
                if(tokenModel.LoginValido == 1)
                {
                    Session["token"] = tokenModel;
                    Session["aplicativo"] = tokenModel.Aplicativo;
                    Session["user"] = tokenModel.Usuario;
                    Session["nombre"] = tokenModel.Nombre;
                    Session["email"] = tokenModel.CorreoElectronico;
                    Session["cookie"] = tokenModel.SesionId;
                    Session["login"] = tokenModel.LoginValido;
                    Session["cerror"] = tokenModel.CodigoError;
                    Session["rol"] = tokenModel.Roles[0].Rol;

                    SqlParameter parameter = new SqlParameter("@usuario", txtUser.Text);
                    SqlCommand cmd = new SqlCommand("Pry1015_ListadoFirmasLoginJuris", conexionBD);
                    cmd.Parameters.Add(parameter);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conexionBD.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Session["jurisdiccion_id"] = reader["jurisdiccion_id"].ToString();
                        Session["nombreJuris"] = reader["nombre"].ToString();
                        Session["estatus"] = reader["estatus"].ToString();

                        var estatus = Session["estatus"];

                        switch(estatus)
                        {
                            case "ACTIVO":
                                Response.Redirect("~/Default");
                                break;
                            case "INACTIVO":
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Usuario DESHABILITADO' , 'warning');", true);
                                break;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Usuario no registrado en SISTEMA DE FIRMAS' , 'warning');", true);
                    }   
                }
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('!', '"+ex.Message+"' , 'warning');", true);
        }
        */





    }
           
}