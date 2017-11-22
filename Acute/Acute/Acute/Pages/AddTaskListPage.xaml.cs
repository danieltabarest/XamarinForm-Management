using System;

using Acute.Models;

using Xamarin.Forms;
using Acute.PageModels;
using FreshMvvm;

namespace Acute.Pages
{
    public partial class AddTaskListPage : ContentPage
    {

        public AddTaskListPage()
        {
            try
            {
                InitializeComponent();
                BindingContext = new AddTaskListPageModel();
                this.Title = AddTaskListPageModel.Instance.ActiviyName;
                //NavigationPage.SetHasNavigationBar(this, false);
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
            catch (Exception ex) 
            {

            }

        }

        protected override void OnAppearing()
        {

            AddTaskListPageModel.Instance.RefreshCommand.Execute(null);
            base.OnAppearing();
        }
    }
}