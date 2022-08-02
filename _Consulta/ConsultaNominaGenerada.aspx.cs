using System.Data;
using System.Data.SqlClient;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;

namespace ListadoDeFirmasDSP._Consulta
{
    public partial class ConsultaNominaGenerada : System.Web.UI.Page
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
                if (!IsPostBack)
                {
                    var rol = Session["rol"];
                    switch (rol)
                    {
                        case "Operador del sistema":
                            Response.Redirect("~/Default");
                            break;
                        case "Validador":

                            break;
                    }

                    ParametrosNomina();
                }
            }

            */
        }


        private void ParametrosNomina()
        {
            ddlJuris.Items.Clear();
            ddlJuris.Items.Add("Selecciona");
            ddlJuris.Items.Add("TODAS");
            SqlCommand cmdJuris = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPJuris ", conexionBD);
            SqlDataAdapter sdaJuris = new SqlDataAdapter(cmdJuris);
            DataTable dtJuris = new DataTable();
            sdaJuris.Fill(dtJuris);
            ddlJuris.DataSource = dtJuris;
            ddlJuris.DataBind();
        }

        protected void ddlJuris_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJuris.SelectedItem.Text == "Selecciona")
            {
                ddlAnio.Enabled = false;
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");

                ddlQna.Enabled = false;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");


            }
            else if (ddlJuris.SelectedItem.Text == "TODAS")
            {
                dvMessageJuris.Visible = false;
                dvMessageAnio.Visible = false;
                dvMessageQna.Visible = false;

                lbAnio.Visible = false;
                lbJuris.Visible = false;
                lbQna.Visible = false;


                ddlQna.Enabled = false;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlAnio.Enabled = true;
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");

                SqlCommand cmdAnio = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPAnio", conexionBD);
                SqlDataAdapter sdaAnio = new SqlDataAdapter(cmdAnio);
                DataTable dtAnio = new DataTable();
                sdaAnio.Fill(dtAnio);
                ddlAnio.DataSource = dtAnio;
                ddlAnio.DataBind();
            }
            else
            {
                dvMessageJuris.Visible = false;
                dvMessageAnio.Visible = false;
                dvMessageQna.Visible = false;

                lbAnio.Visible = false;
                lbJuris.Visible = false;
                lbQna.Visible = false;

                ddlQna.Enabled = false;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlAnio.Enabled = true;
                ddlAnio.Items.Clear();
                ddlAnio.Items.Add("Selecciona");

                SqlCommand cmdAnio = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPAnio @jurisdiccionN='" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdaAnio = new SqlDataAdapter(cmdAnio);
                DataTable dtAnio = new DataTable();
                sdaAnio.Fill(dtAnio);
                ddlAnio.DataSource = dtAnio;
                ddlAnio.DataBind();
            }
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

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");
            }
            else if (ddlJuris.SelectedItem.Text == "TODAS")
            {
                dvMessageJuris.Visible = false;
                dvMessageAnio.Visible = false;
                dvMessageQna.Visible = false;

                lbAnio.Visible = false;
                lbJuris.Visible = false;
                lbQna.Visible = false;

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlQna.Enabled = true;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                SqlCommand cmdQnaSJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPQna @anio ='" + ddlAnio.Text + "'", conexionBD);
                SqlDataAdapter sdaQnaSJ = new SqlDataAdapter(cmdQnaSJ);
                DataTable dtQnaSJ = new DataTable();
                sdaQnaSJ.Fill(dtQnaSJ);
                ddlQna.DataSource = dtQnaSJ;
                ddlQna.DataBind();
            }
            else
            {
                dvMessageJuris.Visible = false;
                dvMessageAnio.Visible = false;
                dvMessageQna.Visible = false;

                lbAnio.Visible = false;
                lbJuris.Visible = false;
                lbQna.Visible = false;

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlQna.Enabled = true;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");

                SqlCommand cmdQnaCJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPQna @anio ='" + ddlAnio.Text + "', @jurisdiccionN ='" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdaQnaCJ = new SqlDataAdapter(cmdQnaCJ);
                DataTable dtQnaCJ = new DataTable();
                sdaQnaCJ.Fill(dtQnaCJ);
                ddlQna.DataSource = dtQnaCJ;
                ddlQna.DataBind();
            }
        }

        protected void ddlQna_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlQna.SelectedItem.Text == "Selecciona")
            {

                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");
            }
            else if (ddlJuris.SelectedItem.Text == "TODAS")
            {
                dvMessageJuris.Visible = false;
                dvMessageAnio.Visible = false;
                dvMessageQna.Visible = false;

                lbAnio.Visible = false;
                lbJuris.Visible = false;
                lbQna.Visible = false;

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");

                ddlNomina.Enabled = true;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                SqlCommand cmdNomiSJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPNom @anio ='" + ddlAnio.Text + "', @qna ='" + ddlQna.Text + "'", conexionBD);
                SqlDataAdapter sdaNomiSJ = new SqlDataAdapter(cmdNomiSJ);
                DataTable dtNomiSJ = new DataTable();
                sdaNomiSJ.Fill(dtNomiSJ);
                ddlNomina.DataSource = dtNomiSJ;
                ddlNomina.DataBind();
            }
            else
            {
                dvMessageJuris.Visible = false;
                dvMessageAnio.Visible = false;
                dvMessageQna.Visible = false;

                lbAnio.Visible = false;
                lbJuris.Visible = false;
                lbQna.Visible = false;

                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");

                ddlNomina.Enabled = true;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("TODAS");

                SqlCommand cmdNomiCJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPNom @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@jurisdiccionN ='" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdaNomiCJ = new SqlDataAdapter(cmdNomiCJ);
                DataTable dtNomiCJ = new DataTable();
                sdaNomiCJ.Fill(dtNomiCJ);
                ddlNomina.DataSource = dtNomiCJ;
                ddlNomina.DataBind();
            }

        }

        protected void ddlNomina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNomina.SelectedItem.Text == "TODAS")
            {
                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");
            }
            else if (ddlJuris.SelectedItem.Text == "TODAS")
            {
                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");

                ddlUr.Enabled = true;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("TODAS");

                SqlCommand cmdUrSJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPUr @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "'", conexionBD);
                SqlDataAdapter sdaUrSJ = new SqlDataAdapter(cmdUrSJ);
                DataTable dtUrSJ = new DataTable();
                sdaUrSJ.Fill(dtUrSJ);
                ddlUr.DataSource = dtUrSJ;
                ddlUr.DataBind();
            }
            else
            {
                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");

                ddlUr.Enabled = true;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("TODAS");

                SqlCommand cmdUrCJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPUr @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "',@jurisdiccionN = '" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdaUrCJ = new SqlDataAdapter(cmdUrCJ);
                DataTable dtUrCJ = new DataTable();
                sdaUrCJ.Fill(dtUrCJ);
                ddlUr.DataSource = dtUrCJ;
                ddlUr.DataBind();
            }
        }

        protected void ddlUr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUr.SelectedItem.Text == "TODAS")
            {
                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");


                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");
            }
            else if (ddlJuris.SelectedItem.Text == "TODAS")
            {

                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");

                ddlPrd.Enabled = true;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("TODOS");

                SqlCommand cmdPrdSJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPPrd @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "',@ur = '" + ddlUr.Text + "'", conexionBD);
                SqlDataAdapter sdaPrdSJ = new SqlDataAdapter(cmdPrdSJ);
                DataTable dtPrdSJ = new DataTable();
                sdaPrdSJ.Fill(dtPrdSJ);
                ddlPrd.DataSource = dtPrdSJ;
                ddlPrd.DataBind();
            }
            else
            {
                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");

                ddlPrd.Enabled = true;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("TODOS");

                SqlCommand cmdPrdCJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPPrd @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "',@ur = '" + ddlUr.Text + "', @jurisdiccionN='" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdaPrdCJ = new SqlDataAdapter(cmdPrdCJ);
                DataTable dtPrdCJ = new DataTable();
                sdaPrdCJ.Fill(dtPrdCJ);
                ddlPrd.DataSource = dtPrdCJ;
                ddlPrd.DataBind();
            }
        }

        protected void ddlPrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlPrd.SelectedItem.Text == "TODOS")
            {
                ddlInstru.Enabled = false;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("Selecciona");
            }
            else if (ddlJuris.SelectedItem.Text == "TODAS")
            {
                ddlInstru.Enabled = true;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("TODOS");

                SqlCommand cmdInstSJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPInst @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "',@ur = '" + ddlUr.Text + "', @prd='" + ddlPrd.Text + "'", conexionBD);
                SqlDataAdapter sdaInstSJ = new SqlDataAdapter(cmdInstSJ);
                DataTable dtInstSJ = new DataTable();
                sdaInstSJ.Fill(dtInstSJ);
                ddlInstru.DataSource = dtInstSJ;
                ddlInstru.DataBind();
            }
            else
            {
                ddlInstru.Enabled = true;
                ddlInstru.Items.Clear();
                ddlInstru.Items.Add("TODOS");

                SqlCommand cmdInstCJ = new SqlCommand("Pry1015_ListadoFirmasNominaGeneradosDetalle_SPInst @anio ='" + ddlAnio.Text + "',@qna ='" + ddlQna.Text + "',@nomina='" + ddlNomina.Text + "',@ur = '" + ddlUr.Text + "', @prd='" + ddlPrd.Text + "', @jurisdiccionN ='" + ddlJuris.Text + "'", conexionBD);
                SqlDataAdapter sdaInstCJ = new SqlDataAdapter(cmdInstCJ);
                DataTable dtInstCJ = new DataTable();
                sdaInstCJ.Fill(dtInstCJ);
                ddlInstru.DataSource = dtInstCJ;
                ddlInstru.DataBind();
            }
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            if ("Selecciona".Equals(ddlAnio.Text))
            {
                dvMessageAnio.Visible = true;
                lbAnio.Visible = true;

            }
            else
            {
                if ("Selecciona".Equals(ddlJuris.Text))
                {
                    dvMessageJuris.Visible = true;
                    lbJuris.Visible = true;

                }

                else
                {

                    if ("Selecciona".Equals(ddlQna.Text))
                    {
                        dvMessageQna.Visible = true;
                        lbQna.Visible = true;

                    }
                    else
                    {

                        BindGridView();
                    }
                }
            }
        }



        protected void BindGridView()
        {
            DataTable dtInstruCJ = new DataTable();
            SqlDataAdapter qInstruCJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada" +
                  " @jurisdiccionNLF ='" + ddlJuris.Text + "',@anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF='" + ddlQna.Text + "' ,@nominaConsultaLF ='" + ddlNomina.Text +
                  "' ,@urConsultaLF ='" + ddlUr.Text + "' ,@prdnameConsultaLF ='" + ddlPrd.Text + "',@instruConsultaLF ='" + ddlInstru.Text + "'", conexionBD);
            conexionBD.Open();

            qInstruCJ.Fill(dtInstruCJ);
            conexionBD.Close();
            if (dtInstruCJ.Rows.Count > 0)
            {
                gvListadoNomina.DataSource = dtInstruCJ;
                gvListadoNomina.DataBind();
                gvListadoNomina.Columns[0].Visible = false;
                btnExporta.Enabled = true;
            }
            else
            {
                DataTable dtInstruSJ = new DataTable();
                SqlDataAdapter qInstruSJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "',@urConsultaLF ='" + ddlUr.Text + "',@prdnameConsultaLF='" + ddlPrd.Text + "',@instruConsultaLF ='" + ddlInstru.Text + "'", conexionBD);
                conexionBD.Open();

                qInstruSJ.Fill(dtInstruSJ);
                conexionBD.Close();

                if (dtInstruSJ.Rows.Count > 0)
                {
                    gvListadoNomina.DataSource = dtInstruSJ;
                    gvListadoNomina.DataBind();
                    gvListadoNomina.Columns[0].Visible = false;
                    btnExporta.Enabled = true;
                }
                else
                {
                    DataTable dtInstruCJSI = new DataTable();
                    SqlDataAdapter qInstruCJSI = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @jurisdiccionNLF ='" + ddlJuris.Text + "', @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "',@urConsultaLF ='" + ddlUr.Text + "',@prdnameConsultaLF='" + ddlPrd.Text + "'", conexionBD);
                    conexionBD.Open();

                    qInstruCJSI.Fill(dtInstruCJSI);
                    conexionBD.Close();

                    if (dtInstruCJSI.Rows.Count > 0)
                    {
                        gvListadoNomina.DataSource = dtInstruCJSI;
                        gvListadoNomina.DataBind();
                        gvListadoNomina.Columns[0].Visible = false;
                        btnExporta.Enabled = true;
                    }
                    else
                    {
                        DataTable dtInstruSJSI = new DataTable();
                        SqlDataAdapter qInstruSJSI = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "',@urConsultaLF ='" + ddlUr.Text + "',@prdnameConsultaLF='" + ddlPrd.Text + "'", conexionBD);
                        conexionBD.Open();

                        qInstruSJSI.Fill(dtInstruSJSI);
                        conexionBD.Close();

                        if (dtInstruSJSI.Rows.Count > 0)
                        {
                            gvListadoNomina.DataSource = dtInstruSJSI;
                            gvListadoNomina.DataBind();
                            gvListadoNomina.Columns[0].Visible = false;
                            btnExporta.Enabled = true;
                        }
                        else
                        {
                            DataTable dtPrdCJ = new DataTable();
                            SqlDataAdapter qPrdCJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @jurisdiccionNLF ='" + ddlJuris.Text + "', @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "',@urConsultaLF ='" + ddlUr.Text + "'", conexionBD);
                            conexionBD.Open();

                            qPrdCJ.Fill(dtPrdCJ);
                            conexionBD.Close();

                            if (dtPrdCJ.Rows.Count > 0)
                            {
                                gvListadoNomina.DataSource = dtPrdCJ;
                                gvListadoNomina.DataBind();
                                gvListadoNomina.Columns[0].Visible = false;
                                btnExporta.Enabled = true;
                            }
                            else
                            {
                                DataTable dtPrdSJ = new DataTable();
                                SqlDataAdapter qPrdSJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada  @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "',@urConsultaLF ='" + ddlUr.Text + "'", conexionBD);
                                conexionBD.Open();

                                qPrdSJ.Fill(dtPrdSJ);
                                conexionBD.Close();

                                if (dtPrdSJ.Rows.Count > 0)
                                {
                                    gvListadoNomina.DataSource = dtPrdSJ;
                                    gvListadoNomina.DataBind();
                                    gvListadoNomina.Columns[0].Visible = false;
                                    btnExporta.Enabled = true;
                                }
                                else
                                {
                                    DataTable dtUrCJ = new DataTable();
                                    SqlDataAdapter qUrCJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @jurisdiccionNLF ='" + ddlJuris.Text + "' ,@anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "'", conexionBD);
                                    conexionBD.Open();

                                    qUrCJ.Fill(dtUrCJ);
                                    conexionBD.Close();

                                    if (dtUrCJ.Rows.Count > 0)
                                    {
                                        gvListadoNomina.DataSource = dtUrCJ;
                                        gvListadoNomina.DataBind();
                                        gvListadoNomina.Columns[0].Visible = false;
                                        btnExporta.Enabled = true;
                                    }
                                    else
                                    {
                                        DataTable dtUrSJ = new DataTable();
                                        SqlDataAdapter qUrSJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "',@nominaConsultaLF ='" + ddlNomina.Text + "'", conexionBD);
                                        conexionBD.Open();

                                        qUrSJ.Fill(dtUrSJ);
                                        conexionBD.Close();

                                        if (dtUrSJ.Rows.Count > 0)
                                        {
                                            gvListadoNomina.DataSource = dtUrSJ;
                                            gvListadoNomina.DataBind();
                                            gvListadoNomina.Columns[0].Visible = false;
                                            btnExporta.Enabled = true;
                                        }
                                        else
                                        {
                                            DataTable dtNomCJ = new DataTable();
                                            SqlDataAdapter qNomCJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @jurisdiccionNLF ='" + ddlJuris.Text + "' ,@anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "'", conexionBD);
                                            conexionBD.Open();

                                            qNomCJ.Fill(dtNomCJ);
                                            conexionBD.Close();

                                            if (dtNomCJ.Rows.Count > 0)
                                            {
                                                gvListadoNomina.DataSource = dtNomCJ;
                                                gvListadoNomina.DataBind();
                                                gvListadoNomina.Columns[0].Visible = false;
                                                btnExporta.Enabled = true;
                                            }
                                            else
                                            {
                                                DataTable dtNomSJ = new DataTable();
                                                SqlDataAdapter qNomSJ = new SqlDataAdapter("exec pry1015_ListadoFirmas_ConsultaNominaGenerada @anioConsultaLF ='" + ddlAnio.Text + "',@qnaConsultaLF ='" + ddlQna.Text + "'", conexionBD);
                                                conexionBD.Open();

                                                qNomSJ.Fill(dtNomSJ);
                                                conexionBD.Close();

                                                if (dtNomSJ.Rows.Count > 0)
                                                {
                                                    gvListadoNomina.DataSource = dtNomSJ;
                                                    gvListadoNomina.DataBind();
                                                    gvListadoNomina.Columns[0].Visible = false;
                                                    btnExporta.Enabled = true;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        protected void btnLimpia_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

        public void ResetControl()
        {
            ddlQna.Items.Clear();
            ddlQna.Items.Add("Selecciona");
            ddlQna.Enabled = false;


            ddlNomina.Items.Clear();
            ddlNomina.Items.Add("Selecciona");
            ddlNomina.Enabled = false;

            ddlUr.Items.Clear();
            ddlUr.Items.Add("Selecciona");
            ddlUr.Enabled = false;

            ddlPrd.Items.Clear();
            ddlPrd.Items.Add("Selecciona");
            ddlPrd.Enabled = false;

            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");
            ddlAnio.Enabled = false;


            ddlInstru.Items.Clear();
            ddlInstru.Items.Add("Selecciona");
            ddlInstru.Enabled = false;

            gvListadoNomina.DataSource = null;
            gvListadoNomina.DataBind();

            dvMessageAnio.Visible = false;
            dvMessageJuris.Visible = false;
            dvMessageQna.Visible = false;

            lbAnio.Visible = false;
            lbJuris.Visible = false;
            lbQna.Visible = false;

            btnExporta.Enabled = false;


            ParametrosNomina();
        }


        protected void btnExporta_Click(object sender, EventArgs e)
        {
            string NombreArchivo = "Consulta de listados de nómina generados " + DateTime.Now + ".xls";

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo);
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1252");
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                gvListadoNomina.AllowPaging = false;
                this.BindGridView();

                gvListadoNomina.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvListadoNomina.HeaderRow.Cells)
                {
                    cell.BackColor = gvListadoNomina.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvListadoNomina.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvListadoNomina.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvListadoNomina.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvListadoNomina.RenderControl(hw);


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


    }
}




