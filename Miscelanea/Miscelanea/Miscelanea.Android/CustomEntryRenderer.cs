using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Util;
using Android.Views;
using Android.Widget;
using Miscelanea.CustomControls;
using Miscelanea.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Miscelanea.Droid
{
    class CustomEntryRenderer : EntryRenderer
    {
        CustomEntry view;
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                //Control.Background = Context.GetDrawable(Resource.Drawable.CustomEntry);
                //Control.TextAlignment = Android.Views.TextAlignment.Center;

                 view = (CustomEntry)Element;

                if (view.IsCurvedCornersEnabled)
                {
                    // creating gradient drawable for the curved background
                    var _gradientBackground = new GradientDrawable();
                    _gradientBackground.SetShape(ShapeType.Rectangle);
                    _gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                    // Thickness of the stroke line
                    _gradientBackground.SetStroke(view.BorderWidth, view.BorderColor.ToAndroid());

                    // Radius for the curves
                    _gradientBackground.SetCornerRadius(
                        DpToPixels(this.Context,
                            Convert.ToSingle(view.CornerRadius)));

                    // set the background of the label
                    Control.SetBackground(_gradientBackground);
                }

                if (!string.IsNullOrWhiteSpace(view.Image))
                {
                    switch (view.ImageAlignment)
                    {
                        case ImageAlignment.Left:
                            this.Control.SetCompoundDrawablesWithIntrinsicBounds(GetDrawable(view.Image), null, null, null);
                            break;
                        case ImageAlignment.Right:
                            this.Control.SetCompoundDrawablesWithIntrinsicBounds( null, null, GetDrawable(view.Image), null);
                            break;
                        default:
                            break;
                    }
                    this.Control.CompoundDrawablePadding = 25;
                    Control.Background.SetColorFilter(view.LineColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
                }

                Control.SetPadding(
                   (int)DpToPixels(this.Context, Convert.ToSingle(12)),
                   Control.PaddingTop,
                   (int)DpToPixels(this.Context, Convert.ToSingle(12)),
                   Control.PaddingBottom);
            }

        }//OnElemnt

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }

        private BitmapDrawable GetDrawable(string imageEntryImage)
        {
            int resID = Resources.GetIdentifier(imageEntryImage, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            return new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, view.ImageWidth * 2, view.ImageHeight * 2, true));
        }

    }//Class
}