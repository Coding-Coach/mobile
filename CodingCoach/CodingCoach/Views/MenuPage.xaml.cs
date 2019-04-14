using CodingCoach.Models;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.Views
{
   [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MenuPage : ContentPage
   {
      MainPage RootPage { get => Application.Current.MainPage as MainPage; }
      List<HomeMenuItem> menuItems;
      public MenuPage()
      {
         InitializeComponent();

         menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.Browse, Title="Mentors" },
                new HomeMenuItem {Id = MenuItemType.About, Title="About" },
                new HomeMenuItem {Id = MenuItemType.Contact, Title="Contact" }
            };

         ListViewMenu.ItemsSource = menuItems;

         ListViewMenu.SelectedItem = menuItems[0];
         ListViewMenu.ItemSelected += async (sender, e) =>
         {
            if (e.SelectedItem == null)
               return;

            var id = (int)((HomeMenuItem)e.SelectedItem).Id;
            await RootPage.NavigateFromMenu(id);
         };
      }
   }
}