
using Acute.PageModels;
using Xamarin.Forms;

namespace Acute.Pages
{
    public partial class MenuPage : ContentPage
    {
        ProjectListPageModel bindingcontext;
        public MenuPage()
        {

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

        }
    }
}
