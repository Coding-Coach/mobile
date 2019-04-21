using CodingCoach.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CodingCoach.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

[assembly: XamlCompilation( XamlCompilationOptions.Compile )]

namespace CodingCoach
{
   public partial class App
   {
      public App()
      {
         InitializeComponent();
         DependencyService.Register<ApiAccessService>();
         DependencyService.Register<LoadService>();
         MainPage = new MainPage();
      }

      protected override void OnStart()
      {
         AppCenter.Start( $"android={Secrets.Instance.AppCenterAndroid};" +
                          $"ios={Secrets.Instance.AppCenteriOS};",
                          typeof(Analytics), typeof(Crashes) );
      }

      protected override void OnSleep()
      {
         // Handle when your app sleeps
      }

      protected override void OnResume()
      {
         // Handle when your app resumes
      }
   }
}