using System;

namespace PeopleApp.Android
{
	public class FileAccessHelper
	{
		public FileAccessHelper()
		{
		}

		/// <summary>
		/// Gets the local file path.
		/// </summary>
		/// <returns>The local file path.</returns>
		/// <param name="filename">Filename.</param>
		public static string GetLocalFilePath(string filename)
		{
			var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return System.IO.Path.Combine(path, filename);

		}
	}
}

