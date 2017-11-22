using System;

using Acute.Models;

using Xamarin.Forms;
using Acute.PageModels;

namespace Acute.Pages
{
    public partial class TaskContentPage : ContentPage
    {
        public TaskContentPage()
        {
            InitializeComponent();
            BindingContext = new TaskContentPageModel();

            assignmentsList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                // don't do anything if we just de-selected the row
                if (e.Item == null) return;
                // do something with e.SelectedItem
                ((ListView)sender).SelectedItem = null; // de-select the row

            };
            MyEditor.Unfocused += (object sender, FocusEventArgs e) => {
                MyScrollView.ScrollToAsync(MyEditor, ScrollToPosition.Start, true);
            };

            MyEditor.Focused += (object sender, FocusEventArgs e) => {
                MyScrollView.ScrollToAsync(MyEditor, ScrollToPosition.Start, true);
            };

        }

        //protected override bool OnBackButtonPressed()
        //{
        //    // If you want to continue going back
        //    base.OnBackButtonPressed();
        //    //App.Navigator.PopAsync(new AccordionViewPage(ProjectListPageModel.Instance.SelectedProject, null))
        //    return false;

        //    // If you want to stop the back button
        //    return true;

        //}



        void OnTapGestureRecognizerTapped(object sender, TappedEventArgs args)
        {
            try
            {
                TaskContentPageModel.instance.OnTaskEditClicked.Execute(args.Parameter);
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnAppearing()
        {
            TaskContentPageModel.Instance.RefreshCommand.Execute(null);
            base.OnAppearing();
        }


    }
}