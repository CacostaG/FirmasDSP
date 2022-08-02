<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="ListadoDeFirmasDSP._404" %>

<link href="//netdna.bootstrapcdn.com/bootstrap/3.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//netdna.bootstrapcdn.com/bootstrap/3.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
</head>
<body>
     <form id="form404" runat="server" align="center" width="100%">

         <div class="container"  width="100%  >
            <div class="row">
                <div class="col" >
                    <img alt="logoInicio" src="IMG/ConstSESVERVeracruzRGB2.png" class="img-fluid"  width="100% />
                </div>
            </div>
        </div>



    <div class="container">
    <div class="row ">
        <div class="col-md-12">
            <div class="error-template">
                <h1>Oops!</h1>
                <h2>404 Pagina no Encontrada</h2>

                <div class="error-details">
                    Lo sentimos, se ha producido un error. ¡No se encontró la página solicitada!!
                </div>
                <br /><br />
                <div class="error-actions">
                    <a href="Default.aspx" class="btn btn-primary btn-lg"><span class="glyphicon glyphicon-home"></span> Pagina Inicio </a>&nbsp;&nbsp;
                    <a href="Contact.aspx" class="btn btn-default btn-lg"><span class="glyphicon glyphicon-envelope"></span> Soporte </a>
                </div>
            </div>
        </div>

    </div>
</div>
          </form>
</body>
</html>

