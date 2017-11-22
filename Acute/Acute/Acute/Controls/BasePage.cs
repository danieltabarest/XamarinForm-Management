using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Acute.Controls
{
    public class BasePage : ContentPage
    {
        ContentView _header;
        public ContentView Header
        {
            get
            {
                return _header;
            }
            set
            {
                if (_mainLayout != null)
                {
                    if (_header != null && _mainLayout.Children.Contains(_header))
                        _mainLayout.Children.Remove(_header);

                    _header = value;
                    if (Device.OS == TargetPlatform.iOS)
                        _mainLayout.Children.Add(_header, 0, 1);
                    else
                        _mainLayout.Children.Add(_header, 0, 0);
                }
            }
        }

        //ContentView _footer;
        //public ContentView Footer
        //{
        //    get
        //    {
        //        return _footer;
        //    }
        //    set
        //    {
        //        if (_mainLayout != null)
        //        {
        //            if (_footer != null && _mainLayout.Children.Contains(_footer))
        //                _mainLayout.Children.Remove(_footer);

        //            _footer = value;
        //            if (Device.OS == TargetPlatform.iOS)
        //                _mainLayout.Children.Add(_footer, 0, 3);
        //            else
        //                _mainLayout.Children.Add(_footer, 0, 2);
        //        }
        //    }
        //}

        ContentView _content;
        public ContentView ContentPresenter
        {
            get
            {
                return _content;
            }
            set
            {
                if (_mainLayout != null)
                {
                    if (_content != null && _mainLayout.Children.Contains(_content))
                        _mainLayout.Children.Remove(_content);

                    _content = value;
                    if (Device.OS == TargetPlatform.iOS)
                        _mainLayout.Children.Add(_content, 0, 2);
                    else
                        _mainLayout.Children.Add(_content, 0, 1);
                }
            }
        }

        ContentView _popUpView;
        BoxView _maskView;
        public ContentView PopUpView
        {
            get
            {
                return _popUpView;
            }
            set
            {
                if (_mainLayout != null)
                {
                    if (_maskView != null && _mainLayout.Children.Contains(_maskView))
                        _mainLayout.Children.Remove(_maskView);

                    if (_popUpView != null && _mainLayout.Children.Contains(_popUpView))
                        _mainLayout.Children.Remove(_popUpView);

                    _popUpView = value;
                    if (_popUpView == null)
                        return;

                    if (_maskView == null)
                        _maskView = new BoxView { Color = Color.Black.MultiplyAlpha(0.5), IsVisible = false };
                    if (Device.OS == TargetPlatform.iOS)
                        _mainLayout.Children.Add(_maskView, 0, 1, 0, 4);
                    else
                        _mainLayout.Children.Add(_maskView, 0, 1, 0, 3);
                    _popUpView.IsVisible = false;
                    if (Device.OS == TargetPlatform.iOS)
                        _mainLayout.Children.Add(_popUpView, 0, 1, 0, 4);
                    else
                        _mainLayout.Children.Add(_popUpView, 0, 1, 0, 3);
                }
            }
        }

        public static readonly BindableProperty ShowPopupProperty = BindableProperty.Create(nameof(ShowPopup), typeof(bool), typeof(BasePage), default(bool));
        public bool ShowPopup
        {
            get { return (bool)GetValue(ShowPopupProperty); }
            set { SetValue(ShowPopupProperty, value); }
        }

        Grid _mainLayout;

        public BasePage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            _mainLayout = new Grid
            {
                Padding = new Thickness(0),
                RowSpacing = 0,
            };
            if (Device.OS == TargetPlatform.iOS)
            _mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(20, GridUnitType.Absolute) });
            _mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(44, GridUnitType.Absolute) });
            _mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            _mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(44, GridUnitType.Absolute) });

            Content = new ContentView { Content = _mainLayout };
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            if (propertyName == ShowPopupProperty.PropertyName)
            {
                if (_maskView != null && PopUpView != null)
                {
                    _maskView.IsVisible = ShowPopup;
                    _popUpView.IsVisible = ShowPopup;
                }
            }
        }

        public Task<bool> ShowAlert(FormattedString message, string rightButtonText = null, string leftButtonText = null, string middleButtonText = null)
        {
            var mainLaout = new Grid
            {
                RowSpacing = 0,
                RowDefinitions = new RowDefinitionCollection {
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition{Height = new GridLength(1, GridUnitType.Absolute)},
                    new RowDefinition{Height = new GridLength(40, GridUnitType.Absolute)},
                },
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                }
            };

            var messageLabel = new Label
            {
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FormattedText = message,
                Margin = new Thickness(10),
            };
            mainLaout.Children.Add(messageLabel, 0, 3, 0, 1);

            var line = new BoxView { Color = Color.Black, HeightRequest = 1 };
            mainLaout.Children.Add(line, 0, 3, 1, 2);

            var background = new BoxView { Color = Color.FromHex("#F7F7F7") };
            mainLaout.Children.Add(background, 0, 3, 2, 3);

            TaskCompletionSource<bool> completionSource = null;

            if (!string.IsNullOrEmpty(leftButtonText))
            {
                var leftButton = new Button
                {
                    BackgroundColor = Color.FromHex("#F7F7F7"),
                    Text = leftButtonText,
                    TextColor = Color.FromHex("#06A2D5"),
                };
                completionSource = new TaskCompletionSource<bool>();
                leftButton.Clicked += (sender, e) =>
                {
                    completionSource.SetResult(false);
                    ShowPopup = false;
                };
                mainLaout.Children.Add(leftButton, 0, 1, 2, 3);
            }

            if (!string.IsNullOrEmpty(middleButtonText))
            {
                var middleButton = new Button
                {
                    BackgroundColor = Color.FromHex("#F7F7F7"),
                    Text = middleButtonText,
                    TextColor = Color.FromHex("#06A2D5"),
                };
                completionSource = new TaskCompletionSource<bool>();
                middleButton.Clicked += (sender, e) =>
                {
                    completionSource.SetResult(true);
                    ShowPopup = false;
                };
                mainLaout.Children.Add(middleButton, 1, 2, 2, 3);
            }

            if (!string.IsNullOrEmpty(rightButtonText))
            {
                var rightButton = new Button
                {
                    BackgroundColor = Color.FromHex("#F7F7F7"),
                    Text = rightButtonText,
                    TextColor = Color.FromHex("#06A2D5"),
                };
                completionSource = new TaskCompletionSource<bool>();
                rightButton.Clicked += (sender, e) =>
                {
                    completionSource.SetResult(true);
                    ShowPopup = false;
                };
                mainLaout.Children.Add(rightButton, 2, 3, 2, 3);
            }

            // No buttons set here
            if (completionSource == null)
            {
                completionSource = new TaskCompletionSource<bool>();
                Task.Run(async () =>
                {
                    await Task.Delay(3000);
                    completionSource.SetResult(true);
                    ShowPopup = false;
                });
            }
            PopUpView = new ContentView
            {
                Padding = new Thickness(0),
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(5, 0),
                Content = new Frame
                {
                    Content = mainLaout,
                    IsClippedToBounds = true,
                    Padding = new Thickness(0),
                    BackgroundColor = Color.White
                },
            };
            ShowPopup = true;
            return completionSource.Task;
        }

        public void ShowLoading(string title = null)
        {
            var mainLayout = new StackLayout();
            var indicator = new ActivityIndicator { IsRunning = true };
            mainLayout.Children.Add(indicator);
            if (!string.IsNullOrEmpty(title))
            {
                var label = new Label
                {
                    Text = title,
                    HorizontalTextAlignment = TextAlignment.Center,
                    TextColor = Color.White
                };
                mainLayout.Children.Add(label);
            }
            PopUpView = new ContentView
            {
                Content = mainLayout,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = Color.Transparent
            };
            ShowPopup = true; ;
        }

        public void HideAllPopup()
        {
            PopUpView = null;
            ShowPopup = false;
        }

    }
}
