using System;
using Xamarin.Forms;

namespace Acute.Controls
{
    public class LineStyleEntry : Entry
    {
        public static readonly BindableProperty TurnHelperOnProperty =
            BindableProperty.Create("TurnHelperOn", typeof(bool), typeof(LineStyleEntry), true);

        public bool TurnHelperOn
        {
            get
            {
                return (bool)GetValue(TurnHelperOnProperty);
            }

            set
            {
                SetValue(TurnHelperOnProperty, value);
            }
        }

        //BorderColor
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create<LineStyleEntry, Color>(p => p.BorderColor, Color.LightGray);
        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }
    }
}
