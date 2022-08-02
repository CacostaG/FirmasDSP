using System.Data;
using System.Data.SqlClient;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListadoDeFirmasDSP._Administracion

{
    public partial class PrepararQuincena : System.Web.UI.Page
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

            */
        }

        private void Parametros()
        {
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");
                      

            SqlCommand cmd = new SqlCommand("exec Pry1015_ParametrosGenerales_Anio ", conexionBD);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            ddlAnio.DataSource = dt;
            ddlAnio.DataBind();

             
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
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
                ResetControl();
            }
            else
            {
                dvMessageAnio1.Visible = false;
                lblMensajeErrorAnio1.Visible = false;

                dvMessageQuincena.Visible = false;
                lblMensajeErrorQuincena.Visible = false;

                ddlQuincena.Enabled = true;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");

                SqlCommand cmdQuincena = new SqlCommand("exec Pry1015_ParametrosGenerales_Quincena @anio='" + ddlAnio.SelectedItem.Value + "'", conexionBD);
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
               

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else
            {


                dvMessageQuincena.Visible = false;
                lblMensajeErrorQuincena.Visible = false;

                ddlNomina.Enabled = true;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");

                SqlCommand cmdNomina = new SqlCommand("exec Pry1015_ParametrosGenerales_Nomina @anio='" + ddlAnio.SelectedItem.Value + "' , @qna='" + ddlQuincena.Text + "'", conexionBD);
                SqlDataAdapter sdaNomina = new SqlDataAdapter(cmdNomina);
                DataTable dtNomina = new DataTable();
                sdaNomina.Fill(dtNomina);

                ddlNomina.DataSource = dtNomina;
                ddlNomina.DataBind();
            }

        }

        protected void ddlNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNomina.SelectedItem.Text == "TODAS")
            {
               

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else
            {
                ddlUR.Enabled = true;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
                

                SqlCommand cmdUR = new SqlCommand("exec Pry1015_ParametrosGenerales_UR @anio='" + ddlAnio.SelectedItem.Value + "' , @qna='" + ddlQuincena.Text + "' ,@nomina='" + ddlNomina.Text + "'", conexionBD);
                SqlDataAdapter sdaUR = new SqlDataAdapter(cmdUR);
                DataTable dtUR = new DataTable();
                sdaUR.Fill(dtUR);

                ddlUR.DataSource = dtUR;
                ddlUR.DataBind();

            }
        }
        public void ResetControl()
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {


                ddlQuincena.Enabled = false;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else if (ddlQuincena.SelectedItem.Text == "Selecciona")
            {
                 

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else if (ddlNomina.SelectedItem.Text == "TODAS")
            {
                

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else if (ddlUR.SelectedItem.Text == "TODAS")
            {
                 ddlUR.Enabled = true;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else if ((ddlNomina.SelectedItem.Text == "TODAS") || (ddlUR.SelectedItem.Text == "TODAS"))
            {

               

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");

            }
            else if ((ddlNomina.SelectedItem.Text == "TODAS") || (ddlQuincena.SelectedItem.Text == "Selecciona"))
            {
              

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");

            }
            else if ((ddlAnio.SelectedItem.Text == "Selecciona") || (ddlQuincena.SelectedItem.Text == "Selecciona"))
            {

                ddlQuincena.Enabled = true;
                ddlQuincena.Items.Clear();
                ddlQuincena.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");

            }
            else { Parametros(); }

        }
        protected void Buscar_Click(object sender, EventArgs e)
        {


            if ("Selecciona".Equals(ddlAnio.Text))
            {
                dvMessageAnio1.Visible = true;
                lblMensajeErrorAnio1.Text = "Seleccione ejercicio";

            }
            else
            {

                if ("Selecciona".Equals(ddlQuincena.Text))
                {
                    dvMessageQuincena.Visible = true;
                    lblMensajeErrorQuincena.Visible = true;
                }
                else
                {
                    BindGridView();
                }
            }
        }

        protected void BindGridView()
        {

            DataTable TablaGVUR = new DataTable();
            SqlDataAdapter consultaGVUR = new SqlDataAdapter("exec Pry1015_PrepararQuincena_Buscar @anio='" + ddlAnio.Text + "',@qna='" + ddlQuincena.Text + "',@nomina='" + ddlNomina.Text + "',@ur='" + ddlUR.Text + "'", conexionBD);
            conexionBD.Open();

            consultaGVUR.Fill(TablaGVUR);
            conexionBD.Close();

            if (TablaGVUR.Rows.Count > 0)
            {
                gvPreparaQuincena.DataSource = TablaGVUR;
                gvPreparaQuincena.DataBind();

                int totaPagos = TablaGVUR.AsEnumerable().Sum(row => row.Field<int>("Pagos_Qna"));
                Decimal totaImporteBruto = TablaGVUR.AsEnumerable().Sum(row => row.Field<Decimal>("Importe_Bruto"));
                Decimal totaImporteDescuento = TablaGVUR.AsEnumerable().Sum(row => row.Field<Decimal>("Descuentos"));
                Decimal totaImporteNeto = TablaGVUR.AsEnumerable().Sum(row => row.Field<Decimal>("Importe_neto"));
                gvPreparaQuincena.FooterRow.Cells[6].Text = "Totales";
                gvPreparaQuincena.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;

                gvPreparaQuincena.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
                gvPreparaQuincena.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
                gvPreparaQuincena.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
                gvPreparaQuincena.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");

                gvPreparaQuincena.Columns[0].Visible = false;
                gvPreparaQuincena.Columns[1].Visible = false;
                gvPreparaQuincena.Columns[2].Visible = false;
                gvPreparaQuincena.Columns[11].Visible = false;

                dvBtnQna.Visible = true;
                btnPreparaPrd.Visible = true;

            }


            else
            {
                DataTable TablaGVNomina = new DataTable();
                SqlDataAdapter consultaGVNomina = new SqlDataAdapter("exec Pry1015_PrepararQuincena_Buscar @anio='" + ddlAnio.Text + "',@qna='" + ddlQuincena.Text + "',@nomina='" + ddlNomina.Text + "'", conexionBD);
                conexionBD.Open();
                consultaGVNomina.Fill(TablaGVNomina);
                conexionBD.Close();

                if (TablaGVNomina.Rows.Count > 0)
                {
                    gvPreparaQuincena.DataSource = TablaGVNomina;
                    gvPreparaQuincena.DataBind();

                    int totaPagos = TablaGVNomina.AsEnumerable().Sum(row => row.Field<int>("Pagos_Qna"));
                    Decimal totaImporteBruto = TablaGVNomina.AsEnumerable().Sum(row => row.Field<Decimal>("Importe_Bruto"));
                    Decimal totaImporteDescuento = TablaGVNomina.AsEnumerable().Sum(row => row.Field<Decimal>("Descuentos"));
                    Decimal totaImporteNeto = TablaGVNomina.AsEnumerable().Sum(row => row.Field<Decimal>("Importe_neto"));
                    gvPreparaQuincena.FooterRow.Cells[6].Text = "Totales";
                    gvPreparaQuincena.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;

                    gvPreparaQuincena.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
                    gvPreparaQuincena.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
                    gvPreparaQuincena.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
                    gvPreparaQuincena.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");

                    gvPreparaQuincena.Columns[0].Visible = false;
                    gvPreparaQuincena.Columns[1].Visible = false;
                    gvPreparaQuincena.Columns[2].Visible = false;
                    gvPreparaQuincena.Columns[11].Visible = false;

                    dvBtnQna.Visible = true;
                    btnPreparaPrd.Visible = true;
                }
                else
                {
                    DataTable TablaGVquincena = new DataTable();
                    SqlDataAdapter consultaGVquincena = new SqlDataAdapter("exec Pry1015_PrepararQuincena_Buscar @anio='" + ddlAnio.Text + "',@qna='" + ddlQuincena.Text + "'", conexionBD);
                    conexionBD.Open();
                    consultaGVquincena.Fill(TablaGVquincena);
                    conexionBD.Close();

                    if (TablaGVquincena.Rows.Count > 0)
                    {
                        gvPreparaQuincena.DataSource = TablaGVquincena;
                        gvPreparaQuincena.DataBind();

                        int totaPagos = TablaGVquincena.AsEnumerable().Sum(row => row.Field<int>("Pagos_Qna"));
                        Decimal totaImporteBruto = TablaGVquincena.AsEnumerable().Sum(row => row.Field<Decimal>("Importe_Bruto"));
                        Decimal totaImporteDescuento = TablaGVquincena.AsEnumerable().Sum(row => row.Field<Decimal>("Descuentos"));
                        Decimal totaImporteNeto = TablaGVquincena.AsEnumerable().Sum(row => row.Field<Decimal>("Importe_neto"));
                        gvPreparaQuincena.FooterRow.Cells[6].Text = "Totales";
                        gvPreparaQuincena.FooterRow.Cells[1].HorizontalAlign = HorizontalAlign.Center;

                        gvPreparaQuincena.FooterRow.Cells[10].Text = totaPagos.ToString("N0");
                        gvPreparaQuincena.FooterRow.Cells[9].Text = totaImporteNeto.ToString("C");
                        gvPreparaQuincena.FooterRow.Cells[8].Text = totaImporteDescuento.ToString("C");
                        gvPreparaQuincena.FooterRow.Cells[7].Text = totaImporteBruto.ToString("C");

                        gvPreparaQuincena.Columns[0].Visible = false;
                        gvPreparaQuincena.Columns[1].Visible = false;
                        gvPreparaQuincena.Columns[2].Visible = false;
                        gvPreparaQuincena.Columns[11].Visible = false;

                        dvBtnQna.Visible = true;
                        btnPreparaPrd.Visible = true;
                    }
                    else
                    {

                    }

                }
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

        protected void Limpiar_Click(object sender, EventArgs e)
        {
            gvPreparaQuincena.DataSource = null;
            gvPreparaQuincena.DataBind();

            dvBtnQna.Visible = false;
            btnPreparaPrd.Visible = false;
            gvPreparaQuincena.DataSource = null;
            gvPreparaQuincena.DataBind();
            CleanControl(this.Controls);
            ddlQuincena.Items.Clear();
            ddlQuincena.Items.Add(new ListItem("Selecciona", "0"));
            ddlNomina.Items.Clear();
            ddlNomina.Items.Add(new ListItem("Selecciona", "0"));
            ddlUR.Items.Clear();
            ddlUR.Items.Add(new ListItem("Selecciona", "0"));
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add(new ListItem("Selecciona", "0"));

            SqlCommand cmd = new SqlCommand("exec Pry1015_ParametrosGenerales_Anio", conexionBD);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlAnio.DataSource = dt;
            ddlAnio.DataBind();
        }
        protected void gvTablaUno_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }


        protected void btnPreparaPrd_Click(object sender, EventArgs e)
        {
            int contador = 0;

            try
            {
                foreach (GridViewRow row in gvPreparaQuincena.Rows)
                {
                    SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
                    conexionBD.Open();

                    var checkboxSelectActualizaPreparaQuincena = row.FindControl("Checkbox1") as CheckBox;

                    if (checkboxSelectActualizaPreparaQuincena.Checked)
                    {

                        // OBTENER_DATOS();
                        SqlCommand ActualizaPreparaQuincena = new SqlCommand("Pry1015_PrepararQuincena_inserta", conexionBD);
                        ActualizaPreparaQuincena.CommandType = CommandType.StoredProcedure;
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@CNm_Key", (row.FindControl("columCNm_Key") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@anio", (row.FindControl("columAnio") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@qna", (row.FindControl("columQna") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@nomina", (row.FindControl("columQuincena") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@ur", (row.FindControl("columUR") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@prdname", (row.FindControl("columPRDNAME") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@percepciones", (row.FindControl("columPercepciones") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@deducciones", (row.FindControl("columDeducciones") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@neto", (row.FindControl("columNeto") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@registros", (row.FindControl("columRegistros") as Label).Text);
                        ActualizaPreparaQuincena.Parameters.AddWithValue("@tipo", (row.FindControl("columTipo") as Label).Text);
                 
                       

                       int respuesta =   ActualizaPreparaQuincena.ExecuteNonQuery();
                        


                        if (respuesta > 0 )
                        {

                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal({" +
                                  " title: '¿Desea continuar con el proceso?'," +
                                  " text: 'Esta a punto de guardar un producto de nómina !'," +
                                  " type: 'info'," +
                                  " showCancelButton: true," +
                                  " confirmButtonClass: 'btn-info'," +
                                  " confirmButtonText: 'Si, guardar producto!'," +
                                  " cancelButtonText: 'No, cancelar el proceso!'," +
                                  " closeOnConfirm: false," +
                                  " closeOnCancel: false," +
                                  "}," +
                                  "function(isConfirm) { " +
                                  " if (isConfirm) { " +
                                  "swal('Finalizado!'," +
                                  " 'El registro se ha agregado con éxito.','success');" +
                                  " }else {" +
                                  " swal('Cancelado', 'El registro no se ha modificado'," +
                                  " 'error'); }}); ", true) ;
                            conexionBD.Close();
                            gvPreparaQuincena.DataSource = null;
                            gvPreparaQuincena.DataBind();
                            btnPreparaPrd.Visible = false;

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'El producto de nómina ya ha sido cargado previamente', 'error');", true);
                            gvPreparaQuincena.DataSource = null;
                            gvPreparaQuincena.DataBind();
                            btnPreparaPrd.Visible = false;

                        }
                       
                    }
                    else
                    {                       
                        contador++;
                    }
                }

                if(contador == gvPreparaQuincena.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes seleccionar un producto de nómina', 'warning');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!','" + ex.Message + "', 'warning');", true);
            }
        }

    }
}


