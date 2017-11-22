using Acute.Models;
using Acute.PageModels.Base;
using FreshMvvm;
using Simedia.App.SDK;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.SpeechRecognition;
using Acr.UserDialogs;
using Plugin.TextToSpeech.Abstractions;
using Plugin.TextToSpeech;
using System.Threading;
using System.Reactive.Linq;
using Acute.Pages;
using Acute.DataServices.Interfaces.Models;
using Plugin.Connectivity;

namespace Acute.PageModels
{
    public class TaskContentPageModel : BasePageModel, INotifyPropertyChanged
    {
        public TaskContentPageModel()
        {
            speechReconizer = CrossSpeechRecognition.Current;

            speechReconizer
                .WhenListeningStatusChanged()
                .Subscribe(x => this.ListenText = x
                    ? "Listening..."
                    : ""
                );
            sdk = new SimediaSDK("https://acute360.com/");
            OnTaskEditClicked = new Command(TaskEditClicked);
            instance = this;
            this.speechReconizer = CrossSpeechRecognition.Current;
            SimediaSDK = new SimediaSDK("https://acute360.com/");
            Init(TaskListPageModel.Instance.activitySelected);
            //PageTitle = TaskListPageModel.Instance.activitySelected.name;
        }
        public SimediaSDK sdk { get; set; }
        public static TaskContentPageModel instance;
        public static TaskContentPageModel Instance
        {
            get { return instance; }
        }
        public ICommand OnTaskEditClicked { get; private set; }
        private async void TaskEditClicked(object obj)
        {
            try
            {
                //var tasklog = (AttributesTaskLog)obj;
                //var loginPage = FreshPageModelResolver.ResolvePageModel<EditTaskListPageModel>(obj);
                //var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);

                AttributesTaskLogSelected = (AttributesTaskLog)obj;
                //var loginPage = FreshPageModelResolver.ResolvePageModel<TaskContentPageModel>(obj);
                //var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
                await App.Navigator.PushAsync(new EditTaskListPage());
                //App.Master.IsPresented = false;
                //await App.Navigator.PushAsync(loginContainer);
            }
            catch (Exception ex)
            {
            }
        }

