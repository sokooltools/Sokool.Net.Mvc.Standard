using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Sokool.Net.DataLibrary.Data;

namespace Sokool.Net.Web.Models
{
	public class PhotosModel : List<Photo>
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="PhotosModel" /> class.
		/// </summary>
		/// <param name="folder">The folder containing the images.</param>
		/// <param name="extension">
		/// The extension used to limit the results. [All files in the virtual folder are returned by default]
		/// </param>
		//------------------------------------------------------------------------------------------------------------------------
		public PhotosModel(string folder, string extension = ".*")
		{
			string path = HttpContext.Current.Server.MapPath(folder);
			var di = new DirectoryInfo(path);
			foreach (FileInfo file in di.EnumerateFiles("*" + extension, SearchOption.TopDirectoryOnly))
			{
				Add(new Photo(String.Concat(folder, file.Name), Path.GetFileNameWithoutExtension(file.Name)));
			}
		}
	}
}