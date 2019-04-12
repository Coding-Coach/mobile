using Android.Content;
using Android.Graphics;
using CodingCoach.CustomControls;
using CodingCoach.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FontAwesomeBrandIcon), typeof(FontAwesomeBrandIconRenderer))]
namespace CodingCoach.Droid
{
   public class FontAwesomeBrandIconRenderer : LabelRenderer
   {
      private readonly Context _context;

      public FontAwesomeBrandIconRenderer(Context context) : base(context)
      {
         _context = context;
      }

      protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
      {
         base.OnElementChanged(e);
         if (e.OldElement == null)
         {
            //The ttf in /Assets is CaseSensitive, so name it FontAwesome.ttf
            Control.Typeface = Typeface.CreateFromAsset(_context.Assets, FontAwesomeBrandIcon.Typeface + ".ttf");
         }
      }
   }
}