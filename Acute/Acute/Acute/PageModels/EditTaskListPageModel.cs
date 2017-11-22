using Acute.DataServices.Interfaces.Models;
using Acute.Models;
using Acute.PageModels.Base;
using Acute.Services;
using FreshMvvm;
using Plugin.SpeechRecognition;
using Simedia.App.SDK;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Connectivity;
using Xamarin.Forms;
using Plugin.FilePicker.Abstractions;
using System.Collections.Generic;

namespace Acute.PageModels
{
    public class EditTaskListPageModel : BasePageModel, INotifyPropertyChanged
    {
        public EditTaskListPageModel()
        {
            //_authenticationService = authenticationService;
            instance = this;
            speechReconizer = CrossSpeechRecognition.Current;
            OnAttachClicked = new Command(AttachClicked);
            speechReconizer
                .WhenListeningStatusChanged()
                 .Subscribe(x => this.ListenText = x
                    ? "Listening..."
                    : ""
                );
            sdk = new SimediaSDK("https://acute360.com/");
            this.speechReconizer = CrossSpeechRecognition.Current;
            // configure the TapCommand with a method
            tapCommand = new Command(OnTapped);
            FetchUsernameFromMemory();
            PageTitle = TaskContentPageModel.Instance.AttributesTaskLogSelected.idtasklog.ToString();
            Attachments = new ObservableCollection<Attachment>();
            
            Init(TaskContentPageModel.Instance.AttributesTaskLogSelected);
        }

        string PercentageInicial;
        string HoursInicial;
        string TextSpeechInicial = "";
        List<Attachment> AttachmentsInicial = new List<Attachment>();
        public ICommand OnAttachClicked { get; private set; }
        public static EditTaskListPageModel instance;
        public static EditTaskListPageModel Instance
        {
            get { return instance; }
        }
        private void FetchUsernameFromMemory()
        {
            Username = LoginPageModel.Instance.sdk.AuthenticationService.Username;
        }
        public SimediaSDK sdk { get; set; }
        string username;
        public string Username
        {
            set
            {
                if (username != value)
                {
                    username = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Username"));
                    }
                }
            }
            get
            {
                return username;
            }
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



        private DateTime _fecha;

        public DateTime Fecha
        {
            get { return _fecha; }
            set
            {
                //_fecha = new DateTime(value.Year, value.Month, value.Day,
                //    Hora.Hour, Hora.Minute, Hora.Second);
                _fecha = new DateTime(value.Year, value.Month, value.Day, 0, 0, 0);
                RaisePropertyChanged();
            }
        }

        string percentage = "";
        public string Percentage
        {
            get { return percentage; }
            set
            {
                percentage = value;
                RaisePropertyChanged();
            }
        }

        string hours = "";
        public string Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                RaisePropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private string taskid;

        public string TaskId
        {
            get { return tasklog.idtasklog.ToString(); }
            set
            {
                taskid = value;
                RaisePropertyChanged();
            }
        }
        private string id;

        public string ID
        {
            get { return tasklog.idtasklog.ToString(); }
            set
            {
                id = value;
                RaisePropertyChanged();
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
        string pageTitle = "";
        public string PageTitle
        {
            set
            {
                if (pageTitle != value)
                {
                    pageTitle = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("PageTitle"));
                    }
                }
            }
            get
            {
                return pageTitle;
            }
        }
        AttributesTaskLog tasklog;
        public override void Init(object initData)
        {
            IsBusy = true;
            base.Init(initData);
            if (initData != null)
            {
                Tasklog = ((AttributesTaskLog)initData);
            }

            if (initData != null)
            {
                if (initData is AttributesTaskLog)
                {
                    Tasklog = (AttributesTaskLog)initData;
                }
                ActiviyName = tasklog.comment;
            }
            base.Init(initData);
            Fecha = Convert.ToDateTime(Tasklog.date);
            PercentageInicial = Percentage = Tasklog.percentRnd.ToString();
            TextSpeechInicial = TextSpeech = Tasklog.comment;
            HoursInicial = Hours = Tasklog.minutes.ToString();

            var task = TaskContentPageModel.Instance.attachTasklog;

            foreach (var item in task)
            {
                var split = item.Key.Split(' ');
                if (TaskContentPageModel.Instance.AttributesTaskLogSelected.idtasklog == Convert.ToInt32(split[1]))
                {
                    foreach (var items in item.Value)
                    {
                        if (items.id == Convert.ToInt32(split[0]))
                        {
                            Attachments.Add(new Attachment() { name = items.attributes.name, id = items.id });
                        }
                    }
                }
            }
            AttachmentsInicial.AddRange(Attachments);
            IsBusy = false;
        }

