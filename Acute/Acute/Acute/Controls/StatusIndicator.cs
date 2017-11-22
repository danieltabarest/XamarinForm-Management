using Xamarin.Forms;


namespace Acute.Controls
{
    public class StatusIndicator : ContentView
    {
        public static readonly BindableProperty ActiveTextProperty =
            BindableProperty.Create("ActiveText", typeof(string), typeof(StatusIndicator), "");

        public static readonly BindableProperty InActiveTextProperty =
            BindableProperty.Create("InActiveText", typeof(string), typeof(StatusIndicator), "");

        public static readonly BindableProperty IsActiveProperty =
            BindableProperty.Create("IsActive", typeof(bool), typeof(StatusIndicator), false);


        private View _layout;
        private Label _activeTextLabel;
        private Label _inActiveTextLabel;

        public StatusIndicator()
        {
            PrepareComposites();
            SetBindings();

            Content = _layout;
        }

        public string ActiveText
        {
            get
            {
                return (string)GetValue(ActiveTextProperty);
            }

            set
            {
                SetValue(ActiveTextProperty, value);
            }
        }

        public string InActiveText
        {
            get
            {
                return (string)GetValue(InActiveTextProperty);
            }

            set
            {
                SetValue(InActiveTextProperty, value);
            }
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

        private void SetBindings()
        {
            _activeTextLabel.SetBinding(Label.TextProperty, new Binding("ActiveText", BindingMode.OneWay, source: this));
            _activeTextLabel.SetBinding(IsVisibleProperty, new Binding("IsActive", BindingMode.OneWay, source: this));
            _inActiveTextLabel.SetBinding(Label.TextProperty, new Binding("InActiveText", BindingMode.OneWay, source: this));
            //_inActiveTextLabel.SetBinding(IsVisibleProperty, new Binding("IsActive", BindingMode.OneWay, new InvertVisibilityValueConverter(), source: this));
        }

        private void PrepareComposites()
        {
            _activeTextLabel = CreateLabel(10, Color.FromHex("#53C34A"));
            _inActiveTextLabel = CreateLabel(10, Color.FromHex("#9B9B9B"));

            var baseLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            baseLayout.Children.Add(CreateLabel("Status:", 10, Color.FromHex("#4A4A4A")));
            baseLayout.Children.Add(_activeTextLabel);
            baseLayout.Children.Add(_inActiveTextLabel);

            _layout = baseLayout;
        }

        private Label CreateLabel(string text, double fontSize, Color color)
        {
            var label = CreateLabel(fontSize, color);
            label.Text = text;
            return label;
        }

        private Label CreateLabel(double fontSize, Color color)
        {
            return new Label
            {
                FontSize = fontSize,
                TextColor = color
            };
        }

    }
}
