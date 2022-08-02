<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaChequesGenerados.aspx.cs" Inherits="ListadoDeFirmasDSP._Consulta.ConsultaChequesGenerados" EnableEventValidation="false" ClientIDMode="AutoID" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/27c01da83f.js" crossorigin="anonymous"></script>

    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                Consulta de listados de cheques generados
            </div>

            <div class="panel-body">
                <div class="row col-lg-12">
                    <asp:UpdatePanel ID="updatePanelConsultaCheques" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <!--Inicia dropdown-->

                            <form class="form-inline">
                               
                                <!--dropdown anio-->
                                <div class="form-group col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Ejercicio</label>
                                    <asp:DropDownList ID="ddlAnio" runat="server"
                                        AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="True"
                                        DataTextField="anio" aling="center" UseSubmitBehavior="False" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="dvMessageAnio" runat="server" visible="false"
                                        class="alert alert-danger">
                                        <strong>Error: </strong>
                                        <asp:Label ID="lblAnioError" runat="server" Text="Selecciona año" Visible ="false"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group col-lg-2 col-md-6 col-lg-12">
                                    <label class="control-label">Jurisdicción</label>
                                    <asp:DropDownList ID ="ddlJuris" runat="server" Enabled ="false"
                                        autopostback="true" CssClass="form-control" AppendDataBoundItems="true"
                                        DataTextField="ClaveJuris" aling="center"
                                        UseSubmitBehavior="false" OnSelectedIndexChanged="ddlJuris_SelectedIndexChanged" >
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id ="dvMessageJuris" runat="server" visible ="false" class="alert alert-danger">
                                        <strong>Error: </strong>
                                        <asp:Label runat="server" ID ="lblJuris" Text="Selecciona jurisdicción"></asp:Label>
                                    </div>
                                </div>

                                <!--dropdown qna -->
                                <div class="form-group col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Quincena</label>
                                    <asp:DropDownList ID="ddlQna" runat="server"
                                        AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="True" Enabled="false"
                                        DataTextField="qna" aling="center" UseSubmitBehavior="False" OnSelectedIndexChanged="ddlQna_SelectedIndexChanged">
                                        <asp:ListItem Value="0">
                                            Selecciona
                                        </asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="dvMessageQna" runat="server" visible="false"
                                        class="alert alert-danger">
                                        <strong>Error:</strong>
                                        <asp:Label ID="lblQnaEror" runat="server" Text ="Selecciona una quincena" ></asp:Label>
                                    </div>

                                </div>

                                <!--dropdown nomina -->
                                <div class="form-group col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Nómina</label>
                                    <asp:DropDownList ID="ddlNomina" runat="server"
                                        AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="True" Enabled="false"
                                        DataTextField="nomina" aling="center" UseSubmitBehavior="False" OnSelectedIndexChanged="ddlNomina_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                                <!--dropdown ur -->
                                <div class="form-group col-lg-4 col-md-6 col-lx-12">
                                    <label class="control-label">Unidad responsable</label>
                                    <asp:DropDownList ID="ddlUr" runat="server" Enabled="false"
                                        AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="True"
                                        DataTextField="ur" aling="center" UseSubmitBehavior="False" OnSelectedIndexChanged="ddlUr_SelectedIndexChanged">
                                        <asp:ListItem Value="0">
                                            Selecciona
                                        </asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                                <!--dropdown producto -->
                                <div class="form-group col-lg-4 col-md-6 col-lx-12">
                                    <label class="control-label">Producto de nómina</label>
                                    <asp:DropDownList ID="ddlPrd" runat="server"
                                        AutoPostBack="true" CssClass="form-control" AppendDataBoundItems="True" Enabled="False"
                                        DataTextField="prdname" aling="center" UseSubmitBehavior="False" >
                                        <asp:ListItem Value="0">
                                            Selecciona
                                        </asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                                <div class="form-group col-xs-12 col-md-12 col-lg-12">
                                    <asp:Button ID="btnBusca" runat="server" Text="Buscar" Height="35px" CssClass="btn btn-success" align="center" OnClick="btnBusca_Click" />

                                    <asp:Button  ID="btnLimpia" runat="server" Text="Limpiar" CssClass="btn btn-danger" OnClick="btnLimpia_Click"/>
                                        
                                <asp:Button ID="btnExporta" runat="server" OnClick="btnExporta_Click" Text="Exportar" Height="35px" CssClass="btn btn-primary" align="center" Enabled="false" />

                                    <br />
                                    <br />

                                </div>


                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-12 col-xs-12 col-lg-12">
                                            <div class="table-responsive">

                                                <asp:GridView ID="gvListadoCheques" runat="server"
                                                    CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                    Width="100%" Style="font-size: 13px" 
                                                    ShowFooter="True" AutoGenerateColumns="False" >

                                                    <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="#CCCCC1" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Producto_nomina_id" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="Producto_nomina_id" runat="server" Text='<%# Eval("Producto_nomina_id") %>'></asp:Label>

                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Año" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columAnio" runat="server" Text='<%# Eval("anio") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Quincena" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columQna" runat="server" Text='<%# Eval("qna") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Nómina" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columNomina" runat="server" Text='<%# Eval("nomina") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="UR" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columUr" runat="server" Text='<%# Eval("ur") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Producto de nómina" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columPrd" runat="server" Text='<%# Eval("prdname") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Importe neto" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columImporte" runat="server" Text='<%# Eval("ImporteNeto","{0:C}") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Descripción" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columDesc" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Jurisdicción" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columNombJuris" runat="server" Text='<%# Eval("nombre") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Registros" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columRegis" runat="server" Text='<%# Eval("registros" ,"{0:N0}") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                          <asp:TemplateField HeaderText="Memorandum" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columMemo" runat="server" Text='<%# Eval("memorandum") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                          <asp:TemplateField HeaderText="Póliza" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columPoliza" runat="server" Text='<%# Eval("poliza") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Usuario que generó" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columUsuario" runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Impreso" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columPrint" runat="server" Text='<%# Eval("EstatusImpresion") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                          <asp:TemplateField HeaderText="Fecha de impresión" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columFechaAplicacion" runat="server" Text='<%# Eval("fecha_aplicacion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                         <asp:TemplateField HeaderText="Número de ticket" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columNumTicket" runat="server" Text='<%# Eval("listado_firmas_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                      <asp:TemplateField HeaderText="Eliminar" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                 <asp:LinkButton runat="server" ID="lbElimina" CssClass ="btn btn-danger" onclick="lbElimina_Click">
                                                                     <span aria-hidden="true" class="fas fa-trash-alt" ></span>
                                                                 </asp:LinkButton>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center" />
                                                        </asp:TemplateField>

                                                    </Columns>


                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#383838" />

                                                </asp:GridView>
                                                <asp:HiddenField ID="hfPageIndex" runat="server" Value="1" />
                                                    <asp:HiddenField ID="hfTotalPage" runat="server" Value="0" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </form>

                        </ContentTemplate>

                        <Triggers>
                            <asp:PostBackTrigger  ControlID="btnExporta"/>
                            </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>


        <!-- Modal -->

    </div>

       <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="updatePanelConsultaCheques">
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
