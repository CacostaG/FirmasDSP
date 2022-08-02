using System.Data;
using System.Data.SqlClient;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;


namespace ListadoDeFirmasDSP._Consulta
{
    public partial class ConsultaMedidasFinAnioGenerados : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    var rol = Session["rol"];
                    var estatus = Session["estatus"];
                    switch (rol)
                    {
                        case "Validador":
                            Response.Redirect("~/Default");
                            break;
                        case "Operador del sistema":
                            Response.Redirect("~/Default");
                            break;
                    }
                   



                    ParametrosMedidasFinAnio();
                }
            }
            */
        }


        private void ParametrosMedidasFinAnio()
        {

            SqlCommand cmdAnioMFA = new SqlCommand("EXEC Pry1015_ParametrosImpresionMedidasFinAnio_Ejercicio", conexionBD);
            SqlDataAdapter sdAnioMFA = new SqlDataAdapter(cmdAnioMFA);
            DataTable dtAnioMFA = new DataTable();
            sdAnioMFA.Fill(dtAnioMFA);
            ddlAnio.DataSource = dtAnioMFA;
            ddlAnio.DataBind();

           

        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {
                ddlJuris.Enabled = false;
                ddlJuris.Items.Clear();
                ddlJuris.Items.Add("Selecciona");
                dvMessageAnio.Visible = false;
                dvMessageLote.Visible = false;
                ResetControl();
            }
            else
            {
                dvMessageAnio.Visible = false;
                dvMessageLote.Visible = false;

                ddlLote.Enabled = false;
                ddlLote.Items.Clear();
                ddlLote.Items.Add("Selecciona");
                
                ddlJuris.Enabled = true;
                ddlJuris.Items.Clear();
                ddlJuris.Items.Add("Todas");

                SqlCommand cmdJurisdiccion = new SqlCommand("exec Pry1015_ParametrosImpresionMedidasFinAnio_ClaveJuris 	@anio='" + ddlAnio.Text + "'", conexionBD);
                SqlDataAdapter sdJurisdiccion = new SqlDataAdapter(cmdJurisdiccion);
                DataTable dtJuridiccion = new DataTable();
                sdJurisdiccion.Fill(dtJuridiccion);
                ddlJuris.DataSource = dtJuridiccion;
                ddlJuris.DataBind();





            }

        }


        protected void ddlJuris_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJuris.SelectedItem.Text == "Selecciona")
            {
                ddlLote.Enabled = false;
                ddlLote.Items.Clear();
                ddlLote.Items.Add("Selecciona");
                dvMessageLote.Visible = false;
                ResetControl();

            }
            else
            {
                ddlLote.Enabled = true;
                ddlLote.Items.Clear();
                ddlLote.Items.Add("Todos");
                dvMessageLote.Visible = false;

                SqlCommand cmLote = new SqlCommand("exec Pry1015_ParametrosImpresionMedidasFinAnio_Lote @anio='"+ddlAnio.Text+"', @clavejuris='"+ddlJuris.Text+"'",conexionBD);
                SqlDataAdapter sdLote = new SqlDataAdapter(cmLote);
                DataTable dtLote = new DataTable();
                sdLote.Fill(dtLote);
                ddlLote.DataSource = dtLote;
                ddlLote.DataBind();

            }




        }

   





        /*Modificar consultaclick*/
        protected void ConsultarListado_Click(object sender, EventArgs e)
        {
            

        }


        protected void BindGridView()
        {

            DataTable dtConsutlaMedidaLote = new DataTable();
            SqlDataAdapter consultaMedidasLote = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaMedidasFinAnio @anio='"+ddlAnio.Text+ "' , @ClaveJuris='"+ddlJuris.Text+ "' , @lote='"+ddlLote.Text+"'", conexionBD);
            conexionBD.Open();
            consultaMedidasLote.Fill(dtConsutlaMedidaLote);
            conexionBD.Close();

            if (dtConsutlaMedidaLote.Rows.Count > 0)
            {
                btnExporta.Enabled = true;
                gvConsultaMedidasFinAnio.DataSource = dtConsutlaMedidaLote;
                gvConsultaMedidasFinAnio.DataBind();

            }
            else
            {
                DataTable dtConsutlaMedidasJuris = new DataTable();
                SqlDataAdapter consultaMedidasJuris = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaMedidasFinAnio @anio='" + ddlAnio.Text + "' , @ClaveJuris='" + ddlJuris.Text + "'", conexionBD);
                conexionBD.Open();
                consultaMedidasJuris.Fill(dtConsutlaMedidasJuris);
                conexionBD.Close();

                if (dtConsutlaMedidasJuris.Rows.Count > 0)
                {
                    btnExporta.Enabled = true;
                    gvConsultaMedidasFinAnio.DataSource = dtConsutlaMedidasJuris;
                    gvConsultaMedidasFinAnio.DataBind();

                }
                else
                {
                    DataTable dtConsultaMedidasAnio = new DataTable();
                    SqlDataAdapter consultaMedidasAnio = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaMedidasFinAnio @anio='" + ddlAnio.Text + "'", conexionBD);
                    conexionBD.Open();
                    consultaMedidasAnio.Fill(dtConsultaMedidasAnio);
                    conexionBD.Close();
                    btnExporta.Enabled = true;
                    gvConsultaMedidasFinAnio.DataSource = dtConsultaMedidasAnio;
                    gvConsultaMedidasFinAnio.DataBind();

                }


            }


        }

        protected void btnLimpia_Click(object sender, EventArgs e)
        {
            ResetControl();
        }


        public void ResetControl()
        {
            ddlLote.Items.Clear();
            ddlLote.Items.Add("Selecciona");
            ddlLote.Enabled = false;


            ddlJuris.Items.Clear();
            ddlJuris.Items.Add("Selecciona");
            ddlJuris.Enabled = false;


            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");
            ddlAnio.Enabled = true;


         

            gvConsultaMedidasFinAnio.DataSource = null;
            gvConsultaMedidasFinAnio.DataBind();

         

            lblMensajeErrorAnio.Visible = false;
            lblMensajeErrorJuris.Visible = false;
            lblMensajeErrorLote.Visible = false;

            btnExporta.Enabled = false;



            ParametrosMedidasFinAnio();
        }



        protected void btnExporta_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "Consulta de listados de FEAC generados " + DateTime.Now + ".xls";

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo);
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1252");
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                gvConsultaMedidasFinAnio.AllowPaging = false;
                this.BindGridView();

                gvConsultaMedidasFinAnio.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvConsultaMedidasFinAnio.HeaderRow.Cells)
                {
                    cell.BackColor = gvConsultaMedidasFinAnio.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvConsultaMedidasFinAnio.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvConsultaMedidasFinAnio.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvConsultaMedidasFinAnio.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvConsultaMedidasFinAnio.RenderControl(hw);


                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            if (ddlAnio.SelectedItem.Text == "Selecciona")
            {
                dvMessageAnio.Visible = true;
                lblMensajeErrorAnio.Text = "Seleccione periodo";
            }

            else
            {
                dvMessageLote.Visible = false;
                dvMessageAnio.Visible = false;
                BindGridView();
            }
        }
    }
}