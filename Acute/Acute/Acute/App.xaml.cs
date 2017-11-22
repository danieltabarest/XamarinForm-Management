using Acute.Data;
using Acute.Data.Base;
using Acute.Services;
using FreshMvvm;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acute.PageModels;
using Acute;
using System;
using Acute.Pages;
using Plugin.Iconize;
using Acute.Data.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Acute
{
    public partial class App : Application
    {

        public static App Instance;
        #region Properties
        public static NavigationPage Navigator { get; internal set; }

        public static MasterPage Master { get; internal set; }
        #endregion

        public App()
        {
            Instance = this;
            InitializeComponent();
            RegisterServices();
            RegisterNavigationContainers();

            Current.Resources = new ResourceDictionary();
            var navigationStyle = new Style(typeof(NavigationPage));
            var barTextColorSetter = new Setter { Property = NavigationPage.BarTextColorProperty, Value = Color.White};
            var barBackgroundColorSetter = new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = Color.FromHex("#39537D") };

            navigationStyle.Setters.Add(barTextColorSetter);
            navigationStyle.Setters.Add(barBackgroundColorSetter);

            Current.Resources.Add(navigationStyle);

            //SetMainPage();
        }


        private void RegisterNavigationContainers()
        {
            try
            {
                var loginPage = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
                MainPage = loginContainer;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        private void RegisterServices()
        {
            //if (Device.OS == TargetPlatform.iOS)
            //{
            //    return;
            //}
            FreshIOC.Container.Register<IRequestProvider, RequestProvider>();
            FreshIOC.Container.Register<IAPIContext, APIContext>();
            FreshIOC.Container.Register<IAuthenticationService, AuthenticationService>();

            FreshIOC.Container.Register<ISingleObjectCacheRepository<Models.UserProfile>, SingleObjectCacheRepository<Models.UserProfile,Data.RealmModels.UserProfile>>();
            
            FreshIOC.Container.Register<ISingleObjectCacheRepository<Models.UserAccount>, SingleObjectCacheRepository<Models.UserAccount, Data.RealmModels.UserAccount>>();
            /*            FreshIOC.Container.Register<IUserProfileService, UserProfileService>();

                        FreshIOC.Container.Register<ISingleObjectCacheRepository<Models.UserProfileImage>, SingleObjectCacheRepository<Models.UserProfileImage, Data.RealmModels.ProfileImage>>();
                        FreshIOC.Container.Register<ISingleObjectCacheRepository<Models.AccountSummary>, SingleObjectCacheRepository<Models.AccountSummary, Data.RealmModels.AccountSummary>>();
                        FreshIOC.Container.Register<ISingleObjectCacheRepository<Models.UserAccount>, SingleObjectCacheRepository<Models.UserAccount, Data.RealmModels.UserAccount>>();
                        FreshIOC.Container.Register<IObjectCollectionCacheRepository<Models.Term>, ObjectCollectionCacheRepository<Models.Term, Data.RealmModels.Term>>();*/
        }


       
    }
}
