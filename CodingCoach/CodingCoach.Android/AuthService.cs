using System;
using System.Threading.Tasks;
using CodingCoach.Droid;
using CodingCoach.Services;
using IdentityModel.OidcClient;
using Xamarin.Forms;

[assembly: Dependency(typeof(AuthService))]

namespace CodingCoach.Droid
{
   public class AuthService : IAuthService
   {
      private readonly ISettingsService _settingsService;

      public AuthService()
      {
         _settingsService = DependencyService.Resolve<ISettingsService>();
      }

      public async Task<bool> Login()
      {
         try
         {
            var client = AuthHelper.GetClient();
            var loginResult = await client.LoginAsync();
            SaveLoggedUserData(loginResult);
            return IsUserAuthenticated();
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            return false;
         }
      }

      private void SaveLoggedUserData(LoginResult loginResult)
      {
         if (string.IsNullOrWhiteSpace(loginResult?.AccessToken))
         {
            _settingsService.LoggedUser = null;
         }
         else
         {
            var loggedUser = new LoggedUser
            {
               AccessToken = loginResult.AccessToken
            };

            _settingsService.LoggedUser = loggedUser;
         }
      }

      public void Logout()
      {
         try
         {
            _settingsService.LoggedUser = null;
         }
         catch (Exception e)
         {
            Console.WriteLine(e);
            throw;
         }
      }

      public bool IsUserAuthenticated()
      {
         var loggedUser = _settingsService.LoggedUser;

         return loggedUser != null;
      }
   }
}