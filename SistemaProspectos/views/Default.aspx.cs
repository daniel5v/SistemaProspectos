using SistemaProspectos.data;
using SistemaProspectos.data.dto;
using SistemaProspectos.data.enums;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaProspectos.views
{
    public partial class Default : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    LoadGridView(0);
                    Session["Files"] = null;
                }
            }
            catch(Exception)
            {
                Response.Redirect("~/Error", true);
            }
        }

        protected void dgvProspecto_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvProspecto.PageIndex = e.NewPageIndex;
                LoadGridView(e.NewPageIndex);
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

        protected void dgvProspecto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(e.CommandArgument);
                if(e.CommandName == "Detalle")
                {
                    DetalleProspecto(id);
                }
                else if(e.CommandName == "Evaluacion")
                {
                    EvaluacionProspecto(id);
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

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Clear();
                Response.Redirect("~/agregar-prospecto", true);
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
                if(e.CommandName == "Descargar")
                {
                    var id = Convert.ToInt32(e.CommandArgument);
                    using(DataContext dcTemp = new DCGlobalDataContext())
                    {
                        Expression<Func<DataContext, DocumentosProspecto>> query =
                            dc => dc.GetTable<DocumentosProspecto>()
                                .FirstOrDefault(documento => documento.id == id);
                        var result = CompiledQuery.Compile(query).Invoke(dcTemp);
                        var doc = new FileStream(result.ruta, FileMode.Open);
                        using(MemoryStream stream = new MemoryStream())
                        {
                            doc.CopyTo(stream);
                            HttpContext.Current.Response.ContentType = GetContentType(result.ext);
                            HttpContext.Current.Response.AddHeader("content-disposition", $"attachment;filename={result.documento}");
                            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            HttpContext.Current.Response.BinaryWrite(stream.ToArray());
                            HttpContext.Current.Response.Flush();
                            HttpContext.Current.Response.SuppressContent = true;
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                            HttpContext.Current.Response.Write(stream);
                            HttpContext.Current.ApplicationInstance.CompleteRequest();
                        }
                        doc.Close();
                        doc.Dispose();
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

        protected void dgvDocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                dgvDocumentos.PageIndex = e.NewPageIndex;
                LoadGridViewDocuments(e.NewPageIndex);
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
        private void LoadGridView(int page)
        {
            using(DataContext dcTemp = new DCGlobalDataContext { ObjectTrackingEnabled = false })
            {
                Expression<Func<DataContext, IQueryable<object>>> expression =
                dc => dc.GetTable<Prospecto>()
                    .OrderByDescending(prospecto => prospecto.id)
                    .Select(prospecto => new
                    {
                        Id = prospecto.id,
                        Nombre = prospecto.nombre,
                        Apellido_paterno = prospecto.apellido_paterno,
                        Apellido_materno = prospecto.apellido_materno,
                        Status = prospecto.StatusProspecto.valor,
                        StatusClass = prospecto.id_status_prospecto == (int)Status_Prospecto.Enviado ?
                            "badge bg-light text-dark" : prospecto.id_status_prospecto == (int)Status_Prospecto.Autorizado ?
                            "badge bg-success" : "badge bg-danger"
                    });
                var result = CompiledQuery.Compile(expression);
                int count = result.Invoke(dcTemp).Count();
                if(count == 0)
                {
                    pnlAlert.Visible = true;
                }
                else
                {
                    Expression<Func<DataContext, IQueryable<object>>> query =
                    dc => result(dc)
                        .Skip(page * dgvProspecto.PageSize)
                        .Take(dgvProspecto.PageSize);
                    var list = query.Compile().Invoke(dcTemp).ToList();
                    dgvProspecto.VirtualItemCount = count;
                    dgvProspecto.DataSource = list;
                    dgvProspecto.DataBind();
                    pnlAlert.Visible = false;
                }
            }
        }

        private void LoadGridViewDocuments(int page)
        {
            int id = Convert.ToInt32(Session["id_prospecto"]);
            using(DataContext dcTemp = new DCGlobalDataContext { ObjectTrackingEnabled = false })
            {
                Expression<Func<DataContext, IQueryable<object>>> expression =
                    dc => dc.GetTable<DocumentosProspecto>()
                    .Where(documento => documento.id_prospecto == id)
                    .Select(documento => new
                    {
                        Id = documento.id,
                        NombreDocumento = documento.nombre_documento,
                        Documento = documento.documento
                    });
                var result = CompiledQuery.Compile(expression);
                int count = result.Invoke(dcTemp).Count();
                Expression<Func<DataContext, IQueryable<object>>> query =
                    dc => result(dc)
                        .Skip(page * dgvDocumentos.PageSize)
                        .Take(dgvDocumentos.PageSize);
                var list = query.Compile().Invoke(dcTemp).ToList();
                dgvDocumentos.VirtualItemCount = count;
                dgvDocumentos.DataSource = list;
                dgvDocumentos.DataBind();
            }
        }

        private void DetalleProspecto(int id)
        {            
            using(DataContext dcTemp = new DCGlobalDataContext())
            {
                Expression<Func<DataContext, DTOProspecto>> query =
                    dc => dc.GetTable<Prospecto>()
                        .Where(prospecto => prospecto.id == id)
                        .Select(prospecto => new DTOProspecto
                        {
                            Id = prospecto.id,
                            Nombre = prospecto.nombre,
                            APaterno = prospecto.apellido_paterno,
                            AMaterno = prospecto.apellido_materno,
                            Calle = prospecto.calle,
                            Numero = Convert.ToString(prospecto.numero),
                            Colonia = prospecto.colonia,
                            CodigoPostal = Convert.ToString(prospecto.codigo_postal),
                            Telefono = prospecto.telefono,
                            Rfc = prospecto.rfc,
                            Status = prospecto.StatusProspecto.valor,
                            Observacion = prospecto.observacion
                        })
                        .FirstOrDefault();
                var result = CompiledQuery.Compile(query).Invoke(dcTemp);
                if(result != null)
                {
                    Session["id_prospecto"] = result.Id;
                    txtNombre.Text = result.Nombre;
                    txtApellidoPaterno.Text = result.APaterno;
                    txtApellidoMaterno.Text = result.AMaterno;
                    txtCalle.Text = result.Calle;
                    txtNumero.Text = result.Numero;
                    txtColonia.Text = result.Colonia;
                    txtCodigoPostal.Text = result.CodigoPostal;
                    txtTelefono.Text = result.Telefono;
                    txtRfc.Text = result.Rfc;
                    txtStatus.Text = result.Status;
                    if(string.IsNullOrEmpty(result.Observacion))
                    {
                        pnlObservacion.Visible = false;
                        txtObservacion.Text = string.Empty;
                    }
                    else
                    {
                        pnlObservacion.Visible = true;
                        txtObservacion.Text = result.Observacion;
                    }
                    LoadGridViewDocuments(0);
                    var script = "setTimeout(() => new bootstrap.Modal(document.getElementById('info')).show(), 110)";
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "modal", script, true);
                }
                else
                {
                    Session.Remove("id_prospecto");
                }
            }
        }

        private void EvaluacionProspecto(int id)
        {
            using(DataContext dcTemp = new DCGlobalDataContext())
            {

                Expression<Func<DataContext, bool>> query =
                    dc => dc.GetTable<Prospecto>()
                        .Any(prospecto => prospecto.id == id &&
                            prospecto.id_status_prospecto == (int)Status_Prospecto.Enviado);
                var result = CompiledQuery.Compile(query).Invoke(dcTemp);
                if(result)
                {
                    Session["id_prospecto"] = id;
                    Response.Redirect("~/evaluar-prospecto", true);
                }
                else
                {
                    var script = @"setTimeout(() =>
                        Swal.fire({
                            icon: 'info',
                            title: 'Información',
                            text: 'El prospecto seleccionado ya ha sido evaluado.',
                            confirmButtonText: 'Aceptar',
                            confirmButtonColor: '#6c757d',
                            }), 110);";                    
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "message", script, true);
                }
            }            
        }

        private string GetContentType(string ext)
        {
            switch(ext.ToLower())
            {
                case "jpeg":
                    return "image/jpeg";
                case "jpg":
                    goto case "jpeg";
                case "png":
                    return "image/png";
                case "pdf":
                    return "application/pdf";
                case "doc":
                    return "application/msword";
                case "docx":
                    return "application/vnd.openxmlformats-officedocument.wordprocessingml.document";
                case "xls":
                    return "application/vnd.ms-excel";
                case "xlsx":
                    return "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                default:
                    return "text/plain";
            }
        }
        #endregion        
    }
}