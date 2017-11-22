using System;

using Acute.Models;

using Xamarin.Forms;
using Acute.PageModels;
using FreshMvvm;

namespace Acute.Pages
{
    public partial class EditTaskListPage : ContentPage
    {

        public EditTaskListPage()
        {
            InitializeComponent();
            //this.Title = EditTaskListPageModel.Instance.ActiviyName;
            BindingContext = new EditTaskListPageModel();
            // NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetBackButtonTitle(this, "");
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


        async void OnTapGestureRecognizerTapped(object sender, EventArgs args)
        {
            var loginPage = FreshPageModelResolver.ResolvePageModel<TaskContentPageModel>();
            var loginContainer = new FreshNavigationContainer(loginPage, NavigationContainerNames.AuthenicationContainer);
            App.Master.IsPresented = false;
            await App.Navigator.PushAsync(loginContainer);
        }

        protected override void OnAppearing()
        {

            EditTaskListPageModel.Instance.RefreshCommand.Execute(null);
            base.OnAppearing();
        }
    }
}