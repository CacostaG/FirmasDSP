using Microsoft.Reporting.WebForms;
using System;
using System.IO;
using System.Web;

namespace ListadoDeFirmasDSP._Reportes
{
    public partial class ReporteFirmasBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserData.token == 0)
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
            string TipoTicket = Convert.ToString(Session["TicketClaveTipo"]);
            string NominaTicket = Convert.ToString(Session["TicketNomina"]);
            string URTicket = Convert.ToString(Session["TicketUR"]);
            string PRDNAMETicket = Convert.ToString(Session["TicketPRDNAME"]);
            string instrumento = Convert.ToString(Session["TicketInstrumento"]);
            string ListaTicket = Convert.ToString(Session["TicketListado"]);
            string claveJurisTicket = Convert.ToString(Session["TicketClave"]);

            rvReporteListadoBase.ServerReport.ReportServerCredentials = new CredencialesReporteria("Carlos Alberto AG", "Aogc1370");
            rvReporteListadoBase.ServerReport.ReportServerUrl = new Uri("http://10.30.17.78/ReportServer");
            rvReporteListadoBase.ServerReport.ReportPath = "/FIRMAS/ReporteListadoFirmasBase";
            rvReporteListadoBase.ShowParameterPrompts = true;


            var ColeccionDeParametrosTicket = new ReportParameterCollection();
            ReportParameterCollection ParametrosReporte = new ReportParameterCollection();

            ColeccionDeParametrosTicket.Add(new ReportParameter("Jurisdiccion", JurisTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("anio", AnioTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("qna", QuincenaTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("tipo", TipoTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("nomina", NominaTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("ur", URTicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("prdname", PRDNAMETicket));
            ColeccionDeParametrosTicket.Add(new ReportParameter("instrumento", instrumento));



            rvReporteListadoBase.ServerReport.SetParameters(ColeccionDeParametrosTicket);
            rvReporteListadoBase.ServerReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType, encoding, extension;
            byte[] bytes = rvReporteListadoBase.ServerReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streamids, out warnings);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "inline; filename=\"" + "ListadoFirmasBase_" + claveJurisTicket + "_" + QuincenaTicket + "_" + NominaTicket + "_" + URTicket + "_" + instrumento + "_" + PRDNAMETicket + ".pdf" + "\"");
                /*    
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=\"" + "ListadoFirmasBase" + JurisTicket + "_" + QuincenaTicket + "_" + NominaTicket + "_" + URTicket + "_" + instrumento + "_" + PRDNAMETicket + ".pdf" + "\"");
                */
                Response.AddHeader("content-length", bytes.Length.ToString()); Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush(); Response.End();
            }
        }
    }
}