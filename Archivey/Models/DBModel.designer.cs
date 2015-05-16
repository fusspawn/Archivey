﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Archivey.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="archiveydb")]
	public partial class DBModelDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertUser(User instance);
    partial void UpdateUser(User instance);
    partial void DeleteUser(User instance);
    partial void InsertServer(Server instance);
    partial void UpdateServer(Server instance);
    partial void DeleteServer(Server instance);
    partial void InsertUpload(Upload instance);
    partial void UpdateUpload(Upload instance);
    partial void DeleteUpload(Upload instance);
    #endregion
		
		public DBModelDataContext() : 
				base(global::Archivey.Properties.Settings.Default.archiveydbConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBModelDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<User> Users
		{
			get
			{
				return this.GetTable<User>();
			}
		}
		
		public System.Data.Linq.Table<Server> Servers
		{
			get
			{
				return this.GetTable<Server>();
			}
		}
		
		public System.Data.Linq.Table<Upload> Uploads
		{
			get
			{
				return this.GetTable<Upload>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Users")]
	public partial class User : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _Username;
		
		private string _Email;
		
		private string _Password;
		
		private System.DateTime _RegisteredAt;
		
		private System.DateTime _LastLogin;
		
		private EntityRef<Server> _Server;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUsernameChanging(string value);
    partial void OnUsernameChanged();
    partial void OnEmailChanging(string value);
    partial void OnEmailChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnRegisteredAtChanging(System.DateTime value);
    partial void OnRegisteredAtChanged();
    partial void OnLastLoginChanging(System.DateTime value);
    partial void OnLastLoginChanged();
    #endregion
		
		public User()
		{
			this._Server = default(EntityRef<Server>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					if (this._Server.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Username", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Username
		{
			get
			{
				return this._Username;
			}
			set
			{
				if ((this._Username != value))
				{
					this.OnUsernameChanging(value);
					this.SendPropertyChanging();
					this._Username = value;
					this.SendPropertyChanged("Username");
					this.OnUsernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Email", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Email
		{
			get
			{
				return this._Email;
			}
			set
			{
				if ((this._Email != value))
				{
					this.OnEmailChanging(value);
					this.SendPropertyChanging();
					this._Email = value;
					this.SendPropertyChanged("Email");
					this.OnEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="Text NOT NULL", CanBeNull=false, UpdateCheck=UpdateCheck.Never)]
		public string Password
		{
			get
			{
				return this._Password;
			}
			set
			{
				if ((this._Password != value))
				{
					this.OnPasswordChanging(value);
					this.SendPropertyChanging();
					this._Password = value;
					this.SendPropertyChanged("Password");
					this.OnPasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RegisteredAt", DbType="DateTime NOT NULL")]
		public System.DateTime RegisteredAt
		{
			get
			{
				return this._RegisteredAt;
			}
			set
			{
				if ((this._RegisteredAt != value))
				{
					this.OnRegisteredAtChanging(value);
					this.SendPropertyChanging();
					this._RegisteredAt = value;
					this.SendPropertyChanged("RegisteredAt");
					this.OnRegisteredAtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastLogin", DbType="DateTime NOT NULL")]
		public System.DateTime LastLogin
		{
			get
			{
				return this._LastLogin;
			}
			set
			{
				if ((this._LastLogin != value))
				{
					this.OnLastLoginChanging(value);
					this.SendPropertyChanging();
					this._LastLogin = value;
					this.SendPropertyChanged("LastLogin");
					this.OnLastLoginChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Server_User", Storage="_Server", ThisKey="Id", OtherKey="UserId", IsForeignKey=true)]
		public Server Server
		{
			get
			{
				return this._Server.Entity;
			}
			set
			{
				Server previousValue = this._Server.Entity;
				if (((previousValue != value) 
							|| (this._Server.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Server.Entity = null;
						previousValue.Users.Remove(this);
					}
					this._Server.Entity = value;
					if ((value != null))
					{
						value.Users.Add(this);
						this._Id = value.UserId;
					}
					else
					{
						this._Id = default(int);
					}
					this.SendPropertyChanged("Server");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Servers")]
	public partial class Server : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _UserId;
		
		private string _APIKey;
		
		private string _IP;
		
		private string _Name;
		
		private System.DateTime _LastUpload;
		
		private System.DateTime _LastContact;
		
		private EntitySet<User> _Users;
		
		private EntitySet<Upload> _Uploads;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserIdChanging(int value);
    partial void OnUserIdChanged();
    partial void OnAPIKeyChanging(string value);
    partial void OnAPIKeyChanged();
    partial void OnIPChanging(string value);
    partial void OnIPChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    partial void OnLastUploadChanging(System.DateTime value);
    partial void OnLastUploadChanged();
    partial void OnLastContactChanging(System.DateTime value);
    partial void OnLastContactChanged();
    #endregion
		
		public Server()
		{
			this._Users = new EntitySet<User>(new Action<User>(this.attach_Users), new Action<User>(this.detach_Users));
			this._Uploads = new EntitySet<Upload>(new Action<Upload>(this.attach_Uploads), new Action<Upload>(this.detach_Uploads));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserId", DbType="Int NOT NULL")]
		public int UserId
		{
			get
			{
				return this._UserId;
			}
			set
			{
				if ((this._UserId != value))
				{
					this.OnUserIdChanging(value);
					this.SendPropertyChanging();
					this._UserId = value;
					this.SendPropertyChanged("UserId");
					this.OnUserIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_APIKey", DbType="NVarChar(36) NOT NULL", CanBeNull=false)]
		public string APIKey
		{
			get
			{
				return this._APIKey;
			}
			set
			{
				if ((this._APIKey != value))
				{
					this.OnAPIKeyChanging(value);
					this.SendPropertyChanging();
					this._APIKey = value;
					this.SendPropertyChanged("APIKey");
					this.OnAPIKeyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IP", DbType="NVarChar(15) NOT NULL", CanBeNull=false)]
		public string IP
		{
			get
			{
				return this._IP;
			}
			set
			{
				if ((this._IP != value))
				{
					this.OnIPChanging(value);
					this.SendPropertyChanging();
					this._IP = value;
					this.SendPropertyChanged("IP");
					this.OnIPChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastUpload", DbType="DateTime NOT NULL")]
		public System.DateTime LastUpload
		{
			get
			{
				return this._LastUpload;
			}
			set
			{
				if ((this._LastUpload != value))
				{
					this.OnLastUploadChanging(value);
					this.SendPropertyChanging();
					this._LastUpload = value;
					this.SendPropertyChanged("LastUpload");
					this.OnLastUploadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastContact", DbType="DateTime NOT NULL")]
		public System.DateTime LastContact
		{
			get
			{
				return this._LastContact;
			}
			set
			{
				if ((this._LastContact != value))
				{
					this.OnLastContactChanging(value);
					this.SendPropertyChanging();
					this._LastContact = value;
					this.SendPropertyChanged("LastContact");
					this.OnLastContactChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Server_User", Storage="_Users", ThisKey="UserId", OtherKey="Id")]
		public EntitySet<User> Users
		{
			get
			{
				return this._Users;
			}
			set
			{
				this._Users.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Server_Upload", Storage="_Uploads", ThisKey="Id", OtherKey="ServerId")]
		public EntitySet<Upload> Uploads
		{
			get
			{
				return this._Uploads;
			}
			set
			{
				this._Uploads.Assign(value);
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
		
		private void attach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Server = this;
		}
		
		private void detach_Users(User entity)
		{
			this.SendPropertyChanging();
			entity.Server = null;
		}
		
		private void attach_Uploads(Upload entity)
		{
			this.SendPropertyChanging();
			entity.Server = this;
		}
		
		private void detach_Uploads(Upload entity)
		{
			this.SendPropertyChanging();
			entity.Server = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Uploads")]
	public partial class Upload : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private int _ServerId;
		
		private System.DateTime _UploadedAt;
		
		private EntityRef<Server> _Server;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnServerIdChanging(int value);
    partial void OnServerIdChanged();
    partial void OnUploadedAtChanging(System.DateTime value);
    partial void OnUploadedAtChanged();
    #endregion
		
		public Upload()
		{
			this._Server = default(EntityRef<Server>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ServerId", DbType="Int NOT NULL")]
		public int ServerId
		{
			get
			{
				return this._ServerId;
			}
			set
			{
				if ((this._ServerId != value))
				{
					if (this._Server.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnServerIdChanging(value);
					this.SendPropertyChanging();
					this._ServerId = value;
					this.SendPropertyChanged("ServerId");
					this.OnServerIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UploadedAt", DbType="DateTime NOT NULL")]
		public System.DateTime UploadedAt
		{
			get
			{
				return this._UploadedAt;
			}
			set
			{
				if ((this._UploadedAt != value))
				{
					this.OnUploadedAtChanging(value);
					this.SendPropertyChanging();
					this._UploadedAt = value;
					this.SendPropertyChanged("UploadedAt");
					this.OnUploadedAtChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Server_Upload", Storage="_Server", ThisKey="ServerId", OtherKey="Id", IsForeignKey=true)]
		public Server Server
		{
			get
			{
				return this._Server.Entity;
			}
			set
			{
				Server previousValue = this._Server.Entity;
				if (((previousValue != value) 
							|| (this._Server.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Server.Entity = null;
						previousValue.Uploads.Remove(this);
					}
					this._Server.Entity = value;
					if ((value != null))
					{
						value.Uploads.Add(this);
						this._ServerId = value.Id;
					}
					else
					{
						this._ServerId = default(int);
					}
					this.SendPropertyChanged("Server");
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