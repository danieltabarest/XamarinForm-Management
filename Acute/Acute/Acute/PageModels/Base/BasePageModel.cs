using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using FreshMvvm;
using Xamarin.Forms;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Acute.PageModels.Base
{
    //[ImplementPropertyChanged]
    public abstract class BasePageModel : FreshBasePageModel, INotifyPropertyChanged
    {
        //public abstract string PageTitle { get; set; }

        private bool _isBusy;
        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;

                if (value)
                    UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
                else
                    UserDialogs.Instance.HideLoading();
            }
        }


        private bool _isEmpty;
        public bool IsEmpty
        {
            get
            {
                return _isEmpty;
            }

            set
            {
                _isEmpty = value;
            }
        }


        protected async Task DisplayAlert(string title, string message, string cancel)
        {
            await CoreMethods.DisplayAlert(title, message, cancel);
        }

        protected async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            return await CoreMethods.DisplayAlert(title, message, accept, cancel);
        }

        protected async Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
        {
            return await CoreMethods.DisplayActionSheet(title, cancel, destruction, buttons);
        }


        protected async Task PushModalAsync<T>() where T : FreshBasePageModel
        {
            await PushModalAsync<T>(null);
        }

        protected async Task PushModalAsync<T>(object data) where T : FreshBasePageModel
        {
            await CoreMethods.PushPageModel<T>(data, true, true);
        }

        protected async Task PushAsync<T>() where T : FreshBasePageModel
        {
            await CoreMethods.PushPageModel<T>(true);
        }

        //protected async Task PushAsync()
        //{
        //    await CoreMethods.PushPageModel(new AccordionView());
        //}

        protected async Task PushAsync<T>(object data) where T : FreshBasePageModel
        {
            await CoreMethods.PushPageModel<T>(data, false, true);
        }


        protected async Task PopToRootAsync()
        {
            await CoreMethods.PopToRoot(true);
        }

        protected async Task PopAsync()
        {
            await CoreMethods.PopPageModel(true);
        }

        protected async Task PopAsync(object data)
        {
            await CoreMethods.PopPageModel(data, false, true);
        }

        protected async Task PopModalAsync()
        {
            await CoreMethods.PopPageModel(true, true);
        }

        protected async Task PopModalAsync(object data)
        {
            await CoreMethods.PopPageModel(data, true, true);
        }

        protected async Task PushModalTabbedPageAsync(FreshTabbedNavigationContainer navigationContainer)
        {
            await CoreMethods.PushNewNavigationServiceModal(navigationContainer);
        }

        protected async Task PushModalNavigationPageAsync<T>() where T : FreshBasePageModel
        {
            var page = FreshMvvm.FreshPageModelResolver.ResolvePageModel<T>();
            var navigationContainer = new FreshNavigationContainer(page);

            await CoreMethods.PushNewNavigationServiceModal(navigationContainer, new FreshBasePageModel[] { page.GetModel() });
        }


        protected void SwitchToMainNavigation()
        {

            var dashboard = FreshPageModelResolver.ResolvePageModel<ProjectListPageModel>();
            var mainContainer = new FreshNavigationContainer(dashboard, NavigationContainerNames.MainContainer);
            CoreMethods.SwitchOutRootNavigation(NavigationContainerNames.MainContainer);
        }


        protected void SwitchToUnAuthenticatedNavigation()
        {
            CoreMethods.SwitchOutRootNavigation(NavigationContainerNames.AuthenicationContainer);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }



        protected void SendNotification<TSender>(string notificationKey, TSender arg) where TSender : class
        {
            MessagingCenter.Send<TSender>(arg, notificationKey);
        }

        protected void SubscribeToNotification<TSender>(object subscriber, string notificationKey, Action<TSender> callback) where TSender : class
        {
            MessagingCenter.Subscribe<TSender>(subscriber, notificationKey, callback);
        }

    }

    public class DelegateCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Constructor not using canExecute.
        /// </summary>
        /// <param name="execute"></param>
        public DelegateCommand(Action execute) : this(execute, null) { }

        /// <summary>
        /// Constructor using both execute and canExecute.
        /// </summary>
        /// <param name="execute"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// This method is called from XAML to evaluate if the command can be executed.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            if (_canExecute != null)
                return _canExecute();

            return true;
        }

        /// <summary>
        /// This method is called from XAML to execute the command.
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// This method allow us to force the execution of CanExecute method to reevaluate execution.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            var tmpHandle = CanExecuteChanged;
            if (tmpHandle != null)
                tmpHandle(this, new EventArgs());
        }

        /// <summary>
        /// This event notify XAML controls using the command to reevaluate the CanExecute of it.
        /// </summary>
        public event EventHandler CanExecuteChanged;
    }
}
