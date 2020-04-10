using CodingCoach.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CodingCoach.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

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

            Application.Current.MainPage = new MainPage();

            // TODO: for login implementation
            // TODO: move to navigation service
            //try
            //{
            //    var authService = DependencyService.Resolve<IAuthService>();
            //    if (authService.IsUserAuthenticated())
            //    {
            //        var page = new MainPage();
            //        Application.Current.MainPage = page;
            //    }
            //    else
            //    {
            //        Application.Current.MainPage = new StartView();
            //    }
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}
        }

        protected override void OnStart()
        {
            AppCenter.Start($"android={Secrets.Instance.AppCenterAndroid};" +
                            $"ios={Secrets.Instance.AppCenteriOS};",
                typeof(Analytics), typeof(Crashes));
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