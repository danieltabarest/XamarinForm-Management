using System;
using Xamarin.Forms;
//

namespace Acute.Controls
{
    public class Checkmark : ContentView
    {
        public static readonly BindableProperty IsActiveProperty =
            BindableProperty.Create("IsActive", typeof(bool), typeof(Checkmark), false);

        private View _layout;
        private Image _activeIcon;
        private Image _inActiveIcon;

        public Checkmark()
        {
            PrepareComposites();
            SetBindings();
            Content = _layout;
        }

        public bool IsActive
        {
            get
            {
                return (bool)GetValue(IsActiveProperty);
            }

            set
            {
                SetValue(IsActiveProperty, value);
            }
        }

        protected void PrepareComposites()
        {
            _activeIcon = CreateIcon(new FileImageSource()
            {
                File = "Images/Checkmark_active.png"
            });

            _inActiveIcon = CreateIcon(new FileImageSource
            {
                File = "Images/Checkmark_inactive.png"
            });

            var baseLayout = new StackLayout();
            baseLayout.Children.Add(_activeIcon);
            baseLayout.Children.Add(_inActiveIcon);

            _layout = baseLayout;
        }

        protected void SetBindings()
        {
            _activeIcon.SetBinding(IsVisibleProperty, 
                                   new Binding("IsActive", BindingMode.OneWay, source: this));

            //_inActiveIcon.SetBinding(IsVisibleProperty, 
            //                         new Binding("IsActive", BindingMode.OneWay, new InvertVisibilityValueConverter(), source:this));
        }

        private Image CreateIcon(ImageSource imageSource)
        {
            return new Image
            {
                Source = imageSource
            };
        }

    }
}
