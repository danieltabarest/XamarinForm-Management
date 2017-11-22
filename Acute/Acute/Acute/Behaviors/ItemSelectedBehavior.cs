using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace Acute.Behaviors
{
    public class ItemSelectedBehavior : Behavior<ListView>
    {
        private VisualElement _element;

        public static readonly BindableProperty ItemSelectedCommandProperty = 
            BindableProperty.Create("ItemSelectedCommand", 
                                    typeof(ICommand), 
                                    typeof(ItemSelectedBehavior), 
                                    default(ICommand), 
                                    BindingMode.OneWay, 
                                    null);

        public ICommand ItemSelectedCommand
        {
            get 
            {
                return (ICommand)GetValue(ItemSelectedCommandProperty);
            }

            set 
            {
                SetValue(ItemSelectedCommandProperty, value);
            }
        }


        protected override void OnAttachedTo(ListView bindable)
        {
            _element = bindable;
            bindable.ItemSelected += Bindable_ItemSelected;
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
        }

        protected override void OnDetachingFrom(ListView bindable)
		{
            _element = null;
            bindable.ItemSelected -= Bindable_ItemSelected;

		}

        private void Bindable_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ItemSelectedCommand != null && ItemSelectedCommand.CanExecute(null))
                ItemSelectedCommand.Execute(null);
        }

		private void Bindable_BindingContextChanged(object sender, EventArgs e)
		{
            BindingContext = _element?.BindingContext;
		}

    }
}
