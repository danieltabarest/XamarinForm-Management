using System;
using System.Diagnostics;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Acute.Models;

namespace Acute
{
    public class DefaultTemplate : AbsoluteLayout
    {
        private ImageSource _arrowRight = ImageSource.FromFile("ic_magnify_black_18dp.png");
        public DefaultTemplate()
        {
            this.Padding = 5;
            this.HeightRequest = 50;
            var stacklayour = new StackLayout { Orientation = StackOrientation.Horizontal };
            var stacklayour1 = new StackLayout { Orientation = StackOrientation.Vertical };
            var Name = new Label { HorizontalTextAlignment = TextAlignment.Start, HorizontalOptions = LayoutOptions.StartAndExpand };
            var Description = new Label { HorizontalTextAlignment = TextAlignment.Start, HorizontalOptions = LayoutOptions.StartAndExpand };

            var title = new Label { HorizontalTextAlignment = TextAlignment.Start, HorizontalOptions = LayoutOptions.StartAndExpand };
            var price = new Label { HorizontalTextAlignment = TextAlignment.End, HorizontalOptions = LayoutOptions.End };
            var Image = new Image { HorizontalOptions = LayoutOptions.End, Source = _arrowRight };
            //Creating TapGestureRecognizers  
            var tapImage = new TapGestureRecognizer();
            //Binding events  
            tapImage.Tapped += tapImage_Tapped;
            //Associating tap events to the image buttons  
            Image.GestureRecognizers.Add(tapImage);

            this.Children.Add(stacklayour);
            this.Children.Add(stacklayour1);
            this.Children.Add(title);
            this.Children.Add(price);

            //this.Children.Add(title, new Rectangle(0, 0.5, 0.5, 1), AbsoluteLayoutFlags.All);
            //this.Children.Add(price, new Rectangle(1, 0.5, 0.5, 1), AbsoluteLayoutFlags.All);
            this.Children.Add(Image, new Rectangle(1, 0.5, 0.5, 1), AbsoluteLayoutFlags.All);
            title.SetBinding(Label.TextProperty, "Date", stringFormat: "{0:dd MMM yyyy}");
            price.SetBinding(Label.TextProperty, "Amount", stringFormat: "{0:C2}");

        }
        void tapImage_Tapped(object sender, EventArgs e)
        {
            // handle the tap  
            //DisplayAlert("Alert", "This is an image button", "OK");
        }
    }

    public class AccordionView : ScrollView
    {
        private StackLayout _layout = new StackLayout { Spacing = 1 };

        public DataTemplate Template { get; set; }
        public DataTemplate SubTemplate { get; set; }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                propertyName: "ItemsSource",
                returnType: typeof(IList),
                declaringType: typeof(AcuteSectionView),
                defaultValue: default(IList),
                propertyChanged: AccordionView.PopulateList);

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public AccordionView(DataTemplate itemTemplate)
        {
            this.SubTemplate = itemTemplate;
            this.Template = new DataTemplate(() => (object)(new AcuteSectionView(itemTemplate, this)));
            this.Content = _layout;
        }

        void PopulateList()
        {
            _layout.Children.Clear();

            foreach (object item in this.ItemsSource)
            {
                var template = (View)this.Template.CreateContent();
                template.BindingContext = item;
                _layout.Children.Add(template);
            }
        }

