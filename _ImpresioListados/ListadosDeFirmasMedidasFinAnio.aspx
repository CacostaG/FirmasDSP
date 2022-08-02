<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadosDeFirmasMedidasFinAnio.aspx.cs" Inherits="ListadoDeFirmasDSP._ImpresioListados.ListadosDeFirmasMedidasFinAnio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">




    <!-- <script src="../Scripts/sweetalert2.all.js"></script>
    <link rel="stylesheet" href="sweetalert2.min.css">
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>-->
    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />
    <script type="text/javascript">
        function CheckOne(obj) {
            var grid = obj.parentNode.parentNode.parentNode;
            var inputs = grid.getElementsByTagName("input");
            for (var i = 0; i < inputs.length; i++) {
                if (inputs[i].type == "checkbox") {
                    if (obj.checked && inputs[i] != obj && inputs[i].checked) {
                        inputs[i].checked = false;
                    }
                }
            }
        }
    </script>

    <asp:Label ID="User" runat="server" Text='<%#Session["user"]%>' Visible="false"></asp:Label>



    <asp:Panel runat="server" ID="Medidas_Fin_Año">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                    Impresión listados de Medidas de fin de año
                </div>
                <!--A_Panel Body-->

                <div class="panel-body">
                    <!--A_columna-->
                    <div class="row col-lg-12">
                        <!--A_Panel--->
                        <asp:UpdatePanel ID="UpdatePanel_ListadosMedidasFinAnio" runat="server">

                            <ContentTemplate>
                                <!---A_FORM-->
                                <form class="form-inline">
                                    <!---A_CalveJuris-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Jurisdicción</label>
                                        <asp:DropDownList ID="ddlJurisMFA" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="ClaveJuris"
                                            OnSelectedIndexChanged="ddlJurisMFA_SelectedIndexChanged"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>

                                        <div id="dvMessageJuris" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorJuris" runat="server" Text="" />
                                        </div>
                                        <!---B_Año-->
                                    </div>

                                    <!---A_Año-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Ejercicio</label>
                                        <asp:DropDownList ID="ddlAnioMFA" runat="server" AppendDataBoundItems="True" DataTextField="anio" CssClass="form-control"
                                            align="center" AutoPostBack="True" Enabled="false"
                                            OnSelectedIndexChanged="ddlAnioMFA_SelectedIndexChanged"
                                            >
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>

                                        <div id="dvMessageAnio" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorAnio" runat="server" Text="" />
                                        </div>
                                        <!---B_Año-->
                                    </div>
                                    <!---A_Lote-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Lote </label>
                                        <asp:DropDownList ID="ddlLoteMFA" runat="server" AppendDataBoundItems="True" DataTextField="lote" CssClass="form-control"
                                            align="center" AutoPostBack="True" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>

                                        <div id="dvMessageLote" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorLote" runat="server" Text="" />
                                        </div>

                                    </div>





                                    <!--A_columna-->

                                    <!----A_BOTONES1---->
                                    <div class="form-group col-xs-12 col-md-12 col-lg-12">
                                        <br />
                                        <asp:Button ID="ConsultarListado" runat="server" OnClick="ConsultarListado_Click" Text="Consultar" Height="35px" CssClass="btn btn-success" align="center" />

                                        <asp:Button ID="BtnClean" runat="server" OnClick="BtnClean_Click" Text="Limpiar" Height="35px" CssClass="btn btn-danger" align="center" />

                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-md-12 col-xs-12 col-lg-12">
                                                    <div class="table-responsive">

                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12" style="font-family: 'Yu Gothic UI Semibold'">
                                                        </div>


                                                        <br />
                                                        <br />

                                                        <asp:GridView ID="gvListadoMedidasFinAnio" runat="server"
                                                            CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                            Width="100%" Style="font-size: 13px"
                                                            ShowFooter="True" OnRowDataBound="gvListadoMedidasFinAnio_RowDataBound" AutoGenerateColumns="False" OnSelectedIndexChanged="gvListadoMedidasFinAnio_SelectedIndexChanged">

                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="#CCCCC1" />
                                                            <Columns>





                                                                <asp:TemplateField HeaderText="Año" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columAnio" runat="server" Text='<%# Eval("anio") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Lote" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columLote" runat="server" Text='<%# Eval("lote") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Descripción de lote" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columDescripcionLote" runat="server" Text='<%# Eval("descripcion_lote") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Registros" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columRegistros" runat="server" Text='<%# Eval("numero_tarjetas" ,"{0:N0}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Importe" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columImporte" runat="server" Text='<%# Eval("importe_total" ,"{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>



                                                                <asp:TemplateField HeaderText="ID_Juris" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columID_Juris" runat="server" Text='<%# Eval("jurisdiccion_id") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>



                                                                <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="CheckBox" runat="server" onclick="CheckOne(this)" />
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
                                                        <asp:HiddenField ID="hfPageIndex" runat="server" Value="1" />
                                                        <asp:HiddenField ID="hfTotalPage" runat="server" Value="0" />

                                                    </div>
                                                </div>
                                            </div>
                                            <br />
                                            <div id="dvBtnImpriListadodeFirmas" runat="server" visible="false">
                                                <asp:Button ID="BtnImpriListadodeFirmas" runat="server" CssClass="btn btn-primary" data-toggle="modal" data-target="#" Text="Imprimir listado de firma" OnClick="BtnImpriListadodeFirmas_Click" />

                                            </div>
                                        </div>

                                    </div>
                                    <!----B_BOTONES1---->




                                </form>
                                <!---B_FORM-->



                            </ContentTemplate>



                        </asp:UpdatePanel>
                        <!--B_Panel--->


                        <!--B_columna-->
                    </div>



                </div>






            </div>
        </div>

                <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel_ListadosMedidasFinAnio">
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


    </asp:Panel>








</asp:Content>
