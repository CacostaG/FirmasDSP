<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReporteListadoCheques.aspx.cs" Inherits="ListadoDeFirmasDSP._Reportes.ReporteListadoCheques" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Listado de cheques</title>
</head>
<body>
    <script src="../Scripts/sweetalert2.all.js"></script>
    <link rel="stylesheet" href="sweetalert2.min.css"/>

    <form id="listadoCheques" runat="server">
        <div>


            <asp:ScriptManager ID="smListadoCheques" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="rvListadoCheques" runat="server"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
