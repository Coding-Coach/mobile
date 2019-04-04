using System.Collections.Generic;

namespace CodingCoach.Core.Services
{
   public interface IApiAccessService
   {
      IEnumerable<Mentor> GetMentors();
   }
}
