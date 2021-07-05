using SistemaProspectos.data;
using SistemaProspectos.data.dto;
using SistemaProspectos.data.enums;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaProspectos.views
{
    public partial class AgregarProspecto : System.Web.UI.Page
    {
        #region Variables
        private List<DTODocumentos> Files;
        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Session["Files"] == null)
                {
                    Session["Files"] = new List<DTODocumentos>();
                }
            }
            catch(Exception)
            {
                Response.Redirect("~/Error", true);
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje;
                if(ValidarCampos(out mensaje))
                {
                    var prospecto = CrearProspecto();
                    var documentos = CrearDocumentos();
                    using(DataContext dcTemp = new DCGlobalDataContext())
                    {
                        prospecto.DocumentosProspecto.AddRange(documentos);
                        dcTemp.GetTable<Prospecto>().InsertOnSubmit(prospecto);
                        dcTemp.SubmitChanges();
                    }
                    Response.Redirect("~/prospectos", true);
                }
                else
                {
                    var script = @"setTimeout(() =>
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: '" + mensaje + @"',
                            confirmButtonText: 'Aceptar',
                            confirmButtonColor: '#6c757d',
                            }), 110);";
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "message", script, true);
                }
                
            }
            catch(Exception)
            {
                var script = @"setTimeout(() =>
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'Ha ocurrido un error, intenta nuevamente.',
                            confirmButtonText: 'Aceptar',
                            confirmButtonColor: '#6c757d',
                            }), 110);";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "message", script, true);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if(fuFile.HasFile)
                {
                    if(Files == null)
                    {
                        Files = (List<DTODocumentos>)Session["Files"];
                    }
                    var newFile = new DTODocumentos
                    {
                        Id = DateTime.Now.Ticks,
                        NombreDocumento = txtNombreDocumento.Text,
                        Documento = fuFile.PostedFile.FileName,
                        File = fuFile.PostedFile
                    };
                    Files.Add(newFile);
                    dgvDocumentos.DataSource = Files;
                    dgvDocumentos.DataBind();
                    pnlAlert.Visible = false;
                }
            }
            catch(Exception)
            {
                var script = @"setTimeout(() =>
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'Ha ocurrido un error, intenta nuevamente.',
                            confirmButtonText: 'Aceptar',
                            confirmButtonColor: '#6c757d',
                            }), 110);";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "message", script, true);
            }
        }

        protected void dgvDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if(e.CommandName == "Eliminar")
                {
                    int index = Convert.ToInt32(e.CommandArgument);
                    long id = Convert.ToInt64(dgvDocumentos.DataKeys[index].Value);
                    if(Files == null)
                    {
                        Files = (List<DTODocumentos>)Session["Files"];
                    }
                    if(Files.Count > 0 && index < Files.Count && Files[index].Id == id)
                    {
                        Files.RemoveAt(index);
                        dgvDocumentos.DataSource = Files;
                        dgvDocumentos.DataBind();
                        pnlAlert.Visible = Files.Count == 0;
                    }
                }
            }
            catch(Exception)
            {
                var script = @"setTimeout(() =>
                        Swal.fire({
                            icon: 'error',
                            title: 'Error',
                            text: 'Ha ocurrido un error, intenta nuevamente.',
                            confirmButtonText: 'Aceptar',
                            confirmButtonColor: '#6c757d',
                            }), 110);";
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "message", script, true);
            }
        }
        #endregion

        #region Methods
        private Prospecto CrearProspecto()
        {
            var nombre = txtNombre.Text.Trim();
            var apellido_paterno = txtApellidoPaterno.Text.Trim();
            var apellido_materno = txtApellidoMaterno.Text.Trim();
            var calle = txtCalle.Text.Trim();
            var numero = txtNumero.Text.Trim();
            var colonia = txtColonia.Text.Trim();
            var codigo_postal = txtCodigoPostal.Text.Trim();
            var telefono = txtTelefono.Text.Trim();
            var rfc = txtRfc.Text.Trim().ToUpper();
            var prospecto = new Prospecto
            {
                nombre = nombre,
                apellido_paterno = apellido_paterno,
                apellido_materno = apellido_materno,
                calle = calle,
                numero = int.Parse(numero),
                colonia = colonia,
                codigo_postal = int.Parse(codigo_postal),
                telefono = telefono,
                rfc = rfc,
                id_status_prospecto = (int)Status_Prospecto.Enviado
            };
            return prospecto;
        }

        private List<DocumentosProspecto> CrearDocumentos()
        {
            Files = (List<DTODocumentos>)Session["Files"];
            var documentos = new List<DocumentosProspecto>();
            if(Files != null && Files.Count > 0)
            {
                var folder = $"{Server.MapPath(@"~/files/")}{Guid.NewGuid()}";
                Directory.CreateDirectory(folder);
                foreach(var file in Files)
                {
                    var ext = file.Documento.Split('.').LastOrDefault();
                    var path = $"{folder}\\doc-{DateTime.Now.Ticks}.{ext}";
                    documentos.Add(new DocumentosProspecto
                    {
                        nombre_documento = file.NombreDocumento,
                        documento = file.Documento,
                        ext = ext,
                        ruta = path,
                    });
                    file.File.SaveAs(path);
                }
            }
            return documentos;
        }
        #endregion

        #region Validation
        private bool ValidarCampos(out string mensaje)
        {
            if(!ValidarNulos(out mensaje))
            {
                return false;
            }
            if(!ValidaRegistro(out mensaje))
            {
                return false;
            }
            mensaje = string.Empty;
            return true;
        }

        private bool ValidarNulos(out string mensaje)
        {            
            if(string.IsNullOrEmpty(txtNombre.Text))
            {
                mensaje = "Nombre vacío.";
                return false;
            }
            if(string.IsNullOrEmpty(txtApellidoPaterno.Text))
            {
                mensaje = "Apellido Paterno vacío.";
                return false;
            }
            if(string.IsNullOrEmpty(txtCalle.Text))
            {
                mensaje = "Calle vacía.";
                return false;
            }
            if(string.IsNullOrEmpty(txtNumero.Text))
            {
                mensaje = "Número vacío.";
                return false;
            }
            if(string.IsNullOrEmpty(txtColonia.Text))
            {
                mensaje = "Colonia vacía.";
                return false;
            }
            if(string.IsNullOrEmpty(txtCodigoPostal.Text))
            {
                mensaje = "Código Postal vacío.";
                return false;
            }
            if(string.IsNullOrEmpty(txtTelefono.Text))
            {
                mensaje = "Teléfono vacío.";
                return false;
            }
            if(string.IsNullOrEmpty(txtRfc.Text))
            {
                mensaje = "RFC vacío.";
                return false;
            }
            Files = (List<DTODocumentos>)Session["Files"];
            if(Files == null || !Files.Any())
            {
                mensaje = "Faltan agregar documentos.";
                return false;
            }
            mensaje = string.Empty;
            return true;
        }

        private bool ValidaRegistro(out string mensaje)
        {
            if(!Regex.IsMatch(txtNumero.Text.Trim(), @"^\d{1,4}$"))
            {
                mensaje = "El Número no es válido.";
                return false;
            }
            if(!Regex.IsMatch(txtCodigoPostal.Text.Trim(), @"^\d{5}$"))
            {
                mensaje = "El Cósigo Postal no es válido.";
                return false;
            }
            if(!Regex.IsMatch(txtTelefono.Text.Trim(), @"^\d{10}$"))
            {
                mensaje = "El Teléfono no es válido.";
                return false;
            }
            if(!Regex.IsMatch(txtRfc.Text.Trim(), @"^[a-zA-Z]{4}\d{6}[a-zA-Z\d]{3}$"))
            {
                mensaje = "El RFC no es válido.";
                return false;
            }
            mensaje = string.Empty;
            return true;
        }
        #endregion
    }
}