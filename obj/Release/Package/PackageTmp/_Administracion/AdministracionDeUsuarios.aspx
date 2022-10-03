<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdministracionDeUsuarios.aspx.cs" Inherits="ListadoDeFirmasDSP._Administracion.AdministracionDeUsuarios" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/27c01da83f.js" crossorigin="anonymous"></script>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.15.4/css/all.css" integrity="sha384-DyZ88mC6Up2uqS4h/KRgHuoeGwBcD4Ng9SiP4dIRy0EXTlnuz47vAwmeGwVChigm" crossorigin="anonymous">


    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                Administración de usuarios
            </div>

            <div class="panel-body">
                <div class="row col-lg-12">
                    <asp:UpdatePanel ID="UpdatePanelAdministracionUsuarios" runat="server">
                        <ContentTemplate>
                            <form class="form-inline">
                                <!--Principal_Jurisdiccion-->
                                <div class="form-group col-xs-6 col-md-6 col-lg-6" id="ControlJuris" runat="server">
                                    <label class="control-label">Jurisdicción</label>
                                    <asp:DropDownList ID="ddlJuris" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control" DataTextField="claveJuris" align="center" UseSubmitBehavior="False" OnSelectedIndexChanged="ddlJuris_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <!-- Principal_permisos o rol-->
                                <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvUsuario" runat="server">
                                    <label class="control-label">Usuario</label>
                                    <asp:TextBox runat="server" ID="txtUser" class="form-control" value="" OnTextChanged="txtUser_TextChanged" TextMode="SingleLine" AutoPostBack="true"></asp:TextBox>
                                </div>


                                <!---Modulo de Agregar Usuario--->
                                <div id="dvCtrlAgregar" runat="server" visible=" false">

                                    <!-- ModuloAgregar_Jurisdiccion-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="Div1" runat="server">
                                        <label class="control-label">Jurisdicción</label>
                                        <asp:DropDownList ID="ddlCtrlAddJurisdiccion" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="claveJuris" DataValueField ="JurisdiccionID"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <!-- ModuloAgregar_permisos o rol-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="Div4" runat="server">
                                        <label class="control-label">Permisos</label>
                                        <asp:DropDownList ID="ddlCtrlAddRol" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="TipoUsuario" DataValueField ="idTipoUsuario"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                            
                                        </asp:DropDownList>
                                    </div>

                                  

                                    <!-- ModuloAgregar_RFC-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlAddRFC" runat="server">
                                        <label class="control-label">RFC</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddRFC" MaxLength="13" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                    <!-- ModuloAgregar_Curp-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlAddCurp" runat="server">
                                        <label class="control-label">CURP</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddCurp" MaxLength="18" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                     <!-- ModuloAgregar_ApPaterno-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlAddApPaterno" runat="server">
                                        <label class="control-label">Apellido paterno</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddApPaterno" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                      <!-- ModuloAgregar_ApMaterno-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlAddApMaterno" runat="server">
                                        <label class="control-label">Apellido materno</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddApMaterno" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                    <!-- ModuloAgregar_NombredelUsuario-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddNombre" runat="server">
                                        <label class="control-label">Nombre </label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddNombre" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                    <!-- ModuloAgregar_correo-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddEmail" runat="server">
                                        <label class="control-label">Correo electrónico</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddEmail" AutoCompleteType="Email"></asp:TextBox>
                                    </div>

                                      <!-- ModuloAgregar_Usuario-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddUsuario" runat="server">
                                        <label class="control-label">Usuario</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddUsuario"></asp:TextBox>
                                    </div>

                                        <!-- ModuloAgregar_Pass-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddPass" runat="server">
                                        <label class="control-label">Contraseña</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="CtrlAddPass"></asp:TextBox>
                                    </div>

                                          <!-- ModuloAgregar_PassSugerido-->
                                    <div class="form-group col-xs-6 col-md-6 col-lg-6" id="dvCtrlAddPassSugerido" runat="server" visible="false">
                                        <label class="control-label">Contraseña Suegerida</label>
                                        <asp:TextBox runat="server" class="form-control"  ID="CtrlAddPassGenerate"></asp:TextBox>
                                        
                                    </div>

                                </div>


                                <!---Modulo de Modificar Usuario--->
                                <div id="dvCtrlModificar" runat="server" visible=" false">

                                    <!-- ModuloModificar_Usuario-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="CtrlModificarUsuarioId" runat="server">
                                        <asp:Label ID="ctrlModificarIdUser" runat="server" Text="" Visible="false"></asp:Label>
                                        <label class="control-label">UsuarioID</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtIdUsuario" ></asp:TextBox>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="CtrlModificarUsuario" runat="server">
                                        <asp:Label ID="lblUsuario" runat="server" Text="" Visible="false"></asp:Label>
                                        <label class="control-label">Usuario</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarUsuario"></asp:TextBox>
                                    </div>

                                    <!-- ModuloModificar_Jurisdiccion-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarJuris" runat="server" visible="false">
                                        <label class="control-label">Jurisdicción</label>
                                        <asp:DropDownList ID="ddlCtrlModificarJuris" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="claveJuris" DataValueField ="JurisdiccionID"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>

                                    <!-- ModuloModificar_Permisos-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarRol" runat="server" visible="false">
                                        <label class="control-label">Permisos</label>
                                        <asp:DropDownList ID="ddlCtrlModificarRol" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="TipoUsuario" DataValueField="idTipoUsuario"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>

                                    <!-- ModuloModificar_RFC-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarRFC" runat="server" visible="false">
                                        <label class="control-label">RFC</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarRFC" Style="text-transform: uppercase" MaxLength="13"></asp:TextBox>
                                    </div>

                                    <!-- ModuloModificar_CURP-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarCURP" runat="server" visible="false">
                                        <label class="control-label">CURP</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarCURP" Style="text-transform: uppercase" MaxLength="18"></asp:TextBox>
                                    </div>

                                     <!-- ModuloModificar_ApPaterno-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarApPaterno" runat="server" visible="false">
                                        <label class="control-label">Apellido paterno</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarApPaterno" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                    <!-- ModuloModificar_ApPaterno-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarApMaterno" runat="server" visible="false">
                                        <label class="control-label">Apellido materno</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarApMaterno" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>


                                    <!-- ModuloModificar_nombre-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarNombre" runat="server" visible="false">
                                        <label class="control-label">Nombre del usuario</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarNombre" Style="text-transform: uppercase"></asp:TextBox>
                                    </div>

                                    <!-- ModuloModificar_correo-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarCorreo" runat="server" visible="false">
                                        <label class="control-label">Correo electrónico</label>
                                        <asp:TextBox runat="server" class="form-control" value="" ID="txtCtrlModificarCorreo"></asp:TextBox>
                                    </div>

                                    <!-- ModuloModificar_Estatus-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-6" id="dvCtrlModificarEstatus" runat="server" visible="false">
                                        <label class="control-label">Estatus</label>
                                        <asp:DropDownList ID="ddlCtrlModificarEstatus" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="Estatus"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>

                                    </div>
                                </div>


                                <!---Modulo de Consulta (Principal)--->
                                <div class="form-group col-xs-12 col-md-12 col-lg-12">

                                    <!--btn buscar usuario-->
                                    <asp:Button ID="btConsulta" runat="server" Text="Consultar" OnClick="btConsulta_Click" Visible="true" CssClass="btn btn-success" />

                                    <!--btn agregar usuario acceso directo-->
                                    <asp:Button ID="BtnAgregar" runat="server" OnClick="BtnAgregar_Click" Text="Nuevo usuario" Visible="true" CssClass="btn btn-primary" />

                                    <!--btn guarda usuario nuevo-->

                                    <asp:Button ID="btnCtrlAddAgregar" runat="server" OnClick="btnCtrlAddAgregar_Click" Text="Agregar" Visible="false" CssClass="btn btn-success" />

                                    <!--btn contraseña sugerida-->
                                    <asp:Button id="btnCtrolAddPassSugerido" runat="server" OnClick="btnCtrolAddPassSugerido_Click" Text="Contraseña sugerida" Visible="false" CssClass="btn btn-info"/>

                                    <!--btn actualiza-->
                                    <asp:Button ID="btnCtrlModificarGuardar" runat="server" Text="Actualizar" OnClick="btnCtrlModificarGuardar_Click" Visible="false" CssClass="btn btn-success" />


                                    <asp:Button ID="BtnLimpiar" runat="server" OnClick="BtnLimpiar_Click" Text="Limpiar" CssClass="btn btn-danger" Visible="false" />
                                    <asp:Button ID="BtnLimpiaBusqueda" runat="server" Text="Limpiar" CssClass="btn btn-danger" OnClick="BtnLimpiaBusqueda_Click" />
                                    <asp:Button ID="btnCancelaEdit" runat="server" Text="Cancelar" CssClass="btn btn-warning" OnClick="btnCancelaEdit_Click" Visible="false" />
                                    <asp:Button ID="btnInicio" runat="server" OnClick="btnInicio_Click" Text="Regresar" CssClass="btn btn-primary" Visible="false" />
                                    <br />
                                    <br />
                                    <br />

                                    <!--- Grid--->
                                    <div class="container-fluid">
                                        <div class="row">
                                            <div class="col-md-12 col-xs-12 col-lg-12">
                                                <div class="table-responsive">

                                                    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False"
                                                        CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                        Width="100%" Style="font-size: 13px">
                                                        <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                        <AlternatingRowStyle BackColor="#CCCCC1" />
                                                        <Columns>

                                                            <asp:TemplateField HeaderText="usuario_id" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="usuario_id" runat="server" Text='<%# Eval("idUsuario") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Jurisdicción" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnJurisdicion" runat="server" Text='<%# Eval("clavejuris") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="usuario" runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Permisos" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnPermiso" runat="server" Text='<%# Eval("TipoUsuario") %>'></asp:Label>
                                                                </ItemTemplate>

                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="RFC" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnRFC" runat="server" Text='<%# Eval("rfc") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="CURP" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnCURP" runat="server" Text='<%# Eval("curp") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Nombre" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnNombre" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Correo electronico" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnCorreo" runat="server" Text='<%# Eval("correoElectronico") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Estatus" ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnEstatus" runat="server" Text='<%# Eval("Estatus") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Fecha de creación " ItemStyle-HorizontalAlign="Center">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="columnFecha" runat="server" Text='<%# Eval("FechaRegistro") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                            </asp:TemplateField>


                                                            <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton runat="server" ID="eliminaUser" CssClass="btn btn-danger" OnClick="eliminaUser_Click"
                                                                        CommandArgument='<%# Eval("idUsuario") %>'>
                                                                     <span aria-hidden="true" class="fas fa-trash-alt" ></span>
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center" />
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Editar" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="editUser" runat="server" AutoPostBack="true" CssClass="btn btn-info" OnClick="editUser_Click"
                                                                        CommandArgument='<%# Eval("idUsuario") %>'>
                                                                        <i class="far fa-edit"></i> 
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>


                                                        </Columns>

                                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                        <SortedAscendingHeaderStyle BackColor="#808080" />
                                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                        <SortedDescendingHeaderStyle BackColor="#383838" />
                                                    </asp:GridView>





                                                </div>
                                                <br />
                                                <br />
                                                <div id="dvMsgFinal" runat="server" visible="false" class="alert alert-success">
                                                    <strong>Correcto: </strong>
                                                    <asp:Label ID="MsgOkInsert" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>

                                        </div>

                                    </div>

                                </div>

                            </form>

                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>


    <asp:UpdateProgress ID="upAdministracionUsuarios" runat="server" AssociatedUpdatePanelID="UpdatePanelAdministracionUsuarios">
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
