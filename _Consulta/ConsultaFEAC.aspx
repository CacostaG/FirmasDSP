<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaFEAC.aspx.cs" Inherits="ListadoDeFirmasDSP._Consulta.ConsultaFEAC" EnableEventValidation="false" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ContentFEAC" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />

  <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                Consulta de listados de FEAC generados
            </div>


            <div class="panel-body">
                <div class="row col-lg-12">
                    <asp:UpdatePanel ID="updatePanelFEAC" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <form class="form-inline">
                                <div class="form-group  col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Jurisdicción</label>
                                    <asp:DropDownList runat="server" ID="ddlJuris" CssClass="form-control" Autopostback="true" AppendDataBoundItems="true" DataTextField="claveJuris" aling="center" UseSubmitBehavior="false" OnSelectedIndexChanged="ddlJuris_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>

                                     <div id="dvMessageJuris" runat="server" visible="false"
                                        class="alert alert-danger ">
                                        <strong>Error: </strong>
                                        <asp:Label runat="server" id="lbJuris" Text="Selecciona jurisdicción"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Ejercicio</label>
                                    <asp:DropDownList ID="ddlAnio" runat="server"
                                       AutoPostBack="true" CssClass="form-control" Enabled="false" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"
                                        AppendDataBoundItems="true"
                                        DataTextField="anio" aling="center" UseSubmitBehavior="False" >
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>

                                    <div id="dvMessageAnio" runat="server" visible="false"
                                        class="alert alert-danger ">
                                        <strong>Error: </strong>
                                        <asp:Label runat="server" id="lbAnio" Text="Selecciona año"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group  col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Quincena</label>
                                    <asp:DropDownList runat="server" ID="ddlQna" CssClass="form-control" OnSelectedIndexChanged="ddlQna_SelectedIndexChanged"
                                        Autopostback="true" AppendDataBoundItems="true" Enabled="false"
                                        DataTextField="qna" aling="center"
                                        UseSubmitBehavior="false" >
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>

                                     <div id="dvMessageQna" runat="server" visible="false"
                                        class="alert alert-danger ">
                                        <strong>Error: </strong>
                                        <asp:Label runat="server" ID="lbQna" Text="Selecciona quincena"></asp:Label>
                                    </div>
                                </div>

                                <div class="form-group  col-lg-2 col-md-6 col-lx-12">
                                    <label class="control-label">Nómina</label>
                                    <asp:DropDownList runat="server" ID="ddlNomina" CssClass="form-control" OnSelectedIndexChanged="ddlNomina_SelectedIndexChanged"
                                        Autopostback="true" AppendDataBoundItems="true" Enabled="false"
                                        DataTextField="nomina" aling="center"
                                        UseSubmitBehavior="false" >
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group  col-lg-4 col-md-6 col-lx-12">
                                    <label class="control-label">Unidad responsable</label>
                                    <asp:DropDownList runat="server" ID="ddlUr" CssClass="form-control" OnSelectedIndexChanged="ddlUr_SelectedIndexChanged"
                                        Autopostback="true" AppendDataBoundItems="true" Enabled="false"
                                        DataTextField="ur" aling="center"
                                        UseSubmitBehavior="false" >
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                 <div class="form-group  col-lg-4 col-md-6 col-lx-12">
                                    <label class="control-label">Producto de nómina</label>
                                    <asp:DropDownList runat="server" ID="ddlPrd" CssClass="form-control" OnSelectedIndexChanged="ddlPrd_SelectedIndexChanged"
                                        Autopostback="true" AppendDataBoundItems="true" Enabled="false"
                                        DataTextField="prdname" aling="center"
                                        UseSubmitBehavior="false" >
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group  col-lg-4 col-md-6 col-lx-12">
                                    <label class="control-label">Instrumento de pago</label>
                                    <asp:DropDownList runat="server" ID="ddlInstru" CssClass="form-control"
                                        AutoPostBack="true" AppendDataBoundItems="true" Enabled="false"
                                        DataTextField="instrumento" aling="center"
                                        UseSubmitBehavior="false">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>

                                </div>

                                <div class="form-group col-xs-12 col-md-12 col-lg-12">
                                    <asp:Button ID="btnBusca" runat="server" Text="Buscar" Height="35px" CssClass="btn btn-success" align="center"  OnClick="btnBusca_Click" />

                                    <asp:Button ID="btnLimpia" runat="server" Text="Limpiar" CssClass="btn btn-danger"  OnClick="btnLimpia_Click"/>
                                     <asp:Button ID="btnExporta" runat="server" OnClick="btnExporta_Click" Text="Exportar" Height="35px" CssClass="btn btn-primary" align="center" Enabled="false" />
                                    <br />

                                </div>

                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-12 col-xs-12 col-lg-12">
                                            <div class="table-responsive">

                                                <asp:GridView ID="gvListadoNomina" runat="server"
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
                                                                <asp:Label ID="columImporte" runat="server" Text='<%# Eval("neto","{0:C}") %>'></asp:Label>
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
                                                                <asp:Label ID="columRegis" runat="server" Text='<%# Eval("TotalRegistros","{0:N0}") %>'></asp:Label>
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

                                                        <asp:TemplateField HeaderText="Instrumento de pago" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columInstrumento" runat="server" Text='<%# Eval("instrumento") %>'></asp:Label>
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
                                                                <asp:Label ID="columFechaApli" runat="server" Text='<%# Eval("fecha_aplicacion") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                         <asp:TemplateField HeaderText="Número de ticket" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columNumTicket" runat="server" Text='<%# Eval("listado_firmas_id") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
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
    </div>

     <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="updatePanelFEAC">
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

