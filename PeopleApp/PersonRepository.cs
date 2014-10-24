using System;
using SQLite.Net;
using SQLite.Net.Interop;
using PeopleApp.Models;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net.Async;
using System.Threading.Tasks;

namespace PeopleApp
{
	public class PersonRepository
	{
		private SQLiteAsyncConnection dbConn;
		public string StatusMessage{ get; set;}

		/// <summary>
		/// Initializes a new instance of the <see cref="PeopleApp.PersonRepository"/> class.
		/// </summary>
		public PersonRepository(ISQLitePlatform sqlitePlatform, string dbPath)
		{
			if(dbConn == null)
			{
				var connectionFunc = new Func<SQLiteConnectionWithLock>(() => 
					new SQLiteConnectionWithLock
					(
						sqlitePlatform,
						new SQLiteConnectionString(dbPath, storeDateTimeAsTicks:false)
					));
				dbConn = new SQLiteAsyncConnection(connectionFunc);
				dbConn.CreateTableAsync<Person>();
			}
		}

		/// <summary>
		/// Adds the new person async.
		/// </summary>
		/// <returns>The new person async.</returns>
		/// <param name="name">Name.</param>
		public async Task AddNewPersonAsync(string name)
		{
			var result = 0;
			try
			{
				//Test to ensure we have a name
				if(string.IsNullOrEmpty(name))
					throw new Exception("Valid Name Required");

				result = await dbConn.InsertAsync(new Person{Name = name});
				StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);

			}
			catch(Exception ex){
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
			}

		}

		/// <summary>
		/// Gets all people.
		/// </summary>
		/// <returns>The all people.</returns>
		public async Task<List<Person>> GetAllPeopleAsync()
		{
			var result = await dbConn.Table<Person>().ToListAsync();
			return result;

		}
	}
}

