﻿using System.Collections.Generic;
using System.IO;
using System.Web;
using Sokool.Net.DataLibrary.Data;

namespace Sokool.Net.Web.Models
{
	public class SamplesModel : List<Sample>
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="SamplesModel" /> class.
		/// A list of Sample objects is created from all sample files in the specified virtual folder having the specified
		/// extension.
		/// </summary>
		/// <param name="virtualFolder">The virtual folder.</param>
		/// <param name="extension">The extension. [All files in the virtual folder are returned by default]</param>
		//------------------------------------------------------------------------------------------------------------------------
		public SamplesModel(string virtualFolder, string extension = ".*")
		{
			string physicalPath = HttpContext.Current.Server.MapPath(virtualFolder);
			var di = new DirectoryInfo(physicalPath);
			foreach (FileInfo file in di.EnumerateFiles("*" + extension, SearchOption.TopDirectoryOnly))
			{
				Add(new Sample(virtualFolder, file.FullName));
			}
		}
	}
}