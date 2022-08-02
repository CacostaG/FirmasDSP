using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListadoDeFirmasDSP._ImpresioListados
{


    public partial class ListadosDeFirmasFEAC : System.Web.UI.Page
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
                /*   jurisid.Text = Session["jurisdiccion_id"].ToString();*/
                if (!IsPostBack)
                {
                    var rol = Session["rol"];
                    switch (rol)
                    {
                        case "Validador":
                            Response.Redirect("~/Default");
                            break;
                        case "Opereador del sistema":
                            Response.Redirect("~/Default");
                            break;
                    }
                    Parametros();
                }
            }

        }
        private void Parametros()
        {

            ddlAnio.Enabled = false;
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");

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

            SqlCommand cmdCR = new SqlCommand("EXEC Pry1015_ParametrosImpresionListadosFEAC_Jurisddiccion", conexionBD);
            SqlDataAdapter sdCR = new SqlDataAdapter(cmdCR);
            DataTable dtCR = new DataTable();
            sdCR.Fill(dtCR);
            ddlJURISid.DataSource = dtCR;
            ddlJURISid.DataBind();
        }
        protected void ddlJURISid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJURISid.SelectedItem.Text == "Selecciona")
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

                ddlAnio.Enabled = true;
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");
                SqlCommand cmdAnio = new SqlCommand("EXEC Pry1015_ParametrosImpresionListadosFEAC_Ejercicio @ClaveJuris='" + ddlJURISid.Text + "'", conexionBD);
                SqlDataAdapter sdAnio = new SqlDataAdapter(cmdAnio);
                DataTable dtAnio = new DataTable();
                sdAnio.Fill(dtAnio);
                ddlAnio.DataSource = dtAnio;
                ddlAnio.DataBind();

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

        }
        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {

                ddlQuincena.Enabled = false;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");

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
                SqlCommand cmQuincena = new SqlCommand("EXEC Pry1015_ParametrosImpresionListadosFEAC_Quincena @anio='" + ddlAnio.Text + "' ,@ClaveJuris='" + ddlJURISid.Text + "'", conexionBD);
                SqlDataAdapter sdQuincena = new SqlDataAdapter(cmQuincena);
                DataTable dtQuincena = new DataTable();
                sdQuincena.Fill(dtQuincena);
                ddlQuincena.DataSource = dtQuincena;
                ddlQuincena.DataBind();
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
        }
        protected void ddlQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuincena.SelectedItem.Text == "Selecciona")
            {

                ddlTipo.Enabled = false;
                ddlTipo.Items.Clear();
                ddlTipo.Items.Add("Selecciona");
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
                SqlCommand cmdTipo = new SqlCommand("EXEC Pry1015_ParametrosImpresionListadosFEAC_Tipo @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @ClaveJuris='" + ddlJURISid.Text + "'", conexionBD);
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
        }
        protected void ddlTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipo.SelectedItem.Text == "Selecciona")

            {

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
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
                SqlCommand cmdNomina = new SqlCommand("EXEC Pry1015_ParametrosImpresionListadosFEAC_Nomina @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @ClaveJuris='" + ddlJURISid.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
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
        }
        protected void ddlNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNomina.SelectedItem.Text == "Selecciona")
            {

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

                ddlUR.Enabled = true;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                SqlCommand cmUR = new SqlCommand("exec Pry1015_ParametrosImpresionListadosFEAC_UnidadResponsable @anio='" + ddlAnio.Text + "'  ,@qna='" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@ClaveJuris ='" + ddlJURISid.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdUR = new SqlDataAdapter(cmUR);
                DataTable dtUR = new DataTable();
                sdUR.Fill(dtUR);
                ddlUR.DataSource = dtUR;
                ddlUR.DataBind();
            }
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
                SqlCommand cmPRDNAME = new SqlCommand("exec Pry1015_ParametrosImpresionListadosFEAC_ProductoDeNomina @anio='" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@ur= '" + ddlUR.Text + "' ,@ClaveJuris ='" + ddlJURISid.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdPRDNAME = new SqlDataAdapter(cmPRDNAME);
                DataTable dtPRDNAME = new DataTable();
                sdPRDNAME.Fill(dtPRDNAME);
                ddlPrdname.DataSource = dtPRDNAME;
                ddlPrdname.DataBind();

            }
        }

        protected void Consultar_Click(object sender, EventArgs e)
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


                                    dvBtnImpriListadodeFirmas.Visible = true;
                                    BtnImpriListadodeFirmas.Visible = true;
                                    BtnImpriListadodeFirmas.Enabled = true;

                                    btnDescargaConstancia.Visible = true;
                                    btnDescargaConstancia.Enabled = true;


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
            SqlDataAdapter consultaGeneralO = new SqlDataAdapter("exec Pry1015_ImpresionListados_BusquedaFEAC  @ClaveJuris='" + ddlJURISid.Text + "' ,@anio='" + ddlAnio.Text + "' ,@qna='" + ddlQuincena.Text + "', @nomina='" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' , @prdname='" + ddlPrdname.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
            conexionBD.Open();

            consultaGeneralO.Fill(tbGeneral);
            conexionBD.Close();
            
            gvListadosDeFirmas.DataSource = tbGeneral;
            gvListadosDeFirmas.DataBind();

            int totaPagos = tbGeneral.AsEnumerable().Sum(row => row.Field<int>("TotalRegistros"));

            Decimal totaImporteNeto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i3"));

            gvListadosDeFirmas.FooterRow.Cells[5].Text = "Totales";
            gvListadosDeFirmas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            gvListadosDeFirmas.FooterRow.Cells[7].Text = totaPagos.ToString("N0");
            gvListadosDeFirmas.FooterRow.Cells[6].Text = totaImporteNeto.ToString("C");

            gvListadosDeFirmas.Columns[0].Visible = false;
            gvListadosDeFirmas.Columns[1].Visible = false;
            gvListadosDeFirmas.Columns[2].Visible = false;
            gvListadosDeFirmas.Columns[8].Visible = false;
            gvListadosDeFirmas.Columns[11].Visible = false;
            gvListadosDeFirmas.Columns[12].Visible = false;
            gvListadosDeFirmas.Columns[15].Visible = false;/*persona*/




            dvBtnImpriListadodeFirmas.Visible = true;
            BtnImpriListadodeFirmas.Visible = true;
            BtnImpriListadodeFirmas.Enabled = true;

            btnDescargaConstancia.Visible = true;
            btnDescargaConstancia.Enabled = true;



        }



        protected void gvTabla_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        private void ResetControl()
        {
            if (ddlJURISid.SelectedItem.Text == "Selecciona")
            {

                ddlAnio.Enabled = false;
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");
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




            }
            else if (ddlAnio.SelectedItem.Text == "Selecciona")
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
        protected void BtnClean_Click(object sender, EventArgs e)
        {

            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadosDeFirmas.DataSource = null;
            gvListadosDeFirmas.DataBind();
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

            Parametros();

        }

        protected void BtnImpriListadodeFirmas_Click(object sender, EventArgs e)
        {
            int contador = 0; 
            try
            {
                foreach (GridViewRow row in gvListadosDeFirmas.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    var checkboxListadosDeFirmasInserta = row.FindControl("CheckBox") as CheckBox;
                    {
                        if (checkboxListadosDeFirmasInserta.Checked)
                        {
                            Session["TicketListado"] = "LISTADO DE FEAC";
                            Session["TicketJurisdiccion"] = ddlJURISid.Text;
                            Session["TicketAnio"] = ddlAnio.Text;
                            Session["TicketQuincena"] = ddlQuincena.Text;
                            Session["TicketClaveTipo"] = ddlTipo.Text;
                            Session["TicketNomina"] = ddlNomina.Text;
                            Session["TicketUR"] = ddlUR.Text;
                            Session["TicketPRDNAME"] = ddlPrdname.Text;
                            Session["TicketInstrumento"] = (row.FindControl("columInstrumento") as Label).Text;
                            Session["PersonalFEAC"] = (row.FindControl("columPersona") as Label).Text;
                            ReporteListadoFEAC();



                        }
                        else 
                        {
                            contador++;
                        }



                    }
                }
                if (contador == gvListadosDeFirmas.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + ex.Message + "', 'error');", true);
            }
        }

        protected void ddlPrdname_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvMessagePrdname.Visible = false;
            lblMensajeErrorPrdname.Visible = false;
        }

        private void Reportecedula()
        {
            string PersonalFEAC = Convert.ToString(Session["PersonalFEAC"]);

            if (PersonalFEAC == "Trabajador")
            {



                string dowload = "window.open('../_Reportes/ReporteCedulasFEACEmpleados.aspx', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito', 'success');", true);

            }
            else
            {

                string dowload = "window.open('../_Reportes/ReporteCedulasFeacPensiones.aspx', '_newtab');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito', 'success');", true);


            }

         

        }
        private void ReporteListadoFEAC()
        {
            string dowload = "window.open('../_Reportes/ReporteFirmasFEAC.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);

            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito', 'success');", true);

        }
       

        private void ticket()
        {
            string open = "window.open('../_Reportes/TicketdeImpresion.aspx',  '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);

             
          
        }
        public void clean()
        {

            gvListadosDeFirmas.DataSource = null;
            gvListadosDeFirmas.DataBind();
            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadosDeFirmas.DataSource = null;
            gvListadosDeFirmas.DataBind();
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
            /* btnDescargaReporte.Visible = false;*/
            Parametros();
        }

        protected void btnDescargaConstancia_Click(object sender, EventArgs e)
        {
            

            int contador = 0;
            try
            {
                foreach (GridViewRow row in gvListadosDeFirmas.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    var checkboxListadosDeFirmasInserta = row.FindControl("CheckBox") as CheckBox;
                    {
                        if (checkboxListadosDeFirmasInserta.Checked)
                        {
                            Session["TicketListado"] = "LISTADO DE FEAC";
                            Session["TicketJurisdiccion"] = ddlJURISid.Text;
                            Session["TicketAnio"] = ddlAnio.Text;
                            Session["TicketQuincena"] = ddlQuincena.Text;
                            Session["TicketClaveTipo"] = ddlTipo.Text;
                            Session["TicketNomina"] = ddlNomina.Text;
                            Session["TicketUR"] = ddlUR.Text;
                            Session["TicketPRDNAME"] = ddlPrdname.Text;
                            Session["TicketInstrumento"] = (row.FindControl("columInstrumento") as Label).Text;
                            Session["PersonalFEAC"] = (row.FindControl("columPersona") as Label).Text;
                            Reportecedula();



                        }
                        else
                        {
                            contador++;
                        }



                    }
                }
                if (contador == gvListadosDeFirmas.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + ex.Message + "', 'error');", true);
            }


        }
    }
}
