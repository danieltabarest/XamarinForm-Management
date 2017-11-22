using Acute;
using Acute.Models;
using Acute.PageModels;
using Acute.Services;
using FreshMvvm;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Acute.ViewModels
{
    public class MenuItemViewModel
    {
        #region Attributes
        //private NavigationService navigationService;
        //private DataService dataService; 
        #endregion

        #region Properties
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }
        #endregion

        #region Constructors
        public MenuItemViewModel()
        {
            //LoadMenu();
            //navigationService = new NavigationService();
            //dataService = new DataService();
        }
        #endregion

        #region Commands
        public Command NavigateCommand { get { return new Command(() => Navigate()); } }

        private void Navigate()
        {
            //var mainviewModel = MainViewModel.GetInstance();

            if (PageName == "LoginPage")
            {
                var loginPage = FreshPageModelResolver.ResolvePageModel<LoginPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
                App.Current.MainPage = loginContainer;
            }
            if (PageName == "ProjectList")
            {
                var loginPage = FreshPageModelResolver.ResolvePageModel<MasterPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
                App.Current.MainPage = loginContainer;
            }

        }



        #endregion
    }


}