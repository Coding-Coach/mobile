using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using CodingCoach.Services;
using CodingCoach.Views;
using Xamarin.Forms;

namespace CodingCoach.ViewModels
{
   public class StartViewModel
   {
      private readonly IAuthService _authService;
      public ICommand LoginCommand => new Command(OnLogin);

      public StartViewModel(IAuthService authService)
      {
         _authService = authService;
      }

      public StartViewModel() : this(DependencyService.Resolve<IAuthService>())
      {
      }

      private async void OnLogin()
      {
         var userLogged = await _authService.Login();
         if (!userLogged) return;

         // TODO: move to navigation service
         try
         {
            if (_authService.IsUserAuthenticated())
            {
               var page = new MainPage();
               Application.Current.MainPage = page;
            }
            else
            {
               Application.Current.MainPage = new StartView();
            }
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }
   }
}