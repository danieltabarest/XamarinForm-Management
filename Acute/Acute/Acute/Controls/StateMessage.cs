using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Acute.Controls
{
    public class StateMessage : ContentView
    {
        public static readonly BindableProperty IconSourceProperty =
            BindableProperty.Create("IconSource", typeof(ImageSource), typeof(StateMessage), null);

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create("Title", typeof(string), typeof(StateMessage), "");

        public static readonly BindableProperty DescriptionProperty =
            BindableProperty.Create("Description", typeof(string), typeof(StateMessage), "");

        private View _layout;
        private Image _icon;
        private Label _titleLabel;
        private Label _descriptionLabel;

        public StateMessage()
        {
            PrepareComposites();
            SetBindings();
            Content = _layout;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.FromHex("#FAFAFA");
        }

        public ImageSource IconSource
        {
            get
            {
                return (ImageSource)GetValue(IconSourceProperty);
            }

            set
            {
                SetValue(IconSourceProperty, value);
            }
        }

        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }

            set
            {
                SetValue(TitleProperty, value);
            }
        }

        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }

            set
            {
                SetValue(DescriptionProperty, value);
            }
        }

        private void SetBindings()
        {
            _titleLabel.SetBinding(Label.TextProperty,
                                   new Binding("Title", BindingMode.OneWay, source: this));

            _descriptionLabel.SetBinding(Label.TextProperty,
                                         new Binding("Description", BindingMode.OneWay, source: this));

            _icon.SetBinding(Image.SourceProperty,
                             new Binding("IconSource", BindingMode.OneWay, source: this));
        }

        private void PrepareComposites()
        {
            var baseLayout = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(30, 60, 30, 0),
                HorizontalOptions = LayoutOptions.Center
            };

            _icon = CreateIcon();
            _titleLabel = CreateLabel(16.0f, Color.FromHex("#3D434D"));
            _descriptionLabel = CreateLabel(14.0f, Color.FromHex("#666D70"));

            baseLayout.Children.Add(_icon);

            baseLayout.Children.Add(new BoxView
            {
                HeightRequest = 20.0f
            });

            baseLayout.Children.Add(_titleLabel);
            baseLayout.Children.Add(_descriptionLabel);

            _layout = baseLayout;
        }

        private Label CreateLabel(float fontSize, Color textColor)
        {
            return new Label
            {
                FontSize = fontSize,
                TextColor = textColor,
                HorizontalTextAlignment = TextAlignment.Center
            };
        }

        private Image CreateIcon()
        {
            return new Image
            {
                WidthRequest = 175.0f,
                HeightRequest = 175.0f,
                HorizontalOptions = LayoutOptions.Center
            };
        }
    }
}