        public AttributesTaskLog Tasklog
        {
            set
            {
                if (tasklog != value)
                {
                    tasklog = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Tasklog"));
                    }
                }
            }
            get
            {
                return tasklog;
            }
        }


        int taps = 0;
        ICommand tapCommand;

        public ICommand TapCommand
        {
            get { return tapCommand; }
        }
        void OnTapped(object s)
        {
            taps++;
            //   Debug.WriteLine("parameter: " + s);
        }
        //region INotifyPropertyChanged code omitted

        public Command MoreCommand
        {
            get
            {
                return new Command(async () => await MoreInfoTask());
                //return new Command(async () => await PushAsync<TaskListPageModel>());
                //return new Command(() => App.Current.MainPage = new NavigationPage(new AccordionViewPage()));
                //return new Command(async () => await PushAsync<AccordionView>());
            }
        }

        private async Task MoreInfoTask()
        {
            App.Master.IsPresented = false;
            //await App.Navigator.PushAsync(new AccordionViewPage());
            //App.Current.MainPage = new NavigationPage(new AccordionViewPage());
        }

        //public Command<Project> ProjectSelected
        //{
        //    get
        //    {
        //        return new Command<Project>(async (Project) => await NavigateToProject(Project));
        //    }
        //}

        public Command TaskSelected
        {
            get
            {
                //return new Command(() => App.Current.MainPage = new NavigationPage(new AccordionViewPage()));
                return new Command(async () => await MoreInfoTask());
                //return new Command(async () => await PushAsync<TaskListPageModel>());
            }
        }


