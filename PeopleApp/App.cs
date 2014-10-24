using System;
using Xamarin.Forms;
using SQLite.Net.Interop;

namespace PeopleApp
{
	public class App
	{
		public static PersonRepository PersonRepository { get; private set;}

		/// <summary>
		/// Gets the main page.
		/// </summary>
		/// <returns>The main page.</returns>
		/// <param name="displayText">Display text.</param>
		public static Page GetMainPage(ISQLitePlatform sqlitePlatform, string dbPath)
		{	
			PersonRepository = new PersonRepository(sqlitePlatform, dbPath);
			return new MainPage();
		}
	}
}

