using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Acute.Helpers;
using Acute.Models;

using Xamarin.Forms;
using Acute.Services;
using System.Threading;
using Acute.PageModels.Base;
using Acute.Pages;
using FreshMvvm;
using System.ComponentModel;
using Simedia.App.SDK;

namespace Acute.PageModels
{

    public class LoginPageModel : BasePageModel, INotifyPropertyChanged
    {
        private readonly AuthenticationService _authenticationservice;
        private readonly IAuthenticationService _authenticationService;
        private CancellationTokenSource _cancel;
        public string Username
        {
            get;
            set;
        }

        public static LoginPageModel instance;
        public static LoginPageModel Instance
        {
            get { return instance; }
        }
        public string Password
        {
            get;
            set;
        }

        string errormessage;
        public string ErrorMessage
        {
            set
            {
                if (errormessage != value)
                {
                    errormessage = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ErrorMessage"));
                    }
                }
            }
            get
            {
                return errormessage;
            }
        }

        
        string messageLogin = "";
        public string MessageLogin
        {
            set
            {
                if (messageLogin != value)
                {
                    messageLogin = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MessageLogin"));
                    }
                }
            }
            get
            {
                return messageLogin;
            }
        }
        public bool RememberMe
        {
            get;
            set;
        }

        bool isEnabled;
        public bool IsEnabled
        {
            set
            {
                if (isEnabled != value)
                {
                    isEnabled = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsEnabled"));
                    }
                }
            }
            get
            {
                return isEnabled;
            }
        }
        bool errorvisible;
        public bool ErrorVisible
        {
            set
            {
                if (errorvisible != value)
                {
                    errorvisible = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ErrorVisible"));
                    }
                }
            }
            get
            {
                return errorvisible;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public LoginPageModel()
        {
            instance = this;
            //MessageLogin = "First Time Login / Première connexion";
        }

        public LoginPageModel(IAuthenticationService authenticationService)
        {
            FetchUsernameFromMemory();
            //_authenticationService = new AuthenticationService() ;
        }
        public SimediaSDK sdk { get; set; }
        public override void Init(object initData)
        {
            sdk = new SimediaSDK("https://acute360.com/");
            FetchUsernameFromMemory();
        }

        private void FetchUsernameFromMemory()
        {
            Username = LoginPageModel.Instance.sdk.AuthenticationService.Username;
            MessageLogin= LoginPageModel.Instance.sdk.AuthenticationService.Company;
            if (Username == "")
            {
                MessageLogin = "First Time Login / Première connexion";
            }
        }

        public Command ValidateCommand
        {
            get
            {
                return new Command(() => Enable());
            }
        }

        public Command LoginCommand
        {
            get
            {
                try
                {

                    return new Command(async () => await Login());
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }



        private void RememberUsername()
        {
            LoginPageModel.Instance.sdk.AuthenticationService.SaveUsername();
            //sdk.AuthenticationService.SaveUsername();
            //_authenticationService.SaveUsername();
        }


        private void ForgetUsername()
        {
            LoginPageModel.Instance.sdk.AuthenticationService.ClearUsername();
            //sdk.AuthenticationService.ClearUsername();
            //_authenticationService.ClearUsername();
        }

        private async Task Login()
        {
            var isAuthenticated = false;

            var alertMessage = "Please try again!";
            var alertTitle = "Authentication failed!";
            var okButtonLabel = "OK";

            try
            {
                IsBusy = true;
                DisableLoginButton();

                //isAuthenticated = await sdk.AuthenticationService.AuthenticateAsync("igor@simedia.ca", "1234567");
                isAuthenticated = await sdk.AuthenticationService.AuthenticateAsync(Username, Password);

                if (isAuthenticated)
                {
                    alertTitle = "Something went wrong!";
                    alertMessage = "Contact the system administrator.";
                    ErrorMessage = "Incorrect Crendentials";
                    ErrorVisible = true;
                }
            }
            catch (Exception ex)
            {
                alertTitle = "Something went wrong!";
                alertMessage = "Contact the system administrator.";
                ErrorMessage = ex.Message;
                ErrorVisible = true;
            }
            finally
            {
                IsBusy = false;
                EnableLoginButton();
            }

            if (isAuthenticated)
            {
                ClearForm();
                var loginPage = FreshPageModelResolver.ResolvePageModel<MasterPageModel>();
                var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
                App.Current.MainPage = loginContainer;
                RememberUsername();
                //SwitchToMainNavigation();
                return;
            }
            await DisplayAlert(alertTitle, alertMessage, okButtonLabel);
        }





        private void Enable()
        {
            IsEnabled = (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password));
        }

        private void ClearForm()
        {
            ErrorMessage = string.Empty;
            if (!RememberMe) Username = string.Empty;
            Password = string.Empty;
        }

        private void EnableLoginButton()
        {
            IsEnabled = true;
        }

        private void DisableLoginButton()
        {
            IsEnabled = false;
        }

        protected override void ViewIsAppearing(object sender, EventArgs e)
        {
            base.ViewIsAppearing(sender, e);
            NavigationPage.SetHasNavigationBar(CurrentPage, false);
        }
    }
}