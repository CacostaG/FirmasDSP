using Microsoft.Reporting.WebForms;
using System;
using System.IO;


namespace ListadoDeFirmasDSP._Reportes
{
    public partial class ReporteFirmasFEAC : System.Web.UI.Page
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
                    if (Session["TicketJurisdiccion"] == null)
                    {
                        Response.Redirect("~/404.aspx");
                    }
                    else
                    {
                        ReporteBase();

                    }
                }
            }
        }

        private void ReporteBase()
        {
            string JurisTicket = Convert.ToString(Session["TicketJurisdiccion"]);

            string AnioTicket = Convert.ToString(Session["TicketAnio"]);
            
            string QuincenaTicket = Convert.ToString(Session["TicketQuincena"]);
            

            
            string NominaTicket = Convert.ToString(Session["TicketNomina"]);
            string URTicket = Convert.ToString(Session["TicketUR"]);
            string PRDNAMETicket = Convert.ToString(Session["TicketPRDNAME"]);
            string instrumento = Convert.ToString(Session["TicketInstrumento"]);
          

            rvReporteListadoFEAC.ServerReport.ReportServerCredentials = new CredencialesReporteria("rss", "Passw0rd");
            rvReporteListadoFEAC.ServerReport.ReportServerUrl = new Uri("http://10.30.3.190/reportserver");
            rvReporteListadoFEAC.ServerReport.ReportPath = "/FIRMAS/ReporteListadoFEAC";
            rvReporteListadoFEAC.ShowParameterPrompts = true;


            var ColeccionDeParametrosTicket = new ReportParameterCollection();
            ReportParameterCollection ParametrosReporte = new ReportParameterCollection();

            ColeccionDeParametrosTicket.Add(new ReportParameter("Jurisdiccion", JurisTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("anio", AnioTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("qna", QuincenaTicket));

            ColeccionDeParametrosTicket.Add(new ReportParameter("nomina", NominaTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("ur", URTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("prdname", PRDNAMETicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("instrumento", instrumento));



            rvReporteListadoFEAC.ServerReport.SetParameters(ColeccionDeParametrosTicket);
            rvReporteListadoFEAC.ServerReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, extension;
            byte[] bytes = rvReporteListadoFEAC.ServerReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streamids, out warnings);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline; filename=ListadoFirmasFEAC_" + NominaTicket + "_" + URTicket + "_" + instrumento + "_" + PRDNAMETicket + ".pdf");
                Response.AddHeader("content-length", bytes.Length.ToString()); Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush(); Response.End();
            }
        }
    }
}