using System;

using Acute.Models;

using Xamarin.Forms;
using Acute.PageModels;

namespace Acute.Pages
{
    public partial class ProjectListPage : ContentPage
    {
        public Item Item { get; set; }
        ProjectListPageModel bindingcontext;
        public ProjectListPage()
        {
            try
            {
                
                //this.Navigation.SetHidesBackButton(true, false);
                InitializeComponent();
                if (ProjectListPageModel.Instance == null)
                {
                    bindingcontext = new ProjectListPageModel();
                }
                else
                {
                    bindingcontext = ProjectListPageModel.Instance;
                }

                BindingContext = bindingcontext;
                assignmentsList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
                {
                // don't do anything if we just de-selected the row
                if (e.Item == null) return;
                // do something with e.SelectedItem
                ((ListView)sender).SelectedItem = null; // de-select the row
                
                };


            }
            catch (Exception ex)
            {

                throw;
            }
       }
        void OnTapGestureRecognizerTappedDescription(object sender, TappedEventArgs args)
        {
            try
            {
                //TaskListPageModel.instance.CurrentPage.DisplayAlert("Project Description", ((ProjectAcute)args.Parameter).Description, "Close");
                this.DisplayAlert("Project Description", ((ProjectAcute)args.Parameter).Description, "Close");
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnAppearing()
        {

            ProjectListPageModel.Instance.RefreshCommand.Execute(null);
            base.OnAppearing();
        }


    }
}