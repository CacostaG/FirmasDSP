<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListadoDeFirmas.aspx.cs" Inherits="ListadoDeFirmasDSP._ImpresioListados.ListadoDeFirmas" EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   
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
    <asp:Label ID="txtIdJurisdiccion" runat="server" Text='<%#Session["jurisdiccion_id"]%>' ></asp:Label>
    <asp:Label ID="txtCheckDeposito" runat="server" Text='' ></asp:Label>
     <asp:Label ID="txtCheckCheque" runat="server" Text='' ></asp:Label>
    <asp:Label ID="ValidaCheck" runat="server" Text='' ></asp:Label>


    <asp:Panel runat="server" ID="Listado_firmas">
        <div class="container-fluid">
            <div class="panel panel-default">
                <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                   Impresión listados de nómina generada
                </div>

                <!--A_Panel Body-->
                <div class="panel-body">
                    <!--A_columna-->
                    <div class="row col-lg-12">
                        <!--A_Panel--->
                        <asp:UpdatePanel ID="UpdatePanel_ListadoFirmas" runat="server">
                           
                            <ContentTemplate>
                                <!---A_FORM-->
                                <form class="form-inline">
                                    <!---A_Año-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Ejercicio</label>
                                        <asp:DropDownList ID="ddlAnio" runat="server"
                                            AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                            DataTextField="anio"
                                            OnSelectedIndexChanged="ddlAnio_SelectedIndexChanged"  align="center"
                                            UseSubmitBehavior="False">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageAnio" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorAnio" runat="server" Text="" />
                                        </div>
                                        <!---B_Año-->
                                    </div>
                                    <!---A_Quincena-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Quincena </label>
                                        <asp:DropDownList ID="ddlQuincena" runat="server"
                                            AppendDataBoundItems="True" DataTextField="qna" CssClass="form-control" align="center" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlQuincena_SelectedIndexChanged" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageQuincena" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorQuincena" runat="server" Text="" />
                                        </div>
                                      
                                    </div>  
                                    <!---B_Quincena-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Tipo </label>
                                        <asp:DropDownList ID="ddlTipo" runat="server"
                                            AppendDataBoundItems="True" DataTextField="ClavePago" CssClass="form-control" align="center" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlTipo_SelectedIndexChanged"   Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageTipo" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorTipo" runat="server" Text="" />
                                        </div>
                                      
                                    </div>  

                                    <!--A_Nomina-->
                                     <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="contr-label">Nómina</label>
                                        <asp:DropDownList ID="ddlNomina" runat="server"
                                            AppendDataBoundItems="True" DataTextField="nomina" AutoPostBack="True" CssClass="form-control" align="center"
                                            OnSelectedIndexChanged="ddlNomina_SelectedIndexChanged"  Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                          <div id="dvMessageNomina" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorNomina" runat="server" Text="" />
                                        </div>
                                    </div>
                                    <!--B_Nomina-->
                                     <!--A_UR--> 
                                  <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                      <label class="control-label">Unidad responsable</label>
                                        <asp:DropDownList id="ddlUR" runat="server"
                                            AppendDataBoundItems="True" DataTextField="ur" AutoPostBack="True" CssClass="form-control" align="center"
                                            OnSelectedIndexChanged="ddlUR_SelectedIndexChanged"  Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                       <div id="dvMessageUR" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorUR" runat="server" Text="" />
                                        </div>
                                  </div>
                                    <!--B_UR-->
                                    <!--A_PRDNAME-->
                                    <div class="form-group col-xs-12 col-md-6 col-lg-4">
                                        <label class="control-label">Producto de nómina</label>
                                        <asp:DropDownList ID="ddlPrdname" runat="server" 
                                            AppendDataBoundItems="True" DataTextField="prdname" AutoPostBack="True" CssClass="form-control" align="center" Enabled="false" OnSelectedIndexChanged="ddlPrdname_SelectedIndexChanged"  >
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessagePrdname" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorPrdname" runat="server" Text="" />
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

                                                       <asp:GridView ID="gvListadoDeFirmas" runat="server"
                                                           CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                           BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                           Width="100%" Style="font-size: 13px"
                                                           ShowFooter="True" OnRowDataBound="gvListadoDeFirmas_RowDataBound" AutoGenerateColumns="False">

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

                                                                <asp:TemplateField HeaderText="Producto de nómina" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columPRDNAME" runat="server" Text='<%# Eval("prdname") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Percepciones" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columPercepciones" runat="server" Text='<%# Eval("i1" ,"{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Deducciones" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columDeducciones" runat="server" Text='<%# Eval("i2" ,"{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Neto" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columNeto" runat="server" Text='<%# Eval("i3" ,"{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Registros" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columRegistros" runat="server" Text='<%# Eval("TotalRegistros" ,"{0:N0}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                   <asp:TemplateField HeaderText="tpersonal" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columTpersonal" runat="server" Text='<%# Eval("TotalRegistros" ,"{0:N0}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Instrumento de Pago" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columInstrumento" runat="server" Text='<%# Eval("instrumento") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Descripcion" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columDescripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="ID_Juris" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columD_Juris" runat="server" Text='<%# Eval("jurisdiccion_id") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Producto_nomina_id" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columPrudctoNominaID" runat="server" Text='<%# Eval("producto_nomina_id") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Memorandum" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columMemorandum" runat="server" Text='<%# Eval("memorandum") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Poliza" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columPOliza" runat="server" Text='<%# Eval("Poliza") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                
                                                                    <asp:TemplateField HeaderText="claveJuris" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columClaveJuris" runat="server" Text='<%# Eval("ClaveJuris") %>'></asp:Label>
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
                                              <asp:Button ID="BtnImpriListadodeFirmas"  runat="server" CssClass="btn btn-primary" data-toggle="modal" data-target="#" Text="Imprimir listado de firma" OnClick="BtnImpriListadodeFirmas_Click" />
                                              
                                              <asp:Button id="btnDescargaReporte" runat ="server" CssClass="btn btn-info" text="Descarga comprobante" OnClick="btnDescargaReporte_Click" visible="false"/>
                                            </div>
                                        </div>   
                              
                                        </div>
                      <!----B_BOTONES1---->

                                  

                                   
                                </form> <!---B_FORM-->
                           


                                </ContentTemplate>
                            

                            
                        </asp:UpdatePanel><!--B_Panel--->


                        <!--B_columna-->
                    </div>


         
                </div>
            </div>
        </div>




    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel_ListadoFirmas">
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