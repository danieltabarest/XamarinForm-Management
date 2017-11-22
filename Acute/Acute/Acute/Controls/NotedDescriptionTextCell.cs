using System;
using Xamarin.Forms;


namespace Acute.Controls
{
    public class NotedDescriptionTextCell : DescriptionTextCell
    {
        public static BindableProperty NoteTextProperty =
            BindableProperty.Create("NoteText", typeof(string), typeof(DescriptionTextCell), "");

        public static BindableProperty NoteTextColorProperty =
            BindableProperty.Create("NoteTextColor", typeof(Color), typeof(DescriptionTextCell), Color.FromHex("#4A4A4A"));


        private Label _noteLabel;

        public NotedDescriptionTextCell()
        {
            Height = 80;
        }

        public string NoteText
        {
            get
            {
                return (string)GetValue(NoteTextProperty);
            }

            set
            {
                SetValue(NoteTextProperty, value);
            }
        }

        public Color NoteTextColor
        {
            get
            {
                return (Color)GetValue(NoteTextColorProperty);
            }

            set
            {
                SetValue(NoteTextColorProperty, value);
            }
        }

        protected override void SetBindings()
        {
            base.SetBindings();

            //_noteLabel.SetBinding(VisualElement.IsVisibleProperty,
            //                      new Binding("NoteText",
            //                                  BindingMode.OneWay,
            //                                  new StringToBoolValueConverter(),
            //                                  source: this));

            _noteLabel.SetBinding(Label.TextProperty,
                                  new Binding("NoteText", source: this));

            _noteLabel.SetBinding(Label.TextColorProperty,
                                  new Binding("NoteTextColor", source: this));
        }

        protected override void PrepareComposites()
        {
            base.PrepareComposites();

            _noteLabel = CreateLabel(12);
            _layout.Children.Add(_noteLabel);
        }

    }
}
