<%@ Page Title="" Language="C#" MasterPageFile="~/views/Site.Master" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="SistemaProspectos.views.error.Error" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row mb-4"></div>
        <div class="row">
            <div class="col-lg-6 col-sm-12 offset-lg-3 offset-sm-0 row">
                <div class="col">
                    <div class="alert alert-danger text-center" role="alert">
                        <i class="fas fa-ban"></i>&nbsp;<strong>Ha ocurrido un error inesperado al procesar la solicitud.</strong>
                        <div class="row mb-2"></div>
                        <div class="row">
                            <div class="col text-center">
                                <asp:LinkButton ID="btnInicio" runat="server" CssClass="btn btn-danger w-25" PostBackUrl="~/prospectos">
                                    <i class="fas fa-home"></i>&nbsp;Inicio
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
