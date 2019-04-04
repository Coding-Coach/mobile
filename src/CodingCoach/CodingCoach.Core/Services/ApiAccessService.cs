using System.Collections.Generic;
using Newtonsoft.Json;

namespace CodingCoach.Core.Services
{
   public class ApiAccessService : IApiAccessService
   {
      private readonly ILoadService _loadService;

      public ApiAccessService( ILoadService loadService )
      {
         _loadService = loadService;
      }

      public IEnumerable<Mentor> GetMentors()
      {
         var mentorsString = _loadService.GetTextFromEmbeddedResource( "mentors.json" );
         var mentors       = JsonConvert.DeserializeObject<IEnumerable<Mentor>>( mentorsString );
         return mentors;
      }
   }
}