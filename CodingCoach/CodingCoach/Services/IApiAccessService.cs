using System.Collections.Generic;
using CodingCoach.Core.Services;

namespace CodingCoach.Services
{
   public interface IApiAccessService
   {
      IList<Mentor> GetMentors(string techFilter);
      IList<string> GetTechList();
   }
}
