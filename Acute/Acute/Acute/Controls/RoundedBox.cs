//Credits: https://gist.github.com/rudyryk/8cbe067a1363b45351f6

using Xamarin.Forms;

namespace Acute.Controls
{
	public class RoundedBox : BoxView
	{
		public static readonly BindableProperty CornerRadiusProperty =
			BindableProperty.Create("CornerRadius", typeof(double), typeof(RoundedBox), 0.0);
		
		public static readonly BindableProperty BorderWidthProperty =
			BindableProperty.Create("BorderWidth", typeof(double), typeof(RoundedBox), 0.0);

		public static readonly BindableProperty BorderColorProperty =
			BindableProperty.Create("BorderColor", typeof(Color), typeof(RoundedBox), Color.White);

		public double CornerRadius
		{
			get 
			{ 
				return (double)GetValue(CornerRadiusProperty);
			}

			set 
			{ 
				SetValue(CornerRadiusProperty, value);
			}
		}

		public double BorderWidth
		{
			get 
			{ 
				return (double)GetValue(BorderWidthProperty);
			}

			set 
			{ 
				SetValue(BorderWidthProperty, value);
			}
		}

		public Color BorderColor
		{
			get 
			{ 
				return (Color)GetValue(BorderColorProperty);
			}

			set 
			{ 
				SetValue(BorderColorProperty, value);
			}
		}
	}
}