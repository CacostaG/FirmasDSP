using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListadoDeFirmasDSP._ImpresioListados
{
    public partial class ListadodeFirmasCheques : System.Web.UI.Page


    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {

            /*
            if (Session["token"] == null)
            {
                Response.Redirect("~/InicioSesion.aspx");
            }
            else
            {
                User.Text = Session["user"].ToString();
                txtIdJurisdiccion.Text = Session["jurisdiccion_id"].ToString();
                txtIdJurisdiccion.Visible = false;
                if (!IsPostBack)
                {
                    var rol = Session["rol"];
                    switch (rol)
                    {
                        case "Validador":
                            Response.Redirect("~/Default");
                            break;
                        case "Administrador":
                            Response.Redirect("~/Default");
                            break;
                    }
                    Parametros();
                }
            }*/
        }
        private void Parametros()
        {

            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");
            SqlCommand cmdAnio = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasChequeAnio @jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
            SqlDataAdapter sdAnio = new SqlDataAdapter(cmdAnio);
            DataTable dtAnio = new DataTable();
            sdAnio.Fill(dtAnio);
            ddlAnio.DataSource = dtAnio;
            ddlAnio.DataBind();

            dvBtnImpriListadodeFirmas.Visible = false;

        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {

                ddlQuincena.Enabled = false;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");
                dvMessageNomina.Visible = false;

                ddlTipo.Enabled = false;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
                dvMessageTipo.Visible = false;

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                dvMessageNomina.Visible = false;

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessageUR.Visible = false;

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;
                ResetControl();
            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessagePrdname.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageTipo.Visible = false;

                ddlQuincena.Enabled = true;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");
                SqlCommand cmQuincena = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasChequeQuincena @anio='" + ddlAnio.Text + "' ,@jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
                SqlDataAdapter sdQuincena = new SqlDataAdapter(cmQuincena);
                DataTable dtQuincena = new DataTable();
                sdQuincena.Fill(dtQuincena);
                ddlQuincena.DataSource = dtQuincena;
                ddlQuincena.DataBind();

                ddlTipo.Enabled = false;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
                dvMessageTipo.Visible = false;

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                dvMessageNomina.Visible = false;

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessageUR.Visible = false;

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;
            }


            dvBtnImpriListadodeFirmas.Visible = false;
        }

        protected void ddlQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuincena.SelectedItem.Text == "Selecciona")
            {

                ddlTipo.Enabled = false;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
                dvMessageTipo.Visible = false;

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                dvMessageNomina.Visible = false;

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessageUR.Visible = false;

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;

                ResetControl();
            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessagePrdname.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageTipo.Visible = false;

                ddlTipo.Enabled = true;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
                SqlCommand cmdTipo = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasChequeTipo @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
                SqlDataAdapter sdTipo = new SqlDataAdapter(cmdTipo);
                DataTable dtTipo = new DataTable();
                sdTipo.Fill(dtTipo);
                ddlTipo.DataSource = dtTipo;
                ddlTipo.DataBind();

                

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessageUR.Visible = false;

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;

            }


            dvBtnImpriListadodeFirmas.Visible = false;
        }

        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedItem.Text == "Selecciona")

            {

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                dvMessageNomina.Visible = false;

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessageUR.Visible = false;

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;

                ResetControl();
            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessagePrdname.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageTipo.Visible = false;

                ddlNomina.Enabled = true;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                SqlCommand cmdNomina = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasChequeNomina @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdNomina = new SqlDataAdapter(cmdNomina);
                DataTable dtNomina = new DataTable();
                sdNomina.Fill(dtNomina);
                ddlNomina.DataSource = dtNomina;
                ddlNomina.DataBind();
               

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;

            }


            dvBtnImpriListadodeFirmas.Visible = false;
        }

        protected void ddlNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNomina.SelectedItem.Text == "Selecciona")
            {

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ResetControl();
            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessagePrdname.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageTipo.Visible = false;

                ddlUR.Enabled = true;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                SqlCommand cmUR = new SqlCommand("exec Pry1015_ParametroListadosDeFirmasChequeUR @anio='" + ddlAnio.Text + "'  ,@qna='" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdUR = new SqlDataAdapter(cmUR);
                DataTable dtUR = new DataTable();
                sdUR.Fill(dtUR);
                ddlUR.DataSource = dtUR;
                ddlUR.DataBind();
            }


            dvBtnImpriListadodeFirmas.Visible = false;
        }

        protected void ddlUR_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUR.SelectedItem.Text == "Selecciona")
            {

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                ResetControl();

            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessagePrdname.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageTipo.Visible = false;

                ddlPrdname.Enabled = true;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                SqlCommand cmPRDNAME = new SqlCommand("exec Pry1015_ParametroListadosDeFirmasChequePRDNAME @anio='" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@ur= '" + ddlUR.Text + "' ,@jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdPRDNAME = new SqlDataAdapter(cmPRDNAME);
                DataTable dtPRDNAME = new DataTable();
                sdPRDNAME.Fill(dtPRDNAME);
                ddlPrdname.DataSource = dtPRDNAME;
                ddlPrdname.DataBind();

            }


            dvBtnImpriListadodeFirmas.Visible = false;
        }

        protected void ddlPrdname_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvMessagePrdname.Visible = false;
        }


        protected void ConsultarListado_Click(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {

                dvMessageAnio.Visible = true;
                lblMensajeErrorAnio.Text = "Seleccione periodo";
            }
            else
            {
                if (ddlQuincena.SelectedItem.Text == "Selecciona")
                {
                    dvMessageQuincena.Visible = true;
                    lblMensajeErrorQuincena.Text = "Seleccione quincena";
                }
                else
                {
                    if (ddlTipo.SelectedItem.Text == "Selecciona")
                    {
                        dvMessageTipo.Visible = true;
                        lblMensajeErrorTipo.Text = "Seleccione nomina";
                    }
                    else
                    {
                        if (ddlNomina.SelectedItem.Text == "Selecciona")
                        {
                            dvMessageNomina.Visible = true;
                            lblMensajeErrorNomina.Text = "Seleccione nomina";
                        }
                        else
                        {
                            if (ddlUR.SelectedItem.Text == "Selecciona")
                            {
                                dvMessageUR.Visible = true;
                                lblMensajeErrorUR.Text = "Seleccione unidad responsable";
                            }
                            else
                            {
                                if (ddlPrdname.SelectedItem.Text == "Selecciona")
                                {
                                    dvMessagePrdname.Visible = true;
                                    lblMensajeErrorPrdname.Text = "Seleccione producto";
                                }
                                else
                                {
                                    BindGridView();
                                }
                            }
                        }
                    }

                }
            }
        }

        protected void BindGridView()
        {

            DataTable tbGeneral = new DataTable();
            SqlDataAdapter consultaGeneralO = new SqlDataAdapter("exec Pry1015_ListadosDeFirmasChequeBuscar  @jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@anio='" + ddlAnio.Text + "' ,@qna='" + ddlQuincena.Text + "', @nomina='" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' , @prdname='" + ddlPrdname.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
            conexionBD.Open();

            consultaGeneralO.Fill(tbGeneral);
            conexionBD.Close();
            
            gvListadoDeFirmas_Cheques.DataSource = tbGeneral;
            gvListadoDeFirmas_Cheques.DataBind();

          

                 int totaPagos = tbGeneral.AsEnumerable().Sum(row => row.Field<int>("registros"));

            Decimal totaImporteNeto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("neto"));

            gvListadoDeFirmas_Cheques.FooterRow.Cells[5].Text = "Totales";
            gvListadoDeFirmas_Cheques.FooterRow.Cells[6].Text = totaImporteNeto.ToString("C");
            gvListadoDeFirmas_Cheques.FooterRow.Cells[7].Text = totaPagos.ToString("N0");
            gvListadoDeFirmas_Cheques.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            gvListadoDeFirmas_Cheques.Columns[0].Visible = false;/*Culumna Cnmkey*/
            gvListadoDeFirmas_Cheques.Columns[1].Visible = false;/*Columna Anio*/
            gvListadoDeFirmas_Cheques.Columns[2].Visible = false;/*Columna Quincena*/
            gvListadoDeFirmas_Cheques.Columns[9].Visible = false;/*idJuris*/
            gvListadoDeFirmas_Cheques.Columns[10].Visible = false;/*ProductoNomina*/
            gvListadoDeFirmas_Cheques.Columns[13].Visible = false;
            gvListadoDeFirmas_Cheques.Columns[14].Visible = false;
            
            
            
            if (gvListadoDeFirmas_Cheques.Rows.Count > 0)
            {
                dvBtnImpriListadodeFirmas.Visible = true;

                BtnImpriListadodeFirmas.Enabled = true;
                BtnImpriListadodeFirmas.Visible = true;

                btnDescargaComprobante.Visible = false;
                btnDescargaComprobante.Enabled = true;
            }

        }
       

        protected void gvListadoDeFirmas_Cheques_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

       

        /*metodos*/

        private void Ticket()
        {
            string _open = "window.open('../_Reportes/TicketdeImpresion.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);

          

        }

        private void ReporteListado()
        {
            string _open = "window.open('../_Reportes/ReporteListadoCheques.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), _open, true);
        }

    

     



        /*botones*/

        protected void btnDescargaComprobante_Click(object sender, EventArgs e)
        {
            Ticket();

            BtnImpriListadodeFirmas.Enabled = true;
            btnDescargaComprobante.Enabled = false;

        }
        protected void BtnImpriListadodeFirmas_Click(object sender, EventArgs e)
        {
            int contador = 0;
            try
            {
                foreach (GridViewRow row in gvListadoDeFirmas_Cheques.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    var checkboxListadosDeFirmasInserta = row.FindControl("CheckBox") as CheckBox;
                    {
                        if (checkboxListadosDeFirmasInserta.Checked)
                        {




                            SqlCommand ListadosDeFirmasInserta = new SqlCommand("Pry1015_ListadosDeFirmasCheques_Inserta", conexionBD);
                            ListadosDeFirmasInserta.CommandType = CommandType.StoredProcedure;
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@PRODUCTO_NOMINA_ID", (row.FindControl("columPrudctoNominaID") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@JURISDICCION_ID", (row.FindControl("columD_Juris") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@NETO", (row.FindControl("columNeto") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@REGISTROS", (row.FindControl("columRegistros") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@USUARIO", Convert.ToString(User.Text));
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@INSTRUMENTO_PAGO", (row.FindControl("columInstrumento") as Label).Text);

                            int respuesta = ListadosDeFirmasInserta.ExecuteNonQuery();

                            if (respuesta > 0)
                            {
                                Session["TicketListado"] = "LISTADO DE CHEQUES";
                                Session["TicketJurisdiccion"] = (row.FindControl("columClaveJuris") as Label).Text;
                                Session["TicketInstrumento"] = (row.FindControl("columInstrumento") as Label).Text;
                                Session["TicketAnio"] = ddlAnio.Text;
                                Session["TicketQuincena"] = ddlQuincena.Text;
                                Session["TicketClaveTipo"] = ddlTipo.Text;
                                Session["TicketNomina"] = ddlNomina.Text;
                                Session["TicketUR"] = ddlUR.Text;
                                Session["TicketPRDNAME"] = ddlPrdname.Text;



                                ReporteListado();
                               

                                BtnImpriListadodeFirmas.Enabled = false;
                                btnDescargaComprobante.Visible = true;
                                btnDescargaComprobante.Enabled = true;


                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito, no olvides descargar el comprobante de operación',  'success');", true);
                                conexionBD.Close();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Ha ocurrido un error', 'error');", true);
                            }

                        }
                        else
                        {
                            contador++;
                        }


                    }
                }

                if (contador == gvListadoDeFirmas_Cheques.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }

               
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + ex.Message + "', 'error');", true);
            }


        }

        /*otros*/

        private void clean()
        {
            gvListadoDeFirmas_Cheques.DataSource = null;
            gvListadoDeFirmas_Cheques.DataBind();
            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadoDeFirmas_Cheques.DataSource = null;
            gvListadoDeFirmas_Cheques.DataBind();
            CleanControl(this.Controls);
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add(new ListItem("Selecciona", "0"));
            ddlQuincena.Items.Clear();
            ddlQuincena.Items.Add(new ListItem("Selecciona", "0"));
            ddlTipo.Items.Clear();
            ddlTipo.Items.Add(new ListItem("Selecciona", "0"));
            ddlNomina.Items.Clear();
            ddlNomina.Items.Add(new ListItem("Selecciona", "0"));
            ddlUR.Items.Clear();
            ddlUR.Items.Add(new ListItem("Selecciona", "0"));
            ddlPrdname.Items.Clear();
            ddlPrdname.Items.Add(new ListItem("Selecciona", "0"));
            btnDescargaComprobante.Visible = false;
            Parametros();
        }

        protected void BtnClean_Click(object sender, EventArgs e)
        {

            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadoDeFirmas_Cheques.DataSource = null;
            gvListadoDeFirmas_Cheques.DataBind();
            CleanControl(this.Controls);
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add(new ListItem("Selecciona", "0"));
            ddlQuincena.Items.Clear();
            ddlQuincena.Items.Add(new ListItem("Selecciona", "0"));
            ddlTipo.Items.Clear();
            ddlTipo.Items.Add(new ListItem("Selecciona", "0"));
            ddlNomina.Items.Clear();
            ddlNomina.Items.Add(new ListItem("Selecciona", "0"));
            ddlUR.Items.Clear();
            ddlUR.Items.Add(new ListItem("Selecciona", "0"));
            ddlPrdname.Items.Clear();
            ddlPrdname.Items.Add(new ListItem("Selecciona", "0"));
            btnDescargaComprobante.Visible = false;
            Parametros();

        }
        private void ResetControl()
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {

                ddlQuincena.Enabled = false;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");
                ddlTipo.Enabled = false;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessageAnio.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageUR.Visible = false;
                dvMessagePrdname.Visible = false;
                dvBtnImpriListadodeFirmas.Visible = false;


            }
            else if (ddlQuincena.SelectedItem.Text == "Selecciona")
            {

                ddlTipo.Enabled = false;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");

                dvMessageAnio.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageUR.Visible = false;
                dvMessagePrdname.Visible = false;
                dvBtnImpriListadodeFirmas.Visible = false;



            }
            else if (ddlNomina.SelectedItem.Text == "Selecciona")
            {

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessageAnio.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageUR.Visible = false;
                dvMessagePrdname.Visible = false;




                dvBtnImpriListadodeFirmas.Visible = false;
            }
            else if (ddlUR.SelectedItem.Text == "Selecciona")
            {

                ddlPrdname.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                dvMessageAnio.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageUR.Visible = false;
                dvMessagePrdname.Visible = false;




                dvBtnImpriListadodeFirmas.Visible = false;
            }
            else { Parametros(); }
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
        }
    }
}