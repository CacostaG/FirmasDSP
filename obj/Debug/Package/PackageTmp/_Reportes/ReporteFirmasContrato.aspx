<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteFirmasContrato.aspx.cs" Inherits="ListadoDeFirmasDSP._Reportes.ReporteFirmasContrato" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de Firmas Contratos</title>
</head>
<body>
    <script src="../Scripts/sweetalert2.all.js"></script>
    <link rel="stylesheet" href="sweetalert2.min.css"/>

    <form id="ListadoFirmasContratos" runat="server">

         <div class="container-fluid">
          <asp:ScriptManager ID="smReporteListadoContratos" runat="server"></asp:ScriptManager>
             <rsweb:ReportViewer ID="rvReporteListadoContratos" runat="server"></rsweb:ReportViewer>
      
            </div>
    </form>
</body>
</html>