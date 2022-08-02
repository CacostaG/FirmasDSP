<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketdeImpresionMedidas.aspx.cs" Inherits="ListadoDeFirmasDSP._Reportes.TicketdeImpresionMedidas" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Ticket de Impresión</title>
</head>
<body>
        <script src="../Scripts/sweetalert2.all.js"></script>
    <link rel="stylesheet" href="sweetalert2.min.css"/>

    <form id="TicketdeImpresionMedidas" runat="server">
       
         <div class="container-fluid">
                 <asp:ScriptManager ID="smTicketdeImpresionMedidas" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvTicketdeImpresionMedidas" runat="server"> </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
