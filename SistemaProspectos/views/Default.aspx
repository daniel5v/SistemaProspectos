<%@ Page Title="" Async="true" Language="C#" MasterPageFile="~/views/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SistemaProspectos.views.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%=Page.ResolveUrl("~/content/css/paging.css") %>" />
    <link rel="stylesheet" href="<%=Page.ResolveUrl("~/content/css/updateprogress.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="upGeneral" runat="server">
        <ContentTemplate>
            <div class="container p-3">
                <div class="row mb-3">
                    <div class="col-lg-6 col-sm-12 text-lg-start text-sm-center">
                        <h5 class="text-primary">Lista de Prospectos</h5>
                    </div>
                    <div class="col-lg-6 col-sm-12 text-lg-end text-sm-start">
                        <asp:LinkButton ID="btnAgregar" runat="server" CssClass="btn btn-primary" OnClick="btnAgregar_Click">
                            <i class="fas fa-plus"></i>
                                &nbsp;Agregar
                        </asp:LinkButton>
                    </div>
                </div>

                <div class="table-responsive">
                    <asp:GridView ID="dgvProspecto" runat="server" AutoGenerateColumns="false" DataKeyNames="id"
                        CssClass="table table-hover" AllowPaging="true" AllowCustomPaging="true" PageSize="10"
                        OnPageIndexChanging="dgvProspecto_PageIndexChanging" OnRowCommand="dgvProspecto_RowCommand">
                        <PagerStyle CssClass="table-paging" />
                        <HeaderStyle CssClass="text-center" />
                        <Columns>
                            <asp:BoundField DataField="Nombre" HeaderText="Nombre" ReadOnly="True" />
                            <asp:BoundField DataField="Apellido_paterno" HeaderText="Apellido Paterno" ReadOnly="True" />
                            <asp:BoundField DataField="Apellido_materno" HeaderText="Apellido Materno" ReadOnly="True" />
                            <asp:TemplateField HeaderText="Status" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <span class='<%# Eval("StatusClass") %>'>
                                        <%# Eval("Status") %>
                                    </span>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Evaluación" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEvaluacion" CssClass="btn btn-light" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Evaluacion">
                                        <span class="fas fa-clipboard-list"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Detalle" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDetalle" CssClass="btn btn-light" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Detalle">
                                        <span class="fas fa-info-circle"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="Numeric" PageButtonCount="5" />
                    </asp:GridView>
                </div>

                <asp:Panel ID="pnlAlert" runat="server" CssClass="alert alert-primary" Visible="false" role="alert" data-mdb-color="primary">
                    Aún no se han registrado prospectos.
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>         
            <asp:AsyncPostBackTrigger ControlID="dgvProspecto" EventName="RowCommand" />   
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="upLoadGeneral" runat="server" AssociatedUpdatePanelID="upGeneral" DisplayAfter="0">
        <ProgressTemplate>
            <div class="overlay">
                <div class="overlayContent">
                    <h2>Espere un momento.</h2>
                    <img src="<%=Page.ResolveUrl("~/content/img/load-spinner.svg") %>" alt="Cargando" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <!-- Modal Info -->
    <div class="modal fade" id="info" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Detalle Prospecto</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upModal" runat="server">
                        <ContentTemplate>
                            <div class="row">
                                <p class="text-primary pl-6">Información Prospecto</p>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtNombre">
                                        <i class="fas fa-user"></i>&nbsp;Nombre:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtApellidoPaterno">
                                        <i class="fas fa-user"></i>&nbsp;Apellido Paterno:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtApellidoMaterno">
                                        <i class="fas fa-user"></i>&nbsp;Apellido Materno:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtCalle">
                                        <i class="fas fa-road"></i>&nbsp;Calle:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtNumero">
                                        <i class="fas fa-hashtag"></i>&nbsp;Número:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtColonia">
                                        <i class="fas fa-building"></i>&nbsp;Colonia:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtCodigoPostal">
                                        <i class="fas fa-address-card"></i>&nbsp;Código Postal:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtTelefono">
                                        <i class="fas fa-phone-alt"></i>&nbsp;Teléfono:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtRfc">
                                        <i class="fas fa-id-card"></i>&nbsp;RFC:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtRfc" runat="server" CssClass="form-control text-uppercase" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <div class="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtStatus">
                                        <i class="fas fa-check-circle"></i>&nbsp;Status:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                </div>
                            </div>

                            <asp:Panel ID="pnlObservacion" runat="server" CssClass="row mb-2">
                                <div class="col-lg-5 col-sm-12">
                                    <label class="form-label" for="ctl00$content$txtStatus">
                                        <i class="fas fa-clipboard"></i>&nbsp;Observación de rechazo:
                                    </label>
                                </div>
                                <div class="col-lg-7 col-sm-12">
                                    <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true"></asp:TextBox>
                                </div>
                            </asp:Panel>

                            <div class="row">
                                <p class="text-primary pl-6">Documentos Prospecto</p>
                            </div>

                            <div class="row">
                                <div class="table-responsive">
                                    <asp:GridView ID="dgvDocumentos" runat="server" AutoGenerateColumns="false"
                                        CssClass="table table-hover" AllowPaging="true" AllowCustomPaging="true" PageSize="5"
                                        OnPageIndexChanging="dgvDocumentos_PageIndexChanging" OnRowCommand="dgvDocumentos_RowCommand">
                                        <PagerStyle CssClass="table-paging" />
                                        <HeaderStyle CssClass="text-center" />
                                        <Columns>
                                            <asp:BoundField DataField="NombreDocumento" HeaderText="Nombre" ReadOnly="True" />
                                            <asp:BoundField DataField="Documento" HeaderText="Documento" ReadOnly="True" />
                                            <asp:TemplateField HeaderText="Descargar" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDescargar" CssClass="btn btn-light" runat="server" CommandArgument='<%# Eval("id")%>' CommandName="Descargar">
                                                        <span class="fas fa-download text-primary"></span>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <PagerSettings Mode="Numeric" PageButtonCount="5" />
                                    </asp:GridView>
                                </div>
                        </ContentTemplate>
                        <Triggers>                            
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdateProgress ID="upLoad" runat="server" AssociatedUpdatePanelID="upModal" DisplayAfter="0">
        <ProgressTemplate>
            <div class="overlay">
                <div class="overlayContent">
                    <h2>Espere un momento.</h2>
                    <img src="<%=Page.ResolveUrl("~/content/img/load-spinner.svg") %>" alt="Cargando" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
