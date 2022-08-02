using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ListadoDeFirmasDSP._ImpresioListados
{
    public partial class ListadoDeFirmasMedidasFinAnio : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
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
            }
        }
        private void Parametros()
        {
            ddlAnioMFA.Items.Clear();
            ddlAnioMFA.Items.Add("Selecciona");
            SqlCommand cmdAnioMFA = new SqlCommand("EXEC Pry1015_ParametrosImpresionMedidasFinAnio_Ejercicio @jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
            SqlDataAdapter sdAnioMFA = new SqlDataAdapter(cmdAnioMFA);
            DataTable dtAnioMFA = new DataTable();
            sdAnioMFA.Fill(dtAnioMFA);
            ddlAnioMFA.DataSource = dtAnioMFA;
            ddlAnioMFA.DataBind();

            dvBtnImpriListadodeFirmas.Visible = false;

        }

        protected void ddlAnioMFA_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnioMFA.SelectedItem.Text == "Selecciona")
            {
                ddlLoteMFA.Enabled = false;
                ddlLoteMFA.Items.Clear();
                ddlLoteMFA.Items.Add("Selecciona");
                dvMessageLote.Visible = false;

                ResetControl();

            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageLote.Visible = false;
                ddlLoteMFA.Enabled = true;
                ddlLoteMFA.Items.Clear();
                ddlLoteMFA.Items.Add("Selecciona");

                SqlCommand cmdLoteMFA = new SqlCommand("EXEC Pry1015_ParametrosImpresionMedidasFinAnio_Lote @anio='" + ddlAnioMFA.Text + "' , @jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
                SqlDataAdapter sdLoteMFA = new SqlDataAdapter(cmdLoteMFA);
                DataTable dtLoteMFA = new DataTable();
                sdLoteMFA.Fill(dtLoteMFA);
                ddlLoteMFA.DataSource = dtLoteMFA;
                ddlLoteMFA.DataBind();


            }
        }



        protected void ConsultarListado_Click(object sender, EventArgs e)
        {
            if (ddlAnioMFA.SelectedItem.Text == "Selecciona")
            {
                dvMessageAnio.Visible = true;
                lblMensajeErrorAnio.Text = "Seleccione periodo";
            }
            else
            {
                if (ddlLoteMFA.SelectedItem.Text == "Selecciona")
                {
                    dvMessageLote.Visible = true;
                    lblMensajeErrorLote.Text = "Seleccione Lote";
                }
                else
                {
                    dvMessageLote.Visible = false;
                    dvMessageAnio.Visible = false;
                    BindGridView();
                }

            }

        }
        protected void BindGridView()
        {
            DataTable tbGeneral = new DataTable();
            SqlDataAdapter consultaGenralMedidasFinAnio = new SqlDataAdapter("Pry1015_ImpresionMedidaFinAnio_Busqueda @jurisdiccion_id='" + txtIdJurisdiccion.Text + "', @anio='" + ddlAnioMFA.Text + "', @lote='" + ddlLoteMFA.Text + "'", conexionBD);
            conexionBD.Open();
            consultaGenralMedidasFinAnio.Fill(tbGeneral);
            conexionBD.Close();
            gvListadoMedidasFinAnio.DataSource = tbGeneral;
            gvListadoMedidasFinAnio.DataBind();

            int totalTarjetas = tbGeneral.AsEnumerable().Sum(row => row.Field<int>("numero_tarjetas"));
            decimal totalImporte = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("importe_total"));
            gvListadoMedidasFinAnio.FooterRow.Cells[2].Text = "Totales";
            gvListadoMedidasFinAnio.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            gvListadoMedidasFinAnio.FooterRow.Cells[3].Text = totalTarjetas.ToString("N0");
            gvListadoMedidasFinAnio.FooterRow.Cells[4].Text = totalImporte.ToString("C");
            gvListadoMedidasFinAnio.Columns[0].Visible = false;
            gvListadoMedidasFinAnio.Columns[5].Visible = false;

            if (gvListadoMedidasFinAnio.Rows.Count > 0)
            {
                dvBtnImpriListadodeFirmas.Visible = true;
                BtnImpriListadodeFirmas.Enabled = true;
                BtnImpriListadodeFirmas.Visible = true;

                btnDescargaReporte.Visible = false;
                btnDescargaReporte.Enabled = true;

            }


        }
        protected void gvListadoMedidasFinAnio_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void BtnClean_Click(object sender, EventArgs e)
        {
            gvListadoMedidasFinAnio.DataSource = null;
            gvListadoMedidasFinAnio.DataBind();
            dvBtnImpriListadodeFirmas.Visible = false;


            CleanControl(this.Controls);
            ddlAnioMFA.Items.Clear();
            ddlAnioMFA.Items.Add(new ListItem("Selecciona", "0"));
            Parametros();

        }



        protected void BtnImpriListadodeFirmas_Click(object sender, EventArgs e)
        {
            int contador = 0;

            try
            {
                foreach (GridViewRow row in gvListadoMedidasFinAnio.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    var checkboxListadosDeFirmasInserta = row.FindControl("CheckBox") as CheckBox;
                    {
                        if (checkboxListadosDeFirmasInserta.Checked)
                        {

                            SqlCommand ListadosDeFirmasInserta = new SqlCommand("Pry1015_ListadosDeFirmasMedidasFinAnioInserta", conexionBD);
                            ListadosDeFirmasInserta.CommandType = CommandType.StoredProcedure;

                            ListadosDeFirmasInserta.Parameters.AddWithValue("@JURISDICCION_ID", (row.FindControl("columID_Juris") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@LOTE", (row.FindControl("columLote") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@ANIO", (row.FindControl("columAnio") as Label).Text);
                            ListadosDeFirmasInserta.Parameters.AddWithValue("@IMPORTE", (row.FindControl("columImporte") as Label).Text);

                            ListadosDeFirmasInserta.Parameters.AddWithValue("@REGISTROS", (row.FindControl("columRegistros") as Label).Text);

                            ListadosDeFirmasInserta.Parameters.AddWithValue("@USUARIO", Convert.ToString(User.Text));
                            /*Actualiza.Parameters.Clear();*/

                            int respuesta = ListadosDeFirmasInserta.ExecuteNonQuery();

                            if (respuesta > 0)


                            {



                                Session["MedidaLote"] = (row.FindControl("columLote") as Label).Text;
                                Session["MedidaJurisdiccion"] = (row.FindControl("columID_Juris") as Label).Text;
                                Session["MedidaAnio"] = (row.FindControl("columAnio") as Label).Text;


                                ReporteListadoMedidasFinAnio();



                                BtnImpriListadodeFirmas.Enabled = false;

                                btnDescargaReporte.Visible = true;
                                btnDescargaReporte.Enabled = true;










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

                if (contador == gvListadoMedidasFinAnio.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + ex.Message + "', 'error');", true);
            }
        }

        private void ReporteListadoMedidasFinAnio()
        {
            string dowload = "window.open('../_Reportes/ReporteFirmasMedidas', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);
        }

        protected void btnDescargaReporte_Click(object sender, EventArgs e)
        {
            string dowload = "window.open('../_Reportes/TicketdeImpresionMedidas', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);

        }

        protected void gvListadoMedidasFinAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        public void clean()
        {
            gvListadoMedidasFinAnio.DataSource = null;
            gvListadoMedidasFinAnio.DataBind();
            dvBtnImpriListadodeFirmas.Visible = false;
            dvMessageAnio.Visible = false;
            dvMessageLote.Visible = false;



            CleanControl(this.Controls);
            ddlAnioMFA.Items.Clear();
            ddlAnioMFA.Items.Add(new ListItem("Selecciona", "0"));
            ddlLoteMFA.Items.Add(new ListItem("Selecciona", "0"));

            Parametros();
        }
        private void ResetControl()
        {
            if (ddlAnioMFA.SelectedItem.Text == "Selecciona")
            {
                ddlLoteMFA.Enabled = false;
                ddlLoteMFA.Items.Clear();
                ddlLoteMFA.Items.Add("Selecciona");


                dvMessageAnio.Visible = false;
                dvMessageLote.Visible = false;
                dvBtnImpriListadodeFirmas.Visible = false;

            }
            else
            {
                Parametros();
            }
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