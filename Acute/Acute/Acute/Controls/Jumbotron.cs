using System;
using Xamarin.Forms;

namespace Acute.Controls
{
    public class Jumbotron : ContentView
    {
        public static readonly BindableProperty BackgroundImageSourceProperty = 
            BindableProperty.Create("BackgroundImageSource", typeof(ImageSource), typeof(Jumbotron), null);
        
        public static readonly BindableProperty TextProperty = 
            BindableProperty.Create("Text", typeof(string), typeof(Jumbotron), "");
        
        public static readonly BindableProperty TextColorProperty = 
            BindableProperty.Create("TextColor", typeof(Color), typeof(Jumbotron), Color.White);

        private Image _backgroundImage;
        private Label _headingLabel;
        private AbsoluteLayout _layout;

        public Jumbotron()
        {
            PrepareComposites();
            SetBindings();
            Content = _layout;
        }

        public ImageSource BackgroundImageSource
        {
            get 
            {
                return (ImageSource)GetValue(BackgroundImageSourceProperty);
            }

            set 
            {
                SetValue(BackgroundImageSourceProperty, value);
            }
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

        protected void SetBindings()
        {
            _headingLabel.SetBinding(Label.TextProperty, 
                                     new Binding("Text", BindingMode.OneWay, source: this));
            
            _headingLabel.SetBinding(Label.TextColorProperty, 
                                     new Binding("TextColor", BindingMode.OneWay, source: this));
            
            _backgroundImage.SetBinding(Image.SourceProperty, 
                                       new Binding("BackgroundImageSource", BindingMode.OneWay, source: this));
        }

		protected void PrepareComposites()
		{
			_layout = CreateLayout();
			_headingLabel = CreateHeading();
			_backgroundImage = CreateImage();
			var overlay = CreateOverlay();

			overlay.Children.Add(_headingLabel);

			_layout.Children.Add(_backgroundImage, new Rectangle(1, 1, 1, 1), AbsoluteLayoutFlags.All);
			_layout.Children.Add(overlay, new Rectangle(1, 1, 1, 1), AbsoluteLayoutFlags.All);
		}

		protected AbsoluteLayout CreateLayout()
		{
			return new AbsoluteLayout
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				MinimumHeightRequest = 100.0,
				VerticalOptions = LayoutOptions.StartAndExpand
			};
		}

		protected Image CreateImage()
		{
			return new Image
			{
				Aspect = Aspect.AspectFill
			};
		}

		protected StackLayout CreateOverlay()
		{
			return new StackLayout
			{
				Padding = new Thickness(40, 20)
			};
		}

		protected Label CreateHeading()
		{
			return new Label
			{
				FontSize = 18,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				VerticalOptions = LayoutOptions.CenterAndExpand,
				VerticalTextAlignment = TextAlignment.Center,
				HorizontalTextAlignment = TextAlignment.Center
			};
		}

    }
}
