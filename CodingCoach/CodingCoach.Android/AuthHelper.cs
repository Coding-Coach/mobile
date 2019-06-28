using Auth0.OidcClient;
using CodingCoach.Services;

namespace CodingCoach.Droid
{
   public class AuthHelper
   {
      public static Auth0Client GetClient()
      {
         return new Auth0Client(new Auth0ClientOptions
         {
            Domain = Secrets.Instance.Auth0Domain,
            ClientId = Secrets.Instance.Auth0ClientId
         });
      }
   }
}