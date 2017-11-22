using System;
namespace Acute.Models
{
    public class AppConfig
    {
		public static AppConfig ForPlatform(string platform)
		{
			//TODO:AppConfig: Any platform specifics, remember, no secrets!
			return new AppConfig();
		}
        public AppConfig()
        {
            this.Projects_InfiniteThresholdSize = 500;
            this.Projects_InfiniteThresholdCount = 3;
            this.Projects_PageSize = 8;
            this.Projects_StaleSeconds = 300;
        }

        public int Projects_InfiniteThresholdCount { get; set; }
        public int Projects_InfiniteThresholdSize { get; set; }
        public int Projects_PageSize { get; set; }
        public int Projects_StaleSeconds { get; set; }

		public int Tasks_InfiniteThresholdCount { get; set; }
		public int Tasks_InfiniteThresholdSize { get; set; }
		public int Tasks_PageSize { get; set; }
		public int Tasks_StaleSeconds { get; set; }
    }
}
