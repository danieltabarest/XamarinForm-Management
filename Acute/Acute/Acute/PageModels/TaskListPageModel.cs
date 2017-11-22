using Acute.Models;
using Acute.PageModels.Base;
using Acute.Pages;
using FreshMvvm;
using Simedia.App.SDK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Acute.PageModels
{
    public class TaskListPageModel : BasePageModel, INotifyPropertyChanged
    {


        public static TaskListPageModel instance;
        public static TaskListPageModel Instance
        {
            get { return instance; }
        }
        public ICommand OnTaskClicked { get; private set; }
        public SimediaSDK sdk { get; set; }
        public TaskListPageModel()
        {
            sdk = new SimediaSDK("https://acute360.com/");
            instance = this;
            OnTaskClicked = new Command(TaskClicked);
            OnHelpClicked = new Command(HelpClicked);
        }
        public Command OpenMenuCommand
        {
            get
            {
                return new Command(() => OpenMenu());
            }
        }

        public Attributes activitySelected { get; set; }
        private void OpenMenu()
        {
            App.Master.IsPresented = true;
        }

        private void HelpClicked(object obj)
        {
            App.Current.MainPage.DisplayAlert("Project Description", ((Attributes)obj).description, "Close");
            //App.Current.MainPage.DisplayAlert("Project Description", ((Attributes)
            //   args.Parameter).description, "Close");
        }


        public ICommand OnHelpClicked { get; private set; }
        private async void TaskClicked(object obj)
        {
            try
            {
                activitySelected = (Attributes)obj;
                await LoadActivities();
                await App.Navigator.PushAsync(new TaskContentPage());
            }
            catch (Exception ex)
            {
            }
        }

        private async Task LoadActivities()
        {
            IsBusy = true;

            try
            {
                var activity = await this.sdk.ActivityService.ActiveActivityAsync();
                
                foreach (var item in activity.data)
                {
                    if (item.id == activitySelected.idactivity)
                    {
                        activitySelected = item.attributes;
                        activitySelected.idactivity = item.id;
                        break;
                    }
                   
                }
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
            LoadActivities();
            IsRefreshing = false;
        }

        string pagetitle = "Acute";
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
        public event PropertyChangedEventHandler PropertyChanged;
        public override async void Init(object initData)
        {
            base.Init(initData);
        }

        public Command MoreCommand
        {
            get
            {
                return new Command(async () => await MoreInfoTask());

            }
        }

        private async Task MoreInfoTask()
        {
            App.Master.IsPresented = false;
            ;
        }



        public Command TaskSelected
        {
            get
            {
                return new Command(async () => await MoreInfoTask());
            }
        }




        //private async void LoadActivities()
        //{
        //    IsBusy = true;

        //    try
        //    {
        //        ProjectListPageModel.Instance.RefreshCommand.Execute(null);
        //    }
        //    catch (Exception ex)
        //    {
        //        //await DisplayDataErrorMessage();
        //    }
        //    finally
        //    {
        //        IsBusy = false;
        //    }
        //}

    }
}
