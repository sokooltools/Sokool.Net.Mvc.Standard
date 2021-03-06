﻿namespace Sokool.Net.DataLibrary.Data
{
	public class Photo
	{
		public string Path { get; private set; }

		public string Description { get; private set; }

		//------------------------------------------------------------------------------------------------------------------------
		/// <summary>
		/// Initializes a new instance of the <see cref="Photo" /> class.
		/// </summary>
		/// <param name="virtualFolder">The virtual folder.</param>
		/// <param name="description">The description.</param>
		//------------------------------------------------------------------------------------------------------------------------
		public Photo(string virtualFolder, string description)
		{
			Path = virtualFolder;
			Description = description;
		}
	}
}