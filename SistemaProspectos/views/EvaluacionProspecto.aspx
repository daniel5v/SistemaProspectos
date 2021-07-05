<%@ Page Title="" Language="C#" MasterPageFile="~/views/Site.Master" AutoEventWireup="true" CodeBehind="EvaluacionProspecto.aspx.cs" Inherits="SistemaProspectos.views.EvaluacionProspecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-3">
            <div class="col text-lg-start text-sm-center">
                <hr />
                <h5 class="text-primary">Evaluación del prospecto</h5>
            </div>            
        </div>

        <div class="row">
            <p class="text-primary pl-6">Información Prospecto</p>
        </div>

        <div class="row mb-2">
            <div class="col">
                <label class="form-label" for="ctl00$content$txtNombre">
                    <i class="fas fa-user"></i>&nbsp;Nombre:
                </label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-2">
            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtApellidoPaterno">
                    <i class="fas fa-user"></i>&nbsp;Apellido Paterno:
                </label>
                <asp:TextBox ID="txtApellidoPaterno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtApellidoMaterno">
                    <i class="fas fa-user"></i>&nbsp;Apellido Materno:
                </label>
                <asp:TextBox ID="txtApellidoMaterno" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-2">
            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtCalle">
                    <i class="fas fa-road"></i>&nbsp;Calle:
                </label>
                <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtNumero">
                    <i class="fas fa-hashtag"></i>&nbsp;Número:
                </label>
                <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-2">
            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtColonia">
                    <i class="fas fa-building"></i>&nbsp;Colonia:
                </label>
                <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtCodigoPostal">
                    <i class="fas fa-address-card"></i>&nbsp;Código Postal:
                </label>
                <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-2">
            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtTelefono">
                    <i class="fas fa-phone-alt"></i>&nbsp:Teléfono:
                </label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtRfc">
                    <i class="fas fa-id-card"></i>&nbsp;RFC:
                </label>
                <asp:TextBox ID="txtRfc" runat="server" CssClass="form-control text-uppercase" ReadOnly="true"></asp:TextBox>
            </div>
        </div>

        <div class="row mb-4">
            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtStatus">
                    <i class="fas fa-check-circle"></i>&nbsp;Status:
                </label>
                <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
            </div>

            <div class="col-lg-6 col-sm-12">
                <label class="form-label" for="ctl00$content$txtStatus">
                    <i class="fas fa-clipboard"></i>&nbsp;Observación de rechazo:
                </label>
                <asp:TextBox ID="txtObservacion" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="frvObservacion" runat="server" ErrorMessage="Completa este campo."
                    CssClass="text-danger" Display="Dynamic" ControlToValidate="txtObservacion" ValidationGroup="vgRechazo">
                </asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="row mb-3 text-center">
            <div class="col-lg-6 col-sm-12 offset-lg-3 offset-sm-0 row">
                <div class="col">
                    <asp:LinkButton ID="btnAutorizar" runat="server" CssClass="btn btn-success w-100" OnClick="btnAutorizar_Click">Autorizar</asp:LinkButton>
                </div>
                <div class="col">
                    <asp:LinkButton ID="btnRechazar" runat="server" CssClass="btn btn-danger w-100" OnClick="btnRechazar_Click" ValidationGroup="vgRechazo">Rechazar</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
