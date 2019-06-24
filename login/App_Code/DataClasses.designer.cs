﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ShowmarkNET")]
public partial class DataClassesDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region 可扩展性方法定义
  partial void OnCreated();
  partial void InsertClass(Class instance);
  partial void UpdateClass(Class instance);
  partial void DeleteClass(Class instance);
  partial void InsertKc(Kc instance);
  partial void UpdateKc(Kc instance);
  partial void DeleteKc(Kc instance);
  partial void Insertpingjia(pingjia instance);
  partial void Updatepingjia(pingjia instance);
  partial void Deletepingjia(pingjia instance);
  partial void InsertTeacher(Teacher instance);
  partial void UpdateTeacher(Teacher instance);
  partial void DeleteTeacher(Teacher instance);
  partial void InsertTerm(Term instance);
  partial void UpdateTerm(Term instance);
  partial void DeleteTerm(Term instance);
  #endregion
	
	public DataClassesDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["ShowmarkNETConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public DataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Class> Class
	{
		get
		{
			return this.GetTable<Class>();
		}
	}
	
	public System.Data.Linq.Table<Kc> Kc
	{
		get
		{
			return this.GetTable<Kc>();
		}
	}
	
	public System.Data.Linq.Table<pingjia> pingjia
	{
		get
		{
			return this.GetTable<pingjia>();
		}
	}
	
	public System.Data.Linq.Table<Teacher> Teacher
	{
		get
		{
			return this.GetTable<Teacher>();
		}
	}
	
	public System.Data.Linq.Table<Term> Term
	{
		get
		{
			return this.GetTable<Term>();
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Class")]
public partial class Class : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _class_no;
	
	private string _class_name;
	
	private EntitySet<pingjia> _pingjia;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onclass_noChanging(int value);
    partial void Onclass_noChanged();
    partial void Onclass_nameChanging(string value);
    partial void Onclass_nameChanged();
    #endregion
	
	public Class()
	{
		this._pingjia = new EntitySet<pingjia>(new Action<pingjia>(this.attach_pingjia), new Action<pingjia>(this.detach_pingjia));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_class_no", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int class_no
	{
		get
		{
			return this._class_no;
		}
		set
		{
			if ((this._class_no != value))
			{
				this.Onclass_noChanging(value);
				this.SendPropertyChanging();
				this._class_no = value;
				this.SendPropertyChanged("class_no");
				this.Onclass_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_class_name", DbType="NChar(10)")]
	public string class_name
	{
		get
		{
			return this._class_name;
		}
		set
		{
			if ((this._class_name != value))
			{
				this.Onclass_nameChanging(value);
				this.SendPropertyChanging();
				this._class_name = value;
				this.SendPropertyChanged("class_name");
				this.Onclass_nameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Class_pingjia", Storage="_pingjia", ThisKey="class_no", OtherKey="class_no")]
	public EntitySet<pingjia> pingjia
	{
		get
		{
			return this._pingjia;
		}
		set
		{
			this._pingjia.Assign(value);
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
	
	private void attach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Class = this;
	}
	
	private void detach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Class = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Kc")]
public partial class Kc : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _kc_no;
	
	private string _kc_name;
	
	private EntitySet<pingjia> _pingjia;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onkc_noChanging(int value);
    partial void Onkc_noChanged();
    partial void Onkc_nameChanging(string value);
    partial void Onkc_nameChanged();
    #endregion
	
	public Kc()
	{
		this._pingjia = new EntitySet<pingjia>(new Action<pingjia>(this.attach_pingjia), new Action<pingjia>(this.detach_pingjia));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kc_no", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int kc_no
	{
		get
		{
			return this._kc_no;
		}
		set
		{
			if ((this._kc_no != value))
			{
				this.Onkc_noChanging(value);
				this.SendPropertyChanging();
				this._kc_no = value;
				this.SendPropertyChanged("kc_no");
				this.Onkc_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kc_name", DbType="NChar(10) NOT NULL", CanBeNull=false)]
	public string kc_name
	{
		get
		{
			return this._kc_name;
		}
		set
		{
			if ((this._kc_name != value))
			{
				this.Onkc_nameChanging(value);
				this.SendPropertyChanging();
				this._kc_name = value;
				this.SendPropertyChanged("kc_name");
				this.Onkc_nameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kc_pingjia", Storage="_pingjia", ThisKey="kc_no", OtherKey="kc_no")]
	public EntitySet<pingjia> pingjia
	{
		get
		{
			return this._pingjia;
		}
		set
		{
			this._pingjia.Assign(value);
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
	
	private void attach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Kc = this;
	}
	
	private void detach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Kc = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.pingjia")]
public partial class pingjia : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _pj_no;
	
	private int _kc_no;
	
	private int _th_no;
	
	private int _class_no;
	
	private int _ter_no;
	
	private string _fuser;
	
	private EntityRef<Class> _Class;
	
	private EntityRef<Kc> _Kc;
	
	private EntityRef<Teacher> _Teacher;
	
	private EntityRef<Term> _Term;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onpj_noChanging(int value);
    partial void Onpj_noChanged();
    partial void Onkc_noChanging(int value);
    partial void Onkc_noChanged();
    partial void Onth_noChanging(int value);
    partial void Onth_noChanged();
    partial void Onclass_noChanging(int value);
    partial void Onclass_noChanged();
    partial void Onter_noChanging(int value);
    partial void Onter_noChanged();
    partial void OnfuserChanging(string value);
    partial void OnfuserChanged();
    #endregion
	
	public pingjia()
	{
		this._Class = default(EntityRef<Class>);
		this._Kc = default(EntityRef<Kc>);
		this._Teacher = default(EntityRef<Teacher>);
		this._Term = default(EntityRef<Term>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pj_no", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int pj_no
	{
		get
		{
			return this._pj_no;
		}
		set
		{
			if ((this._pj_no != value))
			{
				this.Onpj_noChanging(value);
				this.SendPropertyChanging();
				this._pj_no = value;
				this.SendPropertyChanged("pj_no");
				this.Onpj_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kc_no", DbType="Int NOT NULL")]
	public int kc_no
	{
		get
		{
			return this._kc_no;
		}
		set
		{
			if ((this._kc_no != value))
			{
				if (this._Kc.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.Onkc_noChanging(value);
				this.SendPropertyChanging();
				this._kc_no = value;
				this.SendPropertyChanged("kc_no");
				this.Onkc_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_th_no", DbType="Int NOT NULL")]
	public int th_no
	{
		get
		{
			return this._th_no;
		}
		set
		{
			if ((this._th_no != value))
			{
				if (this._Teacher.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.Onth_noChanging(value);
				this.SendPropertyChanging();
				this._th_no = value;
				this.SendPropertyChanged("th_no");
				this.Onth_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_class_no", DbType="Int NOT NULL")]
	public int class_no
	{
		get
		{
			return this._class_no;
		}
		set
		{
			if ((this._class_no != value))
			{
				if (this._Class.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.Onclass_noChanging(value);
				this.SendPropertyChanging();
				this._class_no = value;
				this.SendPropertyChanged("class_no");
				this.Onclass_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ter_no", DbType="Int NOT NULL")]
	public int ter_no
	{
		get
		{
			return this._ter_no;
		}
		set
		{
			if ((this._ter_no != value))
			{
				if (this._Term.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.Onter_noChanging(value);
				this.SendPropertyChanging();
				this._ter_no = value;
				this.SendPropertyChanged("ter_no");
				this.Onter_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fuser", DbType="Text", UpdateCheck=UpdateCheck.Never)]
	public string fuser
	{
		get
		{
			return this._fuser;
		}
		set
		{
			if ((this._fuser != value))
			{
				this.OnfuserChanging(value);
				this.SendPropertyChanging();
				this._fuser = value;
				this.SendPropertyChanged("fuser");
				this.OnfuserChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Class_pingjia", Storage="_Class", ThisKey="class_no", OtherKey="class_no", IsForeignKey=true)]
	public Class Class
	{
		get
		{
			return this._Class.Entity;
		}
		set
		{
			Class previousValue = this._Class.Entity;
			if (((previousValue != value) 
						|| (this._Class.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Class.Entity = null;
					previousValue.pingjia.Remove(this);
				}
				this._Class.Entity = value;
				if ((value != null))
				{
					value.pingjia.Add(this);
					this._class_no = value.class_no;
				}
				else
				{
					this._class_no = default(int);
				}
				this.SendPropertyChanged("Class");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Kc_pingjia", Storage="_Kc", ThisKey="kc_no", OtherKey="kc_no", IsForeignKey=true)]
	public Kc Kc
	{
		get
		{
			return this._Kc.Entity;
		}
		set
		{
			Kc previousValue = this._Kc.Entity;
			if (((previousValue != value) 
						|| (this._Kc.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Kc.Entity = null;
					previousValue.pingjia.Remove(this);
				}
				this._Kc.Entity = value;
				if ((value != null))
				{
					value.pingjia.Add(this);
					this._kc_no = value.kc_no;
				}
				else
				{
					this._kc_no = default(int);
				}
				this.SendPropertyChanged("Kc");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Teacher_pingjia", Storage="_Teacher", ThisKey="th_no", OtherKey="th_no", IsForeignKey=true)]
	public Teacher Teacher
	{
		get
		{
			return this._Teacher.Entity;
		}
		set
		{
			Teacher previousValue = this._Teacher.Entity;
			if (((previousValue != value) 
						|| (this._Teacher.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Teacher.Entity = null;
					previousValue.pingjia.Remove(this);
				}
				this._Teacher.Entity = value;
				if ((value != null))
				{
					value.pingjia.Add(this);
					this._th_no = value.th_no;
				}
				else
				{
					this._th_no = default(int);
				}
				this.SendPropertyChanged("Teacher");
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Term_pingjia", Storage="_Term", ThisKey="ter_no", OtherKey="ter_no", IsForeignKey=true)]
	public Term Term
	{
		get
		{
			return this._Term.Entity;
		}
		set
		{
			Term previousValue = this._Term.Entity;
			if (((previousValue != value) 
						|| (this._Term.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Term.Entity = null;
					previousValue.pingjia.Remove(this);
				}
				this._Term.Entity = value;
				if ((value != null))
				{
					value.pingjia.Add(this);
					this._ter_no = value.ter_no;
				}
				else
				{
					this._ter_no = default(int);
				}
				this.SendPropertyChanged("Term");
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

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Teacher")]
public partial class Teacher : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _th_no;
	
	private string _th_name;
	
	private EntitySet<pingjia> _pingjia;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onth_noChanging(int value);
    partial void Onth_noChanged();
    partial void Onth_nameChanging(string value);
    partial void Onth_nameChanged();
    #endregion
	
	public Teacher()
	{
		this._pingjia = new EntitySet<pingjia>(new Action<pingjia>(this.attach_pingjia), new Action<pingjia>(this.detach_pingjia));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_th_no", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int th_no
	{
		get
		{
			return this._th_no;
		}
		set
		{
			if ((this._th_no != value))
			{
				this.Onth_noChanging(value);
				this.SendPropertyChanging();
				this._th_no = value;
				this.SendPropertyChanged("th_no");
				this.Onth_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_th_name", DbType="Char(10)")]
	public string th_name
	{
		get
		{
			return this._th_name;
		}
		set
		{
			if ((this._th_name != value))
			{
				this.Onth_nameChanging(value);
				this.SendPropertyChanging();
				this._th_name = value;
				this.SendPropertyChanged("th_name");
				this.Onth_nameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Teacher_pingjia", Storage="_pingjia", ThisKey="th_no", OtherKey="th_no")]
	public EntitySet<pingjia> pingjia
	{
		get
		{
			return this._pingjia;
		}
		set
		{
			this._pingjia.Assign(value);
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
	
	private void attach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Teacher = this;
	}
	
	private void detach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Teacher = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Term")]
public partial class Term : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _ter_no;
	
	private string _ter_info;
	
	private EntitySet<pingjia> _pingjia;
	
    #region 可扩展性方法定义
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void Onter_noChanging(int value);
    partial void Onter_noChanged();
    partial void Onter_infoChanging(string value);
    partial void Onter_infoChanged();
    #endregion
	
	public Term()
	{
		this._pingjia = new EntitySet<pingjia>(new Action<pingjia>(this.attach_pingjia), new Action<pingjia>(this.detach_pingjia));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ter_no", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int ter_no
	{
		get
		{
			return this._ter_no;
		}
		set
		{
			if ((this._ter_no != value))
			{
				this.Onter_noChanging(value);
				this.SendPropertyChanging();
				this._ter_no = value;
				this.SendPropertyChanged("ter_no");
				this.Onter_noChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ter_info", DbType="Char(10) NOT NULL", CanBeNull=false)]
	public string ter_info
	{
		get
		{
			return this._ter_info;
		}
		set
		{
			if ((this._ter_info != value))
			{
				this.Onter_infoChanging(value);
				this.SendPropertyChanging();
				this._ter_info = value;
				this.SendPropertyChanged("ter_info");
				this.Onter_infoChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Term_pingjia", Storage="_pingjia", ThisKey="ter_no", OtherKey="ter_no")]
	public EntitySet<pingjia> pingjia
	{
		get
		{
			return this._pingjia;
		}
		set
		{
			this._pingjia.Assign(value);
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
	
	private void attach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Term = this;
	}
	
	private void detach_pingjia(pingjia entity)
	{
		this.SendPropertyChanging();
		entity.Term = null;
	}
}
#pragma warning restore 1591