<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistroDePolizas.aspx.cs" Inherits="ListadoDeFirmasDSP._Administracion.RegistroDePolizas" EnableEventValidation="false" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />

    <asp:Label ID="User" runat="server" Text='<%#Session["user"]%>' Visible="false"></asp:Label>

    


    <asp:Panel runat="server" ID="Registro_Polizas">



        <div class="container-fluid"> 
             
             
            <div class="panel panel-default">
                <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                    Registro de pólizas

                </div>

                <!--panel boody-->
                <div class="panel-body">
                    <div class="row col-lg-12">
                        <asp:UpdatePanel ID="UpdatePanelRegistroPolizas" runat="server">
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
                                            <asp:Label ID="lblMensajeErrorAnio" runat="server" Text="" />
                                        </div>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="control-label">Quincena</label>
                                        <asp:DropDownList ID="ddlQuincena" runat="server"
                                            AppendDataBoundItems="True" DataTextField="qna" CssClass="form-control" align="center" Autopostback="true"
                                            OnSelectedIndexChanged="ddlQuincena_SelectedIndexChanged" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageQuincena" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorQuincena" runat="server" Text="" />
                                        </div>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-2">
                                        <label class="contr-label">Nómina</label>
                                        <asp:DropDownList ID="ddlNomina" runat="server"
                                            AppendDataBoundItems="True" DataTextField="nomina" AutoPostBack="True" CssClass="form-control" align="center"
                                            OnSelectedIndexChanged="ddlNomina_SelectedIndexChanged" Enabled="false">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageNomina" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorNomina" runat="server" Text="" />
                                        </div>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-4">
                                        <label class="control-label">Unidad responsable</label>
                                        <asp:DropDownList ID="ddlUR" runat="server"
                                            AppendDataBoundItems="True" DataTextField="ur" AutoPostBack="True" CssClass="form-control" align="center"
                                            OnSelectedIndexChanged="ddlUR_SelectedIndexChanged" Enabled="false">

                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessageUR" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorUR" runat="server" Text="" />
                                        </div>
                                    </div>

                                    <div class="form-group col-xs-12 col-md-6 col-lg-4">
                                        <label class="control-label">Producto de nómina</label>
                                        <asp:DropDownList ID="ddlPrdname" runat="server"
                                            AppendDataBoundItems="True" DataTextField="prdname" AutoPostBack="true" CssClass="form-control" align="center" Enabled="false"  OnSelectedIndexChanged="ddlPrdname_SelectedIndexChanged">
                                            <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                        </asp:DropDownList>
                                        <div id="dvMessagePrdname" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorPrdname" runat="server" Text="" />
                                        </div>
                                    </div>






                                    <div class="form-group col-xs-12 col-md-8 col-lg-6" id="dvDescripcion" runat="server" visible="false" required ="true">
                                        <label class="control-label">Descripcion</label>


                                        <asp:TextBox ID="txtDescripcion" runat="server" class="form-control" Text="" value=""  ></asp:TextBox>

                                        <asp:RequiredFieldValidator ID ="validaDescripcion" controltovalidate="txtDescripcion" runat="server"  errormessage="Campo obligatorio!" ValidationGroup="validabtn" ></asp:RequiredFieldValidator>
                                        <div id="dvMessageDescripcion" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorDescripcion" runat="server" Text="" />
                                        </div>
                                    </div>





                                    

                                    <div class="form-group col-xs-12 col-md-6 col-lg-2" id="dvMEmorandum" runat="server" visible="false">
                                        <label class="control-label">Memorandum</label>


                                        <asp:TextBox ID="txtMemo" runat="server" class="form-control" value="" type="number" CausesValidation="true" ValidationGroup="NumericValidate"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="ValidatortxtMemo" runat="server" ControlToValidate="txtMemo" ErrorMessage="Ingrese Numeros" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                        <div id="dvMessageMemo" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorMemo" runat="server" Text="" />
                                        </div>
                                    </div>








                                    <div class="form-group col-xs-12 col-md-6 col-lg-2" id="dvPoliza" runat="server" visible="false">
                                        <label class="control-label">Poliza</label>


                                        <asp:TextBox ID="txtPoliza" runat="server" class="form-control" value="" type="number" CausesValidation="true" ValidationGroup="NumericValidate"></asp:TextBox>

                                        <asp:RegularExpressionValidator ID="ValidatortxtPoliza" runat="server" ControlToValidate="txtPoliza" ErrorMessage="Ingrese Numeros" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                        </script>
                                                                      <div id="dvMessagePoliza" runat="server" visible="false" class="alert alert-danger">
                                                                          <strong>Error:  </strong>
                                                                          <asp:Label ID="lblMensajeErrorPoliza" runat="server" Text="" />
                                                                      </div>



                                    </div>



                                    <div class="form-group col-xs-12 col-md-6 col-lg-3" id="dvFecha_Elabora" runat="server" visible="false">
                                        <label class="control-label">Fecha elaboracion</label>

                                        <asp:TextBox ID="txt_FechaElabora" runat="server" class="form-control" type="date" CausesValidation="true" ValidationGroup="DateValidate"></asp:TextBox>
                                        <div id="dvMessageFechaElabora" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorFechaElabora" runat="server" Text="" />
                                        </div>



                                    </div>



                                    <div class="form-group col-xs-12 col-md-6 col-lg-3" id="dvFecha_Pago" runat="server" visible="false">
                                        <label class="control-label">Fecha pago</label>


                                        <asp:TextBox ID="txt_FechaPago" runat="server" class="form-control" value="" type="date" CausesValidation="true" ValidationGroup="DateValidate"></asp:TextBox>

                                        <div id="dvMessageFechaPago" runat="server" visible="false" class="alert alert-danger">
                                            <strong>Error:  </strong>
                                            <asp:Label ID="lblMensajeErrorFechaPago" runat="server" Text="" />
                                        </div>

                                    </div>
                                    





                                    <div class="form-group col-xs-12 col-md-12 col-lg-12">

                                        
                                        <!--
                                        <asp:Button ID="GuardarM" runat="server" CssClass="btn btn-success" data-toggle="modal" data-target="#Confirmacion" Text="Guardar" OnClientClick="return false;" />
                                            -->
                                        <asp:Button ID="BtnClean" runat="server" OnClick="Limpiar_Click" Text="Limpiar" Height="35px" CssClass="btn btn-danger" align="center" />

                                        <asp:Button Id="btnSave" runat="server" text ="Guardar" CssClass="btn btn-success" OnClick="btnSave_Click"/>

                                        <!-- Modal -->
                                        <div id="Confirmacion" class="modal fade" role="dialog">
                                            <div class="modal-dialog">

                                                <!-- Modal content-->
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal">&times;</button>

                                                        <h4 class="modal-title">
                                                            <center>¿Desea continuar?</center>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                            <h4></h4>
                                                       
                                                        </h4>
                                                    </div>
                                                    <div class="modal-body">



                                                        <label class="control-label">Con los siguientes cambios correspondientes:</label><br />
                                                        <asp:Label ID="LbModalGuardar1" runat="server" Text=""></asp:Label><br />


                                                    </div>
                                                    <div class="modal-footer">
                                                        <asp:Button ID="BtnGuardar" runat="server" OnClick="BtnGuardar_Click" Text="Guardar" Height="35px" CssClass="btn btn-success" align="center" CausesValidation="true" />



                                                        <button type="button" class="btn btn-danger" data-dismiss="modal">Cerrar</button>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>

                                        <br />
                                        <br />
                                        <br />
                                        <br />
                                                   <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-md-12 col-xs-12 col-lg-12">
                                                    <div class="table-responsive">

                                                        <div class="col-md-12 col-lg-12 col-sm-12 col-xs-12" style="font-family: 'Yu Gothic UI Semibold'">
                                                        </div>
                                                        <br />
                                                        <br />

                                                        <asp:GridView ID="gvRegisgtroDePolizas" runat="server" 
                                                            CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                            BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                            Width="100%" Style="font-size: 13px"
                                                            ShowFooter="True" OnRowDataBound="gvRegisgtroDePolizas_RowDataBound" AutoGenerateColumns="False">

                                                            <FooterStyle BackColor="#CCCC99" HorizontalAlign="Center" VerticalAlign="Middle" />
                                                            <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                            <AlternatingRowStyle BackColor="#CCCCC1" />
                                                            <Columns>



                                                                <asp:TemplateField HeaderText="producto_nomina_id" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="producto_nomina_id" runat="server" Text='<%# Eval("producto_nomina_id") %>'></asp:Label>

                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Cnmkey" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="CNmkey" runat="server" Text='<%# Eval("CNm_Key") %>'></asp:Label>

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

                                                                <asp:TemplateField HeaderText="Unidad responsable" ItemStyle-HorizontalAlign="Center">
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
                                                                        <asp:Label ID="columPercepciones" runat="server" Text='<%# Eval("percepciones","{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>


                                                                <asp:TemplateField HeaderText="Deducciones" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columDeducciones" runat="server" Text='<%# Eval("deducciones" ,"{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Importe neto" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columNeto" runat="server" Text='<%# Eval("neto" ,"{0:C}") %>'></asp:Label>
                                                                    </ItemTemplate>

                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="Registros" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columRegistros" runat="server" Text='<%# Eval("registros","{0:N0}") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>


                                                                 <asp:TemplateField HeaderText="Descripción" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columdescripcion" runat="server" Text='<%# Eval("descripcion") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                   <asp:TemplateField HeaderText="Memorandum" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="colummemorandum" runat="server" Text='<%# Eval("memorandum") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Póliza" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columpoliza" runat="server" Text='<%# Eval("poliza") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="Fecha de elaboración"  ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columfecha_elaboracion" runat="server"    DataFormatString="{0:dd-MM-yyyy}" Text='<%# Eval("fecha_elaboracion") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                                 <asp:TemplateField HeaderText="Fecha de pago" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columfecha_pago" runat="server" Text='<%# Eval("fecha_pago") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>

                                                              

                                                                 <asp:TemplateField HeaderText="Usuario" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columusuario" runat="server" Text='<%# Eval("usuario") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:TemplateField>
                                                                 <asp:TemplateField HeaderText="fecha_aplicacion" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="columfecha_aplicacion" runat="server" Text='<%# Eval("fecha_aplicacion") %>'></asp:Label>
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
                                            <!--
                                            <div id="dvBtnQna" runat="server" visible="false">
                                                <asp:Button ID="bntPreparaProducto" runat="server" Text="Preparar producto" CssClass="btn btn-primary" align="center" data-toggle="modal" data-target="#Confirmacion" OnClientClick="return false;" />


                                            </div>-->

                                            

                                        </div>

                                        <div id="dvMsgFinal" runat="server" visible="false" class="alert alert-success">
                                            <strong>Correcto: </strong>
                                            <asp:Label ID="MsgOkInsert" runat="server" Text=""></asp:Label>
                                        </div>





                                    </div>
                                   
                                </form>










                            </ContentTemplate>



                        </asp:UpdatePanel>
                    </div>

                </div>
            </div>
        </div>






        <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="UpdatePanelRegistroPolizas">
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
