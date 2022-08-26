using System;
using System.Web.UI;
using Microsoft.Reporting.WebForms;
using System.IO;

namespace ListadoDeFirmasDSP._Reportes
{
    public partial class ReporteListadoCheques : System.Web.UI.Page
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
                        ReporteListado();
                        
                    }
                }
            }
        }

        private void ReporteListado()
        {
           
                string JurisTicket = Convert.ToString(Session["TicketJurisdiccion"]);
                string AnioTicket = Convert.ToString(Session["TicketAnio"]);
                string QuincenaTicket = Convert.ToString(Session["TicketQuincena"]);
                string NominaTicket = Convert.ToString(Session["TicketNomina"]);
                string URTicket = Convert.ToString(Session["TicketUR"]);
                string PRDNAMETicket = Convert.ToString(Session["TicketPRDNAME"]);


                rvListadoCheques.ServerReport.ReportServerCredentials = new CredencialesReporteria("Carlos Alberto AG", "Aogc1370");
                rvListadoCheques.ServerReport.ReportServerUrl = new Uri("http://10.30.17.78/ReportServer");
                rvListadoCheques.ServerReport.ReportPath = "/FIRMAS/ReporteListadoCheques";
                rvListadoCheques.ShowParameterPrompts = true;


                var ColeccionDeParametrosTicket = new ReportParameterCollection();
                ReportParameterCollection ParametrosReporte = new ReportParameterCollection();

                ColeccionDeParametrosTicket.Add(new ReportParameter("Jurisdiccion", JurisTicket));
                ColeccionDeParametrosTicket.Add(new ReportParameter("anio", AnioTicket));
                ColeccionDeParametrosTicket.Add(new ReportParameter("qna", QuincenaTicket));
                ColeccionDeParametrosTicket.Add(new ReportParameter("nomina", NominaTicket));
                ColeccionDeParametrosTicket.Add(new ReportParameter("ur", URTicket));
                ColeccionDeParametrosTicket.Add(new ReportParameter("prdname", PRDNAMETicket));




                rvListadoCheques.ServerReport.SetParameters(ColeccionDeParametrosTicket);
                rvListadoCheques.ServerReport.Refresh();

                Warning[] warnings;
                string[] streamids;
                string mimeType, encoding, extension;
                byte[] bytes = rvListadoCheques.ServerReport.Render("PDF", string.Empty, out mimeType, out encoding, out extension, out streamids, out warnings);

                using (MemoryStream memoryStream = new MemoryStream(bytes))
                {
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "inline; filename=ListadoCheques" + NominaTicket + "_" + URTicket + "_" + PRDNAMETicket + ".pdf");
                    Response.AddHeader("content-length", bytes.Length.ToString()); Response.BinaryWrite(memoryStream.ToArray());
                    Response.Flush(); Response.End();
                }
            
          

            
        }

    }

}
