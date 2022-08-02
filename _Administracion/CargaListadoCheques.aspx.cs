using System.Data;
using System.Data.SqlClient;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Linq;
using System.Web;

namespace ListadoDeFirmasDSP._Administracion
{
    public partial class CargaListadoCheques : System.Web.UI.Page
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
            }*/
        }

        /*select parametros*/
        private void Parametros()
        {
            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");
            SqlCommand cmd = new SqlCommand("exec Pry1015_ListadoFirmas_ParametrosChequesDetalle_SPAnio ", conexionBD);
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
                ddlQna.Enabled = false;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                ResetControl();
            }
            else
            {
                dvMessageAnio1.Visible = false;

                ddlQna.Enabled = true;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");

                lblMensajeErrorAnio1 = null;
                SqlCommand cmdQuincenaInicial = new SqlCommand("exec Pry1015_ListadoFirmas_ParametrosChequesDetalle_SPQna @anio='" + ddlAnio.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaQuincenaInicial = new SqlDataAdapter(cmdQuincenaInicial);
                DataTable dtQuincenaInicial = new DataTable();
                sdaQuincenaInicial.Fill(dtQuincenaInicial);
                ddlQna.DataSource = dtQuincenaInicial;
                ddlQna.DataBind();

                  

            }
        }

        protected void ddlQuincenaInicial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlQna.SelectedItem.Text == "Selecciona")
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


                ddlNomina.Enabled = true;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");
               

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("Selecciona");
                dvMessageQuincenaInicial1.Visible = false;

                SqlCommand cmdNom = new SqlCommand("exec Pry1015_ListadoFirmas_ParametrosChequesDetalle_SPNom @anio = '" + ddlAnio.SelectedItem.Value + "', @qna= '" + ddlQna.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaNom = new SqlDataAdapter(cmdNom);
                DataTable dtNom = new DataTable();
                sdaNom.Fill(dtNom);

                ddlNomina.DataSource = dtNom;
                ddlNomina.DataBind();
                lblMensajeErrorQuincenaInicial1 = null;
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

                SqlCommand cmdUr = new SqlCommand("exec Pry1015_ListadoFirmas_ParametrosChequesDetalle_SPUR @anio= '" + ddlAnio.SelectedItem.Value + "',@qna = '" + ddlQna.SelectedItem.Value + "',@nomina ='" + ddlNomina.SelectedItem.Value + "'", conexionBD);
                SqlDataAdapter sdaUr = new SqlDataAdapter(cmdUr);
                DataTable dtUr = new DataTable();
                sdaUr.Fill(dtUr);
                ddlUR.DataSource = dtUr;
                ddlUR.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {

            if ("0".Equals(ddlAnio.Text))
            {
                dvMessageAnio1.Visible = true;
                lblMensajeErrorAnio1.Text = "Seleccione periodo";
            }
            else
            {

                if ("Inicio".Equals(ddlQna.Text))
                {
                    dvMessageQuincenaInicial1.Visible = true;
                    lblMensajeErrorQuincenaInicial1.Text = "Seleccione quincena ";
                }
                else
                {
                    BindGridView();
                }
            }
        }


        public void ResetControl()
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {
                ddlQna.Enabled = false;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                ddlUR.Enabled = false;
                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
            }
            else if (ddlQna.SelectedItem.Text == "TODAS")
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
            else if ((ddlNomina.SelectedItem.Text == "TODAS") || (ddlQna.SelectedItem.Text == "Selecciona"))
            {
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");
                ddlNomina.Enabled = true;

                ddlUR.Items.Clear();
                ddlUR.Items.Add("TODAS");
                ddlUR.Enabled = false;

                gvListadoCheques.DataSource = null;
                gvListadoCheques.DataBind();

                gvProductos.DataSource = null;
                gvProductos.DataBind();

            }
           

           
            else { Parametros(); }
        }
        protected void BindGridView()
        {
            DataTable TablaUR = new DataTable();
            SqlDataAdapter consultaUR = new SqlDataAdapter("exec Pry1015_ListadoFirmas_CargaListadoCheques @anio='" + ddlAnio.Text + "',@qna='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "',@ur='" + ddlUR.Text + "'", conexionBD);
            conexionBD.Open();
            consultaUR.Fill(TablaUR);
            conexionBD.Close();

            if (TablaUR.Rows.Count > 0)
            {
                gvProductos.DataSource = TablaUR;
                gvProductos.DataBind();
                btnSave.Enabled = true;
                btnSelect.Enabled = true;
                cargaArchivo.Enabled = true;
            }
            else
            {
                DataTable TablaNomina = new DataTable();
                SqlDataAdapter consultaNomina = new SqlDataAdapter("exec Pry1015_ListadoFirmas_CargaListadoCheques @anio='" + ddlAnio.Text + "',@qna='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "'", conexionBD);
                conexionBD.Open();
                consultaNomina.Fill(TablaNomina);
                conexionBD.Close();
                if (TablaNomina.Rows.Count > 0)
                {
                    gvProductos.DataSource = TablaNomina;
                    gvProductos.DataBind();
                    btnSave.Enabled = true;
                    btnSelect.Enabled = true;
                    cargaArchivo.Enabled = true;
                }
                else
                {
                    DataTable Tablaquincena = new DataTable();
                    SqlDataAdapter consultaquincena = new SqlDataAdapter("exec Pry1015_ListadoFirmas_CargaListadoCheques @anio='" + ddlAnio.Text + "',@qna='" + ddlQna.Text + "'", conexionBD);
                    conexionBD.Open();
                    consultaquincena.Fill(Tablaquincena);
                    conexionBD.Close();
                    if (Tablaquincena.Rows.Count > 0)
                    {
                        gvProductos.DataSource = Tablaquincena;
                        gvProductos.DataBind();
                        btnSave.Enabled = true;
                        btnSelect.Enabled = true;
                        cargaArchivo.Enabled = true;
                    }
                    else
                    {
                        Parametros();
                        ResetControl();
                    }
                }
            }
        }
        /*boton Visualiza excel*/
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            if (cargaArchivo.PostedFile != null)
            {
                try
                {
                    string path = string.Concat(Server.MapPath("~/ImportDocument/" + cargaArchivo.FileName));
                    cargaArchivo.SaveAs(path);
                    string excelCS = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);
                    DataTable dtGV = new DataTable();
                    using (OleDbConnection con = new OleDbConnection(excelCS))
                    {
                        con.Open();
                        dtGV = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                        string hoja = dtGV.Rows[0].Field<string>("TABLE_NAME");
                        OleDbDataAdapter dbDataAdapter = new OleDbDataAdapter($"select * from [{hoja}]", con);
                        DataTable datos = new DataTable();
                        dbDataAdapter.Fill(datos);
                        gvListadoCheques.DataSource = datos;
                        gvListadoCheques.DataBind();
                        gvListadoCheques.Visible = true;

                       
                    }
                }
                catch (Exception error)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', '" + error.Message + "' , 'warning');", true);
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'Debes de agregar un archivo válido' , 'warning');", true);
            }
        }
        /*boton para cargar y actualizar */
        protected void btnSave_Click(object sender, EventArgs e)
        {
            /*carga datos*/
            SqlConnection conexionBD = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());
            conexionBD.Open();

            int contador = 0;
            try
            {

                foreach (GridViewRow rowP in gvProductos.Rows)
                {
                    var CheckBox = rowP.FindControl("CheckBox") as CheckBox;
                    if (CheckBox.Checked)
                    {


                        foreach (GridViewRow rowL in gvListadoCheques.Rows)
                        {

                            SqlCommand save = new SqlCommand("Pry1015_ListadoFirmas_CargaListadoChequesInsert", conexionBD);
                            save.CommandType = CommandType.StoredProcedure;
                            save.Parameters.Clear();

                            save.Parameters.AddWithValue("@Producto_nomina_id", (rowP.FindControl("Producto_nomina_id") as Label).Text);
                            save.Parameters.AddWithValue("@nomina", (rowP.FindControl("columNomina") as Label).Text);
                            save.Parameters.AddWithValue("@ur", (rowP.FindControl("columUR") as Label).Text);
                            save.Parameters.AddWithValue("@anio", (rowP.FindControl("columAnio") as Label).Text);
                            save.Parameters.AddWithValue("@qna", (rowP.FindControl("columQna") as Label).Text);
                            save.Parameters.AddWithValue("@prdname", (rowP.FindControl("columPRDNAME") as Label).Text);

                            save.Parameters.AddWithValue("@RFC", Convert.ToString(rowL.Cells[0].Text));
                           

                            string NombreText = HttpUtility.HtmlDecode(rowL.Cells[1].Text);
                            rowL.Cells[1].Text = NombreText;

                            /*Convert.ToString(rowL.Cells[1].Text));*/

                             save.Parameters.AddWithValue("@Nombre", NombreText);

                            save.Parameters.AddWithValue("@Total", Convert.ToDecimal(rowL.Cells[3].Text));
                            save.Parameters.AddWithValue("@Recibo", Convert.ToString(rowL.Cells[4].Text));
                            save.Parameters.AddWithValue("@Centro", Convert.ToString(rowL.Cells[5].Text));
                            save.Parameters.AddWithValue("@NombreCentro", Convert.ToString(rowL.Cells[6].Text));
                            save.Parameters.AddWithValue("@User", Convert.ToString(User.Text));


                            int respuesta = save.ExecuteNonQuery();
                           


                            if (respuesta > 0)
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito.', 'success');", true);
                                btnSelect.Enabled = false;
                                cargaArchivo.Enabled = false;
                                gvListadoCheques.DataSource = null;
                                gvListadoCheques.DataBind();
                                gvProductos.DataSource = null;
                                gvProductos.DataBind();

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!', 'El producto de nómina ya ha sido cargado previamente', 'error');", true);
                                btnSelect.Enabled = false;
                                cargaArchivo.Enabled = false;
                                gvListadoCheques.DataSource = null;
                                gvListadoCheques.DataBind();
                                gvProductos.DataSource = null;
                                gvProductos.DataBind();
                            }


                           
                        }

                      
                    }
                    else
                    {
                        contador++;
                        
                    }
                }

                if(contador == gvListadoCheques.Rows.Count)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención!', 'Debes seleccionar un producto de nómina.', 'warning');", true);
                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!','" + ex.Message + "', 'warning');", true);
            }

        }
        protected void btnClean_Click(object sender, EventArgs e)
        {
            gvListadoCheques.DataSource = null;
            gvListadoCheques.DataBind();
            gvProductos.DataSource = null;
            gvProductos.DataBind();

            ddlAnio.Items.Clear();
            ddlAnio.Items.Add(new ListItem("Selecciona", "0"));

            ddlQna.Items.Clear();
            ddlQna.Items.Add(new ListItem("Selecciona", "0"));

            ddlNomina.Items.Clear();
            ddlNomina.Items.Add(new ListItem("Selecciona", "0"));

            ddlUR.Items.Clear();
            ddlUR.Items.Add(new ListItem("Selecciona", "0"));

            dvMessageAnio1.Visible = false;
            dvMessageQuincenaInicial1.Visible = false;

            btnSave.Enabled = false;
            btnSelect.Enabled = false;
            cargaArchivo.Enabled = false;
            Parametros();
        }


    }
}
