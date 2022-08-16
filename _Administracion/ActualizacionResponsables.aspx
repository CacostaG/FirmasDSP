<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ActualizacionResponsables.aspx.cs" Inherits="ListadoDeFirmasDSP._Administracion.ActualizacionResponsables" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../Scripts/sweetalert.min.js"></script>
    <link href="../css/sweetalert.css" rel="stylesheet" />

    <div class="container-fluid">
        <div class="panel panel-default">
            <div class="panel-heading" style="font-family: 'Yu Gothic UI Semibold'">
                Actualización de responsables de jurisdicción u hospital
            </div>

            <div class="panel-body">
                <div class="row col-lg-12">

                    <asp:UpdatePanel ID="UpdatePaneActualizaResponsable" runat="server">
                        <contenttemplate>
                        <form class="form-inline">
                            <div class="form-group col-xs-12 col-md-6 col-lg-6">
                                <label class="control-label">Jurisdicción</label>
                                <asp:DropDownList ID="ddlJuris" runat="server"
                                    AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                    DataTextField="jurisdiccion"
                                    align="center"
                                    UseSubmitBehavior="False" OnSelectedIndexChanged="ddlJuris_SelectedIndexChanged">
                                    <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                </asp:DropDownList>
                                <div id="dvMessageJuris" runat="server" visible="false" class="alert alert-danger">
                                    <strong>Error:  </strong>
                                    <asp:Label ID="lblMensajeErrorJuris" runat="server" Text="" />
                                </div>
                            </div>

                            <div class="form-group col-xs-12 col-md-6 col-lg-6">
                                <asp:Label ID="txtJuris" Visible="false" Text="" runat="server"></asp:Label>
                                <label class="control-label">Cargo</label>
                                <asp:DropDownList ID="ddlCargo" runat="server"
                                    AppendDataBoundItems="True" AutoPostBack="True" CssClass="form-control"
                                    DataTextField="cargo"
                                    align="center"
                                    UseSubmitBehavior="False"
                                    enable="false"
                                    OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged">


                                    <asp:ListItem Value="0">Selecciona</asp:ListItem>
                                </asp:DropDownList>



                                <div id="dvMessageCargo" runat="server" visible="false" class="alert alert-danger">
                                    <strong>Error:  </strong>
                                    <asp:Label ID="Label1" runat="server" Text="" />
                                </div>

                            </div>





                            <div class="form-group col-xs-6 col-md-6 col-lg-12" id="dvMEmorandum" runat="server" visible ="false">
                                <label class="control-label">Responsable</label>
                                <asp:TextBox runat="server" class="form-control" value="" ID="txtResponsable"></asp:TextBox>




                            </div>


                            <div class="form-group col-xs-12 col-md-12 col-lg-12">
                                <!--
                                <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-success" Text="Guardar" data-toggle="modal" data-target="#Confirmacion" OnClientClick="return false;" />
                                -->
                                <asp:Button  ID="btnSave" runat ="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnSave_Click" visible="false"/>

                                <asp:Button ID="BtnClean" runat="server" OnClick="Limpiar_Click" Text="Limpiar" Height="35px" CssClass="btn btn-danger" align="center" />

                                <br />
                                <br />
                                <br />

                                <div class="container-fluid">
                                    <div class="row">
                                        <div class="col-md-12 col-xs-12 col-lg-12">
                                        <div class="table-responsive">
                                            <asp:GridView ID="gvResponsables" runat="server" AutoGenerateColumns="false"
                                              CssClass="table table-striped" BackColor="White" BorderColor="#999999"
                                                BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical"
                                                Width="100%" Style="font-size: 13px" >

                                               
                                                <HeaderStyle CssClass="thead-dark" BackColor="Black" Font-Bold="True" ForeColor="White" />
                                                <AlternatingRowStyle BackColor="#CCCCC1" />
                                                <Columns>                                               
                                                    <asp:TemplateField HeaderText="Jurisdicción" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Jurisdiccion" runat="server" Text='<%# Eval("jurisdiccion") %>'></asp:Label>
                                                        </ItemTemplate>

                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>

                                                     <asp:TemplateField HeaderText="Jefe de la jurisdicción" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Jefe" runat="server" Text='<%# Eval("jefe") %>'></asp:Label>
                                                        </ItemTemplate>

                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>                                         
                                                   
                                                     <asp:TemplateField HeaderText="Administrador" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Administrador" runat="server" Text='<%# Eval("administrador") %>'></asp:Label>
                                                        </ItemTemplate>

                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                    </asp:TemplateField>                                                   

                                                           <asp:TemplateField HeaderText="Director" ItemStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <asp:Label ID="Director" runat="server" Text='<%# Eval("director") %>'></asp:Label>
                                                        </ItemTemplate>
                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
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
                                            </h4>
                                        </div>
                                        <div class="modal-body">



                                            <label class="control-label">
                                                <center>La actualización se realizará con los siguientes datos:</center>
                                            </label>
                                            <br />
                                            <asp:Label ID="LbModalGuardar1" runat="server" Text=""></asp:Label><br />


                                        </div>
                                        <div class="modal-footer">
                                       <!--     <asp:Button ID="BtnGuardarM" runat="server" Text="Guardar" Height="35px" CssClass="btn btn-success" align="center" />



                                            <button type="button" class="btn btn-danger" data-dismiss="modal">Cancelar</button>-->
                                        </div>
                                    </div>

                                </div>
                            </div>





                            <asp:Label ID="idJurisTex" runat="server" Text="" Visible="false"></asp:Label>

                        </form>





                    </contenttemplate>


                    </asp:UpdatePanel>
                    

                    
                </div>
            </div>
        </div>
    </div>


    <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="UpdatePaneActualizaResponsable">
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
