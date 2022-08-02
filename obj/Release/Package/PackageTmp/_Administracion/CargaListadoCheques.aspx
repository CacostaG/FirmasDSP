<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CargaListadoCheques.aspx.cs" Inherits="ListadoDeFirmasDSP._Administracion.CargaListadoCheques" EnableEventValidation="false"  %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--script para seleccionar un solo checkbox-->
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

    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                Carga del  listado de cheques
            </div>
            <!--Select parametros-->
            <div class="panel-body">
                <div class="row col-lg-12">
                    <asp:UpdatePanel ID="UpdatePanel" runat="server">
                        <ContentTemplate>

                            <form class="form-inline">
                                <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                    <label class="control-label">Ejercicio</label>
                                    <asp:DropDownList ID="ddlAnio" runat="server"
                                        AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                        DataTextField="anio"
                                        align="center"
                                        UseSubmitBehavior="False" OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="dvMessageAnio1" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error:  </strong>
                                        <asp:Label ID="lblMensajeErrorAnio1" runat="server" Text="" />
                                    </div>
                                </div>

                                <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                    <label class="control-label">Quincena</label>
                                    <asp:DropDownList ID="ddlQna" runat="server"
                                        AppendDataBoundItems="True" DataTextField="qna" CssClass="form-control" align="center" AutoPostBack="True"
                                        Enabled="false" OnSelectedIndexChanged="ddlQuincenaInicial_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                    <div id="dvMessageQuincenaInicial1" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error:  </strong>
                                        <asp:Label ID="lblMensajeErrorQuincenaInicial1" runat="server" Text="" />
                                    </div>
                                </div>

                                <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                    <label class="contr-label">Nómina</label>
                                    <asp:DropDownList ID="ddlNomina" runat="server"
                                        AppendDataBoundItems="True" DataTextField="nomina" AutoPostBack="True" CssClass="form-control" align="center"
                                        Enabled="false" OnSelectedIndexChanged="ddlNomina_SelectedIndexChanged">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                </div>

                                <div class="form-group col-xs-12 col-md-8 col-lg-4">
                                    <label class="control-label">Unidad responsable</label>
                                    <asp:DropDownList ID="ddlUR" runat="server"
                                        AppendDataBoundItems="True" DataTextField="ur" AutoPostBack="True" CssClass="form-control" align="center" Enabled="false">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>
                                </div>


                                <div class="form-group col-xs-12 col-md-12 col-lg-12">
                                    <br />
                                    <asp:Button ID="btnBusca" runat="server" Text="Buscar" Height="35px" CssClass="btn btn-success" align="center" OnClick="btnBusca_Click" />

                                    <asp:Button ID="btnClean" runat="server" Text="Limpiar" Height="35px" CssClass="btn btn-danger" align="center" OnClick="btnClean_Click" />

                                    <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-info" OnClick="btnSave_Click" Enabled="false" />

                                    <br />
                                    <br />


                                </div>

                                <asp:Label runat="server" ID="lbl" Visible="false"></asp:Label>
                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-12 col-xs-12 col-lg-12">
                                            <div class="table-responsive">

                                                <asp:GridView ID="gvProductos" runat="server" AutoGenerateColumns="false"
                                                    CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                    Width="100%" Style="font-size: 13px"
                                                    ShowFooter="true">

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

                                                        <asp:TemplateField HeaderText="Nómina" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columNomina" runat="server" Text='<%# Eval("nomina") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="UR" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columUR" runat="server" Text='<%# Eval("ur") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Año" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columAnio" runat="server" Text='<%# Eval("anio") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Quincena" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columQna" runat="server" Text='<%# Eval("qna") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Producto de nómina" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columPRDNAME" runat="server" Text='<%# Eval("prdname") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Descripción" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columDesc" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
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


                                            <div>
                                                <label class="control-label">Selecciona archivo de cheques:</label>
                                                <br />

                                                <asp:FileUpload ID="cargaArchivo" runat="server"
                                                    enctype="multipart/form-data" Enabled="false" />

                                                <asp:Label ID="User" runat="server" Text='<%#Session["user"]%>' Visible="false"></asp:Label>



                                                <br />

                                                <asp:Button ID="btnSelect" runat="server" Text="Vista Previa"
                                                    CssClass="btn btn-primary" OnClick="btnSelect_Click" Enabled="false" />
                                                <br />
                                            </div>


                                            <div class="table-responsive">
                                                <br />
                                                <br />
                                                <asp:GridView ID="gvListadoCheques" runat="server" CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                    Width="100%" Style="font-size: 13px"
                                                    ShowFooter="True" AutoGenerateColumns="False">
                                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                                    <Columns>

                                                        <asp:BoundField HeaderText="RFC" DataField="rfc" ItemStyle-HorizontalAlign="Center" HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Nombre" DataField="nombreem" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Producto de nómina" DataField="tn" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Total" DataField="total" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Número cheque" DataField="recibo" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Centro" DataField="centro" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Nombre del centro" DataField="nom_centro" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Jurisdicción" DataField="juris" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                        <asp:BoundField HeaderText="Nombre  de la jurisdicción" DataField="nom_juris" ItemStyle-HorizontalAlign="Center">
                                                            <HeaderStyle HorizontalAlign="Center" />
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:BoundField>

                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" />
                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                                </asp:GridView>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                            </form>


                        </ContentTemplate>

                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnSelect" />
                        </Triggers>

                    </asp:UpdatePanel>

                </div>
            </div>


        </div>
    </div>


    <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="UpdatePanel">
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




