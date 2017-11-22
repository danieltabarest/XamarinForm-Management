using System;

using Acute.Models;

using Xamarin.Forms;
using Acute.PageModels;
using FreshMvvm;
using System.Threading.Tasks;

namespace Acute.Pages
{
    public partial class TaskListPage : ContentView
    {
        public Item Item { get; set; }

        public TaskListPage()
        {
            InitializeComponent();
            BindingContext = new TaskListPageModel();
            NavigationPage.SetBackButtonTitle(this, "");
            
        }

        void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
        {
            try
            {
                TaskListPageModel.instance.OnTaskClicked.Execute(args.Parameter);
            }
            catch (Exception ex)
            {

            }
        }

        void OnTapGestureRecognizerTappedDescription(object sender, TappedEventArgs args)
        {
            try
            {
                //TaskListPageModel.instance.CurrentPage.DisplayAlert("Project Description",((Attributes)
                //    args.Parameter).description,"Close");

                App.Current.MainPage.DisplayAlert("Project Description", ((Attributes)
                    args.Parameter).description, "Close");
            }
            catch (Exception ex)
            {

            }
        }


     

    }
}