        static void PopulateList(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AccordionView)bindable).PopulateList();
        }
    }

    public class AcuteSectionView : StackLayout
    {
        private ImageSource icono_interogacion = ImageSource.FromFile("icono_interogacion.png");

        private StackLayout _content1 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Padding = new Thickness(15, 15, 15, 10),
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            //BackgroundColor = Color.WhiteSmoke,
        };
        private StackLayout _content2 = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            Padding = 0,
            Spacing = 3
        };

        private StackLayout _content3 = new StackLayout
        {
            Orientation = StackOrientation.Horizontal,
            Padding = 0,
            Spacing = 3
        };



        private Label _labelDescription = new Label
        {
            Text = "Description",
            FontSize = 12,
            TextColor = Color.Gray,
            HorizontalOptions = LayoutOptions.Start,
            VerticalOptions = LayoutOptions.StartAndExpand,
        };


        private Image _buttonhelp = new Image
        {
            HorizontalOptions = LayoutOptions.StartAndExpand,
            VerticalOptions = LayoutOptions.StartAndExpand,
            HeightRequest = 14,
            //BackgroundColor = Color.FromHex("#6185BC")
        };

        private Button _buttonhelp2 = new Button
        {
            HorizontalOptions = LayoutOptions.StartAndExpand,
            VerticalOptions = LayoutOptions.StartAndExpand,
            HeightRequest = 14,
            BackgroundColor = Color.FromHex("#6185BC")
        };

        private StackLayout _content4 = new StackLayout
        {
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.EndAndExpand,
            Padding = new Thickness(0, 0, 50, 0),
            //Padding = 0,
            Spacing = 3,
        };


        private Label _DueDate = new Label
        {
            Text = "Due Date",
            FontSize = 12,
            TextColor = Color.Black,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            VerticalOptions = LayoutOptions.EndAndExpand,
        };


        private Label _dateDueDate = new Label
        {
            TextColor = Color.Gray,
            FontSize = 12,
            VerticalOptions = LayoutOptions.CenterAndExpand,
            HorizontalOptions = LayoutOptions.StartAndExpand,
            Text = "dateDue",
        };

        private bool _isExpanded = false;
        private StackLayout _content = new StackLayout { HeightRequest = 0 };
        //private Color _headerColor = Color.FromHex("0067B7");
        private Color _headerColor = Color.FromHex("#FFFFF");
        private ImageSource _arrowRight = ImageSource.FromFile("ic_keyboard_arrow_down_black_24dp.png");
        private ImageSource _arrowDown = ImageSource.FromFile("ic_keyboard_arrow_up_black_24dp.png");
        //private AbsoluteLayout _header = new AbsoluteLayout();
        private StackLayout _header = new StackLayout()
        {
            Orientation = StackOrientation.Horizontal,
            Padding = new Thickness(20, 0, 20, 20),
            BackgroundColor = Color.LightGray,
        };
        private Image _headerIcon = new Image { VerticalOptions = LayoutOptions.Center, HeightRequest = 25 };
        private Label _headerTitle = new Label
        {
            TextColor = Color.Black,
            FontSize = 12,
            VerticalTextAlignment = TextAlignment.Center,
            //HeightRequest = 50
        };
        private DataTemplate _template;

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(
                propertyName: "ItemsSource",
                returnType: typeof(IList),
                declaringType: typeof(AcuteSectionView),
                defaultValue: default(IList),
                propertyChanged: AcuteSectionView.PopulateList);

        public IList ItemsSource
        {
            get { return (IList)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty TitleProperty =
            BindableProperty.Create(
                propertyName: "Title",
                returnType: typeof(string),
                declaringType: typeof(AcuteSectionView),
                propertyChanged: AcuteSectionView.ChangeTitle);

        public static readonly BindableProperty DescriptionProperty =
        BindableProperty.Create(
            propertyName: "Description",
            returnType: typeof(string),
            declaringType: typeof(AcuteSectionView),
            propertyChanged: AcuteSectionView.ChangeDescription);

        public static readonly BindableProperty DueDateProperty =
      BindableProperty.Create(
          propertyName: "DueDate",
          returnType: typeof(string),
          declaringType: typeof(AcuteSectionView),
          propertyChanged: AcuteSectionView.ChangeDueDate);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string DueDate
        {
            get { return (string)GetValue(DueDateProperty); }
            set { SetValue(DueDateProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        public AcuteSectionView(DataTemplate itemTemplate, ScrollView parent)
        {
            _template = itemTemplate;
            _headerTitle.BackgroundColor = _headerColor;
            _headerIcon.Source = _arrowRight;

            _header.BackgroundColor = _headerColor;
            _buttonhelp.Source = icono_interogacion;
            //_buttonhelp2.Image = icono_interogacion;
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                //handle the tap
                if (true)
                {
                    Image lblClicked = (Image)s;
                    //string txt = lblClicked.te;
                    //TaskListPageModel.instance.CurrentPage.DisplayAlert("Project Description", ((ProjectAcute)args.Parameter).Description, "Close");
                    //  App.Current.MainPage.DisplayAlert("Project Description", ((ProjectAcute)e).Description, "Close");
                }
            };
            _buttonhelp.GestureRecognizers.Add(tapGestureRecognizer);

            Button myButton = new Button();
            //_buttonhelp.SetBinding(Button.CommandProperty, new Binding() { Source = NameEntry, Path = "LoginCommand" });
            //_buttonhelp.SetBinding(Button.CommandParameterProperty, new Binding() { Source = NameEntry, Path = "Text" });

            tapGestureRecognizer.SetBinding(TapGestureRecognizer.CommandProperty, "TapCommand");
            //image.GestureRecognizers.Add(tapGestureRecognizer);
            //_buttonhelp.GestureRecognizers.Add(
            //   new TapGestureRecognizer
            //   {
            //       Command = new Command(async () =>
            //       {


            //       })
            //   }
            //   );



            _content1.Children.Add(_content2);
            _content2.Children.Add(_headerTitle);
            _content2.Children.Add(_content3);
            _content3.Children.Add(_labelDescription);
            _content3.Children.Add(_buttonhelp);
            _content4.Children.Add(_DueDate);
            _content4.Children.Add(_dateDueDate);
            _content1.Children.Add(_content4);
            _content1.Children.Add(_headerIcon);
            //_content1.BackgroundColor = Color.WhiteSmoke;
            //_header.Children.Add(_headerTitle);
            //_header.Children.Add(_headerIcon);
            _header.Children.Add(_content1);
            //_header.Children.Add(_content1, new Rectangle(0, 1, .1, 1), AbsoluteLayoutFlags.All); 
            //_header.Children.Add(_content1, new Rectangle(1, 1, .9, 1), AbsoluteLayoutFlags.All);
            //_header.Children.Add(_headerIcon, new Rectangle(0, 1, .1, 1), AbsoluteLayoutFlags.All);

            this.Spacing = 0;

            //_header.BackgroundColor = Color.WhiteSmoke;
            _header.Spacing = 0;
            _header.Padding = 0;

            this.Children.Add(_header);
            this.Children.Add(_content);

            _header.GestureRecognizers.Add(
                new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        if (_isExpanded)
                        {
                            _headerIcon.Source = _arrowRight;
                            _content.HeightRequest = 0;
                            _content.IsVisible = false;
                            _isExpanded = false;
                        }
                        else
                        {
                            _headerIcon.Source = _arrowDown;
                            _content.HeightRequest = _content.Children.Count * 50;
                            _content.IsVisible = true;
                            _isExpanded = true;


                            if (Device.OS == TargetPlatform.Android)
                            {
                                // Scroll top by the current Y position of the section
                                if (parent.Parent is VisualElement)
                                {
                                    await parent.ScrollToAsync(0, this.Y, true);
                                };
                            }

                        }
                    })
                }
            );
        }



        void ChangeDescription()
        {
            //_headerTitle.Text = this.Description;
        }

        void ChangeDueDate()
        {
            _dateDueDate.Text = this.DueDate;
        }
        void ChangeTitle()
        {
            _headerTitle.Text = this.Title;
        }

        void PopulateList()
        {
            _content.Children.Clear();

            foreach (object item in this.ItemsSource)
            {
                var template = (View)_template.CreateContent();
                template.BindingContext = item;
                _content.Children.Add(template);
            }
        }

        void OnTapGestureRecognizerTappedDescription(object sender, TappedEventArgs args)
        {
            try
            {
                //TaskListPageModel.instance.CurrentPage.DisplayAlert("Project Description",((Attributes)
                //    args.Parameter).description,"Close");

                App.Current.MainPage.DisplayAlert("Project Description", ((Attributes)
                    args.Parameter).description, "Close");
            }
            catch (Exception ex)
            {

            }
        }

        static void ChangeTitle(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AcuteSectionView)bindable).ChangeTitle();
        }

        static void ChangeDescription(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AcuteSectionView)bindable).ChangeDescription();
        }

        static void ChangeDueDate(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AcuteSectionView)bindable).ChangeDueDate();
        }


        static void PopulateList(BindableObject bindable, object oldValue, object newValue)
        {
            if (oldValue == newValue) return;
            ((AcuteSectionView)bindable).PopulateList();
        }
    }
}
