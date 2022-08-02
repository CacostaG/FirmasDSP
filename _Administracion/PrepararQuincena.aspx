<%@ Page Title="Preparar producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PrepararQuincena.aspx.cs" Inherits="ListadoDeFirmasDSP._Administracion.PrepararQuincena" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Panel runat="server" ID="Preparar_Quincena">
                  
        <script src="../Scripts/sweetalert.min.js"></script>  
        <link href="../css/sweetalert.css" rel="stylesheet" />
                    <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                    Preparar producto de nómina
                </div>

                <!--panel boody-->
                <div class="panel-body">

                    <!--div columna -->
                    <div class="row col-lg-12">
                        <asp:UpdatePanel ID="UpdatePanelPreparaQuincena" runat="server">
                            <ContentTemplate>

                                <form class="form-inline">

                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Ejercicio</label>
                                        <asp:DropDownList ID="ddlAnio" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="anio"
                                            OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged" align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageAnio1" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorAnio1" runat="server" Text="" />
                                        </div>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Quincena </label>
                                        <asp:DropDownList ID="ddlQuincena" runat="server"
                                            AppendDataBoundItems="True" DataTextField="qna" CssClass="form-control" align="center" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlQuincena_SelectedIndexChanged" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageQuincena" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorQuincena" runat="server" Text="Seleccione quincena" Visible ="false" />
                                        </div>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="contr-label">Nómina</label>
                                        <asp:DropDownList ID="ddlNomina" runat="server"
                                            AppendDataBoundItems="True" DataTextField="nomina" AutoPostBack="True" CssClass="form-control" align="center"
                                            OnSelectedIndexChanged="ddlNomina_SelectedIndexChanged" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-4">
                                        <label class="control-label">Unidad responsable</label>
                                        <asp:DropDownList ID="ddlUR" runat="server"
                                            AppendDataBoundItems="True" DataTextField="ur" AutoPostBack="True" CssClass="form-control" align="center" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-12 col-lg-12">
                                        <br />
                                        <asp:Button ID="Button1" runat="server" OnClick="Buscar_Click" Text="Buscar" Height="35px" CssClass="btn btn-success" align="center" />

                                        <asp:Button ID="BtnClean" runat="server" OnClick="Limpiar_Click" Text="Limpiar" Height="35px" CssClass="btn btn-danger" align="center" />

                                        <asp:Label ID="User" runat="server" Text='<%#Session["user"]%>' Visible="false"></asp:Label>
                                        <!-- Modal -->


                                      



                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                        <!--tabla-->
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-md-12 col-xs-12 col-lg-12">
                                                    <div class="table-responsive">

                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12" style="font-family: 'Yu Gothic UI Semibold'">
                                                        </div>
                                                        <br />
                                                        <br />

                                                        <asp:GridView ID="gvPreparaQuincena" runat="server" 
                                                            CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                            Width="100%" Style="font-size: 13px"
                                                            ShowFooter="True" OnRowDataBound="gvTablaUno_RowDataBound" AutoGenerateColumns="False">

                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="#CCCCC1" />
                                                            <Columns>



                                                                <asp:TemplateField HeaderText="Cnmkey" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columCNm_Key" runat="server" Text='<%# Eval("CNm_key") %>'></asp:Label>

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


                                                                <asp:TemplateField HeaderText="Nómina" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columQuincena" runat="server" Text='<%# Eval("nomina") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="UR" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columUR" runat="server" Text='<%# Eval("ur") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Producto de nómina​" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columPRDNAME" runat="server" Text='<%# Eval("prdname") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                  <asp:TemplateField HeaderText="Tipo" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columTipoCompleto" runat="server" Text='<%# Eval("TipoDescr") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Percepciones" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columPercepciones" runat="server" Text='<%# Eval("Importe_bruto" ) %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Deducciones" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columDeducciones" runat="server" Text='<%# Eval("Descuentos") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Neto" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columNeto" runat="server" Text='<%# Eval("Importe_neto") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Registros" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columRegistros" runat="server" Text='<%# Eval("Pagos_qna") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Tipo_" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columTipo" runat="server" Text='<%# Eval("tipo") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Seleccionar" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <div class="input-group mb-3">
                                                                            <div class="input-group-prepend">
                                                                                <div class="input-group-text">
                                                                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                                </div>
                                                                            </div>
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
                                            <!--
                                            <div id="dvBtnQna" runat="server" visible="false">
                                                <asp:Button ID="bntPreparaProducto" runat="server" Text="Preparar producto" CssClass="btn btn-primary" align="center" data-toggle="modal" data-target="#Confirmacion" OnClientClick="return false;" />


                                            </div>-->

                                            <asp:Button ID="btnPreparaPrd" runat="server" text="Preparar producto "  CssClass="btn btn-primary" OnClick="btnPreparaPrd_Click" Visible="false" />

                                        </div>

                                        <!--tabla fin -->

                                    </div>

                                </form>

                            </ContentTemplate>


                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>

        <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="UpdatePanelPreparaQuincena">
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
