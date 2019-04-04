using System.Collections.Generic;
using System.Threading.Tasks;
using CodingCoach.Core.Services;
using MvvmCross.ViewModels;

namespace CodingCoach.Core.ViewModels
{
   public class MentorsViewModel : MvxViewModel
   {
      private readonly IApiAccessService _apiAccessService;

      public MentorsViewModel( IApiAccessService apiAccessService )
      {
         _apiAccessService = apiAccessService;
      }

      public override Task Initialize()
      {
         Mentors = _apiAccessService.GetMentors();
         return base.Initialize();
      }

      private IEnumerable<Mentor> _mentors;

      public IEnumerable<Mentor> Mentors
      {
         get => _mentors;
         set => SetProperty( ref _mentors, value );
      }
   }
}