        private bool isRefreshing = false;
        public bool IsRefreshing
        {
            set
            {
                if (isRefreshing != value)
                {
                    isRefreshing = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("IsRefreshing"));
                    }
                }
            }
            get
            {
                return isRefreshing;
            }
        }


        public Command RefreshCommand
        {
            get
            {
                return new Command(() => Refresh());
            }
        }

        public void Refresh()
        {
            IsRefreshing = true;
            LoadTasks();
            IsRefreshing = false;
        }
        public AttributesTaskLog AttributesTaskLogSelected { get; set; }
        public SimediaSDK SimediaSDK { get; set; }
        Attributes _activiy;
        public Attributes _Activiy
        {
            set
            {
                if (_activiy != value)
                {
                    _activiy = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("_Activiy"));
                    }
                }
            }
            get
            {
                return _activiy;
            }
        }
        string activiyname;
        public string ActiviyName
        {
            set
            {
                if (activiyname != value)
                {
                    activiyname = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ActiviyName"));
                    }
                }
            }
            get
            {
                return activiyname;
            }
        }

        ObservableCollection<AttributesTaskLog> tasklog;
        public ObservableCollection<AttributesTaskLog> TaskLog
        {
            set
            {
                if (tasklog != value)
                {
                    tasklog = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("TaskLog"));
                    }
                }
            }
            get
            {
                return tasklog;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        readonly IUserDialogs dialogs = UserDialogs.Instance;
        readonly ISpeechRecognizer speechReconizer;
        IDisposable token = null;

        string listenText = "";
        public string ListenText
        {
            set
            {
                if (listenText != value)
                {
                    listenText = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("ListenText"));
                    }
                }
            }
            get
            {
                return listenText;
            }
        }

        public Command SpeechRecognitionCommand
        {
            get
            {
                return new Command(() => SpeechRecognition());
            }
        }

        private async void SpeechRecognition()
        {
            try
            {
                if (!speechReconizer.IsSupported)
                    this.PermissionStatus = "SPEECH RECOGNITION NOT SUPPORTED";

                if (!this.speechReconizer.IsSupported)
                {
                    await DisplayAlert("Message", PermissionStatus, "Close");
                    return;
                }

                var result = await CrossSpeechRecognition.Current.RequestPermission();
                this.PermissionStatus = result.ToString();
                if (PermissionStatus == "Available")
                {
                    this.DoConversation();
                }

            }
            catch (Exception ex)
            {

            }
        }

        public ObservableCollection<ListItemSpeech> Items { get; } = new ObservableCollection<ListItemSpeech>();
        void DoConversation()
        {
            try
            {
                if (token == null)
                {
                    //if (this.useContinuous)
                    //{
                    token = speechReconizer
                        .ContinuousDictation()
                        .Catch<string, Exception>(ex => Observable.Return(ex.ToString()))
                        .Subscribe(x => this.TextSpeech += " " + x);
                    //}
                    //else
                    //{
                    //token = speechReconizer
                    //    .ListenUntilPause()
                    //    .Subscribe(x => this.TextSpeech += " " + x);
                    //}
                }
                else
                {
                    token.Dispose();
                    token = null;
                    this.ListenText = "";
                }

            }
            catch (Exception ex)
            {

            }

        }

        string textspeech;
        public string TextSpeech
        {
            set
            {
                if (textspeech != value)
                {
                    textspeech = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("TextSpeech"));
                    }
                }

            }
            get
            {
                return textspeech;
            }
        }

        string permissionStatus = "Unknown";
        public string PermissionStatus
        {
            set
            {
                if (this.permissionStatus != value)
                {
                    this.permissionStatus = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PermissionStatus"));
                    }
                }
            }
            get
            {
                return this.permissionStatus;
            }
        }
        string pagetitle = "";
        public string PageTitle
        {
            set
            {
                if (pagetitle != value)
                {
                    pagetitle = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PageTitle"));
                    }
                }
            }
            get
            {
                return pagetitle;
            }
        }

        public override void Init(object initData)
        {
            base.Init(initData);
            if (initData != null)
            {
                _Activiy = ((Attributes)initData);
            }

            if (initData != null)
            {
                if (initData is Attributes)
                {
                    _Activiy = (Attributes)initData;
                }
                ActiviyName = _Activiy.name;
            }
            PageTitle = _Activiy.name;
            TextSpeech = _Activiy.myValidation;
            base.Init(initData);
            LoadTasks();
        }


        public Command SumaryCommand
        {
            get
            {
                try
                {
                    return new Command(async () => await DisplaySumary());
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        private async Task DisplaySumary()
        {
            await App.Current.MainPage.DisplayAlert("Summary of the activity", "1 Validation is a periodic analysis of the experimentations and work undertaken to implement the activity’s solution to validate the hypothesis." +
                            "Validate / explain over a selected period the success or failure of the work and experimentation undertaken to implement a solution to the Task’s objective" +
                            "Validate or reject the hypothesis if there is sufficient information to do so.", "Close");

        }


        public Command AddTaskCommand
        {
            get
            {
                return new Command(async () => await AddTask());
            }
        }

        public Command SaveCommand
        {
            get
            {
                return new Command(async () => await SaveActivity());
            }
        }

        private async Task SaveActivity()
        {
            if (!CrossConnectivity.Current.IsConnected)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Check you internet connection.", "Cancel");
                return;
            }


            var isReachable = await CrossConnectivity.Current.IsRemoteReachable("google.com");
            if (!isReachable)
            {

                await App.Current.MainPage.DisplayAlert("Error", "Check you internet connection.", "Cancel");
                return;
            }

            IsBusy = true;

            var alertMessage = "Please try again!";
            var alertTitle = "Authentication failed!";
            var okButtonLabel = "OK";
            bool activitylogs = true;
            try
            {
                var jsonactivitylog = new JsonActivityEdit();
                jsonactivitylog.data = new JsonDatumEdit();
                var dataactivitylog = new JsonDatumEdit();
                dataactivitylog.attributes = new JsonAttributes();
                dataactivitylog.attributes.myValidation = TextSpeech;
                dataactivitylog.id = _Activiy.idactivity;
                dataactivitylog.type = "activities";
                jsonactivitylog.data = dataactivitylog;
                activitylogs = await sdk.TaskLogService.UpdateValidationActivityAsync(jsonactivitylog);

                if (activitylogs == false)
                {
                    alertTitle = "Something went wrong!";
                    alertMessage = "Contact the system administrator.";
                }
                else
                {
                    alertTitle = "Message!";
                    alertMessage = "Successfully Saved.";
                }
            }
            catch (Exception ex)
            {
                alertTitle = "Something went wrong!";
                alertMessage = "Contact the system administrator.";
            }
            finally
            {
                IsBusy = false;
            }
            await App.Current.MainPage.DisplayAlert(alertTitle, alertMessage, okButtonLabel);
            //await App.Navigator.PopAsync();
        }

        public Command OpenMenuCommand
        {
            get
            {
                return new Command(() => OpenMenu());
            }
        }

        private void OpenMenu()
        {
            App.Master.IsPresented = true;
        }

        private async Task AddTask()
        {
            try
            {

                await App.Navigator.PushAsync(new AddTaskListPage());

                //var loginPage = FreshPageModelResolver.ResolvePageModel<AddTaskListPageModel>();
                //var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
                //App.Master.IsPresented = false;
                //await App.Navigator.PushAsync(loginContainer);
            }
            catch (Exception ex)
            {
            }
        }

        public Dictionary<string, List<DataAttachGet>> attachTasklog { get; set; }

        public async void LoadTasks()
        {
            IsBusy = true;
            try
            {
                attachTasklog = new Dictionary<string, List<DataAttachGet>>();
                var tasklogs = await this.SimediaSDK.TaskLogService.TaskLogByActivityAsync(_Activiy.idactivity.ToString());
                var groupedincludes = tasklogs.included.Where(y => y.type == "attachments").ToList();
                
                foreach (var item in tasklogs.data)
                {
                    int idIncludeAttach = 0; int idtasklog = 0;
                    foreach (var items in item.relationships.attachments.data)
                    {
                        idtasklog = item.id;
                        groupedincludes.Where(x => x.id == items.id);
                        idIncludeAttach = items.id;
                        if (!attachTasklog.ContainsKey(idIncludeAttach + " " + idtasklog))
                        {
                            attachTasklog.Add(idIncludeAttach + " " + idtasklog, groupedincludes);
                        }
                    }
                    
                }

                var groupedtasklogs = tasklogs.data.Where(y => y.type == "tasklogs").ToList();

                var taskloglist = (from u in groupedtasklogs
                                   orderby u.attributes.date
                                   select new AttributesTaskLog()
                                   {
                                       idactivity = _Activiy.idactivity.ToString(),
                                       idtasklog = u.id,
                                       comment = u.attributes.comment,
                                       date = u.attributes.date,
                                       minutes = u.attributes.minutes,
                                       percentRnd = u.attributes.percentRnd,
                                   });


                TaskLog = new ObservableCollection<AttributesTaskLog>(taskloglist.OrderByDescending(x => x.date));
                PageTitle = TaskListPageModel.Instance.activitySelected.name;
            }
            catch (Exception ex)
            {
                //await DisplayDataErrorMessage();
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
