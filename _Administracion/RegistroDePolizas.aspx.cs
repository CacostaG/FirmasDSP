using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ListadoDeFirmasDSP._Administracion
{
    public partial class RegistroDePolizas : System.Web.UI.Page
    {
        SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnFirmasDSP"].ToString());
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["token"] == null)

            {
                Response.Redirect("~/InicioSesion.aspx");
            }

            else
            {
                
                
                Session["user"] = UserData.Usuario;
                User.Text = Session["user"].ToString();
                if (!IsPostBack)
                {

                    var rol = Session["rol"];
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
                }
            }

        }
        private void Parametros()
        {

            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");

            SqlCommand cmdPAnio = new SqlCommand("spDSP_EjercicioFirmas", conexionBD);
            SqlDataAdapter sdAnio = new SqlDataAdapter(cmdPAnio);
            DataTable dtAnio = new DataTable();
            sdAnio.Fill(dtAnio);
            ddlAnio.DataSource = dtAnio;
            ddlAnio.DataBind();

            btnSave.Visible = false;
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {
                gvRegisgtroDePolizas.DataSource = null;
                gvRegisgtroDePolizas.DataBind();
                dvDescripcion.Visible = false;
                txtDescripcion.Text = "";
                dvMEmorandum.Visible = false;
                txtMemo.Text = "";
                dvPoliza.Visible = false;
                txtPoliza.Text = "";
                dvFecha_Elabora.Visible = false;
                txt_FechaElabora.Text = "";
                dvFecha_Pago.Visible = false;
                txt_FechaPago.Text = "";
                ddlQuincena.Enabled = false;
                ddlNomina.Enabled = false;
                ddlUR.Enabled = false;
                ddlPrdname.Enabled = false;
                btnSave.Visible = false;
                ResetControl();
            }

            else
            {
                gvRegisgtroDePolizas.DataSource = null;
                gvRegisgtroDePolizas.DataBind();
                btnSave.Visible = false;
                ddlQuincena.Enabled = true;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                SqlCommand cmdQuincena = new SqlCommand("spDSP_DisponibleQnaPrdFirmas @anio='" + ddlAnio.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaQuincena = new SqlDataAdapter(cmdQuincena);
                DataTable dtQuincena = new DataTable();
                sdaQuincena.Fill(dtQuincena);
                ddlQuincena.DataSource = dtQuincena;
                ddlQuincena.DataBind();
               
            }
        }

        protected void ddlQuincena_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQuincena.SelectedItem.Text == "Selecciona")
            {
                gvRegisgtroDePolizas.DataSource = null;
                gvRegisgtroDePolizas.DataBind();
                btnSave.Visible = false;
                dvDescripcion.Visible = false;
                txtDescripcion.Text = "";
                dvMEmorandum.Visible = false;
                txtMemo.Text = "";
                dvPoliza.Visible = false;
                txtPoliza.Text = "";
                dvFecha_Elabora.Visible = false;
                txt_FechaElabora.Text = "";
                dvFecha_Pago.Visible = false;
                txt_FechaPago.Text = "";
                ddlNomina.Enabled = false;
                ddlUR.Enabled = false;
                ddlPrdname.Enabled = false;
                ResetControl();
            }
            else
            {
                
                BindGridViewQuincena();

                btnSave.Visible = false;
                ddlNomina.Enabled = true;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                SqlCommand cmdNomina = new SqlCommand("spDSP_DisponibleNominaPrdFirmas @anio = '" + ddlAnio.SelectedItem.Value + "', @qna = '" + ddlQuincena.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaNomina = new SqlDataAdapter(cmdNomina);
                DataTable dtNomina = new DataTable();
                sdaNomina.Fill(dtNomina);
                ddlNomina.DataSource = dtNomina;
                ddlNomina.DataBind();
                
            }
        }
        


        protected void ddlNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvMessageNomina.Visible = false;
            ddlUR.Enabled = true;

            if (ddlNomina.SelectedItem.Text == "Selecciona")
            {

                BindGridViewQuincena();
                btnSave.Visible = false;
                dvDescripcion.Visible = false;
                txtDescripcion.Text = "";
                dvMEmorandum.Visible = false;
                txtMemo.Text = "";
                dvPoliza.Visible = false;
                txtPoliza.Text = "";
                dvFecha_Elabora.Visible = false;
                txt_FechaElabora.Text = "";
                dvFecha_Pago.Visible = false;
                txt_FechaPago.Text = "";
                ddlUR.Enabled = false;
                ddlPrdname.Enabled = false;
                ResetControl();

            }
            else
            {
                
                BindGridViewNomina();
                btnSave.Visible = false;
                ddlUR.Enabled = true;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                SqlCommand cmdUR = new SqlCommand("spDSP_DisponibleURPrdFirmas @nomina= '" + ddlNomina.SelectedItem.Value + "' ,@qna = '" + ddlQuincena.SelectedItem.Value + "' ,@anio ='" + ddlAnio.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaUR = new SqlDataAdapter(cmdUR);
                DataTable dtUR = new DataTable();
                sdaUR.Fill(dtUR);
                ddlUR.DataSource = dtUR;
                ddlUR.DataBind();
               


            }

        }

        protected void ddlUR_SelectedIndexChanged(object sender, EventArgs e)
        {
            dvMessageUR.Visible = false;

            if (ddlUR.SelectedItem.Text == "Selecciona")
            {
                
                BindGridViewNomina();
                btnSave.Visible = false;
                dvDescripcion.Visible = false;
                txtDescripcion.Text = "";
                dvMEmorandum.Visible = false;
                txtMemo.Text = "";
                dvPoliza.Visible = false;
                txtPoliza.Text = "";
                dvFecha_Elabora.Visible = false;
                txt_FechaElabora.Text = "";
                dvFecha_Pago.Visible = false;
                txt_FechaPago.Text = "";
                ddlPrdname.Enabled = false;
                ResetControl();
            }
            else
            {
                BindGridViewUR();
                btnSave.Visible = false;
                
                ddlPrdname.Enabled = true;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                

       


                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                SqlCommand cmdPRDNAME = new SqlCommand("spDSP_DisponibleProductosPrdFirmas @ur = '" + ddlUR.SelectedItem.Value + "' ,@nomina = '" + ddlNomina.SelectedItem.Value + "' ,@qna = '" + ddlQuincena.SelectedItem.Value + "' ,@anio ='" + ddlAnio.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaPRDNAME = new SqlDataAdapter(cmdPRDNAME);
                DataTable dtPRDNAME = new DataTable();
                sdaPRDNAME.Fill(dtPRDNAME);
                ddlPrdname.DataSource = dtPRDNAME;
                ddlPrdname.DataBind();
                
            }


        }

        protected void ddlPrdname_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (ddlPrdname.SelectedItem.Text == "Selecciona")
            {
                BindGridViewUR();
                dvDescripcion.Visible = false;
                txtDescripcion.Text = "";
                dvMEmorandum.Visible = false;
                txtMemo.Text = "";
                dvPoliza.Visible = false;
                txtPoliza.Text = "";
                dvFecha_Elabora.Visible = false;
                txt_FechaElabora.Text = "";
                dvFecha_Pago.Visible = false;
                txt_FechaPago.Text = "";
            }
            else
            {
                TextBox();
            }
           
        }

        private void TextBox()
        {
            BindGridViewPRDNAME();

             if ((!"Selecciona".Equals(ddlAnio.Text)) || (!"Selecciona".Equals(ddlQuincena.Text)) || (!"Selecciona".Equals(ddlNomina.Text)) || (!"Selecciona".Equals(ddlUR.Text)) || (!"Selecciona".Equals(ddlPrdname)))
              {
                  btnSave.Visible = true;
                  conexionBD.Open();
                  SqlCommand cmdTexBox = new SqlCommand("spDSP_ProductosNominaCompletos @anio ='" + ddlAnio.Text + "' ,@qna='" + ddlQuincena.Text + "' ,@nomina= '" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' ,@prdname='" + ddlPrdname.Text + "'", conexionBD);
                  SqlDataReader TxtDatos;
                  TxtDatos = cmdTexBox.ExecuteReader();
                  while (TxtDatos.Read() == true)
                  {
                      txtDescripcion.Text = TxtDatos["descripcion"].ToString();
                      txtMemo.Text = TxtDatos["memorandum"].ToString();
                      txtPoliza.Text = TxtDatos["poliza"].ToString();
                      txt_FechaElabora.Text = TxtDatos["fecha_elaboracion"].ToString();
                      DateTime Fecha1 = Convert.ToDateTime(TxtDatos["fecha_elaboracion"]); //Recupero fecha inicio y la convierto a datetime
                      txt_FechaElabora.Text = Fecha1.ToString("yyyy-MM-dd");  // Se la asigno en el formato que lo muestra (Lo e probado directo sin convertir y en diferentes formatos y nada).
                                                                              // txt_FechaElabora.Text= DateTime.Now.ToShortDateString();
                      DateTime Fecha2 = Convert.ToDateTime(TxtDatos["fecha_pago"]);
                      txt_FechaPago.Text = Fecha2.ToString("yyyy-MM-dd");
                      //  txt_FechaPago.Text = TxtDatos["fecha_pago"].ToString();
                      dvDescripcion.Visible = true;
                      dvFecha_Elabora.Visible = true;
                      dvFecha_Pago.Visible = true;
                      dvMEmorandum.Visible = true;
                      dvPoliza.Visible = true;

                  }
                  conexionBD.Close();
                  dvDescripcion.Visible = true;
                  dvFecha_Elabora.Visible = true;
                  dvFecha_Pago.Visible = true;
                  dvMEmorandum.Visible = true;
                  dvPoliza.Visible = true;

              }
              else
              {
                  dvDescripcion.Visible = false;
                  txtDescripcion.Text = "";
                  dvMEmorandum.Visible = false;
                  txtMemo.Text = "";
                  dvPoliza.Visible = false;
                  txtPoliza.Text = "";
                  dvFecha_Elabora.Visible = false;
                  txt_FechaElabora.Text = "";
                  dvFecha_Pago.Visible = false;
                  txt_FechaPago.Text = "";
              }


        }

        public void ResetControl()
        {
            if (ddlUR.SelectedItem.Text == "Selecciona")
            {
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                btnSave.Visible = false;
            }
            else if ((ddlUR.SelectedItem.Text == "Selecciona") || (ddlNomina.SelectedItem.Text == "Selecciona"))
            {
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlUR.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                btnSave.Visible = false;
            }
            else if ((ddlUR.SelectedItem.Text == "Selecciona") || (ddlNomina.SelectedItem.Text == "Selecciona") || (ddlQuincena.SelectedItem.Text == "Selecciona"))
            {
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                ddlNomina.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlUR.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                btnSave.Visible = false;
            }
            else if ((ddlUR.SelectedItem.Text == "Selecciona") || (ddlNomina.SelectedItem.Text == "Selecciona") || (ddlQuincena.SelectedItem.Text == "Selecciona") || (ddlAnio.SelectedItem.Text == "Selecciona"))
            {
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");
                ddlQuincena.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                ddlNomina.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlUR.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                btnSave.Visible = false;
            }
            else
            {
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");
                ddlQuincena.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");
                ddlNomina.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ddlUR.Enabled = false;
                ddlPrdname.Items.Clear();
                ddlPrdname.Items.Add("Selecciona");
                ddlPrdname.Enabled = false;
                dvMessagePrdname.Visible = false;
                dvMessageUR.Visible = false;
                dvMessageNomina.Visible = false;
                dvMessageQuincena.Visible = false;
                dvMessageAnio1.Visible = false;
                btnSave.Visible = false;
                Parametros();
            }
        }
        protected void BtnGuardar_Click(object sender, EventArgs e)
        {
            if ("0".Equals(ddlAnio.Text))
            {
                dvMessageAnio1.Visible = true;
                lblMensajeErrorAnio.Text = "Seleccione periodo";
            }
            else
            {

                if ("Selecciona".Equals(ddlQuincena.Text))
                {
                    dvMessageQuincena.Visible = true;
                    lblMensajeErrorQuincena.Text = "Seleccione quincena";
                }
                else
                {

                    if ("Selecciona".Equals(ddlNomina.Text))
                    {
                        dvMessageNomina.Visible = true;
                        lblMensajeErrorNomina.Text = "Seleccione nomina";
                    }
                    else
                    {
                        if ("Selecciona".Equals(ddlUR.Text))
                        {
                            dvMessageUR.Visible = true;
                            lblMensajeErrorUR.Text = "Seleccione ur";
                        }
                        else
                        {
                            if (ddlPrdname.Text == "Selecciona")
                            {
                                dvMessagePrdname.Visible = true;
                                lblMensajeErrorPrdname.Text = "Seleccione PRDNAME";
                            }
                            else
                            {
                                ActualizaBD();
                            }
                        }
                    }

                }
            }
        }

        protected void ActualizaBD()
        {

            try
            {
                DateTime today = DateTime.Today;
                DateTime dateTime = DateTime.UtcNow.Date;
                conexionBD.Open();
                SqlCommand UpdateT = new SqlCommand("spDSP_ProductosNominaCompletosUpdate", conexionBD);
                UpdateT.CommandType = CommandType.StoredProcedure;
                UpdateT.Parameters.Clear();
                UpdateT.Parameters.AddWithValue("@anio", Convert.ToInt16(ddlAnio.Text));
                UpdateT.Parameters.AddWithValue("@qna", Convert.ToInt16(ddlQuincena.Text));
                UpdateT.Parameters.AddWithValue("@nomina", Convert.ToString(ddlNomina.Text));
                UpdateT.Parameters.AddWithValue("@ur", Convert.ToString(ddlUR.Text));
                UpdateT.Parameters.AddWithValue("@prdname", Convert.ToString(ddlPrdname.Text));
                UpdateT.Parameters.AddWithValue("@descripcion", Convert.ToString(txtDescripcion.Text));
                UpdateT.Parameters.AddWithValue("@fecha_elaboracion", Convert.ToDateTime(txt_FechaElabora.Text));
                UpdateT.Parameters.AddWithValue("@fecha_pago", Convert.ToDateTime(txt_FechaPago.Text));
                UpdateT.Parameters.AddWithValue("@memorandum", Convert.ToInt64(txtMemo.Text));
                UpdateT.Parameters.AddWithValue("@poliza", Convert.ToInt64(txtPoliza.Text));
                // vlaidar usuario con carlos por lo de GUA
                UpdateT.Parameters.AddWithValue("@usuario", Convert.ToString(UserData.Usuario));
                UpdateT.ExecuteNonQuery();
                /*
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito.', 'success');", true);
                */

                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal({" +
                              " title: '¿Desea continuar con la actualización de información?'," +
                              " text: 'Año: " + ddlAnio.Text + "  Quincena: " + ddlQuincena.Text + " Nómina: " + ddlNomina.Text + " Ur: "+ ddlUR.Text+" Producto: "+ddlPrdname.Text+" Descripción: "+txtDescripcion.Text+ " Memorandum: "+txtMemo.Text+" Póliza: "+txtPoliza.Text+" Fecha de elaboración :"+txt_FechaElabora.Text+" Fecha de pago: "+txt_FechaPago.Text+"'," +
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


                conexionBD.Close();
                BindGridViewPRDNAME();
            }
            catch (Exception error)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!','" + error.Message + "', 'warning');", true);
            }

        }
     
        protected void Limpiar_Click(object sender, EventArgs e)
        {
            CleanControl(this.Controls);
            ddlQuincena.Items.Clear();
            ddlQuincena.Items.Add(new ListItem("Selecciona", "0"));
            ddlNomina.Items.Clear();
            ddlNomina.Items.Add(new ListItem("Selecciona", "0"));
            ddlUR.Items.Clear();
            ddlUR.Items.Add(new ListItem("Selecciona", "0"));
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add(new ListItem("Selecciona", "0"));
            ddlPrdname.Items.Clear();
            ddlPrdname.Items.Add(new ListItem("Selecciona", "0"));
            dvDescripcion.Visible = false;
            dvFecha_Elabora.Visible = false;
            dvFecha_Pago.Visible = false;
            dvPoliza.Visible = false;
            dvMEmorandum.Visible = false;
            txtDescripcion = null;
            txtMemo = null;
            txtPoliza = null;
            txt_FechaElabora = null;
            txt_FechaPago = null;
            gvRegisgtroDePolizas.DataSource = null;
            gvRegisgtroDePolizas.DataBind();
            
            Parametros();
          
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
        protected void btnSave_Click(object sender, EventArgs e)
        {

          if(string.IsNullOrEmpty(txt_FechaPago.Text))
            {
                validaEmpty();
            }
            else if (string.IsNullOrEmpty(txt_FechaElabora.Text))
            {
                validaEmpty();
            }
            else if (string.IsNullOrEmpty(txt_FechaPago.Text))
            {
                validaEmpty();
            }
            else if (string.IsNullOrEmpty(txtPoliza.Text))
            {
                validaEmpty();
            }
            else if (string.IsNullOrEmpty(txtMemo.Text))
            {
                validaEmpty();
            }
            else if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                validaEmpty();
            }
            else
            {
                ActualizaBD();
                
            }
          
            
        }
        protected void validaEmpty()
        {
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar campos vacíos' , 'warning');", true);
            }
            else
            {
                if(string.IsNullOrEmpty(txtMemo.Text))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar campos vacíos' , 'warning');", true);
                }
                else
                {
                    if (string.IsNullOrEmpty(txtPoliza.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar campos vacíos' , 'warning');", true);
                    }
                    else
                    {
                        if(string.IsNullOrEmpty(txt_FechaElabora.Text))
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar campos vacíos' , 'warning');", true);
                        }
                        else
                        {
                            if(string.IsNullOrEmpty(txt_FechaPago.Text))
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'No puedes dejar campos vacíos' , 'warning');", true);
                            }
                        }
                    }
                }
            }
        }

        protected void BindGridViewQuincena()
        {
            DataTable GridViewQuincena = new DataTable();
            SqlDataAdapter consultaGridViewQuincena = new SqlDataAdapter("spDSP_GvProductosNominaXQna @anio= '" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ", conexionBD);
            conexionBD.Open();

            consultaGridViewQuincena.Fill(GridViewQuincena);
            conexionBD.Close();

           
                gvRegisgtroDePolizas.DataSource = GridViewQuincena;
                gvRegisgtroDePolizas.DataBind();
            
                int totaPagos = GridViewQuincena.AsEnumerable().Sum(row => row.Field<int>("registros"));
                Decimal totaImporteBruto = GridViewQuincena.AsEnumerable().Sum(row => row.Field<Decimal>("percepciones"));
                Decimal totaImporteDescuento = GridViewQuincena.AsEnumerable().Sum(row => row.Field<Decimal>("deducciones"));
                Decimal totaImporteNeto = GridViewQuincena.AsEnumerable().Sum(row => row.Field<Decimal>("neto"));



                 
                gvRegisgtroDePolizas.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
                gvRegisgtroDePolizas.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
                gvRegisgtroDePolizas.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
                gvRegisgtroDePolizas.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");

       



                gvRegisgtroDePolizas.FooterRow.Cells[6].Text = "Totales";
                gvRegisgtroDePolizas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                
                gvRegisgtroDePolizas.Columns[0].Visible = false;
                gvRegisgtroDePolizas.Columns[1].Visible = false;
                gvRegisgtroDePolizas.Columns[2].Visible = false;
                gvRegisgtroDePolizas.Columns[3].Visible = false;
                gvRegisgtroDePolizas.Columns[7].Visible = false;
                gvRegisgtroDePolizas.Columns[8].Visible = false;
                gvRegisgtroDePolizas.Columns[16].Visible = false;
                gvRegisgtroDePolizas.Columns[17].Visible = false;

            
        }
        protected void BindGridViewNomina()
        {
            DataTable GridViewNomina = new DataTable();
            SqlDataAdapter consultaGridViewNomina = new SqlDataAdapter("spDSP_GvProductosNominaXNomina @anio= '" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina='"+ddlNomina.Text+"' ", conexionBD);
            conexionBD.Open();

            consultaGridViewNomina.Fill(GridViewNomina);
            conexionBD.Close();


            gvRegisgtroDePolizas.DataSource = GridViewNomina;
            gvRegisgtroDePolizas.DataBind();

            int totaPagos = GridViewNomina.AsEnumerable().Sum(row => row.Field<int>("registros"));
            Decimal totaImporteBruto = GridViewNomina.AsEnumerable().Sum(row => row.Field<Decimal>("percepciones"));
            Decimal totaImporteDescuento = GridViewNomina.AsEnumerable().Sum(row => row.Field<Decimal>("deducciones"));
            Decimal totaImporteNeto = GridViewNomina.AsEnumerable().Sum(row => row.Field<Decimal>("neto"));




            gvRegisgtroDePolizas.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
            gvRegisgtroDePolizas.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
            gvRegisgtroDePolizas.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
            gvRegisgtroDePolizas.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");



            gvRegisgtroDePolizas.FooterRow.Cells[6].Text = "Totales";
            gvRegisgtroDePolizas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;

            gvRegisgtroDePolizas.Columns[0].Visible = false;
            gvRegisgtroDePolizas.Columns[1].Visible = false;
            gvRegisgtroDePolizas.Columns[2].Visible = false;
            gvRegisgtroDePolizas.Columns[3].Visible = false;
            gvRegisgtroDePolizas.Columns[7].Visible = false;
            gvRegisgtroDePolizas.Columns[8].Visible = false;
            gvRegisgtroDePolizas.Columns[16].Visible = false;
            gvRegisgtroDePolizas.Columns[17].Visible = false;

        }
        protected void BindGridViewUR()
        {
            DataTable GridViewUR = new DataTable();
            SqlDataAdapter consultaGridViewUR = new SqlDataAdapter("spDSP_GvProductosNominaXUR @anio= '" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina='" + ddlNomina.Text +"' ,@ur='"+ddlUR.Text+ "' ", conexionBD);
            conexionBD.Open();

            consultaGridViewUR.Fill(GridViewUR);
            conexionBD.Close();


            gvRegisgtroDePolizas.DataSource = GridViewUR;
            gvRegisgtroDePolizas.DataBind();

            int totaPagos = GridViewUR.AsEnumerable().Sum(row => row.Field<int>("registros"));
            Decimal totaImporteBruto = GridViewUR.AsEnumerable().Sum(row => row.Field<Decimal>("percepciones"));
            Decimal totaImporteDescuento = GridViewUR.AsEnumerable().Sum(row => row.Field<Decimal>("deducciones"));
            Decimal totaImporteNeto = GridViewUR.AsEnumerable().Sum(row => row.Field<Decimal>("neto"));




            gvRegisgtroDePolizas.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
            gvRegisgtroDePolizas.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
            gvRegisgtroDePolizas.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
            gvRegisgtroDePolizas.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");



            gvRegisgtroDePolizas.FooterRow.Cells[6].Text = "Totales";
            gvRegisgtroDePolizas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;

            gvRegisgtroDePolizas.Columns[0].Visible = false;
            gvRegisgtroDePolizas.Columns[1].Visible = false;
            gvRegisgtroDePolizas.Columns[2].Visible = false;
            gvRegisgtroDePolizas.Columns[3].Visible = false;
            gvRegisgtroDePolizas.Columns[7].Visible = false;
            gvRegisgtroDePolizas.Columns[8].Visible = false;
            gvRegisgtroDePolizas.Columns[16].Visible = false;
            gvRegisgtroDePolizas.Columns[17].Visible = false;
        }
        protected void BindGridViewPRDNAME()
        {
            DataTable GridViewPRDNAME = new DataTable();
            SqlDataAdapter consultaGridViewPRDNAME = new SqlDataAdapter("spDSP_GvProductosNominaXPrd @anio= '" + ddlAnio.Text + "' ,@qna= '" + ddlQuincena.Text + "' ,@nomina='" + ddlNomina.Text + "' ,@ur='" + ddlUR.Text + "' ,@prdname='" + ddlPrdname.Text + "' ", conexionBD);
            conexionBD.Open();

            consultaGridViewPRDNAME.Fill(GridViewPRDNAME);
            conexionBD.Close();


            gvRegisgtroDePolizas.DataSource = GridViewPRDNAME;
            gvRegisgtroDePolizas.DataBind();

            int totaPagos = GridViewPRDNAME.AsEnumerable().Sum(row => row.Field<int>("registros"));
            Decimal totaImporteBruto = GridViewPRDNAME.AsEnumerable().Sum(row => row.Field<Decimal>("percepciones"));
            Decimal totaImporteDescuento = GridViewPRDNAME.AsEnumerable().Sum(row => row.Field<Decimal>("deducciones"));
            Decimal totaImporteNeto = GridViewPRDNAME.AsEnumerable().Sum(row => row.Field<Decimal>("neto"));




            gvRegisgtroDePolizas.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
            gvRegisgtroDePolizas.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
            gvRegisgtroDePolizas.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
            gvRegisgtroDePolizas.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");



            gvRegisgtroDePolizas.FooterRow.Cells[6].Text = "Totales";
            gvRegisgtroDePolizas.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;

            gvRegisgtroDePolizas.Columns[0].Visible = false;
            gvRegisgtroDePolizas.Columns[1].Visible = false;
            gvRegisgtroDePolizas.Columns[2].Visible = false;
            gvRegisgtroDePolizas.Columns[3].Visible = false;
            gvRegisgtroDePolizas.Columns[7].Visible = false;
            gvRegisgtroDePolizas.Columns[8].Visible = false;
            gvRegisgtroDePolizas.Columns[16].Visible = false;
            gvRegisgtroDePolizas.Columns[17].Visible = false;
        }

        protected void gvRegisgtroDePolizas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

     
           
    }
}