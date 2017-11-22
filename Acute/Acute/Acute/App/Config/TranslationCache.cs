using System;
using System.Collections.Generic;

namespace Simedia.App
{
	public class TranslationCache
	{
		public TranslationCache()
		{
			this.Translations = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
		}
		public string culture { get; set; }
		public Dictionary<string, string> Translations { get; set; }
	}
}
