using System;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace ListadoDeFirmasDSP._Reportes
{
    public partial class ReporteFirmasMedidas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["token"] == null)
            {
                Response.Redirect("~/InicioSesion.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    
                        Reporte();
                    
                }
                else
                {
                    Response.Redirect("~/404.aspx");
                }
            }

        }

        private void Reporte()
        {
            string Lote = Convert.ToString(Session["MedidaLote"]);
                    string Anio = Convert.ToString(Session["MedidaAnio"]);

            rvImpresionMedidas.ServerReport.ReportServerCredentials = new CredencialesReporteria("rss", "Passw0rd");
            rvImpresionMedidas.ServerReport.ReportServerUrl = new Uri("http://10.30.3.190/reportserver");
            rvImpresionMedidas.ServerReport.ReportPath = "/FIRMAS/MedidasFinAnio";
            rvImpresionMedidas.ShowParameterPrompts = true;

            var ColeccionDeParametrosMedidasFinAnio = new ReportParameterCollection();
            ReportParameterCollection ParametrosReporteMedidasFinAnio = new ReportParameterCollection();

            ColeccionDeParametrosMedidasFinAnio.Add(new ReportParameter("lote", Lote));
            ColeccionDeParametrosMedidasFinAnio.Add(new ReportParameter("anio", Anio));

            rvImpresionMedidas.ServerReport.SetParameters(ColeccionDeParametrosMedidasFinAnio);
            rvImpresionMedidas.ServerReport.Refresh();
            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, extension;
            byte[] bytes = rvImpresionMedidas.ServerReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streamids, out warnings);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline; filename=MedidasFinAño_"  + "_" + Anio + "_" + Lote + ".pdf");
                Response.AddHeader("content-length", bytes.Length.ToString()); Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush(); Response.End();
            }
        }
    }
}