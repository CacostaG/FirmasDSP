using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListadoDeFirmasDSP._ImpresioListados
{
    public partial class ListadosDeFirmas : System.Web.UI.Page
             
     {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserData.token == 0 )
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

            SqlCommand cmdCR = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosJuris", conexionBD);
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
                SqlCommand cmdAnio = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosAnio @juris='" + ddlJURISid.Text + "'", conexionBD);
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
                SqlCommand cmQuincena = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosQna @anio='" + ddlAnio.Text + "' ,@juris='" + ddlJURISid.Text + "'", conexionBD);
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
                SqlCommand cmdTipo = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosTipo @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @juris='" + ddlJURISid.Text + "'", conexionBD);
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
                SqlCommand cmdNomina = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosNomina @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @juris='" + ddlJURISid.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
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
                SqlCommand cmUR = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosUr @anio='" + ddlAnio.Text + "'  ,@qna='" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@juris ='" + ddlJURISid.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
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
                SqlCommand cmPRDNAME = new SqlCommand("spDSP_ListadoProductoNominaPagosCompletosPrdname @anio='" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@ur= '" + ddlUR.Text + "' ,@juris ='" + ddlJURISid.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdPRDNAME = new SqlDataAdapter(cmPRDNAME);
                DataTable dtPRDNAME = new DataTable();
                sdPRDNAME.Fill(dtPRDNAME);
                ddlPrdname.DataSource = dtPRDNAME;
                ddlPrdname.DataBind();

            }
        }
        protected void ddlPrdname_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvMessagePrdname.Visible = false;
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


                                }
                            }
                        }
                    }

                }
            }
        }
        protected void BindGridView()
        {
            dvMessageAnio.Visible = false;
            dvMessageNomina.Visible = false;
            dvMessagePrdname.Visible = false;
            dvMessageQuincena.Visible = false;
            dvMessageUR.Visible = false;
            dvMessageTipo.Visible = false;

            DataTable tbGeneral = new DataTable();
            SqlDataAdapter consultaGeneralO = new SqlDataAdapter("spDSP_ListadoProductoNominaPagosCompletos  @Juris='" + ddlJURISid.Text + "' ,@anio='" + ddlAnio.Text + "' ,@qna='" + ddlQuincena.Text + "', @nomina='" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' , @prdname='" + ddlPrdname.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
            conexionBD.Open();

            consultaGeneralO.Fill(tbGeneral);
            conexionBD.Close();
            gvListadosDeFirmas.DataSource = tbGeneral;
            gvListadosDeFirmas.DataBind();

            int totaPagos = tbGeneral.AsEnumerable().Sum(row => row.Field<int>("registros"));
            Decimal totaImporteBruto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i1"));
            Decimal totaImporteDescuento = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i2"));
            Decimal totaImporteNeto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i3"));
            
            gvListadosDeFirmas.FooterRow.Cells[5].Text = "Totales";
            gvListadosDeFirmas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            gvListadosDeFirmas.FooterRow.Cells[9].Text = totaPagos.ToString("N0");
            gvListadosDeFirmas.FooterRow.Cells[8].Text = totaImporteNeto.ToString("C");
            gvListadosDeFirmas.FooterRow.Cells[7].Text = totaImporteDescuento.ToString("C");
            gvListadosDeFirmas.FooterRow.Cells[6].Text = totaImporteBruto.ToString("C");
            gvListadosDeFirmas.Columns[0].Visible = false;/*Culumna Cnmkey*/
            gvListadosDeFirmas.Columns[1].Visible = false;/*Columna Anio*/
            gvListadosDeFirmas.Columns[2].Visible = false;/*Columna Quincena*/
            gvListadosDeFirmas.Columns[10].Visible = false;/*Columna Tpersonal*/
            gvListadosDeFirmas.Columns[13].Visible = false;/*Columna ID_Juris*/
            gvListadosDeFirmas.Columns[14].Visible = false;/*Columna Producto_Nomina_ID*/
            gvListadosDeFirmas.Columns[17].Visible = false;/*Columna clavepago*/
        
            dvMsgFinalError.Visible = false;
            dvBtnImpriListadodeFirmas.Visible = true;
                     
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
            try
            {
                int contador = 0;

                foreach (GridViewRow row in gvListadosDeFirmas.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
                    conexionBD.Open();

                    var checkboxListadosDeFirmasInserta = row.FindControl("CheckBox") as CheckBox;
                    {
                        if (checkboxListadosDeFirmasInserta.Checked)
                        {
                            Session["TicketListado"] = "NOMINA GENERADA";
                            /*Session["TicketJurisdiccion"] = ddlJURISid.Text;*/
                            Session["TicketJurisdiccion"] = (row.FindControl("columClaveJuris") as Label).Text;
                            Session["TicketAnio"] = ddlAnio.Text;
                            Session["TicketQuincena"] = ddlQuincena.Text;
                            Session["TicketClaveTipo"] = ddlTipo.Text;
                            Session["TicketNomina"] = ddlNomina.Text;
                            Session["TicketUR"] = ddlUR.Text;
                            Session["TicketPRDNAME"] = ddlPrdname.Text;
                            Session["TicketInstrumento"] = (row.FindControl("columInstrumento") as Label).Text;
                            Session["TicketClave"] = ddlJURISid.Text;




                            if (ddlNomina.Text =="CONTRATOS")
                            {
                                ReporteContrato();

                                
                            }
                            else
                            {
                                ReporteBase();
                             

                            }

                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito',  'success');", true);
                        }
                        else
                        {
                            contador++;
                        }/*fin if check*/
                    }
                } /*fin foreach*/


                if(contador == gvListadosDeFirmas.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + ex.Message + "', 'error');", true);
            }
                        
            

        }


        private void ReporteContrato()
        {
            string dowload = "window.open('../_Reportes/ReporteFirmasContrato.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);
        }



        private void ReporteBase()
        {
            string dowload = "window.open('../_Reportes/ReporteFirmasBase.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);
        }


        protected void gvListadosDeFirmas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
           
        }


        private void clean()
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
    }
}
