using Acute.Models;
using Acute.PageModels.Base;
using Acute.ViewModels;
using Plugin.Iconize;
using Simedia.App.SDK;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Plugin.Connectivity;
namespace Acute.PageModels
{
    //[ImplementPropertyChanged]
    public class ProjectListPageModel : BasePageModel, INotifyPropertyChanged
    {
        public ObservableCollection<Section> List { get; set; }

        public static ProjectListPageModel instance;
        public static ProjectListPageModel Instance
        {
            get { return instance; }
        }
        public SimediaSDK SimediaSDK { get; set; }
        public ICommand OnProjectClicked { get; private set; }
        public ICommand OnHelpClicked { get; private set; }
        ObservableCollection<ProjectAcute> project;
        public ObservableCollection<ProjectAcute> Project
        {
            set
            {
                if (project != value)
                {
                    project = value;

                    if (PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("Project"));
                    }
                }
            }
            get
            {
                return project;
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



        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public ProjectListPageModel()
        {
            SimediaSDK = new SimediaSDK("https://acute360.com/");
            instance = this;
            OnProjectClicked = new Command(ProjectClicked);
            OnHelpClicked = new Command(HelpClicked);
            LoadData();
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
        private void HelpClicked(object obj)
        {
            App.Current.MainPage.DisplayAlert("Project Description", ((ProjectAcute)obj).Description, "Close");
        }

        public async void ProjectClicked(object project)
        {
            await MoreProject((ProjectAcute)project);
        }

        private void LoadData()
        {
            try
            {
                CreateMenu();
                LoadActivities();
            }
            catch (Exception ex)
            {

            }
        }

        private IIconModule _module;
        private void CreateMenu()
        {
            foreach (var module in Plugin.Iconize.Iconize.Modules)
            {
                _module = module;
            }

            Menu = new ObservableCollection<MenuItemViewModel>();

            Menu.Add(new MenuItemViewModel
            {
                /*Icon = _module.GetIcon("fa-500px").Key,*///Plugin.Iconize.Iconize.FindIconForKey("19").Key,//"ic_account_black_18dp.png",
                Icon = "ic_format_list_bulleted_white_18dp.png",
                PageName = "ProjectList",
                Title = "Project List",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_logout_white_18dp.png", //_module.GetIcon("fa-500px").Key,
                PageName = "LoginPage",
                Title = "Log out",
            });

        }
        public Command NavigateCommand { get { return new Command(async () => await Navigate()); } }

        private async Task Navigate()
        {

        }

        public Command<ProjectAcute> ProjectSelected
        {
            get
            {
                return new Command<ProjectAcute>(async (project) => await MoreProject(project));
            }
        }

        ProjectAcute _selectedProject;
        public ProjectAcute SelectedProject
        {
            set; get;
        }


        private async Task MoreProject(ProjectAcute project)
        {
            SelectedProject = project;
            await App.Navigator.PushAsync(new AccordionViewPage(project, List));
        }

        private async void LoadActivities()
        {
            IsBusy = true;

            try
            {
                var activity = await this.SimediaSDK.ActivityService.ActiveActivityAsync();
                ObservableCollection<Section> sesionlist = new ObservableCollection<Section>();

                var groupedProjects = activity.included.Where(y => y.type == "projects").ToList();
                var projects = (from u in groupedProjects
                                orderby u.attributes.name
                                select new ProjectAcute()
                                {
                                    project_id = u.id,
                                    Closed = u.attributes.closed,
                                    //EndDate = Convert.ToDateTime(u.attributes.endDate),
                                    //StartDate = Convert.ToDateTime(u.attributes.startDate),
                                    EndDate = u.attributes.endDate,
                                    StartDate = u.attributes.startDate,
                                    Name = u.attributes.name,
                                    Description = u.attributes.description == null ? "No description" : u.attributes.description
                                });

                Project = new ObservableCollection<ProjectAcute>(projects);

                foreach (var item in activity.data)
                {
                    var grouptasks = activity.included.Where(c => c.id == item.relationships.task.data.id && c.type == "tasks").ToList();

                    List<Attributes> listactivities = new List<Attributes>();

                    foreach (var items in grouptasks)
                    {
                        if (item.relationships.task.data.id == items.id && item.type == "activities")
                        {
                            item.attributes.idactivity = item.id;
                            if (item.attributes.description == "" || item.attributes.description == null)
                            {
                                item.attributes.description = "No description";
                            }
                            listactivities.Add(item.attributes);
                        }

                        var sesion = new Section
                        {
                            Title = items.attributes.name,
                            Description = items.attributes.description,
                            DueDate = items.attributes.endDate,
                            IdActivity = items.id,
                            List = listactivities,
                        };
                        sesionlist.Add(sesion);
                    }
                }
                List = sesionlist;
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

        string pagetitle = "PROJECT LIST";
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

        public override async void Init(object initData)
        {
            base.Init(initData);
        }

    }
}
