using Xamarin.Forms;

namespace CodingCoach.CustomControls
{
   public class FontAwesomeIcon : Label
   {
      public static string Typeface => Device.RuntimePlatform == Device.Android ? "fa-solid-900" : "FontAwesome5Free-Solid";

      public FontAwesomeIcon()
      {
         FontFamily = Typeface;
      }

      public FontAwesomeIcon(string fontAwesomeIcon = null)
      {
         FontFamily = Typeface; //iOS is happy with this, Android needs a renderer to add ".ttf"
         Text       = fontAwesomeIcon;
      }
   }

   public class FontAwesomeBrandIcon : Label
   {
      public static string Typeface => Device.RuntimePlatform == Device.Android ? "fa-brands-400" : "FontAwesome5Free-Solid";

      public FontAwesomeBrandIcon()
      {
         FontFamily = Typeface;
      }

      public FontAwesomeBrandIcon(string fontAwesomeIcon = null)
      {
         FontFamily = Typeface; //iOS is happy with this, Android needs a renderer to add ".ttf"
         Text       = fontAwesomeIcon;
      }
   }
}
