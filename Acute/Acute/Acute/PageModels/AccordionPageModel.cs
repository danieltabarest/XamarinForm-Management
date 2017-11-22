using Acute.Models;
using Acute.PageModels.Base;
using Acute.ViewModels;
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
    //[ImplementPropertyChanged]
    public class AccordionPageModel : BasePageModel
    {
        public static AccordionPageModel instance;
        public static AccordionPageModel Instance
        {
            get { return instance; }
        }
        public SimediaSDK SimediaSDK { get; set; }
        public ICommand OnProjectClicked { get; private set; }
        public ObservableCollection<ProjectAcute> Project
        {
            get;
            set;
        }

        public ObservableCollection<Section> Activities
        {
            get;
            set;
        }

        public ObservableCollection<MenuItemViewModel> Menu { get; set; }


        public AccordionPageModel()
        {
            SimediaSDK = new SimediaSDK("https://acute360.com/");
            instance = this;
            OnProjectClicked = new Command(ProjectClicked);
            LoadData();
        }

        public async void ProjectClicked(object project)
        {
            await MoreProject((Project)project);
        }

        private void LoadData()
        {
            try
            {
                LoadActivities();
            }
            catch (Exception ex)
            {

            }
        }

        public Command NavigateCommand { get { return new Command(async () => await Navigate()); } }

        private async Task Navigate()
        {

        }

        public Command<Project> ProjectSelected
        {
            get
            {
                return new Command<Project>(async (project) => await MoreProject(project));
            }
        }

        Project _selectedProject;
        public Project SelectedProject
        {
            get
            {
                return _selectedProject;
            }

            set
            {
                _selectedProject = value;
                if (value != null)
                    ProjectSelected.Execute(value);
            }
        }


        private async Task MoreProject(Project project)
        {
            App.Master.IsPresented = false;
            //await App.Navigator.PushAsync(new AccordionViewPage());
            //App.Current.MainPage = new NavigationPage(new AccordionViewPage());
        }


        string pagetitle = "PROJECT LIST";
        public  string PageTitle
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
            LoadActivities();
        }

        public IEnumerable<Section> List { get; set; }
        private async void LoadActivities()
        {
            IsBusy = true;

            try
            {
                var activity = await this.SimediaSDK.ActivityService.ActiveActivityAsync();
                //List<Section> sesionlist = new List<Section>();
                //foreach (var item in activity.data)
                //{
                //    var grouptasks = activity.included.Where(c => c.id == item.relationships.task.data.id);
                //    var sesion = new Section
                //    {
                //        Title = item.attributes.name,
                //        List = grouptasks,
                //    };
                //    sesionlist.Add(sesion);
                //}
                //List = sesionlist;

                var pr = new ProjectAcute { Name = "TESTING", Description = "DESCRIPTION" };
                var pr1 = new ProjectAcute { Name = "TESTING 1", Description = "DESCRIPTION 2" };
                var pr2 = new ProjectAcute { Name = "TESTING 3", Description = "DESCRIPTION 3" };
                Project = new ObservableCollection<ProjectAcute>();
                Project.Add(pr);
                Project.Add(pr1);
                Project.Add(pr2);
                /*var groupedProjects = Projects
                    //.OrderBy(c => c.Group.Order)
                    //.GroupBy(c => c.Group.Name.ToUpper())
                    .Select(c => new ObservableGroupCollection<Project>(c))
                    .ToList();

                Projects = new ObservableCollection<Project>(groupedProjects);*/

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
