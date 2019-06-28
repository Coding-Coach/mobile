using CodingCoach.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodingCoach.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MainPage : MasterDetailPage
   {
      Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

      public MainPage()
      {
         InitializeComponent();

         MasterBehavior = MasterBehavior.Popover;

         MenuPages.Add((int) MenuItemType.Browse, (NavigationPage) Detail);
      }

      public async Task NavigateFromMenu(int id)
      {
         if (id == (int) MenuItemType.Logout)
         {
            var authService = DependencyService.Resolve<IAuthService>();
            authService.Logout();
            Application.Current.MainPage = new StartView();
            return;
         }

         if (!MenuPages.ContainsKey(id))
         {
            switch (id)
            {
               case (int) MenuItemType.Browse:
                  MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                  break;
               case (int) MenuItemType.About:
                  MenuPages.Add(id, new NavigationPage(new AboutPage()));
                  break;
               case (int) MenuItemType.Contact:
                  MenuPages.Add(id, new NavigationPage(new ContactPage()));
                  break;
            }
         }

         var newPage = MenuPages[id];

         if (newPage != null && Detail != newPage)
         {
            Detail = newPage;

            if (Device.RuntimePlatform == Device.Android)
               await Task.Delay(100);

            IsPresented = false;
         }
      }
   }
}