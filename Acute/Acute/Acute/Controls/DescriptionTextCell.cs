using System;
using Xamarin.Forms;

namespace Acute.Controls
{
    public class DescriptionTextCell : ViewCell
    {
        public static BindableProperty TextProperty =
            BindableProperty.Create("Text", typeof(string), typeof(DescriptionTextCell), "");

        public static BindableProperty DescriptionTextProperty =
            BindableProperty.Create("DescriptionText", typeof(string), typeof(DescriptionTextCell), "");

        public static BindableProperty DescriptionTextColorProperty =
            BindableProperty.Create("DescriptionTextColor", typeof(Color), typeof(DescriptionTextCell), Color.FromHex("#00AFE1"));

        public static BindableProperty TextColorProperty =
            BindableProperty.Create("TextColor", typeof(Color), typeof(DescriptionTextCell), Color.FromHex("#000000"));

        private Label _textLabel;
        private Label _descriptionLabel;
        protected StackLayout _layout;


        public DescriptionTextCell()
        {
            Height = 60;
            BuildLayout();

            View = _layout;
        }

        public string Text
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

        public string DescriptionText
        {
            get
            {
                return (string)GetValue(DescriptionTextProperty);
            }

            set
            {
                SetValue(DescriptionTextProperty, value);
            }
        }

        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }

            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        public Color DescriptionTextColor
        {
            get
            {
                return (Color)GetValue(DescriptionTextColorProperty);
            }

            set
            {
                SetValue(DescriptionTextColorProperty, value);
            }
        }


		private void BuildLayout()
		{
			PrepareComposites();
			SetBindings();
		}

        protected virtual void SetBindings()
        {
            _textLabel.SetBinding(Label.TextProperty, 
                                  new Binding("Text", source: this));
            
            _textLabel.SetBinding(Label.TextColorProperty, 
                                  new Binding("TextColor", source: this));
            
            _descriptionLabel.SetBinding(Label.TextProperty, 
                                         new Binding("DescriptionText", source: this));
            
            _descriptionLabel.SetBinding(Label.TextColorProperty, 
                                         new Binding("DescriptionTextColor", source: this));

        }

        protected virtual void PrepareComposites()
        {
            _textLabel = CreateLabel(16);
            _descriptionLabel = CreateLabel(12);

            var stackLayout = new StackLayout
            {
                Padding = new Thickness(15, 7),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            stackLayout.Children.Add(_descriptionLabel);
            stackLayout.Children.Add(_textLabel);

            _layout = stackLayout;
        }

        protected Label CreateLabel(double fontSize)
        {
            return new Label()
            {
                FontSize = fontSize,
                LineBreakMode = LineBreakMode.WordWrap
            };
        }
    }
}
