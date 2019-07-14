using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Auth0.OidcClient;
using ImageCircle.Forms.Plugin.Droid;

namespace CodingCoach.Droid
{
   [Activity( Label        = "CodingCoach", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true,
      ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
      LaunchMode = LaunchMode.SingleInstance)]
   [IntentFilter(
      new[] { Intent.ActionView },
      Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
      DataScheme = "io.codingcoach.mobile",
      DataHost = "codingcoach.eu.auth0.com",
      DataPathPrefix = "/android/io.codingcoach.mobile/callback")]
   public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
   {
      protected override void OnCreate( Bundle savedInstanceState )
      {
         TabLayoutResource = Resource.Layout.Tabbar;
         ToolbarResource   = Resource.Layout.Toolbar;
         base.OnCreate( savedInstanceState );
         UserDialogs.Init( () => this );
         Xamarin.Essentials.Platform.Init( this, savedInstanceState );
         global::Xamarin.Forms.Forms.Init( this, savedInstanceState );
         ImageCircleRenderer.Init();
         LoadApplication( new App() );
      }

      public override void OnRequestPermissionsResult( int                                              requestCode,
                                                       string[ ]                                        permissions,
                                                       [GeneratedEnum] Android.Content.PM.Permission[ ] grantResults )
      {
         Xamarin.Essentials.Platform.OnRequestPermissionsResult( requestCode, permissions, grantResults );
         base.OnRequestPermissionsResult( requestCode, permissions, grantResults );
      }

      protected override void OnNewIntent(Intent intent)
      {
         base.OnNewIntent(intent);

         ActivityMediator.Instance.Send(intent.DataString);
      }

   }
}