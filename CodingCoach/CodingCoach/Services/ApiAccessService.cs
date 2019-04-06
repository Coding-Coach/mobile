using System.Collections.Generic;
using CodingCoach.Core.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CodingCoach.Services
{
   public class ApiAccessService : IApiAccessService
   {
      private readonly ILoadService _loadService;

      public ApiAccessService() : this( DependencyService.Resolve<ILoadService>() ) { }

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