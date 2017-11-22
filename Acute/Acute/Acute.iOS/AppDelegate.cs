
using Acr.UserDialogs;
using Foundation;
using UIKit;
using IconEntry.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using FFImageLoading;

namespace Acute.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

            CachedImageRenderer.Init();

            var config = new FFImageLoading.Config.Configuration()
            {
                VerboseLogging = false,
                VerbosePerformanceLogging = false,
                VerboseMemoryCacheLogging = false,
                VerboseLoadingCancelledLogging = false,
                //Logger = new CustomLogger(),
            };
            //ImageService.Instance.Initialize(config);

            LoadApplication(new App());
            UIBarButtonItem.Appearance.SetBackButtonTitlePositionAdjustment(new UIOffset(-100, -60), UIBarMetrics.Default);
            //UINavigationBar.Appearance.BarTintColor = UIColor.FromPatternImage(UIImage.FromFile("background_header.jpg"));
            //this.NavigationController.NavigationBar.SetBackgroundImage(UIImage.FromFile("Images/background_header.jpg"), UIBarMetrics.Default);
            //this.NavigationController.NavigationBar.TintColor = UIColor.White;
            //this.NavigationController.NavigationBar.TitleTextAttributes = new UIStringAttributes()
            //{
            //    ForegroundColor = UIColor.White,
            //    Font = UIFont.FromName("OpenSans-Semibold", 15f)
            //};
            
            IconEntryRenderer.Init();
            //FormsPlugin.Iconize.iOS.IconControls.Init();
            //Plugin.Iconize.Iconize.With(new Plugin.Iconize.Fonts.FontAwesomeModule());
            return base.FinishedLaunching(app, options);
		}

        //public class CustomLogger : FFImageLoading.Helpers.IMiniLogger
        //{
        //    public void Debug(string message)
        //    {
        //        Console.WriteLine(message);
        //    }

        //    public void Error(string errorMessage)
        //    {
        //        Console.WriteLine(errorMessage);
        //    }

        //    public void Error(string errorMessage, Exception ex)
        //    {
        //        Error(errorMessage + System.Environment.NewLine + ex.ToString());
        //    }
        //}
    }
}
