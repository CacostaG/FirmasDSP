using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;




namespace ListadoDeFirmasDSP._ImpresioListados
{
    public partial class ListadosdeFirmasCheques : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["connFirmasDSP"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (UserData.token == 0)
            {
                Response.Redirect("~/InicioSesion.aspx");
            }
            else
            {
                
                /*   jurisid.Text = Session["jurisdiccion_id"].ToString();*/
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
                  /*  Parametros();*/
                }
            }


        }
        protected void Parametros()
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

            SqlCommand cmdCR = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasCheques_IdJurisdiccion_Admin", conexionBD);
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

                SqlCommand cmdAnio = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasCheques_Anio_Admin @Id_JurisNombre='" + ddlJURISid.Text + "'", conexionBD);
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
                SqlCommand cmQuincena = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasCheques_Quincena_Admin @anio='" + ddlAnio.Text + "' ,@Id_JurisNombre='" + ddlJURISid.Text + "'", conexionBD);
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
                SqlCommand cmdTipo = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasCheques_Tipo_Admin @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @Id_JurisNombre='" + ddlJURISid.Text + "'", conexionBD);
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
                SqlCommand cmdNomina = new SqlCommand("EXEC Pry1015_ParametroListadosDeFirmasCheques_Nomina_Admin @anio='" + ddlAnio.Text + "'  , @qna='" + ddlQuincena.Text + "' , @Id_JurisNombre='" + ddlJURISid.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
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
                SqlCommand cmUR = new SqlCommand("exec Pry1015_ParametroListadosDeFirmasCheques_UR_Admin @anio='" + ddlAnio.Text + "'  ,@qna='" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@Id_JurisNombre='" + ddlJURISid.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
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
                SqlCommand cmPRDNAME = new SqlCommand("exec Pry1015_ParametroListadosDeFirmasCheques_PRDNAME_Admin @anio='" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina = '" + ddlNomina.Text + "' ,@ur= '" + ddlUR.Text + "' ,@Id_JurisNombre='" + ddlJURISid.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
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
            lblMensajeErrorPrdname.Visible = false;
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
            SqlDataAdapter consultaGeneralO = new SqlDataAdapter("exec Pry1015_ListadosDeFirmasCheques_Buscar_Admin @Id_JurisNombre='" + ddlJURISid.Text + "' ,@anio='" + ddlAnio.Text + "' ,@qna='" + ddlQuincena.Text + "', @nomina='" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' , @prdname='" + ddlPrdname.Text + "' ,@tipo ='" + ddlTipo.Text + "'", conexionBD);
            conexionBD.Open();

            consultaGeneralO.Fill(tbGeneral);
            conexionBD.Close();
           
             gvListadosDeFirmas_Cheques.DataSource = tbGeneral;
             gvListadosDeFirmas_Cheques.DataBind();

            int totaPagos = tbGeneral.AsEnumerable().Sum(row => row.Field<int>("registros"));
      
            Decimal totaImporteNeto = tbGeneral.AsEnumerable().Sum(row => row.Field<Decimal>("neto"));

            gvListadosDeFirmas_Cheques.FooterRow.Cells[5].Text = "Totales";
            gvListadosDeFirmas_Cheques.FooterRow.Cells[6].Text = totaImporteNeto.ToString("C");
            gvListadosDeFirmas_Cheques.FooterRow.Cells[7].Text = totaPagos.ToString("N0");
            gvListadosDeFirmas_Cheques.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
            gvListadosDeFirmas_Cheques.Columns[0].Visible = false;/*Culumna Cnmkey*/
            gvListadosDeFirmas_Cheques.Columns[1].Visible = false;/*Columna Anio*/
            gvListadosDeFirmas_Cheques.Columns[2].Visible = false;/*Columna Quincena*/
            gvListadosDeFirmas_Cheques.Columns[9].Visible = false;/*idJuris*/
            gvListadosDeFirmas_Cheques.Columns[10].Visible = false;/*ProductoNomina*/
            gvListadosDeFirmas_Cheques.Columns[13].Visible = false;/*ProductoNomina*/






            dvMsgFinalError.Visible = false;
            dvBtnImpriListadodeFirmas.Visible = true;
        }

        protected void gvListadosDeFirmas_Cheques_RowDataBound(object sender, GridViewRowEventArgs e)
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
             gvListadosDeFirmas_Cheques.DataSource = null;
             gvListadosDeFirmas_Cheques.DataBind();
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

                foreach (GridViewRow row in gvListadosDeFirmas_Cheques.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    var checkboxListadosDeFirmasInserta = row.FindControl("CheckBox") as CheckBox;
                    {
                        if (checkboxListadosDeFirmasInserta.Checked)
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
                  
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito',  'success');", true);

                        }
                        else
                        {
                            contador++;
                        }
                    }
                }                

                if(contador == gvListadosDeFirmas_Cheques.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + ex.Message + "', 'error');", true);
            }

        }


        private void ReporteListado()
        {
            string dowload = "window.open('../_Reportes/ReporteListadoCheques.aspx', '_newtab');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), Guid.NewGuid().ToString(), dowload, true);
        }
    

        private void clean()
        {
            dvBtnImpriListadodeFirmas.Visible = false;
            gvListadosDeFirmas_Cheques.DataSource = null;
            gvListadosDeFirmas_Cheques.DataBind();
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