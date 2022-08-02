<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaMedidasFinAnioGenerados.aspx.cs" Inherits="ListadoDeFirmasDSP._Consulta.ConsultaMedidasFinAnioGenerados"EnableEventValidation="false" ClientIDMode="AutoID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
  
    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />
    <script src="https://kit.fontawesome.com/27c01da83f.js" crossorigin="anonymous"></script>
      <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                Consulta de listados de medidas de fin de año generados
            </div>


            <div class="panel-body">
                <div class="row col-lg-12">
                    <asp:UpdatePanel ID="updatePanelMedidasFinAnio" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <form class="form-inline">

                                <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                    <label class="control-label">Ejercicio </label>
                                    <asp:DropDownList ID="ddlAnio" runat="server"
                                        AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                        DataTextField="anio"
                                        OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"
                                        align="center"
                                        UseSubmitBehavior="False">
                                        <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                    </asp:DropDownList>

                                    <div id="dvMessageAnio" runat="server" visible="false" class="alert alert-danger">
                                        <strong>Error:  </strong>
                                        <asp:Label ID="lblMensajeErrorAnio" runat="server" Text="" />
                                    </div>
                                    <!---B_Año-->
                                </div>

                                    <!---A_Año-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label"> Jurisdicción</label>

                                         <asp:DropDownList ID="ddlJuris" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="ClaveJuris"
                                            OnSelectedIndexChanged="ddlJuris_SelectedIndexChanged"
                                            align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Todas</asp:ListItem>
                                        </asp:DropDownList>


                                  

                                        <div id="dvMessageJuris" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorJuris" runat="server" Text="" />
                                        </div>
                                        <!---B_Año-->
                                    </div>


                                    <!---A_Lote-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Lote </label>
                                        <asp:DropDownList ID="ddlLote" runat="server" AppendDataBoundItems="True" DataTextField="lote" CssClass="form-control"
                                            align="center" AutoPostBack="True" Enabled="false">
                                            <asp:ListItem Value="0">Todos</asp:ListItem>
                                        </asp:DropDownList>

                                        <div id="dvMessageLote" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorLote" runat="server" Text="" />
                                        </div>

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

                                                <asp:GridView ID="gvConsultaMedidasFinAnio" runat="server"
                                                    CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                    BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                    Width="100%" Style="font-size: 13px" 
                                                    ShowFooter="True" AutoGenerateColumns="False" OnSelectedIndexChanged="gvConsultaMedidasFinAnio_SelectedIndexChanged" >

                                                    <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                    <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                    <AlternatingRowStyle BackColor="#CCCCC1" />
                                                    <Columns>

                                                        <asp:TemplateField HeaderText="Jurisdicción" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="Producto_nomina_id" runat="server" Text='<%# Eval("ClaveJuris") %>'></asp:Label>

                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Año" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="columAnio" runat="server" Text='<%# Eval("anio") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Lote" ItemStyle-HorizontalAlign="Center" >
                                                            <ItemTemplate>
                                                                <asp:Label ID="columQna" runat="server" Text='<%# Eval("lote") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                          <asp:TemplateField HeaderText="Impreso" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columJurisdicción" runat="server" Text='<%# Eval("impreso") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columNomina" runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>



                                                        <asp:TemplateField HeaderText="Fecha de aplicacion" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columUr" runat="server" Text='<%# Eval("fecha_aplicacion") %>'></asp:Label>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        </asp:TemplateField>


                                                        <asp:TemplateField HeaderText="Registro" ItemStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Label ID="columPrd" runat="server" Text='<%# Eval("registros") %>'></asp:Label>
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

     <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="updatePanelMedidasFinAnio">
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
