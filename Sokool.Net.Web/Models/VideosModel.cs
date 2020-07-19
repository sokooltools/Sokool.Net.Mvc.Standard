using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Sokool.Net.DataLibrary.Data;

namespace Sokool.Net.Web.Models
{
	public class VideosModel : ConcurrentBag<Video>
	{
		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="VideosModel" /> class.
		/// </summary>
		/// <param name="vf">The virtual folder containing the videos.</param>
		/// <param name="extension">
		/// The extension used to limit the results. [All files in the virtual folder are returned by default]
		/// </param>
		//------------------------------------------------------------------------------------------------------------------------
		public VideosModel(string vf, string extension = ".*")
		{
			string virtualFolderPath =  $@"~/assets/videos/{vf}/";

			string physicalPath = HttpContext.Current.Server.MapPath(virtualFolderPath);
			IEnumerable<FileInfo> fileSystemEntries =
				new DirectoryInfo(physicalPath).EnumerateFiles("*" + extension, SearchOption.TopDirectoryOnly);
			var options = new ParallelOptions
			{
				MaxDegreeOfParallelism = Environment.ProcessorCount * 2
			};
			Parallel.ForEach(fileSystemEntries, options,
				(fileInfo) =>
				{
					Add(new Video(vf, fileInfo.FullName));
				}
			);
		}
	}
}