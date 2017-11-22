using System;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Acute.Pages;
using Acute.PageModels;
using Acute.Models;
using System.Collections.ObjectModel;
using Simedia.App.SDK;
using System.Threading.Tasks;

namespace Acute
{
    public class ShoppingCart
    {
        public DateTime Date { get; set; }
        public double
            Amount
        { get; set; }
    }

    //public class Section
    //{ 
    //	public string Title { get; set; }
    //	public IEnumerable<ShoppingCart> List { get; set; }
    //}

    public class Section
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string DueDate { get; set; }
        public int IdActivity{ get; set; }
        public IEnumerable<Attributes> List { get; set; }
    }

    public class ViewModel
    {
      
        public ObservableCollection<Section> List { get; set; }
    }

    public class AccordionViewPage : ContentPage
    {
        public static AccordionViewPage instance;
        public static AccordionViewPage Instance
        {
            get { return instance; }
        }

        public AccordionViewPage(ProjectAcute projec, ObservableCollection<Section> list)
        {

            instance= this;

            this.Title = projec.Name;
            var settings = new ToolbarItem
            {
                Icon = "hamburger.png",
                Command = new Command(this.OpenMenu),
            };
            SimediaSDK = new SimediaSDK("https://acute360.com/");
            this.ToolbarItems.Add(settings);


            var template = new DataTemplate(typeof(TaskListPage));
            //var template = new DataTemplate(typeof(DefaultTemplate));


            var view = new AccordionView(template);
            //var view = new Page1(template);
            view.SetBinding(AccordionView.ItemsSourceProperty, "List");
            view.Template.SetBinding(AcuteSectionView.TitleProperty, "Title");
            view.Template.SetBinding(AcuteSectionView.DescriptionProperty, "Description");
            view.Template.SetBinding(AcuteSectionView.DueDateProperty, "DueDate");
            view.Template.SetBinding(AcuteSectionView.ItemsSourceProperty, "List");

            //view.BindingContext = new AccordionPageModel();

            view.BindingContext = new ViewModel
            {
                List = list
            };

            this.Content = view;
        }

        private void OpenMenu()
        {
            App.Master.IsPresented = true;
        }

        protected override  void OnAppearing()
        {
            var page = App.Navigator.Navigation.NavigationStack.Last();
            if (page.GetType().ToString() != "Acute.Pages.TaskContentPage")
                return;
            //await LoadActivities();
            base.OnAppearing();
        }
        public ObservableCollection<Section> List { get; set; }
        public SimediaSDK SimediaSDK { get; set; }
        private async Task LoadActivities()
        {
            IsBusy = true;

            try
            {
                var activity = await this.SimediaSDK.ActivityService.ActiveActivityAsync();
                ObservableCollection<Section> sesionlist = new ObservableCollection<Section>();

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
    }


}
