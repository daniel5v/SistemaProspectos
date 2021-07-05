﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaProspectos.data
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="SistemaProspectos")]
	public partial class DCGlobalDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertProspecto(Prospecto instance);
    partial void UpdateProspecto(Prospecto instance);
    partial void DeleteProspecto(Prospecto instance);
    partial void InsertStatusProspecto(StatusProspecto instance);
    partial void UpdateStatusProspecto(StatusProspecto instance);
    partial void DeleteStatusProspecto(StatusProspecto instance);
    partial void InsertDocumentosProspecto(DocumentosProspecto instance);
    partial void UpdateDocumentosProspecto(DocumentosProspecto instance);
    partial void DeleteDocumentosProspecto(DocumentosProspecto instance);
    #endregion
		
		public DCGlobalDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SistemaProspectosPublish"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DCGlobalDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DCGlobalDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DCGlobalDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DCGlobalDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Prospecto> Prospecto
		{
			get
			{
				return this.GetTable<Prospecto>();
			}
		}
		
		public System.Data.Linq.Table<StatusProspecto> StatusProspecto
		{
			get
			{
				return this.GetTable<StatusProspecto>();
			}
		}
		
		public System.Data.Linq.Table<DocumentosProspecto> DocumentosProspecto
		{
			get
			{
				return this.GetTable<DocumentosProspecto>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Prospecto")]
	public partial class Prospecto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _nombre;
		
		private string _apellido_paterno;
		
		private string _apellido_materno;
		
		private string _calle;
		
		private int _numero;
		
		private string _colonia;
		
		private int _codigo_postal;
		
		private string _telefono;
		
		private string _rfc;
		
		private int _id_status_prospecto;
		
		private string _observacion;
		
		private EntitySet<DocumentosProspecto> _DocumentosProspecto;
		
		private EntityRef<StatusProspecto> _StatusProspecto;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnombreChanging(string value);
    partial void OnnombreChanged();
    partial void Onapellido_paternoChanging(string value);
    partial void Onapellido_paternoChanged();
    partial void Onapellido_maternoChanging(string value);
    partial void Onapellido_maternoChanged();
    partial void OncalleChanging(string value);
    partial void OncalleChanged();
    partial void OnnumeroChanging(int value);
    partial void OnnumeroChanged();
    partial void OncoloniaChanging(string value);
    partial void OncoloniaChanged();
    partial void Oncodigo_postalChanging(int value);
    partial void Oncodigo_postalChanged();
    partial void OntelefonoChanging(string value);
    partial void OntelefonoChanged();
    partial void OnrfcChanging(string value);
    partial void OnrfcChanged();
    partial void Onid_status_prospectoChanging(int value);
    partial void Onid_status_prospectoChanged();
    partial void OnobservacionChanging(string value);
    partial void OnobservacionChanged();
    #endregion
		
		public Prospecto()
		{
			this._DocumentosProspecto = new EntitySet<DocumentosProspecto>(new Action<DocumentosProspecto>(this.attach_DocumentosProspecto), new Action<DocumentosProspecto>(this.detach_DocumentosProspecto));
			this._StatusProspecto = default(EntityRef<StatusProspecto>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre
		{
			get
			{
				return this._nombre;
			}
			set
			{
				if ((this._nombre != value))
				{
					this.OnnombreChanging(value);
					this.SendPropertyChanging();
					this._nombre = value;
					this.SendPropertyChanged("nombre");
					this.OnnombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellido_paterno", DbType="VarChar(50)")]
		public string apellido_paterno
		{
			get
			{
				return this._apellido_paterno;
			}
			set
			{
				if ((this._apellido_paterno != value))
				{
					this.Onapellido_paternoChanging(value);
					this.SendPropertyChanging();
					this._apellido_paterno = value;
					this.SendPropertyChanged("apellido_paterno");
					this.Onapellido_paternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_apellido_materno", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string apellido_materno
		{
			get
			{
				return this._apellido_materno;
			}
			set
			{
				if ((this._apellido_materno != value))
				{
					this.Onapellido_maternoChanging(value);
					this.SendPropertyChanging();
					this._apellido_materno = value;
					this.SendPropertyChanged("apellido_materno");
					this.Onapellido_maternoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_calle", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string calle
		{
			get
			{
				return this._calle;
			}
			set
			{
				if ((this._calle != value))
				{
					this.OncalleChanging(value);
					this.SendPropertyChanging();
					this._calle = value;
					this.SendPropertyChanged("calle");
					this.OncalleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_numero", DbType="Int NOT NULL")]
		public int numero
		{
			get
			{
				return this._numero;
			}
			set
			{
				if ((this._numero != value))
				{
					this.OnnumeroChanging(value);
					this.SendPropertyChanging();
					this._numero = value;
					this.SendPropertyChanged("numero");
					this.OnnumeroChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_colonia", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string colonia
		{
			get
			{
				return this._colonia;
			}
			set
			{
				if ((this._colonia != value))
				{
					this.OncoloniaChanging(value);
					this.SendPropertyChanging();
					this._colonia = value;
					this.SendPropertyChanged("colonia");
					this.OncoloniaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_codigo_postal", DbType="Int NOT NULL")]
		public int codigo_postal
		{
			get
			{
				return this._codigo_postal;
			}
			set
			{
				if ((this._codigo_postal != value))
				{
					this.Oncodigo_postalChanging(value);
					this.SendPropertyChanging();
					this._codigo_postal = value;
					this.SendPropertyChanged("codigo_postal");
					this.Oncodigo_postalChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_telefono", DbType="VarChar(10) NOT NULL", CanBeNull=false)]
		public string telefono
		{
			get
			{
				return this._telefono;
			}
			set
			{
				if ((this._telefono != value))
				{
					this.OntelefonoChanging(value);
					this.SendPropertyChanging();
					this._telefono = value;
					this.SendPropertyChanged("telefono");
					this.OntelefonoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_rfc", DbType="VarChar(13) NOT NULL", CanBeNull=false)]
		public string rfc
		{
			get
			{
				return this._rfc;
			}
			set
			{
				if ((this._rfc != value))
				{
					this.OnrfcChanging(value);
					this.SendPropertyChanging();
					this._rfc = value;
					this.SendPropertyChanged("rfc");
					this.OnrfcChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_status_prospecto", DbType="Int NOT NULL")]
		public int id_status_prospecto
		{
			get
			{
				return this._id_status_prospecto;
			}
			set
			{
				if ((this._id_status_prospecto != value))
				{
					if (this._StatusProspecto.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_status_prospectoChanging(value);
					this.SendPropertyChanging();
					this._id_status_prospecto = value;
					this.SendPropertyChanged("id_status_prospecto");
					this.Onid_status_prospectoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_observacion", DbType="VarChar(150)")]
		public string observacion
		{
			get
			{
				return this._observacion;
			}
			set
			{
				if ((this._observacion != value))
				{
					this.OnobservacionChanging(value);
					this.SendPropertyChanging();
					this._observacion = value;
					this.SendPropertyChanged("observacion");
					this.OnobservacionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Prospecto_DocumentosProspecto", Storage="_DocumentosProspecto", ThisKey="id", OtherKey="id_prospecto")]
		public EntitySet<DocumentosProspecto> DocumentosProspecto
		{
			get
			{
				return this._DocumentosProspecto;
			}
			set
			{
				this._DocumentosProspecto.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="StatusProspecto_Prospecto", Storage="_StatusProspecto", ThisKey="id_status_prospecto", OtherKey="id", IsForeignKey=true)]
		public StatusProspecto StatusProspecto
		{
			get
			{
				return this._StatusProspecto.Entity;
			}
			set
			{
				StatusProspecto previousValue = this._StatusProspecto.Entity;
				if (((previousValue != value) 
							|| (this._StatusProspecto.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._StatusProspecto.Entity = null;
						previousValue.Prospecto.Remove(this);
					}
					this._StatusProspecto.Entity = value;
					if ((value != null))
					{
						value.Prospecto.Add(this);
						this._id_status_prospecto = value.id;
					}
					else
					{
						this._id_status_prospecto = default(int);
					}
					this.SendPropertyChanged("StatusProspecto");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_DocumentosProspecto(DocumentosProspecto entity)
		{
			this.SendPropertyChanging();
			entity.Prospecto = this;
		}
		
		private void detach_DocumentosProspecto(DocumentosProspecto entity)
		{
			this.SendPropertyChanging();
			entity.Prospecto = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.StatusProspecto")]
	public partial class StatusProspecto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _valor;
		
		private EntitySet<Prospecto> _Prospecto;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnvalorChanging(string value);
    partial void OnvalorChanged();
    #endregion
		
		public StatusProspecto()
		{
			this._Prospecto = new EntitySet<Prospecto>(new Action<Prospecto>(this.attach_Prospecto), new Action<Prospecto>(this.detach_Prospecto));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_valor", DbType="VarChar(20) NOT NULL", CanBeNull=false)]
		public string valor
		{
			get
			{
				return this._valor;
			}
			set
			{
				if ((this._valor != value))
				{
					this.OnvalorChanging(value);
					this.SendPropertyChanging();
					this._valor = value;
					this.SendPropertyChanged("valor");
					this.OnvalorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="StatusProspecto_Prospecto", Storage="_Prospecto", ThisKey="id", OtherKey="id_status_prospecto")]
		public EntitySet<Prospecto> Prospecto
		{
			get
			{
				return this._Prospecto;
			}
			set
			{
				this._Prospecto.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Prospecto(Prospecto entity)
		{
			this.SendPropertyChanging();
			entity.StatusProspecto = this;
		}
		
		private void detach_Prospecto(Prospecto entity)
		{
			this.SendPropertyChanging();
			entity.StatusProspecto = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DocumentosProspecto")]
	public partial class DocumentosProspecto : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _id_prospecto;
		
		private string _nombre_documento;
		
		private string _documento;
		
		private string _ext;
		
		private string _ruta;
		
		private EntityRef<Prospecto> _Prospecto;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onid_prospectoChanging(int value);
    partial void Onid_prospectoChanged();
    partial void Onnombre_documentoChanging(string value);
    partial void Onnombre_documentoChanged();
    partial void OndocumentoChanging(string value);
    partial void OndocumentoChanged();
    partial void OnextChanging(string value);
    partial void OnextChanged();
    partial void OnrutaChanging(string value);
    partial void OnrutaChanged();
    #endregion
		
		public DocumentosProspecto()
		{
			this._Prospecto = default(EntityRef<Prospecto>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_prospecto", DbType="Int NOT NULL")]
		public int id_prospecto
		{
			get
			{
				return this._id_prospecto;
			}
			set
			{
				if ((this._id_prospecto != value))
				{
					if (this._Prospecto.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_prospectoChanging(value);
					this.SendPropertyChanging();
					this._id_prospecto = value;
					this.SendPropertyChanged("id_prospecto");
					this.Onid_prospectoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_nombre_documento", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string nombre_documento
		{
			get
			{
				return this._nombre_documento;
			}
			set
			{
				if ((this._nombre_documento != value))
				{
					this.Onnombre_documentoChanging(value);
					this.SendPropertyChanging();
					this._nombre_documento = value;
					this.SendPropertyChanged("nombre_documento");
					this.Onnombre_documentoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_documento", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string documento
		{
			get
			{
				return this._documento;
			}
			set
			{
				if ((this._documento != value))
				{
					this.OndocumentoChanging(value);
					this.SendPropertyChanging();
					this._documento = value;
					this.SendPropertyChanged("documento");
					this.OndocumentoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ext", DbType="VarChar(5) NOT NULL", CanBeNull=false)]
		public string ext
		{
			get
			{
				return this._ext;
			}
			set
			{
				if ((this._ext != value))
				{
					this.OnextChanging(value);
					this.SendPropertyChanging();
					this._ext = value;
					this.SendPropertyChanged("ext");
					this.OnextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ruta", DbType="VarChar(500) NOT NULL", CanBeNull=false)]
		public string ruta
		{
			get
			{
				return this._ruta;
			}
			set
			{
				if ((this._ruta != value))
				{
					this.OnrutaChanging(value);
					this.SendPropertyChanging();
					this._ruta = value;
					this.SendPropertyChanged("ruta");
					this.OnrutaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Prospecto_DocumentosProspecto", Storage="_Prospecto", ThisKey="id_prospecto", OtherKey="id", IsForeignKey=true)]
		public Prospecto Prospecto
		{
			get
			{
				return this._Prospecto.Entity;
			}
			set
			{
				Prospecto previousValue = this._Prospecto.Entity;
				if (((previousValue != value) 
							|| (this._Prospecto.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Prospecto.Entity = null;
						previousValue.DocumentosProspecto.Remove(this);
					}
					this._Prospecto.Entity = value;
					if ((value != null))
					{
						value.DocumentosProspecto.Add(this);
						this._id_prospecto = value.id;
					}
					else
					{
						this._id_prospecto = default(int);
					}
					this.SendPropertyChanged("Prospecto");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
