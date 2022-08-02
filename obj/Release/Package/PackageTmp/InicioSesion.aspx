<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="ListadoDeFirmasDSP.InicioSesion" %>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>

<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" />


<!DOCTYPE html>
  <link href="css/sweetalert.css" rel="stylesheet" />
<script src="Scripts/sweetalert.min.js"></script>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    

    <title></title>
</head>
  




<body>
    <%--LOGIN --%>    
    <form id="form1" runat="server">

        <div class="container">
            <div class="row">
                <div class="col">
                    <img alt="logoInicio" src="IMG/ConstSESVERVeracruzRGB2.png" class="img-fluid"/>
                </div>
            </div>
        </div>




        <div class="container">
            <div class="row justify-content-center">
                <div class="col-10">
                    <h4 align="center">Subdirección de Recursos Humanos</h4> 
                    <h4 align="center">Departamento de Sistematización de Pagos</h4>
                </div>


                <br />
                <br />

                <div id="dvMessage" runat="server" visible="false">
                    <strong>Error:  </strong>
                    <asp:Label ID="lblMensaje" runat="server" Text="Usuario y/o Contraseña Incorrecta." />
                </div>
                
                <div class="col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4 align="center">Inicio de Sesión</h4>
                        </div>
                        <div class="card-body">
                            <div class="row justify-content-center">
                                <div class="col-lg-6 col-md-6 col-sm-12 col-xs-12">

                                    <!--usuario-->
                                    <div class="form-group">
                                        <h4 align="center">
                                            <label>Usuario</label>

                                        </h4>
                                        <div class="input-group">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fa fa-user fa-fw" aria-hidden="true"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" placeholder="Ingrese Usuario" required=""/>
                                        </div>
                                        <div class="help-block with-errors text-danger"></div>
                                    </div>
                                    <!--usuario fin-->


                                    <!--password-->
                                    <div class="form-group">
                                        <h4 align="center">
                                            <label>Contraseña</label>

                                        </h4>
                                        <div class="input-group" >
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fa fa-unlock" aria-hidden="true"></i></span>
                                            </div>
                                            <asp:TextBox ID="Pass" runat="server"  CssClass="form-control" TextMode="Password" placeholder="Ingrese Contraseña" required="" />
                                        </div>
                                        <div class="help-block with-errors text-danger"></div>
                                    </div>
                                    <!--password fin-->

                                    <div class="row">

                                        <div class="col-md-12">

                                            <asp:Button ID="Button1" Text="Iniciar Sesion" runat="server" OnClick="ValidateUser" Class="btn btn-primary btn-lg btn-block" />

                                        </div>
                                    </div>

                                     
                                    </div>
                                    <div class="clear"></div>


                                </div>

                            </div>
                        </div>
                    </div>

                </div>
            </div>

   


        
     

    </form>






</body>
</html>
