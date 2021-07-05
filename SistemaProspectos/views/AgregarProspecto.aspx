<%@ Page Title="" Language="C#" MasterPageFile="~/views/Site.Master" AutoEventWireup="true" CodeBehind="AgregarProspecto.aspx.cs" Inherits="SistemaProspectos.views.AgregarProspecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <p class="text-primary pl-6">Información Prospecto</p>
        </div>

        <div class="row">
            <div class="col">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtNombre" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtNombre">
                        <i class="fas fa-user"></i>
                    </label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" MaxLength="50" placeholder="Nombre"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <asp:RequiredFieldValidator ID="rfvAPaterno" runat="server" ErrorMessage="Completa este campo."
                CssClass="text-danger" Display="Dynamic" ControlToValidate="txtApellidoPaterno" ValidationGroup="vgProspecto">
            </asp:RequiredFieldValidator>
            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtApellidoPaterno">
                        <i class="fas fa-user"></i>
                    </label>
                    <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" MaxLength="50" placeholder="Apellido Paterno"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-12">
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtApellidoMaterno">
                        <i class="fas fa-user"></i>
                    </label>
                    <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" MaxLength="50" placeholder="Apellido Materno"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <asp:RequiredFieldValidator ID="rfvCalle" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCalle" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtCalle">
                        <i class="fas fa-road"></i>
                    </label>
                    <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" MaxLength="50" placeholder="Calle"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-12">
                <asp:RequiredFieldValidator ID="rfvNumero" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtNumero" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revNuemro" runat="server" ErrorMessage="El Número no es válido."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtNumero"
                    ValidationExpression="^\d{1,4}$" ValidationGroup="vgProspecto">
                </asp:RegularExpressionValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtNumero">
                        <i class="fas fa-hashtag"></i>
                    </label>
                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" MaxLength="4" placeholder="Número"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <asp:RequiredFieldValidator ID="rfvColonia" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtColonia" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtColonia">
                        <i class="fas fa-building"></i>
                    </label>
                    <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control" MaxLength="50" placeholder="Colonia"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-12">
                <asp:RequiredFieldValidator ID="rfvCodigoPostal" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCodigoPostal" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revCodigoPostal" runat="server" ErrorMessage="El Cósigo Postal no es válido."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtCodigoPostal"
                    ValidationExpression="^\d{5}$" ValidationGroup="vgProspecto">
                </asp:RegularExpressionValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtCodigoPostal">
                        <i class="fas fa-address-card"></i>
                    </label>
                    <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" MaxLength="5" placeholder="Código Postal"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-lg-6 col-md-6 col-sm-12">
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtTelefono" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ErrorMessage="El Teléfono no es válido."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtTelefono"
                    ValidationExpression="^\d{10}$" ValidationGroup="vgProspecto">
                </asp:RegularExpressionValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtTelefono">
                        <i class="fas fa-phone-alt"></i>
                    </label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="10" placeholder="Teléfono"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 col-md-6 col-sm-12">
                <asp:RequiredFieldValidator ID="rfvRfc" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtRfc" ValidationGroup="vgProspecto">
                </asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revRfc" runat="server" ErrorMessage="El RFC no es válido."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtRfc"
                    ValidationExpression="^[a-zA-Z]{4}\d{6}[a-zA-Z\d]{3}$" ValidationGroup="vgProspecto">
                </asp:RegularExpressionValidator>
                <div class="input-group mb-3">
                    <label class="input-group-text" for="ctl00$content$txtRfc">
                        <i class="fas fa-id-card"></i>
                    </label>
                    <asp:TextBox ID="txtRfc" runat="server" CssClass="form-control text-uppercase" MaxLength="13" placeholder="RFC"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <p class="text-primary pl-6">Documentos Prospecto</p>
        </div>

        <div class="row mb-3">
            <div class="col">
                <button type="button" class="btn btn-primary" onclick="showModal();">
                    <i class="fas fa-plus"></i>
                </button>
            </div>
        </div>

        <div class="row">
            <div class="table-responsive">
                <asp:GridView ID="dgvDocumentos" runat="server" AutoGenerateColumns="false" CssClass="table table-hover"
                    DataKeyNames="Id" OnRowCommand="dgvDocumentos_RowCommand">
                    <HeaderStyle CssClass="text-center" />
                    <Columns>
                        <asp:BoundField DataField="NombreDocumento" HeaderText="Nombre" ReadOnly="True" />
                        <asp:BoundField DataField="Documento" HeaderText="Documento" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Eliminar" ItemStyle-CssClass="text-center">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEliminar" CssClass="btn btn-light" runat="server" CommandArgument='<%# Container.DataItemIndex%>' CommandName="Eliminar">
                                        <span class="fas fa-trash-alt text-danger"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:Panel ID="pnlAlert" runat="server" CssClass="alert alert-primary" role="alert" data-mdb-color="primary">
                    Aún no se han agregado documentos.
                </asp:Panel>
            </div>
        </div>

        <div class="row mb-3 text-center">
            <div class="col-lg-6 col-sm-12 offset-lg-3 offset-sm-0 row">
                <div class="col">
                    <asp:LinkButton ID="btnEnviar" runat="server" CssClass="btn btn-success w-100" ValidationGroup="vgProspecto" OnClick="btnEnviar_Click">Enviar</asp:LinkButton>
                </div>
                <div class="col">
                    <asp:LinkButton ID="btnSalir" runat="server" CssClass="btn btn-danger w-100" OnClientClick="confirm(this, event);" PostBackUrl="~/prospectos">Salir</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal Documentos -->
    <div class="modal fade" id="documentos" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Agregar documento</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <div class="row">
                        <div class="col">
                            <asp:RequiredFieldValidator ID="rfvNombreDocumento" runat="server" ErrorMessage="Completa este campo."
                                CssClass="text-danger" Display="Dynamic" ControlToValidate="txtNombreDocumento" ValidationGroup="vgDocumentos">
                            </asp:RequiredFieldValidator>
                            <div class="input-group mb-3">
                                <label class="input-group-text" for="txtArchivo">
                                    <i class="fas fa-file-signature"></i>
                                </label>
                                <asp:TextBox ID="txtNombreDocumento" runat="server" CssClass="form-control" MaxLength="50" placeholder="Nombre del Documento"></asp:TextBox>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <asp:RequiredFieldValidator ID="rfvDocumento" runat="server" ErrorMessage="Completa este campo."
                            CssClass="text-danger" Display="Dynamic" ControlToValidate="fuFile" ValidationGroup="vgDocumentos">
                        </asp:RequiredFieldValidator>

                        <asp:RegularExpressionValidator ID="revDocumento" runat="server" ErrorMessage="Archivo no permitido. (Solo .jpg, .jpeg, .png, .pdf, .docx, .xlsx)"
                            ValidationExpression="^.*\.(jpg|JPG|jpeg|JPEG|png|PNG|doc|DOC|docx|DOCX|pdf|PDF|xls|XLS|xlsx|XLSX)$"
                            CssClass="text-danger" Display="Dynamic" ControlToValidate="fuFile" ValidationGroup="vgDocumentos">                            
                        </asp:RegularExpressionValidator>

                        <asp:CustomValidator ID="cvDocumento" runat="server" ErrorMessage="El archivo es demasiado grande. (Máximo 3MB)"
                            ClientValidationFunction="validateFileSize"
                            CssClass="text-danger" Display="Dynamic" ControlToValidate="fuFile" ValidationGroup="vgDocumentos">

                        </asp:CustomValidator>

                        <div class="col">
                            <asp:FileUpload ID="fuFile" accept=".jpg,.jpeg,.png,.pdf,.docx,.doc,.xls,.xlsx" runat="server" CssClass="form-control" />
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton ID="btnAceptar" runat="server" CssClass="btn btn-primary" OnClick="btnAceptar_Click" ValidationGroup="vgDocumentos">Aceptar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

    <script>
        function confirm(ctrl, event) {
            const defaultAction = document.getElementById('btnSalir').href;
            event.preventDefault();
            Swal.fire({
                title: 'Advertencia',
                text: 'Si sale de la página se perderan los datos capturados. ¿Desea continuar?',
                icon: 'warning',
                showDenyButton: false,
                showCancelButton: true,
                confirmButtonText: 'Sí',
                cancelButtonText: 'No',
                confirmButtonColor: '#198754',
                cancelButtonColor: '#dc3545',
            }).then((result) => {
                if (result.isConfirmed) {
                    window.location.href = defaultAction;
                    return true;
                } else if (result.isDenied) {
                    return false;
                }
            });
        }

        function validateFileSize(ctrl, event) {
            let file = document.getElementById('fuFile');
            if (file.files.length === 0) {
                event.IsValid = true;
                return;
            }
            let size = file.files[0].size / 1024 / 1024;
            if (size > 3) {
                event.IsValid = false;
                return;
            }
            event.IsValid = true;
        }

        function showModal() {
            let modal = new bootstrap.Modal(document.getElementById('documentos'));
            let fileName = document.getElementById('txtNombreDocumento');
            let file = document.getElementById('fuFile');
            fileName.value = '';
            file.value = '';
            modal.show();
        }
    </script>
</asp:Content>
