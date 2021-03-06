﻿using System.IO;

namespace vskh.UNIXUtils.Concat
{
	public struct Source
	{
		public Source(string description, TextReader reader)
		{
			Description = description;
			Reader = reader;
		}

		public TextReader Reader { get; }
		public string Description { get; }
	}
}