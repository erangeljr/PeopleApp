using System;

namespace PeopleApp.iOS
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
			string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string libFolder = System.IO.Path.Combine(docFolder, "..", "Library", "Databases");

			if (!System.IO.Directory.Exists(libFolder))
			{
				System.IO.Directory.CreateDirectory(libFolder);
			}

			return System.IO.Path.Combine(libFolder, filename);
		}
	}
}

