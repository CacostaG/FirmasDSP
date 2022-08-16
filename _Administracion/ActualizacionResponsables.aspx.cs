using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Web.UI;

using System.Web.UI.WebControls;


namespace ListadoDeFirmasDSP._Administracion
{
    public partial class ActualizacionResponsables : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnFirmasDSP"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((UserData.token == 0 ))
            {
                Response.Redirect("~/InicioSesion.aspx");
            }

            else
            {
                if (!IsPostBack)
                {
                    var rol = (string)UserData.TipoUsuario;
                    switch (rol)
                    {
                        case "Validador":
                            Response.Redirect("~/Default");
                            break;
                        case "Operador del sistema":
                            Response.Redirect("~/Default");
                            break;
                    }
                    Parametros();
                    BindGridViewResponsables();
                }
            }
        }

        protected void BindGridViewResponsables()
        {
            DataTable dtResponsables = new DataTable();
            SqlDataAdapter cmdResponsables = new SqlDataAdapter("spDSP_ResponsablesUnidad", conexionBD);
            conexionBD.Open();
            cmdResponsables.Fill(dtResponsables);
            conexionBD.Close();
            gvResponsables.DataSource = dtResponsables;
            gvResponsables.DataBind();


        }

        private void Parametros()
        {
            dvMEmorandum.Visible = false;

            SqlCommand cmdJuris = new SqlCommand("spDSP_DisponibleJurisdiccionResponsable", conexionBD);
            SqlDataAdapter sdJuris = new SqlDataAdapter(cmdJuris);
            DataTable dtJuris = new DataTable();
            sdJuris.Fill(dtJuris);
            ddlJuris.DataSource = dtJuris;
            ddlJuris.DataBind();

            ddlCargo.Enabled = true;
            ddlCargo.Items.Clear();
            ddlCargo.Items.Add("Selecciona");
        }

        protected void ddlJuris_SelectedIndexChanged(object sender, EventArgs e)

        {
            ddlCargo.Items.Clear();
            ddlCargo.Items.Add("Selecciona");
            dvMEmorandum.Visible = false;
            txtResponsable.Text = "";

            if (ddlJuris.SelectedItem.Text == "Selecciona")
            {

                ddlCargo.Items.Clear();
                ddlCargo.Items.Add("Selecciona");
                ddlCargo.Enabled = false;

                ddlJuris.Items.Clear();
                ddlJuris.Items.Clear();
                ddlJuris.Enabled = false;

                txtResponsable.Text = "";
                txtJuris.Text = "";
            }

            else
            {

                SqlCommand cmdCargo = new SqlCommand("seleccionapuesto @juris ='" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdCargo = new SqlDataAdapter(cmdCargo);
                DataTable dtCargo = new DataTable();
                sdCargo.Fill(dtCargo);
                ddlCargo.DataSource = dtCargo;
                ddlCargo.DataBind();
            }
        }

        protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCargo.SelectedItem.Text == "Selecciona")
            {
                dvMEmorandum.Visible = true;
            }

            else
            {
                conexionBD.Open();

                SqlCommand cmdTexBox = new SqlCommand("cargo @juris='" + ddlJuris.Text + "' ,@cargo='" + ddlCargo.Text + "'", conexionBD);
                SqlDataReader TxtDatos;
                TxtDatos = cmdTexBox.ExecuteReader();

                while (TxtDatos.Read() == true)
                {
                    txtResponsable.Text = TxtDatos["director"].ToString();
                    dvMEmorandum.Visible = true;
                }
                conexionBD.Close();
                dvMEmorandum.Visible = true;
                /*idJuris();*/
            }
        }

        private void idJuris()
        {
            conexionBD.Open();
            SqlCommand cmdTexBoxj = new SqlCommand("exec Pry1015_ParametrosActualizacionResponsablesJurisdiccionId @nombre='" + ddlJuris.Text + "' ,@cargo='" + ddlCargo.Text + "' ", conexionBD);
            SqlDataReader TxtDatosj;
            TxtDatosj = cmdTexBoxj.ExecuteReader();
            while (TxtDatosj.Read() == true)
            {
                idJurisTex.Text = TxtDatosj["jurisdiccion_id"].ToString();
                dvMEmorandum.Visible = true;
                btnSave.Visible = true;
            }
            conexionBD.Close();
           /* Modal();*/
        }

        /*
        private void Modal()
        {
            LbModalGuardar1.Text = "<b>Jurisdiccion u hospital: </b>" + ddlJuris.Text + "<br/> <b>Cargo: </b>" + ddlCargo.Text + "<br/> <b>Responsable: </b>" + txtResponsable.Text;
        }

        
        protected void BtnGuardarM_Click(object sender, EventArgs e)
        {
            conexionBD.Open();
            SqlCommand UpdateResponsablesdeJurisdiccion = new SqlCommand("Pry1015_ActualizacionResponsables", conexionBD);
            UpdateResponsablesdeJurisdiccion.CommandType = CommandType.StoredProcedure;
            UpdateResponsablesdeJurisdiccion.Parameters.Clear();
            UpdateResponsablesdeJurisdiccion.Parameters.AddWithValue("@jurisdiccion_id", Convert.ToInt32(idJurisTex.Text));
            UpdateResponsablesdeJurisdiccion.Parameters.AddWithValue("@cargo", Convert.ToString(ddlCargo.Text));
            UpdateResponsablesdeJurisdiccion.Parameters.AddWithValue("@nombre_completo", Convert.ToString(txtResponsable.Text));
            UpdateResponsablesdeJurisdiccion.ExecuteNonQuery();
            conexionBD.Close();
            dvMsgFinal.Visible = true;
            MsgOkInsert.Text = "<b>Se han guardado los cambios pertinentes<b/>";
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "#Confirmacion", "$('body').removeClass('modal-open');$('.modal-backdrop').remove();", true);
        }*/


        public void CleanControl(ControlCollection controles)
        {
            foreach (Control control in controles)
            {
                if (control is DropDownList)
                    ((DropDownList)control).ClearSelection();
                else if (control.HasControls())
                    CleanControl(control.Controls);
            }
        }

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            dvMsgFinal.Visible = false;
            CleanControl(this.Controls);
            ddlCargo.Items.Clear();
            ddlCargo.Items.Add(new ListItem("Selecciona", "0"));
            txtResponsable.Text = "";
            txtJuris.Text = "";
            Parametros();
            btnSave.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            conexionBD.Open();
            SqlCommand UpdateResponsablesdeJurisdiccion = new SqlCommand("Pry1015_ActualizacionResponsables", conexionBD);
            UpdateResponsablesdeJurisdiccion.CommandType = CommandType.StoredProcedure;
            UpdateResponsablesdeJurisdiccion.Parameters.Clear();
            UpdateResponsablesdeJurisdiccion.Parameters.AddWithValue("@jurisdiccion_id", Convert.ToInt32(idJurisTex.Text));
            UpdateResponsablesdeJurisdiccion.Parameters.AddWithValue("@cargo", Convert.ToString(ddlCargo.Text));
            UpdateResponsablesdeJurisdiccion.Parameters.AddWithValue("@nombre_completo", Convert.ToString(txtResponsable.Text));
            UpdateResponsablesdeJurisdiccion.ExecuteNonQuery();
            conexionBD.Close();


            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal({" +
                              " title: '¿Desea continuar con la actualización de información?'," +
                              " text: 'Jurisdiccion u hospital: "  + ddlJuris.Text +  "  Cargo: " + ddlCargo.Text + " Responsable: " + txtResponsable.Text + "'," +
                              " type: 'warning'," +
                              " showCancelButton: true," +
                              " confirmButtonClass: 'btn-warning'," +
                              " confirmButtonText: 'Si,continuar!'," +
                              " cancelButtonText: 'No, cancelar el proceso!'," +
                              " closeOnConfirm: false," +
                              " closeOnCancel: false," +
                              "}," +
                              "function(isConfirm) { " +
                              " if (isConfirm) { " +
                              "swal('Finaizado!'," +
                              " 'La información se ha actualizado con éxito.','success');" +
                              " }else {" +
                              " swal('Cancelado', 'La información no se ha modificado'," +
                              " 'error'); }}); ", true);
            BindGridViewResponsables();

        }
    }
}








