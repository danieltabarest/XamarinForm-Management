
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Acute.Droid.Renderers;
using Android.Views;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.App;

[assembly: ExportRenderer(typeof(Button), typeof(BorderButtonRenderer))]
namespace Acute.Droid.Renderers
{  /// <summary>
   /// Custom renderer for buttons with a custom border
   /// </summary>
    public class BorderButtonRenderer : ButtonRenderer
    {
        protected override void OnDraw(Android.Graphics.Canvas canvas)
        {
            base.OnDraw(canvas);
        }
    
        //protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        //{
        //        base.OnElementChanged(e);

        //        if (e.OldElement != null || Element == null)
        //        {
        //            return;
        //        }
        //}
    }



}
