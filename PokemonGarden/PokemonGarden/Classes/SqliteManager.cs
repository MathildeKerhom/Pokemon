using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
using SQLite.Net.Interop;
using SQLite.Net.Platform.WinRT;
using Windows.Storage;

namespace PokemonGarden.Classes
{
	class SqliteManager<T> where T : EntityBase, new()
	{
		private SQLiteConnection manager;

		public SqliteManager()
		{
			this.manager = new SQLiteConnection(new SQLitePlatformWinRT(), ApplicationData.Current.LocalFolder.Path + @"\SQLiteDB");

			try
			{
				this.manager.CreateTable<T>();
			}
			catch (Exception e)
			{
				this.manager.MigrateTable<T>();
			}
		}

		public void Insert(T item)
		{
			this.manager.Insert(item);
		}

		public void InsertAllWithChildren(T item)
		{
			this.manager.InsertWithChildren(item);
		}

		//public void InsertAllWithChildren(List<T> items)
		//{
		//	this.manager.InsertAllWithChildren(items);
		//}

		public T Get(T item)
		{
			return this.manager.Get<T>(item.Id);
		}

		public T Get(int pk)
		{
			return this.manager.Get<T>(pk);
		}

		public List<T> Get(List<T> items)
		{
			List<T> result = new List<T>();

			foreach (T item in items)
			{
				result.Add(Get(item));
			}

			return result;
		}

		public List<T> Get(List<int> items)
		{
			List<T> result = new List<T>();

			foreach (int item in items)
			{
				result.Add(Get(item));
			}

			return result;
		}

		public T GetWithChildren(int pk)
		{
			return this.manager.GetWithChildren<T>(pk);
		}
	}
}
