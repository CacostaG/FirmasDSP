using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ListadoDeFirmasDSP._ImpresioListados
{
    public partial class ListadoDeFirmas : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {/*
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
            SqlCommand cmdAnio = new SqlCommand("EXEC Pry1015_ParametrosImpresionListados_Ejercicio  @jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
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
                SqlCommand cmQuincena = new SqlCommand("EXEC Pry1015_ParametrosImpresionListados_Quincena @anio='" + ddlAnio.Text + "' ,@jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
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
                SqlCommand cmdTipo = new SqlCommand("EXEC Pry1015_ParametrosImpresionListados_Tipo @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @jurisdiccion_id='" + txtIdJurisdiccion.Text + "'", conexionBD);
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
                SqlCommand cmdNomina = new SqlCommand("EXEC Pry1015_ParametrosImpresionListados_Nomina @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
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
                dvMessageUR.Visible = false;

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

                ddlUR.Enabled = true;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                SqlCommand cmUR = new SqlCommand("exec Pry1015_ParametrosImpresionListados_UnidadResponsable @anio='" + ddlAnio.Text + "'  ,@qna='" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
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
                SqlCommand cmPRDNAME = new SqlCommand("exec Pry1015_ParametrosImpresionListados_ProductoDeNomina @anio='" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@ur= '" + ddlUR.Text + "' ,@jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
                SqlDataAdapter sdPRDNAME = new SqlDataAdapter(cmPRDNAME);
                DataTable dtPRDNAME = new DataTable();
                sdPRDNAME.Fill(dtPRDNAME);
                ddlPrdname.DataSource = dtPRDNAME;
                ddlPrdname.DataBind();

            }




            dvBtnImpriListadodeFirmas.Visible = false;
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
            SqlDataAdapter consultaGeneralO = new SqlDataAdapter("exec Pry1015_ImpresionListados_Busqueda  @jurisdiccion_id='" + txtIdJurisdiccion.Text + "' ,@anio='" + ddlAnio.Text + "' ,@qna='" + ddlQuincena.Text + "', @nomina='" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' , @prdname='" + ddlPrdname.Text + "' ,@ClavePago ='" + ddlTipo.Text + "'", conexionBD);
            conexionBD.Open();

            consultaGeneralO.Fill(tbGeneral);
            conexionBD.Close();
            gvListadoDeFirmas.DataSource = tbGeneral;
            gvListadoDeFirmas.DataBind();

            int totaPagos = tbGeneral.AsEnumerable().Sum(row => row.Field<int>("TotalRegistros"));
            Decimal totaImporteBruto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i1"));
            Decimal totaImporteDescuento = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i2"));
            Decimal totaImporteNeto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("i3"));

            gvListadoDeFirmas.FooterRow.Cells[5].Text = "Totales";
            gvListadoDeFirmas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            gvListadoDeFirmas.FooterRow.Cells[9].Text = totaPagos.ToString("N0");
            gvListadoDeFirmas.FooterRow.Cells[8].Text = totaImporteNeto.ToString("C");
            gvListadoDeFirmas.FooterRow.Cells[7].Text = totaImporteDescuento.ToString("C");
            gvListadoDeFirmas.FooterRow.Cells[6].Text = totaImporteBruto.ToString("C");
            gvListadoDeFirmas.Columns[0].Visible = false;
            gvListadoDeFirmas.Columns[1].Visible = false;
            gvListadoDeFirmas.Columns[2].Visible = false;
            gvListadoDeFirmas.Columns[10].Visible = false;
            gvListadoDeFirmas.Columns[13].Visible = false;
            gvListadoDeFirmas.Columns[14].Visible = false;
            gvListadoDeFirmas.Columns[17].Visible = false;


         
           if(gvListadoDeFirmas.Rows.Count > 0 )
            {

                dvBtnImpriListadodeFirmas.Visible = true;
                BtnImpriListadodeFirmas.Enabled = true;
                BtnImpriListadodeFirmas.Visible = true;

                btnDescargaReporte.Visible = false;
                btnDescargaReporte.Enabled = true;
            }

      
          
        }
        protected void gvListadoDeFirmas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        /*botones*/
        protected void BtnImpriListadodeFirmas_Click(object sender, EventArgs e)
        {
            int contador = 0;
            try
            {
                foreach (GridViewRow row in gvListadoDeFirmas.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    
                    var check = row.FindControl("Checkbox") as CheckBox;

                    
                    if ( check != null && check.Checked)
                    {
                        SqlCommand ListadosDeFirmasInserta = new SqlCommand("Pry1015_ListadosDeFirmasInserta", conexionBD);
                        ListadosDeFirmasInserta.CommandType = CommandType.StoredProcedure;
                        ListadosDeFirmasInserta.Parameters.Clear();

                        ListadosDeFirmasInserta.Parameters.AddWithValue("@PRODUCTO_NOMINA_ID", (row.FindControl("columPrudctoNominaID") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@JURISDICCION_ID", (row.FindControl("columD_Juris") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@PERCEPCIONES", (row.FindControl("columPercepciones") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@DEDUCCIONES", (row.FindControl("columDeducciones") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@NETO", (row.FindControl("columNeto") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@REGISTROS", (row.FindControl("columRegistros") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@INSTRUMENTO_PAGO", (row.FindControl("columInstrumento") as Label).Text);
                        ListadosDeFirmasInserta.Parameters.AddWithValue("@USUARIO", Convert.ToString(User.Text));
                        /*Actualiza.Parameters.Clear();*/

                        int respuesta = ListadosDeFirmasInserta.ExecuteNonQuery();
               
                        if (respuesta > 0)
                        {
                            Session["TicketAnio"] = ddlAnio.Text;
                            Session["TicketQuincena"] = ddlQuincena.Text;
                            Session["TicketClaveTipo"] = ddlTipo.Text;
                            Session["TicketNomina"] = ddlNomina.Text;
                            Session["TicketUR"] = ddlUR.Text;
                            Session["TicketPRDNAME"] = ddlPrdname.Text;
                            Session["TicketJurisdiccion"] = (row.FindControl("columClaveJuris") as Label).Text;
                            Session["TicketInstrumento"] = (row.FindControl("columInstrumento") as Label).Text;
                            Session["TicketListado"] = "NOMINA GENERADA";


                            
                           
                            
                            if (ddlNomina.Text == "CONTRATOS")
                            {

                                
                                ReporteContrato();
                               

                                BtnImpriListadodeFirmas.Enabled = false;
                                btnDescargaReporte.Visible = true;
                                btnDescargaReporte.Enabled = true;

                            }
                            else
                            {
                                ReporteBase();

                                BtnImpriListadodeFirmas.Enabled = false;
                                btnDescargaReporte.Visible = true;
                                btnDescargaReporte.Enabled = true;

                            }


                        

                         

                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito, no olvides descargar el comprobante de operación',  'success');", true);
                            conexionBD.Close();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Ha ocurrido un error', 'error');", true);
                        }
                        
                    }
                    else
                    {/*
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);*/


                        contador ++;


                    }
                }


                if (contador == gvListadoDeFirmas.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }

                
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" +ex.Message+ "', 'error');", true);
            }
        }
        protected void btnDescargaReporte_Click(object sender, EventArgs e)
        {
            ticket();

            BtnImpriListadodeFirmas.Enabled = true;
            btnDescargaReporte.Enabled = false;
        }


        /*metodos */


        private void ReporteContrato()
        {
            string dowload = "window.open('../_Reportes/ReporteFirmasContrato', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);
        }
        private void ReporteBase()
        {
            string dowload = "window.open('../_Reportes/ReporteFirmasBase', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);
        }

        private void ticket()
        {
            string open = "window.open('../_Reportes/TicketdeImpresion.aspx',  '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), open, true);

           


        }

      


       
        protected void ddlPrdname_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvMessagePrdname.Visible = false;


            dvBtnImpriListadodeFirmas.Visible = false;
        }



        public void clean()
        {

            gvListadoDeFirmas.DataSource = null;
            gvListadoDeFirmas.DataBind();
            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadoDeFirmas.DataSource = null;
            gvListadoDeFirmas.DataBind();
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
            btnDescargaReporte.Visible = false;
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
        protected void BtnClean_Click(object sender, EventArgs e)
        {




            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadoDeFirmas.DataSource = null;
            gvListadoDeFirmas.DataBind();
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