        readonly ISpeechRecognizer speechReconizer;
        IDisposable token = null;

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
            LoadAttach();
            IsRefreshing = false;
        }

        private void LoadAttach()
        {
            IsBusy = true;

            try
            {
                // this.Attachments.Clear();
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
                return new Command(async () => await SpeechRecognition());
            }
        }

        private async Task SpeechRecognition()
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

                //var result = await CrossSpeechRecognition.Current.RequestPermission();
                this.PermissionStatus = "Available";//result.ToString();
                if (PermissionStatus == "Available")
                {
                    this.DoConversation();
                }

            }
            catch (Exception ex)
            {

            }
        }

        ObservableCollection<Attachment> attachments;
        public ObservableCollection<Attachment> Attachments
        {
            set
            {
                if (attachments != value)
                {
                    attachments = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Attachments"));
                    }
                }
            }
            get
            {
                return attachments;
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
                    //    .Subscribe(x => this.Text += " " + x);
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


        public Command SaveCommand
        {
            get
            {
                return new Command(async () => await Edit());
            }
        }

        public Command AddAttachmentCommand
        {
            get
            {
                return new Command(async () => await AddAttachment());
            }
        }
        private async Task AddAttachment()
        {
            //IsBusy = true;
            var alertMessage = "File Loaded!";
            var alertTitle = "Message";
            var okButtonLabel = "OK";
            //bool tasklogs = true;
            FileData myResult = null;
            try
            {
                var crossFilePicker = Plugin.FilePicker.CrossFilePicker.Current;
                myResult = await crossFilePicker.PickFile();
                if (myResult != null)
                {
                    if (!string.IsNullOrEmpty(myResult.FileName)) //Just the file name, it doesn't has the path
                    {
                        //foreach (byte b in myResult.DataArray) //Empty array
                        //    b.ToString();
                        var _Attachment = new Attachment() { name = myResult.FileName, dataArray = myResult.DataArray, path = myResult.FilePath };
                        Attachments.Add(_Attachment);
                    }


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
                //IsBusy = false;
            }

            if (myResult != null)
            {
                await App.Current.MainPage.DisplayAlert(alertTitle, alertMessage, okButtonLabel);

            }

            ////await App.Navigator.PopAsync();
            //if (tasklogs == false)
            //{
            //    await App.Navigator.PopAsync();
            //}
        }

        private async Task<List<JsonAttach>> createattach()
        {
            try
            {
                var result = await sdk.TaskLogService.AddattachAsync(Attachments, "");
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private async void AttachClicked(object obj)
        {
            IsBusy = true;
          /*  var resp = await App.Current.MainPage.DisplayAlert("Alert", "Are you sure that you want to delete this record?", "Ok", "Cancel");
            if (resp == false)
            {
                IsBusy = false;
                return;
            }
            var alertMessage = "Please try again!";
            var alertTitle = "Authentication failed!";
            var okButtonLabel = "OK";
            var selected = (Acute.Models.Attachment)obj;
            Attachments.Remove(selected);

            //var JsonAttachments = new JsonAttachmentsSave();
            //foreach (var item in Attachments)
            //{
            //    JsonAttachments.data.Add(new DataAttach() { id = item.id, type = "attachments" });
            //}
            var result2 = false;
            foreach (var item in Attachments)
            {
                var JsonAttachments = new JsonAttachmentsSave();
                JsonAttachments.data = new DataAttach() { id = item.id, type = "attachments" };
                result2 = await sdk.TaskLogService.AddattachTaskLogAsync(JsonAttachments, Attachments, TaskContentPageModel.Instance.AttributesTaskLogSelected.idtasklog, "");
            }


            //var result2 = await sdk.TaskLogService.AddattachTaskLogAsync(JsonAttachments, Attachments, TaskContentPageModel.Instance.AttributesTaskLogSelected.idtasklog, "");

            if (result2 == false)
            {
                alertTitle = "Something went wrong!";
                alertMessage = "Contact the system administrator.";
                ErrorMessage = "Something went wrong!";
                ErrorVisible = true;
            }
            else
            {
                alertTitle = "Message!";
                alertMessage = "Successfully deleted.";
                //ErrorVisible = true;
            }
            await App.Current.MainPage.DisplayAlert(alertTitle, alertMessage, okButtonLabel);*/
            IsBusy = false;
        }

        private async Task Edit()
        {


            IsBusy = true;
            var alertMessage = "Please try again!";
            var alertTitle = "Authentication failed!";
            var okButtonLabel = "OK";
            GetJsonTasklog tasklog = null;
            try
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

                if (Hours == null || Percentage == null)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You must enter valid values", "Cancel");
                    return;

                }

                if (Convert.ToDouble(Hours) == 0 || Convert.ToDouble(Hours) < 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You must enter the hours.", "Cancel");
                    return;
                }

                if (Convert.ToDouble(Percentage) == 0 || Convert.ToDouble(Percentage) < 0)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You must enter the %RD.", "Cancel");
                    return;
                }
                if (Convert.ToDouble(Percentage) > 100)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You must enter valid  %RD.", "Cancel");
                    return;
                }
                if (TextSpeech == "")
                {
                    await App.Current.MainPage.DisplayAlert("Error", "You must enter the comments.", "Cancel");
                    return;
                }

                var listattach = new System.Collections.Generic.List<JsonAttach>();
                List<DataAttach> DataAttach = new List<DataAttach>();
                if (PercentageInicial == Percentage && HoursInicial == Hours && TextSpeechInicial == TextSpeech)
                {
                    if (Attachments.Count != AttachmentsInicial.Count)
                    {
                        listattach = await createattach();
                        foreach (var item in listattach)
                        {
                            if (item != null)
                            {
                                DataAttach.Add(item.data);
                            }
                        }
                    }
                    else
                    {
                        alertTitle = "Message!";
                        alertMessage = "No modifications.";
                        await App.Current.MainPage.DisplayAlert(alertTitle, alertMessage, okButtonLabel);
                        return;
                    }
                    if (AttachmentsInicial.Count != Attachments.Count)
                    {
                        bool result2 = false;


                        foreach (var item in DataAttach)
                        {
                            try
                            {
								if (item != null)
								{
									var JsonAttachments = new JsonAttachmentsSave();
									JsonAttachments.data = item;
									result2 = await sdk.TaskLogService.AddattachTaskLogAsync(JsonAttachments, Attachments, TaskContentPageModel.Instance.AttributesTaskLogSelected.idtasklog, "");
								}
                            }
                            catch (Exception)
                            {

                            }
                        }

                        if (result2 == false)
                        {
                            alertTitle = "Something went wrong!";
                            alertMessage = "Contact the system administrator.";
                            ErrorMessage = "Something went wrong!";
                            ErrorVisible = true;
                        }
                        else
                        {
                            alertTitle = "Message!";
                            alertMessage = "Successfully Saved.";
                            //ErrorVisible = true;
                        }


                        await App.Current.MainPage.DisplayAlert(alertTitle, alertMessage, okButtonLabel);
                        //await App.Navigator.PopAsync();
						if (result2 == true)
                        {
                            await App.Navigator.PopAsync();
                            return;
                        }
                    }

                }

                if (Attachments.Count > 0)
                {

                    listattach = await createattach();
                }

                //List<DataAttach> DataAttach = new List<DataAttach>();
                foreach (var item in listattach)
                {
					if (item != null)
					{
						DataAttach.Add(item.data);
					}
                }

                var jsontasklog = new JsonTaskLog();
                jsontasklog.data = new JsonDataTaskLog();
                var datatasklog = new JsonDataTaskLog();
                var relationshipstasklog = new JsonRelationshipsTaskLog();
                datatasklog.attributes = new JsonAttributesTaskLog();
                datatasklog.attributes.comment = TextSpeech;
                datatasklog.attributes.date = Fecha.ToString("yyyy-MM-dd");
                datatasklog.attributes.minutes = Convert.ToInt16(Hours);
                datatasklog.attributes.percentRnd = Convert.ToInt16(Percentage);
                datatasklog.type = "tasklogs";
                relationshipstasklog.activity = new JsonActivityTaskLog();
                relationshipstasklog.activity.data = new JsonDataActivityTaskLog();
                relationshipstasklog.activity.data.id = Convert.ToInt16(TaskContentPageModel.Instance._Activiy.idactivity);
                relationshipstasklog.activity.data.type = "activities";
                datatasklog.relationships = new JsonRelationshipsTaskLog();
                relationshipstasklog.attachments = new JsonAttachments();
                relationshipstasklog.attachments.data = new System.Collections.Generic.List<DataAttach>();
                datatasklog.relationships = relationshipstasklog;
                jsontasklog.data = datatasklog;
                tasklog = await sdk.TaskLogService.CreateTaskLogAsync(jsontasklog);



                if (tasklog == null)
                {
                    alertTitle = "Something went wrong!";
                    alertMessage = "Contact the system administrator.";
                    ErrorMessage = "Something went wrong!";
                    ErrorVisible = true;
                }
                else
                {
                    alertTitle = "Message!";
                    alertMessage = "Successfully Saved.";
                    //ErrorVisible = true;
                }
                // await App.Navigator.PopAsync();
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
            }
            await App.Current.MainPage.DisplayAlert(alertTitle, alertMessage, okButtonLabel);
            //await App.Navigator.PopAsync();
            if (tasklog != null)
            {
                await App.Navigator.PopAsync();
            }

        }

        public Command CancelCommand
        {
            get
            {
                return new Command(async () => await Cancel());
            }
        }

        private async Task Cancel()
        {
            IsBusy = true;

            try
            {
                await App.Navigator.PopAsync();
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
