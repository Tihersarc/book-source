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

namespace BookScraper.DALs
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="BookSource")]
	public partial class BookDataClassesDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertBook(Book instance);
    partial void UpdateBook(Book instance);
    partial void DeleteBook(Book instance);
    partial void InsertBook_Category(Book_Category instance);
    partial void UpdateBook_Category(Book_Category instance);
    partial void DeleteBook_Category(Book_Category instance);
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    #endregion
		
		public BookDataClassesDataContext() : 
				base(global::BookScraper.Properties.Settings.Default.BookSourceConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClassesDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClassesDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClassesDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BookDataClassesDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Book> Book
		{
			get
			{
				return this.GetTable<Book>();
			}
		}
		
		public System.Data.Linq.Table<Book_Category> Book_Category
		{
			get
			{
				return this.GetTable<Book_Category>();
			}
		}
		
		public System.Data.Linq.Table<Category> Category
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Book")]
	public partial class Book : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdBook;
		
		private string _Title;
		
		private string _Author;
		
		private string _Description;
		
		private string _ImageUrl;
		
		private string _Subtitle;
		
		private string _Editorial;
		
		private System.Nullable<int> _PageCount;
		
		private System.Nullable<double> _Score;
		
		private EntitySet<Book_Category> _Book_Category;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdBookChanging(int value);
    partial void OnIdBookChanged();
    partial void OnTitleChanging(string value);
    partial void OnTitleChanged();
    partial void OnAuthorChanging(string value);
    partial void OnAuthorChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnImageUrlChanging(string value);
    partial void OnImageUrlChanged();
    partial void OnSubtitleChanging(string value);
    partial void OnSubtitleChanged();
    partial void OnEditorialChanging(string value);
    partial void OnEditorialChanged();
    partial void OnPageCountChanging(System.Nullable<int> value);
    partial void OnPageCountChanged();
    partial void OnScoreChanging(System.Nullable<double> value);
    partial void OnScoreChanged();
    #endregion
		
		public Book()
		{
			this._Book_Category = new EntitySet<Book_Category>(new Action<Book_Category>(this.attach_Book_Category), new Action<Book_Category>(this.detach_Book_Category));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdBook", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdBook
		{
			get
			{
				return this._IdBook;
			}
			set
			{
				if ((this._IdBook != value))
				{
					this.OnIdBookChanging(value);
					this.SendPropertyChanging();
					this._IdBook = value;
					this.SendPropertyChanged("IdBook");
					this.OnIdBookChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this.OnTitleChanging(value);
					this.SendPropertyChanging();
					this._Title = value;
					this.SendPropertyChanged("Title");
					this.OnTitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Author", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string Author
		{
			get
			{
				return this._Author;
			}
			set
			{
				if ((this._Author != value))
				{
					this.OnAuthorChanging(value);
					this.SendPropertyChanging();
					this._Author = value;
					this.SendPropertyChanged("Author");
					this.OnAuthorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="VarChar(1024)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ImageUrl", DbType="VarChar(255)")]
		public string ImageUrl
		{
			get
			{
				return this._ImageUrl;
			}
			set
			{
				if ((this._ImageUrl != value))
				{
					this.OnImageUrlChanging(value);
					this.SendPropertyChanging();
					this._ImageUrl = value;
					this.SendPropertyChanged("ImageUrl");
					this.OnImageUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Subtitle", DbType="VarChar(255)")]
		public string Subtitle
		{
			get
			{
				return this._Subtitle;
			}
			set
			{
				if ((this._Subtitle != value))
				{
					this.OnSubtitleChanging(value);
					this.SendPropertyChanging();
					this._Subtitle = value;
					this.SendPropertyChanged("Subtitle");
					this.OnSubtitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Editorial", DbType="VarChar(255)")]
		public string Editorial
		{
			get
			{
				return this._Editorial;
			}
			set
			{
				if ((this._Editorial != value))
				{
					this.OnEditorialChanging(value);
					this.SendPropertyChanging();
					this._Editorial = value;
					this.SendPropertyChanged("Editorial");
					this.OnEditorialChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PageCount", DbType="Int")]
		public System.Nullable<int> PageCount
		{
			get
			{
				return this._PageCount;
			}
			set
			{
				if ((this._PageCount != value))
				{
					this.OnPageCountChanging(value);
					this.SendPropertyChanging();
					this._PageCount = value;
					this.SendPropertyChanged("PageCount");
					this.OnPageCountChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Score", DbType="Float")]
		public System.Nullable<double> Score
		{
			get
			{
				return this._Score;
			}
			set
			{
				if ((this._Score != value))
				{
					this.OnScoreChanging(value);
					this.SendPropertyChanging();
					this._Score = value;
					this.SendPropertyChanged("Score");
					this.OnScoreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Book_Category", Storage="_Book_Category", ThisKey="IdBook", OtherKey="FkIdBook")]
		public EntitySet<Book_Category> Book_Category
		{
			get
			{
				return this._Book_Category;
			}
			set
			{
				this._Book_Category.Assign(value);
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
		
		private void attach_Book_Category(Book_Category entity)
		{
			this.SendPropertyChanging();
			entity.Book = this;
		}
		
		private void detach_Book_Category(Book_Category entity)
		{
			this.SendPropertyChanging();
			entity.Book = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Book_Category")]
	public partial class Book_Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _FkIdCategory;
		
		private int _FkIdBook;
		
		private EntityRef<Book> _Book;
		
		private EntityRef<Category> _Category;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnFkIdCategoryChanging(int value);
    partial void OnFkIdCategoryChanged();
    partial void OnFkIdBookChanging(int value);
    partial void OnFkIdBookChanged();
    #endregion
		
		public Book_Category()
		{
			this._Book = default(EntityRef<Book>);
			this._Category = default(EntityRef<Category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FkIdCategory", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int FkIdCategory
		{
			get
			{
				return this._FkIdCategory;
			}
			set
			{
				if ((this._FkIdCategory != value))
				{
					if (this._Category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFkIdCategoryChanging(value);
					this.SendPropertyChanging();
					this._FkIdCategory = value;
					this.SendPropertyChanged("FkIdCategory");
					this.OnFkIdCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FkIdBook", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int FkIdBook
		{
			get
			{
				return this._FkIdBook;
			}
			set
			{
				if ((this._FkIdBook != value))
				{
					if (this._Book.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnFkIdBookChanging(value);
					this.SendPropertyChanging();
					this._FkIdBook = value;
					this.SendPropertyChanged("FkIdBook");
					this.OnFkIdBookChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Book_Book_Category", Storage="_Book", ThisKey="FkIdBook", OtherKey="IdBook", IsForeignKey=true)]
		public Book Book
		{
			get
			{
				return this._Book.Entity;
			}
			set
			{
				Book previousValue = this._Book.Entity;
				if (((previousValue != value) 
							|| (this._Book.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Book.Entity = null;
						previousValue.Book_Category.Remove(this);
					}
					this._Book.Entity = value;
					if ((value != null))
					{
						value.Book_Category.Add(this);
						this._FkIdBook = value.IdBook;
					}
					else
					{
						this._FkIdBook = default(int);
					}
					this.SendPropertyChanged("Book");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Book_Category", Storage="_Category", ThisKey="FkIdCategory", OtherKey="IdCategory", IsForeignKey=true)]
		public Category Category
		{
			get
			{
				return this._Category.Entity;
			}
			set
			{
				Category previousValue = this._Category.Entity;
				if (((previousValue != value) 
							|| (this._Category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category.Entity = null;
						previousValue.Book_Category.Remove(this);
					}
					this._Category.Entity = value;
					if ((value != null))
					{
						value.Book_Category.Add(this);
						this._FkIdCategory = value.IdCategory;
					}
					else
					{
						this._FkIdCategory = default(int);
					}
					this.SendPropertyChanged("Category");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _IdCategory;
		
		private string _CategoryName;
		
		private EntitySet<Book_Category> _Book_Category;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdCategoryChanging(int value);
    partial void OnIdCategoryChanged();
    partial void OnCategoryNameChanging(string value);
    partial void OnCategoryNameChanged();
    #endregion
		
		public Category()
		{
			this._Book_Category = new EntitySet<Book_Category>(new Action<Book_Category>(this.attach_Book_Category), new Action<Book_Category>(this.detach_Book_Category));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IdCategory", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int IdCategory
		{
			get
			{
				return this._IdCategory;
			}
			set
			{
				if ((this._IdCategory != value))
				{
					this.OnIdCategoryChanging(value);
					this.SendPropertyChanging();
					this._IdCategory = value;
					this.SendPropertyChanged("IdCategory");
					this.OnIdCategoryChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryName", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string CategoryName
		{
			get
			{
				return this._CategoryName;
			}
			set
			{
				if ((this._CategoryName != value))
				{
					this.OnCategoryNameChanging(value);
					this.SendPropertyChanging();
					this._CategoryName = value;
					this.SendPropertyChanged("CategoryName");
					this.OnCategoryNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Book_Category", Storage="_Book_Category", ThisKey="IdCategory", OtherKey="FkIdCategory")]
		public EntitySet<Book_Category> Book_Category
		{
			get
			{
				return this._Book_Category;
			}
			set
			{
				this._Book_Category.Assign(value);
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
		
		private void attach_Book_Category(Book_Category entity)
		{
			this.SendPropertyChanging();
			entity.Category = this;
		}
		
		private void detach_Book_Category(Book_Category entity)
		{
			this.SendPropertyChanging();
			entity.Category = null;
		}
	}
}
#pragma warning restore 1591