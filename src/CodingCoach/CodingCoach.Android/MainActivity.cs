using Android.App;
using Android.Content.PM;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;

namespace CodingCoach.Droid
{
   [Activity( Label        = "CodingCoach", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
      ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation )]
   public class MainActivity : MvxFormsAppCompatActivity<MvxFormsAndroidSetup<Core.App, CodingCoach.App>, Core.App, CodingCoach.App>
   {

   }
}