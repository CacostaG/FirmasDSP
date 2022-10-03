<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CambioPassword.aspx.cs" Inherits="ListadoDeFirmasDSP.CambioPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/27c01da83f.js" crossorigin="anonymous"></script>
    
     <asp:Label ID="User" runat="server" Text='<%#Session["idUsuario"]%>' Visible="false"></asp:Label>


      <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
               Cambio de contraseña
            </div>

            <div class="panel-body">
                <div class="row col-lg-12">
                    <asp:UpdatePanel ID="UpdatePanelCambioPass" runat="server">
                        <ContentTemplate>
                            <form class="form-inline">
                               
                                <!---Modulo de Agregar Usuario--->
                                <div id="dvCtrlUpdatePass" runat="server" visible=" true" class="form-group col-xs-12 col-md-6 col-lg-12" >
   
                                        <!-- ModuloCambiar_Pass-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddPass" runat="server">
                                        <label class="control-label">Nueva contraseña</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddPass"></asp:TextBox>
                                    </div>

                                          <!-- ModuloAgregar_PassSugerido-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddPassSugerido" runat="server">
                                        <label class="control-label">Contraseña Suegerida</label>
                                        <asp:TextBox runat="server" class="form-control" ID="CtrlAddPassGenerate" Visible="false"></asp:TextBox>
                                    </div>
                                  

                                </div>




                                <div id="dvCtrlCamposConfirma" class="form-group col-xs-12 col-md-6 col-lg-12" >
                                    <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                                        Por seguridad para un cambio exitoso deberas ingresar los siguentes datos
                                    </div>
                                      <!-- ModuloConfirma_RFC-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlAddRFC" runat="server">
                                        <label class="control-label">RFC</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddRFC" MaxLength="13" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                    <!-- ModuloConfirma_correo-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddEmail" runat="server">
                                        <label class="control-label">Correo electrónico</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddEmail" AutoCompleteType="Email"></asp:TextBox>
                                    </div>

                                      <!-- ModuloConfirma_Usuario-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddUsuario" runat="server">
                                        <label class="control-label">Usuario</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddUsuario"></asp:TextBox>
                                    </div>

                                    
                                </div>

                               

                                <!---Modulo de Consulta (Principal)--->
                                <div class="form-group col-xs-12 col-md-12 col-lg-12">

                                    <!--btn actualiza-->
                                    <asp:Button ID="btnCtrlModificarGuardar" runat="server" Text="Actualizar" Visible="true" CssClass="btn btn-success" OnClick="btnCtrlModificarGuardar_Click" />

                                    <asp:Button ID="BtnLimpiar" runat="server" Text="Limpiar" CssClass="btn btn-danger" Visible="true" OnClick="BtnLimpiar_Click"/>
                                    <asp:Button ID="btnCancelaEdit" runat="server" Text="Cancelar" CssClass="btn btn-warning" Visible="true" OnClick="btnCancelaEdit_Click" />


                                    <!--btn contraseña sugerida-->
                                    <asp:Button ID="btnCtrolAddPassSugerido" runat="server" Text="Contraseña sugerida" Visible="true" CssClass="btn btn-info" OnClick="btnCtrolAddPassSugerido_Click" />
                                    <br />
                                    <br />
                                    <br />
                                </div>

                            </form>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>


    <asp:UpdateProgress ID="upAdministracionUsuarios" runat="server" AssociatedUpdatePanelID="UpdatePanelCambioPass">
        <ProgressTemplate>
            <div id="overlay" style="font-family: 'Yu Gothic UI Semilight'; font-weight: normal; font-style: normal">
                <div id="modalprogress">
                    <div id="theprogress">
                        <img alt="indicator" src="../IMG/cargando.gif" />
                    </div>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
