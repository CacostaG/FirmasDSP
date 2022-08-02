using Microsoft.Reporting.WebForms;
using System;
using System.IO;


namespace ListadoDeFirmasDSP._Reportes
{
    public partial class TicketdeImpresionMedidas : System.Web.UI.Page
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
                else { Response.Redirect("~/404.aspx"); }

            }

        }

        private void Reporte()
        {
            string TicketMLote = Convert.ToString(Session["MedidaLote"]);
            string TicketMJurisdiccion = Convert.ToString(Session["MedidaJurisdiccion"]);
            string TicketManio = Convert.ToString(Session["MedidaAnio"]);


            rvTicketdeImpresionMedidas.ServerReport.ReportServerCredentials = new CredencialesReporteria("rss", "Passw0rd");
            rvTicketdeImpresionMedidas.ServerReport.ReportServerUrl= new Uri("http://10.30.3.190/reportserver");
            rvTicketdeImpresionMedidas.ServerReport.ReportPath = "/FIRMAS/TiketListadoDeMedidas";
            rvTicketdeImpresionMedidas.ShowParameterPrompts = true;


            var ColeccionDeParametrosTicketM = new ReportParameterCollection();
            ReportParameterCollection ParametrosReporteM = new ReportParameterCollection();

            ColeccionDeParametrosTicketM.Add(new ReportParameter("anio", TicketManio));
            ColeccionDeParametrosTicketM.Add(new ReportParameter("lote", TicketMLote));
            ColeccionDeParametrosTicketM.Add(new ReportParameter("jurisdiccion_id",TicketMJurisdiccion ));
          

            rvTicketdeImpresionMedidas.ServerReport.SetParameters(ColeccionDeParametrosTicketM);
            rvTicketdeImpresionMedidas.ServerReport.Refresh();


            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, extension;
            byte[] bytes = rvTicketdeImpresionMedidas.ServerReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streamids, out warnings);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline; filename=ComprobanteDeListadoDeImpresión_" + TicketMJurisdiccion + "_" + TicketManio + "_" + TicketMLote +".pdf");
                Response.AddHeader("content-length", bytes.Length.ToString()); Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush(); Response.End();
            }





        }
    }
}