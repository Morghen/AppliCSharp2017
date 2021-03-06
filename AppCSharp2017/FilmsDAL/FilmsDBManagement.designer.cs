﻿#pragma warning disable 1591
#pragma warning disable 0659
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FilmsDAL
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="FilmDB")]
	public partial class FilmsDBManagementDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertActor(Actor instance);
    partial void UpdateActor(Actor instance);
    partial void DeleteActor(Actor instance);
    partial void InsertFilm(Film instance);
    partial void UpdateFilm(Film instance);
    partial void DeleteFilm(Film instance);
    partial void InsertFilmActor(FilmActor instance);
    partial void UpdateFilmActor(FilmActor instance);
    partial void DeleteFilmActor(FilmActor instance);
    partial void InsertFilmGenre(FilmGenre instance);
    partial void UpdateFilmGenre(FilmGenre instance);
    partial void DeleteFilmGenre(FilmGenre instance);
    partial void InsertFilmRealisateur(FilmRealisateur instance);
    partial void UpdateFilmRealisateur(FilmRealisateur instance);
    partial void DeleteFilmRealisateur(FilmRealisateur instance);
    partial void InsertGenre(Genre instance);
    partial void UpdateGenre(Genre instance);
    partial void DeleteGenre(Genre instance);
    partial void InsertRealisateur(Realisateur instance);
    partial void UpdateRealisateur(Realisateur instance);
    partial void DeleteRealisateur(Realisateur instance);
    #endregion
		
		public FilmsDBManagementDataContext() : 
				base(global::FilmsDAL.Properties.Settings.Default.FilmDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public FilmsDBManagementDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FilmsDBManagementDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FilmsDBManagementDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public FilmsDBManagementDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Actor> Actors
		{
			get
			{
				return this.GetTable<Actor>();
			}
		}
		
		public System.Data.Linq.Table<Film> Films
		{
			get
			{
				return this.GetTable<Film>();
			}
		}
		
		public System.Data.Linq.Table<FilmActor> FilmActors
		{
			get
			{
				return this.GetTable<FilmActor>();
			}
		}
		
		public System.Data.Linq.Table<FilmGenre> FilmGenres
		{
			get
			{
				return this.GetTable<FilmGenre>();
			}
		}
		
		public System.Data.Linq.Table<FilmRealisateur> FilmRealisateurs
		{
			get
			{
				return this.GetTable<FilmRealisateur>();
			}
		}
		
		public System.Data.Linq.Table<Genre> Genres
		{
			get
			{
				return this.GetTable<Genre>();
			}
		}
		
		public System.Data.Linq.Table<Realisateur> Realisateurs
		{
			get
			{
				return this.GetTable<Realisateur>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Actor")]
	public partial class Actor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private string _character;
		
		private EntitySet<FilmActor> _FilmActors;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OncharacterChanging(string value);
    partial void OncharacterChanged();
    #endregion
		
		public Actor()
		{
			this._FilmActors = new EntitySet<FilmActor>(new Action<FilmActor>(this.attach_FilmActors), new Action<FilmActor>(this.detach_FilmActors));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_character", DbType="VarChar(200) NOT NULL", CanBeNull=false)]
		public string character
		{
			get
			{
				return this._character;
			}
			set
			{
				if ((this._character != value))
				{
					this.OncharacterChanging(value);
					this.SendPropertyChanging();
					this._character = value;
					this.SendPropertyChanged("character");
					this.OncharacterChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Actor_FilmActor", Storage="_FilmActors", ThisKey="id", OtherKey="id_actor")]
		public EntitySet<FilmActor> FilmActors
		{
			get
			{
				return this._FilmActors;
			}
			set
			{
				this._FilmActors.Assign(value);
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
		
		private void attach_FilmActors(FilmActor entity)
		{
			this.SendPropertyChanging();
			entity.Actor = this;
		}
		
		private void detach_FilmActors(FilmActor entity)
		{
			this.SendPropertyChanging();
			entity.Actor = null;
		}

        public override bool Equals(object obj)
        {
            var actor = obj as Actor;
            return actor != null &&
                   id == actor.id;
        }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Film")]
	public partial class Film : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _title;
		
		private string _original_title;
		
		private System.Nullable<int> _runtime;
		
		private string _posterpath;
		
		private string _url;
		
		private EntitySet<FilmActor> _FilmActors;
		
		private EntitySet<FilmGenre> _FilmGenres;
		
		private EntitySet<FilmRealisateur> _FilmRealisateurs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OntitleChanging(string value);
    partial void OntitleChanged();
    partial void Onoriginal_titleChanging(string value);
    partial void Onoriginal_titleChanged();
    partial void OnruntimeChanging(System.Nullable<int> value);
    partial void OnruntimeChanged();
    partial void OnposterpathChanging(string value);
    partial void OnposterpathChanged();
    partial void OnurlChanging(string value);
    partial void OnurlChanged();
    #endregion
		
		public Film()
		{
			this._FilmActors = new EntitySet<FilmActor>(new Action<FilmActor>(this.attach_FilmActors), new Action<FilmActor>(this.detach_FilmActors));
			this._FilmGenres = new EntitySet<FilmGenre>(new Action<FilmGenre>(this.attach_FilmGenres), new Action<FilmGenre>(this.detach_FilmGenres));
			this._FilmRealisateurs = new EntitySet<FilmRealisateur>(new Action<FilmRealisateur>(this.attach_FilmRealisateurs), new Action<FilmRealisateur>(this.detach_FilmRealisateurs));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				if ((this._title != value))
				{
					this.OntitleChanging(value);
					this.SendPropertyChanging();
					this._title = value;
					this.SendPropertyChanged("title");
					this.OntitleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_original_title", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string original_title
		{
			get
			{
				return this._original_title;
			}
			set
			{
				if ((this._original_title != value))
				{
					this.Onoriginal_titleChanging(value);
					this.SendPropertyChanging();
					this._original_title = value;
					this.SendPropertyChanged("original_title");
					this.Onoriginal_titleChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_runtime", DbType="Int")]
		public System.Nullable<int> runtime
		{
			get
			{
				return this._runtime;
			}
			set
			{
				if ((this._runtime != value))
				{
					this.OnruntimeChanging(value);
					this.SendPropertyChanging();
					this._runtime = value;
					this.SendPropertyChanged("runtime");
					this.OnruntimeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_posterpath", DbType="VarChar(100)")]
		public string posterpath
		{
			get
			{
				return this._posterpath;
			}
			set
			{
				if ((this._posterpath != value))
				{
					this.OnposterpathChanging(value);
					this.SendPropertyChanging();
					this._posterpath = value;
					this.SendPropertyChanged("posterpath");
					this.OnposterpathChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_url", DbType="VarChar(200)")]
		public string url
		{
			get
			{
				return this._url;
			}
			set
			{
				if ((this._url != value))
				{
					this.OnurlChanging(value);
					this.SendPropertyChanging();
					this._url = value;
					this.SendPropertyChanged("url");
					this.OnurlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Film_FilmActor", Storage="_FilmActors", ThisKey="id", OtherKey="id_film")]
		public EntitySet<FilmActor> FilmActors
		{
			get
			{
				return this._FilmActors;
			}
			set
			{
				this._FilmActors.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Film_FilmGenre", Storage="_FilmGenres", ThisKey="id", OtherKey="id_film")]
		public EntitySet<FilmGenre> FilmGenres
		{
			get
			{
				return this._FilmGenres;
			}
			set
			{
				this._FilmGenres.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Film_FilmRealisateur", Storage="_FilmRealisateurs", ThisKey="id", OtherKey="id_film")]
		public EntitySet<FilmRealisateur> FilmRealisateurs
		{
			get
			{
				return this._FilmRealisateurs;
			}
			set
			{
				this._FilmRealisateurs.Assign(value);
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
		
		private void attach_FilmActors(FilmActor entity)
		{
			this.SendPropertyChanging();
			entity.Film = this;
		}
		
		private void detach_FilmActors(FilmActor entity)
		{
			this.SendPropertyChanging();
			entity.Film = null;
		}
		
		private void attach_FilmGenres(FilmGenre entity)
		{
			this.SendPropertyChanging();
			entity.Film = this;
		}
		
		private void detach_FilmGenres(FilmGenre entity)
		{
			this.SendPropertyChanging();
			entity.Film = null;
		}
		
		private void attach_FilmRealisateurs(FilmRealisateur entity)
		{
			this.SendPropertyChanging();
			entity.Film = this;
		}
		
		private void detach_FilmRealisateurs(FilmRealisateur entity)
		{
			this.SendPropertyChanging();
			entity.Film = null;
		}

        public override bool Equals(object obj)
        {
            var film = obj as Film;
            return film != null &&
                   id == film.id;
        }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FilmActor")]
	public partial class FilmActor : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _id_film;
		
		private int _id_actor;
		
		private EntityRef<Actor> _Actor;
		
		private EntityRef<Film> _Film;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onid_filmChanging(int value);
    partial void Onid_filmChanged();
    partial void Onid_actorChanging(int value);
    partial void Onid_actorChanged();
    #endregion
		
		public FilmActor()
		{
			this._Actor = default(EntityRef<Actor>);
			this._Film = default(EntityRef<Film>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_film", DbType="Int NOT NULL")]
		public int id_film
		{
			get
			{
				return this._id_film;
			}
			set
			{
				if ((this._id_film != value))
				{
					if (this._Film.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_filmChanging(value);
					this.SendPropertyChanging();
					this._id_film = value;
					this.SendPropertyChanged("id_film");
					this.Onid_filmChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_actor", DbType="Int NOT NULL")]
		public int id_actor
		{
			get
			{
				return this._id_actor;
			}
			set
			{
				if ((this._id_actor != value))
				{
					if (this._Actor.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_actorChanging(value);
					this.SendPropertyChanging();
					this._id_actor = value;
					this.SendPropertyChanged("id_actor");
					this.Onid_actorChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Actor_FilmActor", Storage="_Actor", ThisKey="id_actor", OtherKey="id", IsForeignKey=true)]
		public Actor Actor
		{
			get
			{
				return this._Actor.Entity;
			}
			set
			{
				Actor previousValue = this._Actor.Entity;
				if (((previousValue != value) 
							|| (this._Actor.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Actor.Entity = null;
						previousValue.FilmActors.Remove(this);
					}
					this._Actor.Entity = value;
					if ((value != null))
					{
						value.FilmActors.Add(this);
						this._id_actor = value.id;
					}
					else
					{
						this._id_actor = default(int);
					}
					this.SendPropertyChanged("Actor");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Film_FilmActor", Storage="_Film", ThisKey="id_film", OtherKey="id", IsForeignKey=true)]
		public Film Film
		{
			get
			{
				return this._Film.Entity;
			}
			set
			{
				Film previousValue = this._Film.Entity;
				if (((previousValue != value) 
							|| (this._Film.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Film.Entity = null;
						previousValue.FilmActors.Remove(this);
					}
					this._Film.Entity = value;
					if ((value != null))
					{
						value.FilmActors.Add(this);
						this._id_film = value.id;
					}
					else
					{
						this._id_film = default(int);
					}
					this.SendPropertyChanged("Film");
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

        public override bool Equals(object obj)
        {
            var actor = obj as FilmActor;
            return actor != null &&
                   id == actor.id;
        }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FilmGenre")]
	public partial class FilmGenre : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _id_film;
		
		private int _id_genre;
		
		private EntityRef<Film> _Film;
		
		private EntityRef<Genre> _Genre;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onid_filmChanging(int value);
    partial void Onid_filmChanged();
    partial void Onid_genreChanging(int value);
    partial void Onid_genreChanged();
    #endregion
		
		public FilmGenre()
		{
			this._Film = default(EntityRef<Film>);
			this._Genre = default(EntityRef<Genre>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_film", DbType="Int NOT NULL")]
		public int id_film
		{
			get
			{
				return this._id_film;
			}
			set
			{
				if ((this._id_film != value))
				{
					if (this._Film.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_filmChanging(value);
					this.SendPropertyChanging();
					this._id_film = value;
					this.SendPropertyChanged("id_film");
					this.Onid_filmChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_genre", DbType="Int NOT NULL")]
		public int id_genre
		{
			get
			{
				return this._id_genre;
			}
			set
			{
				if ((this._id_genre != value))
				{
					if (this._Genre.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_genreChanging(value);
					this.SendPropertyChanging();
					this._id_genre = value;
					this.SendPropertyChanged("id_genre");
					this.Onid_genreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Film_FilmGenre", Storage="_Film", ThisKey="id_film", OtherKey="id", IsForeignKey=true)]
		public Film Film
		{
			get
			{
				return this._Film.Entity;
			}
			set
			{
				Film previousValue = this._Film.Entity;
				if (((previousValue != value) 
							|| (this._Film.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Film.Entity = null;
						previousValue.FilmGenres.Remove(this);
					}
					this._Film.Entity = value;
					if ((value != null))
					{
						value.FilmGenres.Add(this);
						this._id_film = value.id;
					}
					else
					{
						this._id_film = default(int);
					}
					this.SendPropertyChanged("Film");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Genre_FilmGenre", Storage="_Genre", ThisKey="id_genre", OtherKey="id", IsForeignKey=true)]
		public Genre Genre
		{
			get
			{
				return this._Genre.Entity;
			}
			set
			{
				Genre previousValue = this._Genre.Entity;
				if (((previousValue != value) 
							|| (this._Genre.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Genre.Entity = null;
						previousValue.FilmGenres.Remove(this);
					}
					this._Genre.Entity = value;
					if ((value != null))
					{
						value.FilmGenres.Add(this);
						this._id_genre = value.id;
					}
					else
					{
						this._id_genre = default(int);
					}
					this.SendPropertyChanged("Genre");
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

        public override bool Equals(object obj)
        {
            var genre = obj as FilmGenre;
            return genre != null &&
                   id == genre.id;
        }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.FilmRealisateur")]
	public partial class FilmRealisateur : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private int _id_film;
		
		private int _id_realisateur;
		
		private EntityRef<Film> _Film;
		
		private EntityRef<Realisateur> _Realisateur;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void Onid_filmChanging(int value);
    partial void Onid_filmChanged();
    partial void Onid_realisateurChanging(int value);
    partial void Onid_realisateurChanged();
    #endregion
		
		public FilmRealisateur()
		{
			this._Film = default(EntityRef<Film>);
			this._Realisateur = default(EntityRef<Realisateur>);
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_film", DbType="Int NOT NULL")]
		public int id_film
		{
			get
			{
				return this._id_film;
			}
			set
			{
				if ((this._id_film != value))
				{
					if (this._Film.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_filmChanging(value);
					this.SendPropertyChanging();
					this._id_film = value;
					this.SendPropertyChanged("id_film");
					this.Onid_filmChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id_realisateur", DbType="Int NOT NULL")]
		public int id_realisateur
		{
			get
			{
				return this._id_realisateur;
			}
			set
			{
				if ((this._id_realisateur != value))
				{
					if (this._Realisateur.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.Onid_realisateurChanging(value);
					this.SendPropertyChanging();
					this._id_realisateur = value;
					this.SendPropertyChanged("id_realisateur");
					this.Onid_realisateurChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Film_FilmRealisateur", Storage="_Film", ThisKey="id_film", OtherKey="id", IsForeignKey=true)]
		public Film Film
		{
			get
			{
				return this._Film.Entity;
			}
			set
			{
				Film previousValue = this._Film.Entity;
				if (((previousValue != value) 
							|| (this._Film.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Film.Entity = null;
						previousValue.FilmRealisateurs.Remove(this);
					}
					this._Film.Entity = value;
					if ((value != null))
					{
						value.FilmRealisateurs.Add(this);
						this._id_film = value.id;
					}
					else
					{
						this._id_film = default(int);
					}
					this.SendPropertyChanged("Film");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Realisateur_FilmRealisateur", Storage="_Realisateur", ThisKey="id_realisateur", OtherKey="id", IsForeignKey=true)]
		public Realisateur Realisateur
		{
			get
			{
				return this._Realisateur.Entity;
			}
			set
			{
				Realisateur previousValue = this._Realisateur.Entity;
				if (((previousValue != value) 
							|| (this._Realisateur.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Realisateur.Entity = null;
						previousValue.FilmRealisateurs.Remove(this);
					}
					this._Realisateur.Entity = value;
					if ((value != null))
					{
						value.FilmRealisateurs.Add(this);
						this._id_realisateur = value.id;
					}
					else
					{
						this._id_realisateur = default(int);
					}
					this.SendPropertyChanged("Realisateur");
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

        public override bool Equals(object obj)
        {
            var realisateur = obj as FilmRealisateur;
            return realisateur != null &&
                   id == realisateur.id;
        }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Genre")]
	public partial class Genre : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<FilmGenre> _FilmGenres;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Genre()
		{
			this._FilmGenres = new EntitySet<FilmGenre>(new Action<FilmGenre>(this.attach_FilmGenres), new Action<FilmGenre>(this.detach_FilmGenres));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Genre_FilmGenre", Storage="_FilmGenres", ThisKey="id", OtherKey="id_genre")]
		public EntitySet<FilmGenre> FilmGenres
		{
			get
			{
				return this._FilmGenres;
			}
			set
			{
				this._FilmGenres.Assign(value);
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
		
		private void attach_FilmGenres(FilmGenre entity)
		{
			this.SendPropertyChanging();
			entity.Genre = this;
		}
		
		private void detach_FilmGenres(FilmGenre entity)
		{
			this.SendPropertyChanging();
			entity.Genre = null;
		}

        public override bool Equals(object obj)
        {
            var genre = obj as Genre;
            return genre != null &&
                   id == genre.id;
        }
    }
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Realisateur")]
	public partial class Realisateur : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<FilmRealisateur> _FilmRealisateurs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Realisateur()
		{
			this._FilmRealisateurs = new EntitySet<FilmRealisateur>(new Action<FilmRealisateur>(this.attach_FilmRealisateurs), new Action<FilmRealisateur>(this.detach_FilmRealisateurs));
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Realisateur_FilmRealisateur", Storage="_FilmRealisateurs", ThisKey="id", OtherKey="id_realisateur")]
		public EntitySet<FilmRealisateur> FilmRealisateurs
		{
			get
			{
				return this._FilmRealisateurs;
			}
			set
			{
				this._FilmRealisateurs.Assign(value);
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
		
		private void attach_FilmRealisateurs(FilmRealisateur entity)
		{
			this.SendPropertyChanging();
			entity.Realisateur = this;
		}
		
		private void detach_FilmRealisateurs(FilmRealisateur entity)
		{
			this.SendPropertyChanging();
			entity.Realisateur = null;
		}

        public override bool Equals(object obj)
        {
            var realisateur = obj as Realisateur;
            return realisateur != null &&
                   id == realisateur.id;
        }
    }
}
#pragma warning restore 1591
#pragma warning restore 0659
