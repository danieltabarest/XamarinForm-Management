using System;
using Xamarin.Forms;

namespace Acute.Controls
{
    public class FilterBlock : ContentView
    {
        public readonly static BindableProperty ButtonTextProperty = 
            BindableProperty.Create("ButtonText", typeof(string), typeof(FilterBlock), "");

        public readonly static BindableProperty ButtonCommandProperty = 
            BindableProperty.Create("ButtonCommand", typeof(Command), typeof(FilterBlock), null);
        
        private View _layout;
        private Button _button;

        public FilterBlock()
        {
            PrepareComposites();
            SetBindings();
            Content = _layout;
        }

        public string ButtonText
        {
            get 
            {
                return (string)GetValue(ButtonTextProperty);
            }

            set 
            {
                SetValue(ButtonTextProperty, value);
            }
        }

        public Command ButtonCommand
        {
            get 
            {
                return (Command)GetValue(ButtonCommandProperty);
            }

            set 
            {
                SetValue(ButtonCommandProperty, value);
            }
        }

       
        protected void PrepareComposites()
        {
            _button = CreateButton();

            var baseLayout = CreateLayout();
            baseLayout.Children.Add(_button);

            _layout = baseLayout;
        }

        protected void SetBindings()
        {
            _layout.SetBinding(VisualElement.BackgroundColorProperty, 
                               new Binding("BackgroundColor", BindingMode.OneWay, source: this));
            _button.SetBinding(FilterButton.TextProperty, 
                               new Binding("ButtonText", BindingMode.OneWay, source: this));
            _button.SetBinding(Button.CommandProperty, 
                               new Binding("ButtonCommand", BindingMode.OneWay, source: this));
        }

        protected Button CreateButton()
        {
            return new FilterButton();
        }

        protected StackLayout CreateLayout()
        {
            return new StackLayout
            {
				Padding = new Thickness(5.0),
			    HorizontalOptions = LayoutOptions.FillAndExpand
            };
        }

    }
}
