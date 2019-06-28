using System.Threading.Tasks;

namespace CodingCoach.Services
{
   public interface IAuthService
   {
      Task<bool> Login();
      void Logout();
      bool IsUserAuthenticated();
   }
}
