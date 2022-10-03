using System.Data;
using System.Data.SqlClient;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace ListadoDeFirmasDSP._Administracion
{
    public partial class AdministracionDeUsuarios : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Convert.ToBoolean(Session["token"]))
            {

                Response.Redirect("~/InicioSesion.aspx");
            }

            else
            {
                if (!IsPostBack)
                {
                    var rol = Session["rol"];
                    var estatus = Session["estatus"];
                    switch (rol)
                    {
                        case "Validador":
                            Response.Redirect("~/Default");
                            break;
                        case "Operador del sistema":
                            Response.Redirect("~/Default");
                            break;
                    }

                    dvCtrlAgregar.Visible = false;

                    btnCtrlModificarGuardar.Visible = false;
                    ctrlModificarIdUser.Visible = false;

                    CatalogoUsuario();
                    parametros();
                    


                }
            }
        }



        /*Metodos Basicos*/
        protected void BtnLimpiar_Click(object sender, EventArgs e)
        {

            /*Modulo Agregar*/
            ddlCtrlAddJurisdiccion.Items.Clear();
            ddlCtrlAddJurisdiccion.Items.Add("Selecciona");
            ddlCtrlAddRol.Items.Clear();
            ddlCtrlAddRol.Items.Add("Selecciona");
            CtrlAddCurp.Text = null;
            CtrlAddEmail.Text = null;
            CtrlAddNombre.Text = null;
            CtrlAddRFC.Text = null;
            CtrlAddUsuario.Text = null;
            CtrlAddApMaterno.Text = null;
            CtrlAddApPaterno.Text = null;
            CtrlAddPass.Text = null;
            dvCtrlAddPassSugerido.Visible = false;


            /*limpiar modulo modificar*/

            ddlCtrlModificarEstatus.Items.Clear();
            ddlCtrlModificarEstatus.Items.Add("Selecciona");
            ddlCtrlModificarJuris.Items.Clear();
            ddlCtrlModificarJuris.Items.Add("Selecciona");
            ddlCtrlModificarRol.Items.Clear();
            ddlCtrlModificarRol.Items.Add("Selecciona");

            ddlCtrlModificarJuris.Text = null;
            ddlCtrlModificarRol.Text = null;
            ddlCtrlModificarEstatus.Text = null;
            txtCtrlModificarRFC.Text = null;
            txtCtrlModificarCURP.Text = null;
            txtCtrlModificarNombre.Text = null;
            txtCtrlModificarCorreo.Text = null;
            ddlCtrlModificarEstatus.Text = null;
            ctrlModificarIdUser.Text = null;

            dvCtrlModificarJuris.Visible = false;
            dvCtrlModificarRol.Visible = false;
            dvCtrlModificarRFC.Visible = false;
            dvCtrlModificarCURP.Visible = false;
            dvCtrlModificarNombre.Visible = false;
            dvCtrlModificarCorreo.Visible = false;
            dvCtrlModificarEstatus.Visible = false;

            txtCtrlModificarUsuario.Text = null;

            btnCtrlModificarGuardar.Visible = false; /*valida*/

            parametros();
            CatalogoUsuario();

        }
        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control.HasControls())

                    CleanControl(control.Controls);
            }

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    TextBox text = ctrl as TextBox;
                    text.Focus();
                }
            }

        }
        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_Administracion/AdministracionDeUsuarios.aspx");
        }
        private void CatalogoUsuario()
        {
            DataTable dtCatUsuario = new DataTable();
            SqlDataAdapter cmdCatusuario = new SqlDataAdapter("spcatDSP_UsuariosFirmas", conexionBD);
            conexionBD.Open();
            cmdCatusuario.Fill(dtCatUsuario);
            conexionBD.Close();
            gvUsuarios.DataSource = dtCatUsuario;
            gvUsuarios.DataBind();
            gvUsuarios.Columns[0].Visible = false;

        }
        private void parametros()
        {

            SqlCommand cmdJurisdiccion = new SqlCommand("spcatDSP_UsuariosFirmasFiltroxJuris ", conexionBD);
            SqlDataAdapter sdJurisdiccion = new SqlDataAdapter(cmdJurisdiccion);
            DataTable dtJurisdiccion = new DataTable();
            sdJurisdiccion.Fill(dtJurisdiccion);
            ddlJuris.Items.Clear();
            ddlJuris.Items.Add("Selecciona");

            ddlJuris.DataSource = dtJurisdiccion;
            ddlJuris.DataBind();
            
            ddlCtrlAddJurisdiccion.Items.Clear();
            ddlCtrlAddJurisdiccion.Items.Add("Selecciona");
            ddlCtrlAddJurisdiccion.DataSource = dtJurisdiccion;
            ddlCtrlAddJurisdiccion.DataBind();

            ddlCtrlModificarJuris.Items.Clear();
            ddlCtrlModificarJuris.Items.Add("Selecciona");

            ddlCtrlModificarJuris.DataSource = dtJurisdiccion;
            ddlCtrlModificarJuris.DataBind();
            
            SqlCommand cmdRol = new SqlCommand("spcatDSP_UsuariosFirmasFiltroxTipo ", conexionBD);
            SqlDataAdapter sdRol = new SqlDataAdapter(cmdRol);
            DataTable dtRol = new DataTable();
            sdRol.Fill(dtRol);


            ddlCtrlAddRol.Items.Clear();
            ddlCtrlAddRol.Items.Add("Seleeciona");
            ddlCtrlAddRol.DataSource = dtRol;
            ddlCtrlAddRol.DataBind();

            ddlCtrlModificarRol.Items.Clear();
            ddlCtrlModificarRol.Items.Add("Selecciona");
            ddlCtrlModificarRol.DataSource = dtRol;
            ddlCtrlModificarRol.DataBind();
            
            
            SqlCommand cmdESTATUS = new SqlCommand("spcatDSP_UsuariosFirmasFiltroxEstatus ", conexionBD);
            SqlDataAdapter sdESTATUS = new SqlDataAdapter(cmdESTATUS);
            DataTable dtESTATUS = new DataTable();
            sdESTATUS.Fill(dtESTATUS);
            ddlCtrlModificarEstatus.Items.Clear();
            ddlCtrlModificarEstatus.Items.Add("Selecciona");
            ddlCtrlModificarEstatus.DataSource = dtESTATUS;
            ddlCtrlModificarEstatus.DataBind();
         
        }

        /*Modulo Consulta*/
        protected void btConsulta_Click(object sender, EventArgs e)
        {

            BindGridViewConsulta();

        }
        protected void BindGridViewConsulta()
        {
            try
            {
                DataTable ConsultaJuris = new DataTable();
                SqlDataAdapter BuscaJuris = new SqlDataAdapter("spcatDSP_UsuariosFirmasConsulta  @jurisdiccion='" + ddlJuris.Text + "'", conexionBD);
                conexionBD.Open();
                BuscaJuris.Fill(ConsultaJuris);
                conexionBD.Close();

                if (ConsultaJuris.Rows.Count > 0)
                {
                    gvUsuarios.DataSource = ConsultaJuris;
                    gvUsuarios.DataBind();
                    gvUsuarios.Columns[0].Visible = true;
                    gvUsuarios.Columns[10].Visible = true;
                    gvUsuarios.Columns[11].Visible = true;


                }
                else
                {
                    if (string.IsNullOrEmpty(txtUser.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No  existe información', 'error');", true);
                    }
                    else
                    {
                        DataTable ConsultaUsuario = new DataTable();
                        SqlDataAdapter BuscaUsuario = new SqlDataAdapter("spcatDSP_UsuariosFirmasFiltroxNombre  @usuario='" + txtUser.Text + "'", conexionBD);
                        conexionBD.Open();
                        BuscaUsuario.Fill(ConsultaUsuario);
                        conexionBD.Close();

                        if (ConsultaUsuario.Rows.Count > 0)
                        {
                            gvUsuarios.DataSource = ConsultaUsuario;
                            gvUsuarios.DataBind();
                            gvUsuarios.Columns[0].Visible = true;
                            gvUsuarios.Columns[10].Visible = true;
                            gvUsuarios.Columns[11].Visible = true;

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No existe información', 'error');", true);
                        }
                    }
                }

            }
            catch (Exception error)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!'," + error.Message + ", 'info');", true);

            }

        }


        private void OcultaConsulta()
        {
            ControlJuris.Visible = false;
            dvUsuario.Visible = false;
            dvUsuario.Visible = false;
            btConsulta.Visible = false;
            BtnAgregar.Visible = false;

            gvUsuarios.Visible = false;
            ctrlModificarIdUser.Visible = false;
        }

        /*Modulo Actualizar*/


        protected void btnCtrlModificarGuardar_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
                conexionBD.Open();


                SqlCommand UpdateUsuario = new SqlCommand("spDSP_UsuarioEdita", conexionBD);
                UpdateUsuario.CommandType = CommandType.StoredProcedure;

                UpdateUsuario.Parameters.Clear();

                UpdateUsuario.Parameters.AddWithValue("@idUsuario", Convert.ToInt32(txtIdUsuario.Text));
                UpdateUsuario.Parameters.AddWithValue("@usuario", Convert.ToString(txtCtrlModificarUsuario.Text));
                UpdateUsuario.Parameters.AddWithValue("@JurisdiccionID", Convert.ToString(ddlCtrlModificarJuris.Text));
                UpdateUsuario.Parameters.AddWithValue("@TipoUsuario", Convert.ToString(ddlCtrlModificarRol.Text));
                UpdateUsuario.Parameters.AddWithValue("@rfc", Convert.ToString(txtCtrlModificarRFC.Text));
                UpdateUsuario.Parameters.AddWithValue("@curp ", Convert.ToString(txtCtrlModificarCURP.Text));
                UpdateUsuario.Parameters.AddWithValue("@apPaterno", Convert.ToString(txtCtrlModificarApPaterno.Text));
                UpdateUsuario.Parameters.AddWithValue("@apMaterno", Convert.ToString(txtCtrlModificarApMaterno.Text));
                UpdateUsuario.Parameters.AddWithValue("@nombre", Convert.ToString(txtCtrlModificarNombre.Text));
                UpdateUsuario.Parameters.AddWithValue("@correoElectronico", Convert.ToString(txtCtrlModificarCorreo.Text));
                UpdateUsuario.Parameters.AddWithValue("@Estatus", Convert.ToString(ddlCtrlModificarEstatus.Text));


                int respuestaUP = UpdateUsuario.ExecuteNonQuery();
                conexionBD.Close();


                if (respuestaUP > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'El registro se ha actualizado con éxito', 'success');", true);

                    gvUsuarios.Columns[10].Visible = false;
                    gvUsuarios.Columns[11].Visible = false;
                    dvCtrlModificar.Visible = false;
                    ControlJuris.Visible = true;
                    dvUsuario.Visible = true;
                    gvUsuarios.Visible = true;
                    BindGridViewConsulta();
                    // CatalogoUsuario();
                    btnCtrlModificarGuardar.Visible = false;
                    btnCancelaEdit.Visible = false;
                    btConsulta.Visible = true;
                    BtnLimpiaBusqueda.Visible = true;
                    BtnAgregar.Visible = true;
                    parametros();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'La actualización no se pudo completar', 'error');", true);
                }

            }
            catch (Exception errorUpdate)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!'," + errorUpdate.Message + ", 'info');", true);
            }

        }



        /*Modulo de Agregar*/
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

            CtrlAddUsuario.Text = null;
            CtrlAddRFC.Text = null;
            CtrlAddCurp.Text = null;
            CtrlAddNombre.Text = null;
            CtrlAddEmail.Text = null;
            CtrlAddApMaterno.Text = null;
            CtrlAddApPaterno.Text = null;
            CtrlAddPass.Text = null;

            dvCtrlAgregar.Visible = true;
            btnCtrlAddAgregar.Visible = true;
            btnInicio.Visible = true;
            btnCtrolAddPassSugerido.Visible = true;
            OcultaConsulta();

            BtnLimpiaBusqueda.Visible = false;
            BtnLimpiar.Visible = true;
        }
        protected void btnCtrlAddAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string valUsuario = CtrlAddUsuario.Text;
                string valPass = CtrlAddPass.Text;

                if ( valUsuario.Length >0 && valPass.Length > 0 )
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
                    conexionBD.Open();


                    SqlCommand AddUsuario = new SqlCommand("spDSP_UsuarioInserta", conexionBD);
                    AddUsuario.CommandType = CommandType.StoredProcedure;

                    AddUsuario.Parameters.Clear();

                    AddUsuario.Parameters.AddWithValue("@Jurisdiccion", Convert.ToString(ddlCtrlAddJurisdiccion.Text));
                    AddUsuario.Parameters.AddWithValue("@tipoUsuario", Convert.ToString(ddlCtrlAddRol.Text));
                    AddUsuario.Parameters.AddWithValue("@usuario", Convert.ToString(CtrlAddUsuario.Text));
                    AddUsuario.Parameters.AddWithValue("@rfc", Convert.ToString(CtrlAddRFC.Text));
                    AddUsuario.Parameters.AddWithValue("@curp", Convert.ToString(CtrlAddCurp.Text));
                    AddUsuario.Parameters.AddWithValue("@nombre", Convert.ToString(CtrlAddNombre.Text));
                    AddUsuario.Parameters.AddWithValue("@correoElectronico", Convert.ToString(CtrlAddEmail.Text));
                    AddUsuario.Parameters.AddWithValue("@apPaterno", Convert.ToString(CtrlAddApPaterno.Text));
                    AddUsuario.Parameters.AddWithValue("@apMaterno", Convert.ToString(CtrlAddApMaterno.Text));
                    AddUsuario.Parameters.AddWithValue("@pass", Convert.ToString(CtrlAddPass.Text));


                    int respuestaADD = AddUsuario.ExecuteNonQuery();

                    if (respuestaADD > 0)
                    {


                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'El registro se ha agregado con éxito', 'success');", true);

                        CtrlAddUsuario.Text = null;
                        CtrlAddRFC.Text = null;
                        CtrlAddCurp.Text = null;
                        CtrlAddNombre.Text = null;
                        CtrlAddEmail.Text = null;
                        CtrlAddApMaterno.Text = null;
                        CtrlAddApPaterno.Text = null;
                        CtrlAddPass.Text = null;

                        dvCtrlAgregar.Visible = true;
                        btnCtrlAddAgregar.Visible = true;
                        btnInicio.Visible = true;
                        OcultaConsulta();

                        conexionBD.Close();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'El usuario ya existe', 'error');", true);

                    }

                }

                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar el(los) campo(s) USUARIO y/o CONTRASEÑA vaciós', 'warning');", true);
                    
                }
                

            }
            catch (Exception error)
            {

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!'," + error.Message + ", 'info');", true);

            }

        }

        protected void ddlJuris_SelectedIndexChanged(object sender, EventArgs e)
        {

            dvUsuario.Visible = false;

        }



        protected void txtUser_TextChanged(object sender, EventArgs e)
        {
            ControlJuris.Visible = false;

        }


        protected void eliminaUser_Click(object sender, EventArgs e)
        {
            int EliminarIdUsuario = Convert.ToInt32((sender as LinkButton).CommandArgument);

            SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
            SqlCommand deleteUser = new SqlCommand("spDSP_UsuarioDelete", conexionBD);
            deleteUser.CommandType = CommandType.StoredProcedure;
            deleteUser.Parameters.Clear();
            deleteUser.Parameters.AddWithValue("@idUsuario", EliminarIdUsuario);
            conexionBD.Open();
            int eliminaCount = deleteUser.ExecuteNonQuery();

            if (eliminaCount > 0)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'El proceso se ha realizado con éxito', 'success');", true);
                parametros();
                BindGridViewConsulta();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No se ha podido completar el preceso', 'error');", true);
                parametros();
                BindGridViewConsulta();
            }

        }



        protected void editUser_Click(object sender, EventArgs e)
        {
           
                int EditarIdUsuario = Convert.ToInt32((sender as LinkButton).CommandArgument);

                SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
                conexionBD.Open();
                SqlCommand editUser = new SqlCommand("spDSP_UsuarioEditaBusqueda", conexionBD);
                editUser.CommandType = CommandType.StoredProcedure;
                editUser.Parameters.Clear();
                editUser.Parameters.AddWithValue("@idUsuario", EditarIdUsuario);

                SqlDataReader TxtDatos;
                TxtDatos = editUser.ExecuteReader();


                if (TxtDatos.Read() == true)
                {
                    /* ctrlModificarIdUser.Visible = true;*/

                    txtIdUsuario.Text = TxtDatos["idUsuario"].ToString();
                    ddlCtrlModificarJuris.Text = TxtDatos["JurisdiccionID"].ToString();
                    ddlCtrlModificarRol.Text = TxtDatos["idTipoUsuario"].ToString();
                    txtCtrlModificarUsuario.Text = TxtDatos["usuario"].ToString();
                    txtCtrlModificarRFC.Text = TxtDatos["rfc"].ToString();
                    txtCtrlModificarCURP.Text = TxtDatos["curp"].ToString();
                    txtCtrlModificarApPaterno.Text = TxtDatos["ApPaterno"].ToString();
                    txtCtrlModificarApMaterno.Text = TxtDatos["ApMaterno"].ToString();
                    txtCtrlModificarNombre.Text = TxtDatos["nombre"].ToString();
                    txtCtrlModificarCorreo.Text = TxtDatos["correoElectronico"].ToString();
                    ddlCtrlModificarEstatus.Text = TxtDatos["Estatus"].ToString();
                    ctrlModificarIdUser.Text = TxtDatos["idUsuario"].ToString();

                    dvCtrlModificar.Visible = true;
                    dvCtrlModificarJuris.Visible = true;
                    dvCtrlModificarRol.Visible = true;
                    dvCtrlModificarRFC.Visible = true;
                    dvCtrlModificarCURP.Visible = true;
                    dvCtrlModificarNombre.Visible = true;
                    dvCtrlModificarCorreo.Visible = true;
                    dvCtrlModificarEstatus.Visible = true;
                    dvCtrlModificarApPaterno.Visible = true;
                    dvCtrlModificarApMaterno.Visible = true;


                    btnCtrlModificarGuardar.Visible = true;
                    BtnLimpiar.Visible = true;

                    ControlJuris.Visible = false;
                    dvUsuario.Visible = false;
                    btConsulta.Visible = false;
                    btnCtrlAddAgregar.Visible = false;
                    BtnAgregar.Visible = false;
                    BtnLimpiaBusqueda.Visible = false;

                    btnCancelaEdit.Visible = true;
                    BtnLimpiaBusqueda.Visible = false;
                    BtnLimpiar.Visible = false;

                    gvUsuarios.Visible = false;

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', ':(', 'error');", true);
                }

                conexionBD.Close();
           
        }

        protected void BtnLimpiaBusqueda_Click(object sender, EventArgs e)
        {
            gvUsuarios.DataSource = null;
            gvUsuarios.DataBind();

            CleanControl(this.Controls);
            ddlJuris.Items.Clear();
            ddlJuris.Items.Add("Selecciona");


            txtUser.Enabled = true;

            ddlJuris.Enabled = true;

            txtUser.Text = "";

            dvUsuario.Visible = true;
            ControlJuris.Visible = true;

            gvUsuarios.Columns[10].Visible = false;
            gvUsuarios.Columns[11].Visible = false;

            parametros();
            CatalogoUsuario();
        }

        protected void btnCancelaEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/_Administracion/AdministracionDeUsuarios.aspx");
        }

        protected void btnCtrolAddPassSugerido_Click(object sender, EventArgs e)
        {
            dvCtrlAddPassSugerido.Visible = true;

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

       
      
    }
}
