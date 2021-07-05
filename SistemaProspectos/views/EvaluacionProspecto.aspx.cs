using SistemaProspectos.data;
using SistemaProspectos.data.dto;
using SistemaProspectos.data.enums;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SistemaProspectos.views
{
    public partial class EvaluacionProspecto : System.Web.UI.Page
    {
        #region Events
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    txtObservacion.Attributes.Add("maxlength", "150");
                    LoadInformation();
                }
            }
            catch(Exception)
            {
                Response.Redirect("~/Error", true);
            }
        }

        protected void btnAutorizar_Click(object sender, EventArgs e)
        {
            try
            {
                using(DataContext dcTemp = new DCGlobalDataContext())
                {
                    int id = Convert.ToInt32(Session["id_prospecto"]);
                    Expression<Func<DataContext, Prospecto>> query =
                        dc => dc.GetTable<Prospecto>()
                            .FirstOrDefault(prospecto => prospecto.id == id);
                    var result = CompiledQuery.Compile(query).Invoke(dcTemp);
                    result.id_status_prospecto = (int)Status_Prospecto.Autorizado;
                    dcTemp.SubmitChanges();
                    Session.Remove("id_prospecto");
                    Response.Redirect("~/prospectos", true);
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

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            try
            {
                using(DataContext dcTemp = new DCGlobalDataContext())
                {
                    int id = Convert.ToInt32(Session["id_prospecto"]);
                    Expression<Func<DataContext, Prospecto>> query =
                        dc => dc.GetTable<Prospecto>()
                            .FirstOrDefault(prospecto => prospecto.id == id);
                    var result = CompiledQuery.Compile(query).Invoke(dcTemp);
                    result.id_status_prospecto = (int)Status_Prospecto.Rechazado;
                    result.observacion = txtObservacion.Text;
                    dcTemp.SubmitChanges();
                    Session.Remove("id_prospecto");
                    Response.Redirect("~/prospectos", true);
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
        private void LoadInformation()
        {
            using(DataContext dcTemp = new DCGlobalDataContext())
            {
                int id = Convert.ToInt32(Session["id_prospecto"]);
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
                }
                else
                {
                    Response.Redirect("~/prospectos", true);
                }
            }
        } 
        #endregion
    }
}