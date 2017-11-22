using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Acute.Controls
{
	public class ToggleButton : ContentView
	{
		//Credit: https://forums.xamarin.com/discussion/43339/change-toggle-button-with-my-image

		public static readonly BindableProperty CommandProperty = 
			BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(ToggleButton));

		public static readonly BindableProperty CommandParameterProperty =
			BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(ToggleButton));

		public static readonly BindableProperty CheckedProperty =
            BindableProperty.Create(nameof(Checked), typeof(bool), typeof(ToggleButton), false, BindingMode.TwoWay);

		public static readonly BindableProperty AnimateProperty =
			BindableProperty.Create(nameof(Animate), typeof(bool), typeof(ToggleButton), false, BindingMode.TwoWay);

		public static readonly BindableProperty CheckedImageProperty =
			BindableProperty.Create(nameof(CheckedImage), typeof(ImageSource), typeof(ToggleButton), null, BindingMode.TwoWay);

		public static readonly BindableProperty UnCheckedImageProperty =
			BindableProperty.Create(nameof(UnCheckedImage), typeof(ImageSource), typeof(ToggleButton), null, BindingMode.TwoWay);

		private ICommand _toggleCommand;
		private Image _toggleImage;

		public ToggleButton()
		{
			Initialize();
		}

		public ICommand Command
		{
			get 
			{ 
				return (ICommand)GetValue(CommandProperty); 
			}

			set 
			{ 
				SetValue(CommandProperty, value); 
			}
		}

		public object CommandParameter
		{
			get 
			{ 
				return GetValue(CommandParameterProperty); 
			}

			set 
			{ 
				SetValue(CommandParameterProperty, value); 
			}
		}

		public bool Checked
		{
			get 
			{ 
				return (bool)GetValue(CheckedProperty); 
			}

			set 
			{ 
				SetValue(CheckedProperty, value); 
			}
		}

		public bool Animate
		{
			get 
			{ 
				return (bool)GetValue(AnimateProperty); 
			}

			set 
			{ 
				SetValue(AnimateProperty, value); 
			}
		}

		public ImageSource CheckedImage
		{
			get 
			{ 
				return (ImageSource)GetValue(CheckedImageProperty); 
			}

			set 
			{ 
				SetValue(CheckedImageProperty, value); 
			}
		}

		public ImageSource UnCheckedImage
		{
			get 
			{ 
				return (ImageSource)GetValue(UnCheckedImageProperty); 
			}

			set 
			{ 
				SetValue(UnCheckedImageProperty, value); 
			}
		}

		public ICommand ToggleCommand
		{
			get
			{
				return _toggleCommand
					   ?? (_toggleCommand = new Command(
						   async () =>
						   {
							   if (_toggleImage.Source == UnCheckedImage)
							   {
								   _toggleImage.Source = CheckedImage;
								   Checked = true;
							   }
							   else
							   {
								   _toggleImage.Source = UnCheckedImage;
								   Checked = false;
							   }

							   if (Animate)
							   {
								   await this.ScaleTo(0.8, 50, Easing.Linear);
								   await Task.Delay(100);
								   await this.ScaleTo(1, 50, Easing.Linear);
							   }
							   if (Command != null)
							   {
								   Command.Execute(CommandParameter);
							   }
						   }
						   ));
			}
		}

		private void Initialize()
		{
			_toggleImage = new Image();

			Animate = true;
			GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = ToggleCommand
			});

            _toggleImage.Source = UnCheckedImage;

			Content = _toggleImage;
		}

        protected override void OnPropertyChanged(string propertyName = null)
        {

            if (propertyName == "Checked")
                _toggleImage.Source = Checked ? CheckedImage : UnCheckedImage;
                
        }

		protected override void OnParentSet()
		{
			base.OnParentSet();
			_toggleImage.Source = UnCheckedImage;
			Content = _toggleImage;
		}

	}
}
