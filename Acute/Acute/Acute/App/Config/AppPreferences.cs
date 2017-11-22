using System;
namespace Simedia.App
{
	public class AppPreferences
	{
		public AppPreferences()
		{
		}
		public DateTime? LastTranslationCheck { get; set; }
		public string LastTranslationCulture { get; set; }
	}
}
