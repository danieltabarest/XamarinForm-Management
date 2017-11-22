using System;
using FreshMvvm;
using Acute.PageModels.Base;
using Xamarin.Forms;

namespace Acute.Navigation
{
    public class ProjectTabbedNavigationContainer : FreshTabbedNavigationContainer, ITabbedNavigationContainer
    {

        public ProjectTabbedNavigationContainer() 
            : base(NavigationContainerNames.ProjectContainer)
        {
        }
    }
}
