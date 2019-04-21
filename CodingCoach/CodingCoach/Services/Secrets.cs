using Newtonsoft.Json;
using Xamarin.Forms;

namespace CodingCoach.Services
{
   public class Secrets
   {
      private static SecretsData _instance;

      public static SecretsData Instance
      {
         get { return _instance ?? ( _instance = LoadSecrets() ); }
         set { _instance = value; }
      }

      private static SecretsData LoadSecrets()
      {
         try
         {
            var loadService = DependencyService.Resolve<ILoadService>();
            var secretsString = loadService.GetTextFromEmbeddedResource("secrets.json");
            var secrets       = JsonConvert.DeserializeObject<SecretsData>(secretsString);
            return secrets;
         }
         catch
         {
            return new SecretsData();
         }
      }
   }

   public class SecretsData
   {
      public string AppCenterAndroid { get; set; }
      public string AppCenteriOS     { get; set; }
   }
}