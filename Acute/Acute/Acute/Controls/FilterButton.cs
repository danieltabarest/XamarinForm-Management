using System;
using Xamarin.Forms;


namespace Acute.Controls
{
    public class FilterButton : Button
    {
        public static readonly new BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(FilterButton), "");

        public FilterButton()
        {
            Image = "Images/DownArrowIcon.png";
            TextColor = Color.FromHex("#0072CE");
            FontSize = 11.0f;
            HorizontalOptions = LayoutOptions.Center;
            WidthRequest = 200.0f;
            HeightRequest = 25.0f;
            BorderRadius = 15;
            BorderWidth = 1.0;
            BorderColor = Color.FromHex("#0072CE");
            BackgroundColor = Color.White;

            //SetBinding(Button.TextProperty,
                       //new Binding("Text", BindingMode.OneWay, new UppercaseStringValueConverter(), source: this));
        }

        public new string Text
        {
            get 
            {
                return (string)GetValue(TextProperty);    
            }

            set 
            {
                SetValue(TextProperty, value);
            }
        }

    }
}
