using System.Data;
using System.Data.SqlClient;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ListadoDeFirmasDSP
{
    public partial class CambioPassword : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["token"]))
            {

                Response.Redirect("~/InicioSesion.aspx");
            }
            else
            {
                User.Text = Session["idUsuario"].ToString();
                User.Visible = false;
            }
            

        }

        protected void btnCtrlModificarGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
                conexionBD.Open();

                SqlCommand updatePass = new SqlCommand("spDSP_UsuarioUpdatePass", conexionBD);
                updatePass.CommandType = CommandType.StoredProcedure;
                updatePass.Parameters.Clear();

                updatePass.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(User.Text));
                updatePass.Parameters.AddWithValue("@pass", Convert.ToString(CtrlAddPass.Text));
                updatePass.Parameters.AddWithValue("@usuario", Convert.ToString(CtrlAddUsuario.Text));
                updatePass.Parameters.AddWithValue("@rfc", Convert.ToString(CtrlAddRFC.Text));
                updatePass.Parameters.AddWithValue("@correoElectronico", Convert.ToString(CtrlAddEmail.Text));
                
                int respuestaUpdate = updatePass.ExecuteNonQuery();
                 if (respuestaUpdate > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La contraseña ha sido actualizada con éxito , reinicia tu sesión', 'success');", true);
                    conexionBD.Close();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'La contraseña no se ha podido actualizar , verifica los datos', 'error');", true);
                }


            }
            catch (Exception error)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!'," + error.Message + ", 'info');", true);
            }
        }

        protected void btnCtrolAddPassSugerido_Click(object sender, EventArgs e)
        {
            CtrlAddPassGenerate.Visible = true;

            Random rdn = new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890%$#@.¡!¿?_-";
            int longitud = caracteres.Length;
            char letra;
            int longitudContrasenia = 8;
            string contraseniaAleatoria = string.Empty;
            for (int i = 0; i < longitudContrasenia; i++)
            {
                letra = caracteres[rdn.Next(longitud)];
                contraseniaAleatoria += letra.ToString();
                CtrlAddPassGenerate.Text = contraseniaAleatoria;
            }
        }

        protected void btnCancelaEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {
            CtrlAddEmail.Text = null;
            CtrlAddRFC.Text = null;
            CtrlAddPass.Text = null;
            CtrlAddUsuario.Text = null;
            CtrlAddPassGenerate.Visible = false;
        }
    }
}