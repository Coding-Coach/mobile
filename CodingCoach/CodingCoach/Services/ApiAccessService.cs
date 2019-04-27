using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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
         var mentorsString = _loadService.GetTextFromEmbeddedResource( "mentors.json" );
         mentors = JsonConvert.DeserializeObject<IList<Mentor>>( mentorsString );
      }

      private static IList<Mentor> mentors;

      public IList<string> GetTechList()
      {
         return mentors
                .SelectMany(
                   m => m.Tags.Select(
                      t => t ) ).Distinct().ToList();
      }

      public IList<Mentor> GetMentors( string techFilter )
      {
         var mentors = ApiAccessService.mentors;

         // Tech filter
         if ( !string.IsNullOrWhiteSpace( techFilter ) )
            mentors = mentors.Where( m => m.Tags.Any( t => t == techFilter ) ).ToList();
         return mentors;
      }
   }
}