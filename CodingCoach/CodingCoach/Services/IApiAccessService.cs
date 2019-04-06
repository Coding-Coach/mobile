using System.Collections.Generic;
using CodingCoach.Core.Services;

namespace CodingCoach.Services
{
   public interface IApiAccessService
   {
      IEnumerable<Mentor> GetMentors();
   }
}
