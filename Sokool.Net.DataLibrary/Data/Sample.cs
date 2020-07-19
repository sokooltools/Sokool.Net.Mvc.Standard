using System;
using System.IO;

namespace Sokool.Net.DataLibrary.Data
{
	public class Sample
	{
		public string VirtualPath { get; private set; }

		public string PhysicalPath { get; private set; }

		public string Name { get; private set; }

		public string FileName { get; private set; }

		public string Extension { get; private set; }

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="Sample" /> class.
		/// </summary>
		/// <param name="virtualFolder">The virtualFolder.</param>
		/// <param name="physicalPath">The physicalPath.</param>
		//------------------------------------------------------------------------------------------------------------------------
		public Sample(string virtualFolder, string physicalPath)
		{
			PhysicalPath = physicalPath;
			FileName = Path.GetFileName(physicalPath);
			Name = Path.GetFileNameWithoutExtension(physicalPath);
			Extension = Path.GetExtension(physicalPath);
			VirtualPath = String.Concat(virtualFolder.TrimStart('~'), FileName);
		}
	}
}