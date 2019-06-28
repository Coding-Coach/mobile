using System;
using CodingCoach.Services;
using Newtonsoft.Json;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: Dependency(typeof(SettingService))]

namespace CodingCoach.Services

{
   public class SettingService : ISettingsService
   {
      public LoggedUser LoggedUser
      {
         get
         {
            try
            {
               var serializedLoggeduser = Preferences.Get("SerializedLoggedUser", "");
               return string.IsNullOrWhiteSpace(serializedLoggeduser)
                  ? null
                  : JsonConvert.DeserializeObject<LoggedUser>(serializedLoggeduser);
            }
            catch (Exception)
            {
               return null;
            }
         }
         set => Preferences.Set("SerializedLoggedUser", JsonConvert.SerializeObject(value));
      }
   }

   public class LoggedUser
   {
      public string AccessToken { get; set; }
   }
}
