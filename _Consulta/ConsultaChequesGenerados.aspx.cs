﻿using System.Data;
using System.Data.SqlClient;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Configuration;


namespace ListadoDeFirmasDSP._Consulta
{
    public partial class ConsultaChequesGenerados : System.Web.UI.Page
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
                    switch (rol)
                    {
                        case "Operador del sistema":
                            Response.Redirect("~/Default");
                            
                            break;
                        case "Validador":
                            gvListadoCheques.Columns[16].Visible = false;
                            break;
                    }

                    ParametrosCheques();
                }
            }*/

        }

        private void ParametrosCheques()
        {

            ddlAnio.Items.Clear();
            ddlAnio.Items.Add("Selecciona");
            SqlCommand cmd = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPAnio ", conexionBD);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            ddlAnio.DataSource = dt;
            ddlAnio.DataBind();


           
        }

        protected void ddlAnio_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(ddlAnio.SelectedItem.Text =="Selecciona")
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

                ddlJuris.Enabled = false;
                ddlJuris.Items.Clear();
                ddlJuris.Items.Add("Selecciona");
                

            }
            else
            {

               
                dvMessageAnio.Visible = false;
                lblAnioError.Visible = true;

                dvMessageJuris.Visible = false;
                lblJuris.Visible = false;

                dvMessageQna.Visible = false;
                lblQnaEror.Visible = false;


                ddlNomina.Enabled = false;
                ddlNomina.Items.Clear();
                ddlNomina.Items.Add("Selecciona");



                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");


                ddlQna.Enabled = false;
                ddlQna.Items.Clear();
                ddlQna.Items.Add("Selecciona");


                ddlJuris.Enabled = true;
                ddlJuris.Items.Clear();
                ddlJuris.Items.Add("Selecciona");
                ddlJuris.Items.Add("TODAS");

                SqlCommand cmdJuris = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPClaveJuris ", conexionBD);
                SqlDataAdapter sdaJuris = new SqlDataAdapter(cmdJuris);
                DataTable dtJuris = new DataTable();
                sdaJuris.Fill(dtJuris);
                ddlJuris.DataSource = dtJuris;
                ddlJuris.DataBind();

              
            }
        }


        protected void ddlJuris_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlJuris.SelectedItem.Text == "Selecciona")
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
            else
            {

                if (ddlJuris.SelectedItem.Text == "TODAS")
                {
                    dvMessageAnio.Visible = false;
                    lblAnioError.Visible = false;

                    dvMessageJuris.Visible = false;
                    lblJuris.Visible = false;

                    dvMessageQna.Visible = false;
                    lblQnaEror.Visible = false;

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

                    SqlCommand sqlQna = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPQna @anio='" + ddlAnio.Text +   "'", conexionBD);
                    SqlDataAdapter sdaQna = new SqlDataAdapter(sqlQna);
                    DataTable dtQna = new DataTable();
                    sdaQna.Fill(dtQna);

                    ddlQna.DataSource = dtQna;
                    ddlQna.DataBind();
                }
                else
                {
                    dvMessageAnio.Visible = false;
                    lblAnioError.Visible = true;

                    dvMessageJuris.Visible = false;
                    lblJuris.Visible = false;

                    dvMessageQna.Visible = false;
                    lblQnaEror.Visible = false;

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



                    SqlCommand sqlQna = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPQna @anio='" + ddlAnio.Text + "', @claveJuris ='" + ddlJuris.Text + "'", conexionBD);
                    SqlDataAdapter sdaQna = new SqlDataAdapter(sqlQna);
                    DataTable dtQna = new DataTable();
                    sdaQna.Fill(dtQna);

                    ddlQna.DataSource = dtQna;
                    ddlQna.DataBind();
                }



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

              

            }
            else
            {
                if(ddlJuris.SelectedItem.Text =="TODAS")
                {
                    dvMessageAnio.Visible = false;
                    lblAnioError.Visible = true;

                    dvMessageJuris.Visible = false;
                    lblJuris.Visible = false;

                    dvMessageQna.Visible = false;
                    lblQnaEror.Visible = false;

                    ddlNomina.Enabled = true;
                    ddlNomina.Items.Clear();
                    ddlNomina.Items.Add("TODAS");

                    ddlUr.Enabled = false;
                    ddlUr.Items.Clear();
                    ddlUr.Items.Add("Selecciona");

                    ddlPrd.Enabled = false;
                    ddlPrd.Items.Clear();
                    ddlPrd.Items.Add("Selecciona");

                    SqlCommand sqlNomina = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPNom @anio ='" + ddlAnio.Text + "',@qna=' " + ddlQna.Text +  "' ", conexionBD);
                    SqlDataAdapter sdaNomina = new SqlDataAdapter(sqlNomina);
                    DataTable dtNomina = new DataTable();
                    sdaNomina.Fill(dtNomina);

                    ddlNomina.DataSource = dtNomina;
                    ddlNomina.DataBind();
                }
                else
                {
                    dvMessageAnio.Visible = false;
                    lblAnioError.Visible = true;

                    dvMessageJuris.Visible = false;
                    lblJuris.Visible = false;

                    dvMessageQna.Visible = false;
                    lblQnaEror.Visible = false;

                    ddlNomina.Enabled = true;
                    ddlNomina.Items.Clear();
                    ddlNomina.Items.Add("TODAS");

                    ddlUr.Enabled = false;
                    ddlUr.Items.Clear();
                    ddlUr.Items.Add("Selecciona");

                    ddlPrd.Enabled = false;
                    ddlPrd.Items.Clear();
                    ddlPrd.Items.Add("Selecciona");

                    SqlCommand sqlNomina = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPNom @anio ='" + ddlAnio.Text + "',@qna=' " + ddlQna.Text + "',@claveJuris='" + ddlJuris.Text + "' ", conexionBD);
                    SqlDataAdapter sdaNomina = new SqlDataAdapter(sqlNomina);
                    DataTable dtNomina = new DataTable();
                    sdaNomina.Fill(dtNomina);

                    ddlNomina.DataSource = dtNomina;
                    ddlNomina.DataBind();

                }

            }

          


        }

        protected void ddlNomina_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(ddlNomina.SelectedItem.Text =="TODAS")
            {
                ddlUr.Enabled = false;
                ddlUr.Items.Clear();
                ddlUr.Items.Add("Selecciona");

                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("Selecciona");


             
            }
            else
            {
                if(ddlJuris.SelectedItem.Text == "TODAS")
                {
                    ddlUr.Enabled = true;
                    ddlUr.Items.Clear();
                    ddlUr.Items.Add("TODAS");

                    ddlPrd.Enabled = false;
                    ddlPrd.Items.Clear();
                    ddlPrd.Items.Add("Selecciona");


                    SqlCommand sqlUr = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPUR @anio ='" + ddlAnio.Text + "', @qna ='" + ddlQna.Text + "',@nomina ='" + ddlNomina.Text + "'", conexionBD);
                    SqlDataAdapter sdaUr = new SqlDataAdapter(sqlUr);
                    DataTable dtUr = new DataTable();
                    sdaUr.Fill(dtUr);

                    ddlUr.DataSource = dtUr;
                    ddlUr.DataBind();
                }
                else
                {
                    ddlUr.Enabled = true;
                    ddlUr.Items.Clear();
                    ddlUr.Items.Add("TODAS");

                    ddlPrd.Enabled = false;
                    ddlPrd.Items.Clear();
                    ddlPrd.Items.Add("Selecciona");


                    SqlCommand sqlUr = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPUR @anio ='" + ddlAnio.Text + "', @qna ='" + ddlQna.Text + "',@claveJuris ='" + ddlJuris.Text + "',@nomina ='" + ddlNomina.Text + "'", conexionBD);
                    SqlDataAdapter sdaUr = new SqlDataAdapter(sqlUr);
                    DataTable dtUr = new DataTable();
                    sdaUr.Fill(dtUr);

                    ddlUr.DataSource = dtUr;
                    ddlUr.DataBind();
                }
                

            }

            


        }

        protected void ddlUr_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlUr.SelectedItem.Text == "TODAS")
            {
                ddlPrd.Enabled = false;
                ddlPrd.Items.Clear();
                ddlPrd.Items.Add("TODOS");
                
            }
            else
            {
                if(ddlJuris.SelectedItem.Text == "TODAS")
                {
                    ddlPrd.Enabled = true;
                    ddlPrd.Items.Clear();
                    ddlPrd.Items.Add("TODOS");

                    SqlCommand slqPrd = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPPrd @anio ='" + ddlAnio.Text + "', @qna ='" + ddlQna.Text + "', @nomina ='" + ddlNomina.Text +"', @ur='" + ddlUr.Text + "'", conexionBD);
                    SqlDataAdapter sdaPrd = new SqlDataAdapter(slqPrd);
                    DataTable dtPrd = new DataTable();
                    sdaPrd.Fill(dtPrd);

                    ddlPrd.DataSource = dtPrd;
                    ddlPrd.DataBind();
                }
                else
                {
                    ddlPrd.Enabled = true;
                    ddlPrd.Items.Clear();
                    ddlPrd.Items.Add("TODOS");

                    SqlCommand slqPrd = new SqlCommand("Pry1015_ListadoFirmasChequesGeneradosDetalle_SPPrd @anio ='" + ddlAnio.Text + "', @qna ='" + ddlQna.Text + "', @nomina ='" + ddlNomina.Text + "' ,@claveJuris ='" + ddlJuris.Text + "', @ur='" + ddlUr.Text + "'", conexionBD);
                    SqlDataAdapter sdaPrd = new SqlDataAdapter(slqPrd);
                    DataTable dtPrd = new DataTable();
                    sdaPrd.Fill(dtPrd);

                    ddlPrd.DataSource = dtPrd;
                    ddlPrd.DataBind();
                }
               

            }





        }

     

        /*funcion para estado inicial de dropdownlist*/
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

            ddlJuris.Items.Clear();
            ddlJuris.Items.Add("Selecciona");
            ddlJuris.Enabled = false;

            gvListadoCheques.DataSource = null;
            gvListadoCheques.DataBind();


            dvMessageAnio.Visible = false;
            lblAnioError.Visible = true;

            dvMessageJuris.Visible = false;
            lblJuris.Visible = false;

            dvMessageQna.Visible = false;
            lblQnaEror.Visible = false;

            btnExporta.Enabled = false; 





            ParametrosCheques();
        }

        protected void btnBusca_Click(object sender, EventArgs e)
        {
            if ("Selecciona".Equals(ddlAnio.Text))
            {
                dvMessageAnio.Visible = true;
                lblAnioError.Visible = true;

            }
            else
            {
                if ("Selecciona".Equals(ddlJuris.Text))
                {
                    dvMessageJuris.Visible = true;
                    lblJuris.Visible = true;
                }

                else
                {
                   
                    if ("Selecciona".Equals(ddlQna.Text))
                    {
                        dvMessageQna.Visible = true;
                        lblQnaEror.Visible = true;
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
            DataTable dtPrdname = new DataTable();
            SqlDataAdapter queryPrdname = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text + "', @claveJurisConsultaLC='"+ddlJuris.Text+"',  @qnaConsultaLC ='" + ddlQna.Text + "' , @nominaConsultaLC ='" + ddlNomina.Text + "' , @urConsultaLC ='" + ddlUr.Text + "',@prdnameConsultaLC ='" + ddlPrd.Text + "'", conexionBD);
            conexionBD.Open();

            queryPrdname.Fill(dtPrdname);
            conexionBD.Close();

            if (dtPrdname.Rows.Count > 0)
            {
                btnExporta.Enabled = true;
                gvListadoCheques.DataSource = dtPrdname;
                gvListadoCheques.DataBind();
                gvListadoCheques.Columns[0].Visible = false;
               
             
            }
            else
            {
                DataTable dtPrdnameSJ = new DataTable();
                SqlDataAdapter queryPrdnameSJ = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text + "',  @qnaConsultaLC ='" + ddlQna.Text + "' , @nominaConsultaLC ='" + ddlNomina.Text + "' , @urConsultaLC ='" + ddlUr.Text + "',@prdnameConsultaLC ='" + ddlPrd.Text + "'", conexionBD);
                conexionBD.Open();

                queryPrdnameSJ.Fill(dtPrdnameSJ);
                conexionBD.Close();

                if(dtPrdnameSJ.Rows.Count > 0)
                {
                    btnExporta.Enabled = true;
                    gvListadoCheques.DataSource = dtPrdnameSJ;
                    gvListadoCheques.DataBind();
                    gvListadoCheques.Columns[0].Visible = false;
                }
                else
                {
                    DataTable dtUnidadR = new DataTable();
                    SqlDataAdapter queryUnidadR = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text + "', @claveJurisConsultaLC='" + ddlJuris.Text + "',  @qnaConsultaLC ='" + ddlQna.Text + "' , @nominaConsultaLC ='" + ddlNomina.Text + "' , @urConsultaLC ='" + ddlUr.Text + "'", conexionBD);
                    conexionBD.Open();

                    queryUnidadR.Fill(dtUnidadR);
                    conexionBD.Close();

                    if (dtUnidadR.Rows.Count > 0)
                    {
                        btnExporta.Enabled = true;
                        gvListadoCheques.DataSource = dtUnidadR;
                        gvListadoCheques.DataBind();
                        gvListadoCheques.Columns[0].Visible = false;


                    }
                    else
                    {
                        DataTable dtUnidadRSJ = new DataTable();
                        SqlDataAdapter queryUnidadRSJ = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text + "',  @qnaConsultaLC ='" + ddlQna.Text + "' , @nominaConsultaLC ='" + ddlNomina.Text + "' , @urConsultaLC ='" + ddlUr.Text + "'", conexionBD);
                        conexionBD.Open();

                        queryUnidadRSJ.Fill(dtUnidadRSJ);
                        conexionBD.Close();

                        if(dtUnidadRSJ.Rows.Count > 0)
                        {
                            btnExporta.Enabled = true;
                            gvListadoCheques.DataSource = dtUnidadRSJ;
                            gvListadoCheques.DataBind();
                            gvListadoCheques.Columns[0].Visible = false;

                        }
                        else
                        {
                            DataTable dtNomi = new DataTable();
                            SqlDataAdapter queryNomi = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text + "',@claveJurisConsultaLC='" + ddlJuris.Text + "',  @qnaConsultaLC ='" + ddlQna.Text + "' , @nominaConsultaLC ='" + ddlNomina.Text + "'", conexionBD);
                            conexionBD.Open();

                            queryNomi.Fill(dtNomi);
                            conexionBD.Close();

                            if (dtNomi.Rows.Count > 0)
                            {
                                btnExporta.Enabled = true;
                                gvListadoCheques.DataSource = dtNomi;
                                gvListadoCheques.DataBind();
                                gvListadoCheques.Columns[0].Visible = false;


                            }
                            else
                            {
                                DataTable dtNomiSJ = new DataTable();
                                SqlDataAdapter queryNomiSJ = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text +  "',  @qnaConsultaLC ='" + ddlQna.Text + "' , @nominaConsultaLC ='" + ddlNomina.Text + "'", conexionBD);
                                conexionBD.Open();

                                queryNomiSJ.Fill(dtNomiSJ);
                                conexionBD.Close();
                                
                                if(dtNomiSJ.Rows.Count > 0 )
                                {
                                    btnExporta.Enabled = true;
                                    gvListadoCheques.DataSource = dtNomiSJ;
                                    gvListadoCheques.DataBind();
                                    gvListadoCheques.Columns[0].Visible = false;
                                }
                                else
                                {
                                    DataTable dtQn = new DataTable();
                                    SqlDataAdapter queryQn = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text + "', @claveJurisConsultaLC='" + ddlJuris.Text + "',  @qnaConsultaLC ='" + ddlQna.Text + "'", conexionBD);
                                    conexionBD.Open();

                                    queryQn.Fill(dtQn);
                                    conexionBD.Close();

                                    if (dtQn.Rows.Count > 0)
                                    {
                                        gvListadoCheques.DataSource = dtQn;
                                        gvListadoCheques.DataBind();
                                        gvListadoCheques.Columns[0].Visible = false;
                                        btnExporta.Enabled = true;

                                    }
                                    else
                                    {
                                        DataTable dtQnSJ = new DataTable();
                                        SqlDataAdapter queryQnSJ = new SqlDataAdapter("exec Pry1015_ListadoFirmas_ConsultaListadoCheques  @anioConsultaLC='" + ddlAnio.Text +  "',  @qnaConsultaLC ='" + ddlQna.Text + "'", conexionBD);
                                        conexionBD.Open();

                                        queryQnSJ.Fill(dtQnSJ);
                                        conexionBD.Close();
                                        
                                        if(dtQnSJ.Rows.Count > 0)
                                        {
                                            gvListadoCheques.DataSource = dtQnSJ;
                                            gvListadoCheques.DataBind();
                                            gvListadoCheques.Columns[0].Visible = false;
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


        

        protected void btnLimpia_Click(object sender, EventArgs e)
        {
            ResetControl();
        }

       

       
        protected void lbElimina_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conexionBD = new SqlConnection(ConfigurationManager.ConnectionStrings["GalateaKey"].ToString());

                foreach (GridViewRow gvElimina in gvListadoCheques.Rows)
                {
                 
                        

                        SqlCommand deleteRecord = new SqlCommand("Pry1015_ListadoFirmas_DeleteConsultaCheques", conexionBD);
                        deleteRecord.CommandType = CommandType.StoredProcedure;
                        deleteRecord.Parameters.Clear();

                        deleteRecord.Parameters.AddWithValue("@Producto_nomina_id_DeleteConsultaCheques", (gvElimina.FindControl("Producto_nomina_id") as Label).Text);

                        conexionBD.Open();
                        deleteRecord.ExecuteNonQuery();

                        conexionBD.Close();

                        /* ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Correcto.!', 'La operación se ha realizado con éxito.', 'success');", true);*/
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal({" +
                            " title: '¿Desea continuar con el proceso?'," +
                            " text: 'Esta a punto de eliminar el cheque seleccionado!'," +
                            " type: 'warning'," +
                            " showCancelButton: true," +
                            " confirmButtonClass: 'btn-danger'," +
                            " confirmButtonText: 'Si, eliminar cheque!'," +
                            " cancelButtonText: 'No, cancelar el proceso!'," +
                            " closeOnConfirm: false," +
                            " closeOnCancel: false," +
                            "}," +
                            "function(isConfirm) { " +
                            " if (isConfirm) { " +
                            "swal('Eliminado!'," +
                            " 'El registro se ha eliminado con éxito.','success');" +
                            " }else {" +
                            " swal('Cancelado', 'El registro no se ha modificado'," +
                            " 'error'); }}); ", true);
                        gvListadoCheques.Visible = false;
                        ParametrosCheques();
                        ResetControl();
                   

                }

            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "swal('Atención.!','" + ex.Message + "', 'warning');", true);
            }
        }

      



        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

    
        protected void btnExporta_Click(object sender, EventArgs e)
        {

            
       
            string NombreArchivo = "Consulta de listados de cheques generados " + DateTime.Now + ".xls";

            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("Content-Disposition", "attachment;filename=" + NombreArchivo);
            Response.Charset = "utf-8";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1252");
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);


                gvListadoCheques.AllowPaging = false;
                this.BindGridView();

                gvListadoCheques.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gvListadoCheques.HeaderRow.Cells)
                {
                    cell.BackColor = gvListadoCheques.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gvListadoCheques.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvListadoCheques.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvListadoCheques.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gvListadoCheques.RenderControl(hw);


                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
           


        }

       
    }
}


