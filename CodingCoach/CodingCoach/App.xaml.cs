using CodingCoach.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CodingCoach.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
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
         // Handle when your app starts
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
