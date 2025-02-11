﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DTODLL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="HTQLDOANVIEN")]
	public partial class QLHTDOANVIENDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertDAIHOI(DAIHOI instance);
    partial void UpdateDAIHOI(DAIHOI instance);
    partial void DeleteDAIHOI(DAIHOI instance);
    partial void InsertDOANVIEN(DOANVIEN instance);
    partial void UpdateDOANVIEN(DOANVIEN instance);
    partial void DeleteDOANVIEN(DOANVIEN instance);
    partial void InsertTHAMDUDAIHOI(THAMDUDAIHOI instance);
    partial void UpdateTHAMDUDAIHOI(THAMDUDAIHOI instance);
    partial void DeleteTHAMDUDAIHOI(THAMDUDAIHOI instance);
    #endregion
		
		public QLHTDOANVIENDataContext() : 
				base(global::DTODLL.Properties.Settings.Default.HTQLDOANVIENConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public QLHTDOANVIENDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLHTDOANVIENDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLHTDOANVIENDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public QLHTDOANVIENDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<DAIHOI> DAIHOIs
		{
			get
			{
				return this.GetTable<DAIHOI>();
			}
		}
		
		public System.Data.Linq.Table<DOANVIEN> DOANVIENs
		{
			get
			{
				return this.GetTable<DOANVIEN>();
			}
		}
		
		public System.Data.Linq.Table<THAMDUDAIHOI> THAMDUDAIHOIs
		{
			get
			{
				return this.GetTable<THAMDUDAIHOI>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DAIHOI")]
	public partial class DAIHOI : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _MASODH;
		
		private string _CHUDE;
		
		private string _NHIEMKY;
		
		private System.Nullable<System.DateTime> _NGAY;
		
		private System.Nullable<bool> _TRANGTHAI;
		
		private System.Nullable<System.DateTime> _NGAYTAO;
		
		private System.Nullable<System.DateTime> _NGAYCAPNHAT;
		
		private EntitySet<THAMDUDAIHOI> _THAMDUDAIHOIs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMASODHChanging(System.Guid value);
    partial void OnMASODHChanged();
    partial void OnCHUDEChanging(string value);
    partial void OnCHUDEChanged();
    partial void OnNHIEMKYChanging(string value);
    partial void OnNHIEMKYChanged();
    partial void OnNGAYChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYChanged();
    partial void OnTRANGTHAIChanging(System.Nullable<bool> value);
    partial void OnTRANGTHAIChanged();
    partial void OnNGAYTAOChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYTAOChanged();
    partial void OnNGAYCAPNHATChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYCAPNHATChanged();
    #endregion
		
		public DAIHOI()
		{
			this._THAMDUDAIHOIs = new EntitySet<THAMDUDAIHOI>(new Action<THAMDUDAIHOI>(this.attach_THAMDUDAIHOIs), new Action<THAMDUDAIHOI>(this.detach_THAMDUDAIHOIs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MASODH", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid MASODH
		{
			get
			{
				return this._MASODH;
			}
			set
			{
				if ((this._MASODH != value))
				{
					this.OnMASODHChanging(value);
					this.SendPropertyChanging();
					this._MASODH = value;
					this.SendPropertyChanged("MASODH");
					this.OnMASODHChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CHUDE", DbType="NVarChar(300)")]
		public string CHUDE
		{
			get
			{
				return this._CHUDE;
			}
			set
			{
				if ((this._CHUDE != value))
				{
					this.OnCHUDEChanging(value);
					this.SendPropertyChanging();
					this._CHUDE = value;
					this.SendPropertyChanged("CHUDE");
					this.OnCHUDEChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NHIEMKY", DbType="NVarChar(100)")]
		public string NHIEMKY
		{
			get
			{
				return this._NHIEMKY;
			}
			set
			{
				if ((this._NHIEMKY != value))
				{
					this.OnNHIEMKYChanging(value);
					this.SendPropertyChanging();
					this._NHIEMKY = value;
					this.SendPropertyChanged("NHIEMKY");
					this.OnNHIEMKYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAY", DbType="DateTime")]
		public System.Nullable<System.DateTime> NGAY
		{
			get
			{
				return this._NGAY;
			}
			set
			{
				if ((this._NGAY != value))
				{
					this.OnNGAYChanging(value);
					this.SendPropertyChanging();
					this._NGAY = value;
					this.SendPropertyChanged("NGAY");
					this.OnNGAYChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TRANGTHAI", DbType="Bit")]
		public System.Nullable<bool> TRANGTHAI
		{
			get
			{
				return this._TRANGTHAI;
			}
			set
			{
				if ((this._TRANGTHAI != value))
				{
					this.OnTRANGTHAIChanging(value);
					this.SendPropertyChanging();
					this._TRANGTHAI = value;
					this.SendPropertyChanged("TRANGTHAI");
					this.OnTRANGTHAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYTAO", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYTAO
		{
			get
			{
				return this._NGAYTAO;
			}
			set
			{
				if ((this._NGAYTAO != value))
				{
					this.OnNGAYTAOChanging(value);
					this.SendPropertyChanging();
					this._NGAYTAO = value;
					this.SendPropertyChanged("NGAYTAO");
					this.OnNGAYTAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYCAPNHAT", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYCAPNHAT
		{
			get
			{
				return this._NGAYCAPNHAT;
			}
			set
			{
				if ((this._NGAYCAPNHAT != value))
				{
					this.OnNGAYCAPNHATChanging(value);
					this.SendPropertyChanging();
					this._NGAYCAPNHAT = value;
					this.SendPropertyChanged("NGAYCAPNHAT");
					this.OnNGAYCAPNHATChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DAIHOI_THAMDUDAIHOI", Storage="_THAMDUDAIHOIs", ThisKey="MASODH", OtherKey="MASODH")]
		public EntitySet<THAMDUDAIHOI> THAMDUDAIHOIs
		{
			get
			{
				return this._THAMDUDAIHOIs;
			}
			set
			{
				this._THAMDUDAIHOIs.Assign(value);
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
		
		private void attach_THAMDUDAIHOIs(THAMDUDAIHOI entity)
		{
			this.SendPropertyChanging();
			entity.DAIHOI = this;
		}
		
		private void detach_THAMDUDAIHOIs(THAMDUDAIHOI entity)
		{
			this.SendPropertyChanging();
			entity.DAIHOI = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.DOANVIEN")]
	public partial class DOANVIEN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _MASODV;
		
		private string _CMND;
		
		private string _HOLOT;
		
		private string _TEN;
		
		private System.Nullable<bool> _NAM;
		
		private string _NGUYENQUAN;
		
		private string _DANTOC;
		
		private string _TONGIAO;
		
		private string _CMNV;
		
		private string _LLCT;
		
		private System.Nullable<System.DateTime> _NGAYVAODOAN;
		
		private System.Nullable<System.DateTime> _NGAYVAODANG;
		
		private string _GHICHU;
		
		private string _HASHING;
		
		private System.Nullable<System.DateTime> _NGAYTAO;
		
		private System.Nullable<System.DateTime> _NGAYCAPNHAT;
		
		private EntitySet<THAMDUDAIHOI> _THAMDUDAIHOIs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMASODVChanging(System.Guid value);
    partial void OnMASODVChanged();
    partial void OnCMNDChanging(string value);
    partial void OnCMNDChanged();
    partial void OnHOLOTChanging(string value);
    partial void OnHOLOTChanged();
    partial void OnTENChanging(string value);
    partial void OnTENChanged();
    partial void OnNAMChanging(System.Nullable<bool> value);
    partial void OnNAMChanged();
    partial void OnNGUYENQUANChanging(string value);
    partial void OnNGUYENQUANChanged();
    partial void OnDANTOCChanging(string value);
    partial void OnDANTOCChanged();
    partial void OnTONGIAOChanging(string value);
    partial void OnTONGIAOChanged();
    partial void OnCMNVChanging(string value);
    partial void OnCMNVChanged();
    partial void OnLLCTChanging(string value);
    partial void OnLLCTChanged();
    partial void OnNGAYVAODOANChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYVAODOANChanged();
    partial void OnNGAYVAODANGChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYVAODANGChanged();
    partial void OnGHICHUChanging(string value);
    partial void OnGHICHUChanged();
    partial void OnHASHINGChanging(string value);
    partial void OnHASHINGChanged();
    partial void OnNGAYTAOChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYTAOChanged();
    partial void OnNGAYCAPNHATChanging(System.Nullable<System.DateTime> value);
    partial void OnNGAYCAPNHATChanged();
    #endregion
		
		public DOANVIEN()
		{
			this._THAMDUDAIHOIs = new EntitySet<THAMDUDAIHOI>(new Action<THAMDUDAIHOI>(this.attach_THAMDUDAIHOIs), new Action<THAMDUDAIHOI>(this.detach_THAMDUDAIHOIs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MASODV", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid MASODV
		{
			get
			{
				return this._MASODV;
			}
			set
			{
				if ((this._MASODV != value))
				{
					this.OnMASODVChanging(value);
					this.SendPropertyChanging();
					this._MASODV = value;
					this.SendPropertyChanged("MASODV");
					this.OnMASODVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CMND", DbType="VarChar(10)")]
		public string CMND
		{
			get
			{
				return this._CMND;
			}
			set
			{
				if ((this._CMND != value))
				{
					this.OnCMNDChanging(value);
					this.SendPropertyChanging();
					this._CMND = value;
					this.SendPropertyChanged("CMND");
					this.OnCMNDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HOLOT", DbType="NVarChar(100)")]
		public string HOLOT
		{
			get
			{
				return this._HOLOT;
			}
			set
			{
				if ((this._HOLOT != value))
				{
					this.OnHOLOTChanging(value);
					this.SendPropertyChanging();
					this._HOLOT = value;
					this.SendPropertyChanged("HOLOT");
					this.OnHOLOTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TEN", DbType="NVarChar(50)")]
		public string TEN
		{
			get
			{
				return this._TEN;
			}
			set
			{
				if ((this._TEN != value))
				{
					this.OnTENChanging(value);
					this.SendPropertyChanging();
					this._TEN = value;
					this.SendPropertyChanged("TEN");
					this.OnTENChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NAM", DbType="Bit")]
		public System.Nullable<bool> NAM
		{
			get
			{
				return this._NAM;
			}
			set
			{
				if ((this._NAM != value))
				{
					this.OnNAMChanging(value);
					this.SendPropertyChanging();
					this._NAM = value;
					this.SendPropertyChanged("NAM");
					this.OnNAMChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGUYENQUAN", DbType="NVarChar(300)")]
		public string NGUYENQUAN
		{
			get
			{
				return this._NGUYENQUAN;
			}
			set
			{
				if ((this._NGUYENQUAN != value))
				{
					this.OnNGUYENQUANChanging(value);
					this.SendPropertyChanging();
					this._NGUYENQUAN = value;
					this.SendPropertyChanged("NGUYENQUAN");
					this.OnNGUYENQUANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_DANTOC", DbType="NVarChar(50)")]
		public string DANTOC
		{
			get
			{
				return this._DANTOC;
			}
			set
			{
				if ((this._DANTOC != value))
				{
					this.OnDANTOCChanging(value);
					this.SendPropertyChanging();
					this._DANTOC = value;
					this.SendPropertyChanged("DANTOC");
					this.OnDANTOCChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TONGIAO", DbType="NVarChar(100)")]
		public string TONGIAO
		{
			get
			{
				return this._TONGIAO;
			}
			set
			{
				if ((this._TONGIAO != value))
				{
					this.OnTONGIAOChanging(value);
					this.SendPropertyChanging();
					this._TONGIAO = value;
					this.SendPropertyChanged("TONGIAO");
					this.OnTONGIAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CMNV", DbType="NVarChar(100)")]
		public string CMNV
		{
			get
			{
				return this._CMNV;
			}
			set
			{
				if ((this._CMNV != value))
				{
					this.OnCMNVChanging(value);
					this.SendPropertyChanging();
					this._CMNV = value;
					this.SendPropertyChanged("CMNV");
					this.OnCMNVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LLCT", DbType="NVarChar(100)")]
		public string LLCT
		{
			get
			{
				return this._LLCT;
			}
			set
			{
				if ((this._LLCT != value))
				{
					this.OnLLCTChanging(value);
					this.SendPropertyChanging();
					this._LLCT = value;
					this.SendPropertyChanged("LLCT");
					this.OnLLCTChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYVAODOAN", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYVAODOAN
		{
			get
			{
				return this._NGAYVAODOAN;
			}
			set
			{
				if ((this._NGAYVAODOAN != value))
				{
					this.OnNGAYVAODOANChanging(value);
					this.SendPropertyChanging();
					this._NGAYVAODOAN = value;
					this.SendPropertyChanged("NGAYVAODOAN");
					this.OnNGAYVAODOANChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYVAODANG", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYVAODANG
		{
			get
			{
				return this._NGAYVAODANG;
			}
			set
			{
				if ((this._NGAYVAODANG != value))
				{
					this.OnNGAYVAODANGChanging(value);
					this.SendPropertyChanging();
					this._NGAYVAODANG = value;
					this.SendPropertyChanged("NGAYVAODANG");
					this.OnNGAYVAODANGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_GHICHU", DbType="NVarChar(300)")]
		public string GHICHU
		{
			get
			{
				return this._GHICHU;
			}
			set
			{
				if ((this._GHICHU != value))
				{
					this.OnGHICHUChanging(value);
					this.SendPropertyChanging();
					this._GHICHU = value;
					this.SendPropertyChanged("GHICHU");
					this.OnGHICHUChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_HASHING", DbType="NVarChar(128)")]
		public string HASHING
		{
			get
			{
				return this._HASHING;
			}
			set
			{
				if ((this._HASHING != value))
				{
					this.OnHASHINGChanging(value);
					this.SendPropertyChanging();
					this._HASHING = value;
					this.SendPropertyChanged("HASHING");
					this.OnHASHINGChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYTAO", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYTAO
		{
			get
			{
				return this._NGAYTAO;
			}
			set
			{
				if ((this._NGAYTAO != value))
				{
					this.OnNGAYTAOChanging(value);
					this.SendPropertyChanging();
					this._NGAYTAO = value;
					this.SendPropertyChanged("NGAYTAO");
					this.OnNGAYTAOChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NGAYCAPNHAT", DbType="Date")]
		public System.Nullable<System.DateTime> NGAYCAPNHAT
		{
			get
			{
				return this._NGAYCAPNHAT;
			}
			set
			{
				if ((this._NGAYCAPNHAT != value))
				{
					this.OnNGAYCAPNHATChanging(value);
					this.SendPropertyChanging();
					this._NGAYCAPNHAT = value;
					this.SendPropertyChanged("NGAYCAPNHAT");
					this.OnNGAYCAPNHATChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DOANVIEN_THAMDUDAIHOI", Storage="_THAMDUDAIHOIs", ThisKey="MASODV", OtherKey="MASODV")]
		public EntitySet<THAMDUDAIHOI> THAMDUDAIHOIs
		{
			get
			{
				return this._THAMDUDAIHOIs;
			}
			set
			{
				this._THAMDUDAIHOIs.Assign(value);
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
		
		private void attach_THAMDUDAIHOIs(THAMDUDAIHOI entity)
		{
			this.SendPropertyChanging();
			entity.DOANVIEN = this;
		}
		
		private void detach_THAMDUDAIHOIs(THAMDUDAIHOI entity)
		{
			this.SendPropertyChanging();
			entity.DOANVIEN = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.THAMDUDAIHOI")]
	public partial class THAMDUDAIHOI : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<System.Guid> _MASODV;
		
		private System.Nullable<System.Guid> _MASODH;
		
		private int _id;
		
		private bool _TRANGTHAI;
		
		private EntityRef<DAIHOI> _DAIHOI;
		
		private EntityRef<DOANVIEN> _DOANVIEN;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnMASODVChanging(System.Nullable<System.Guid> value);
    partial void OnMASODVChanged();
    partial void OnMASODHChanging(System.Nullable<System.Guid> value);
    partial void OnMASODHChanged();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnTRANGTHAIChanging(bool value);
    partial void OnTRANGTHAIChanged();
    #endregion
		
		public THAMDUDAIHOI()
		{
			this._DAIHOI = default(EntityRef<DAIHOI>);
			this._DOANVIEN = default(EntityRef<DOANVIEN>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MASODV", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> MASODV
		{
			get
			{
				return this._MASODV;
			}
			set
			{
				if ((this._MASODV != value))
				{
					if (this._DOANVIEN.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMASODVChanging(value);
					this.SendPropertyChanging();
					this._MASODV = value;
					this.SendPropertyChanged("MASODV");
					this.OnMASODVChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MASODH", DbType="UniqueIdentifier")]
		public System.Nullable<System.Guid> MASODH
		{
			get
			{
				return this._MASODH;
			}
			set
			{
				if ((this._MASODH != value))
				{
					if (this._DAIHOI.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnMASODHChanging(value);
					this.SendPropertyChanging();
					this._MASODH = value;
					this.SendPropertyChanged("MASODH");
					this.OnMASODHChanged();
				}
			}
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TRANGTHAI", DbType="Bit NOT NULL")]
		public bool TRANGTHAI
		{
			get
			{
				return this._TRANGTHAI;
			}
			set
			{
				if ((this._TRANGTHAI != value))
				{
					this.OnTRANGTHAIChanging(value);
					this.SendPropertyChanging();
					this._TRANGTHAI = value;
					this.SendPropertyChanged("TRANGTHAI");
					this.OnTRANGTHAIChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DAIHOI_THAMDUDAIHOI", Storage="_DAIHOI", ThisKey="MASODH", OtherKey="MASODH", IsForeignKey=true)]
		public DAIHOI DAIHOI
		{
			get
			{
				return this._DAIHOI.Entity;
			}
			set
			{
				DAIHOI previousValue = this._DAIHOI.Entity;
				if (((previousValue != value) 
							|| (this._DAIHOI.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DAIHOI.Entity = null;
						previousValue.THAMDUDAIHOIs.Remove(this);
					}
					this._DAIHOI.Entity = value;
					if ((value != null))
					{
						value.THAMDUDAIHOIs.Add(this);
						this._MASODH = value.MASODH;
					}
					else
					{
						this._MASODH = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("DAIHOI");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="DOANVIEN_THAMDUDAIHOI", Storage="_DOANVIEN", ThisKey="MASODV", OtherKey="MASODV", IsForeignKey=true)]
		public DOANVIEN DOANVIEN
		{
			get
			{
				return this._DOANVIEN.Entity;
			}
			set
			{
				DOANVIEN previousValue = this._DOANVIEN.Entity;
				if (((previousValue != value) 
							|| (this._DOANVIEN.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._DOANVIEN.Entity = null;
						previousValue.THAMDUDAIHOIs.Remove(this);
					}
					this._DOANVIEN.Entity = value;
					if ((value != null))
					{
						value.THAMDUDAIHOIs.Add(this);
						this._MASODV = value.MASODV;
					}
					else
					{
						this._MASODV = default(Nullable<System.Guid>);
					}
					this.SendPropertyChanged("DOANVIEN");
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
