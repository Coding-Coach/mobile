using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CodingCoach.Core.Services;
using Xamarin.Forms;
using CodingCoach.Services;

namespace CodingCoach.ViewModels
{
   public class ItemsViewModel : BaseViewModel
   {
      private string _techFilter;

      private readonly IApiAccessService            _apiAccessService;
      public           ObservableCollection<Mentor> Mentors          { get; set; }
      public           Command                      LoadItemsCommand { get; set; }
      public ICommand TechListSelectedCommand =>
         new Command<string>( OnTechListSelected );

      private async void OnTechListSelected( string key )
      {
         _techFilter = key;
         await LoadMentors();
      }

      public ItemsViewModel() : this( DependencyService.Get<IApiAccessService>() ) { }

      public ItemsViewModel( IApiAccessService apiAccessService )
      {
         _apiAccessService = apiAccessService;
         Title             = "Mentors";
         Mentors           = new ObservableCollection<Mentor>();
         LoadItemsCommand  = new Command( async () => await ExecuteLoadItemsCommand() );
      }

      private IList<KeyValuePair<string, string>> _techList;

      public IList<KeyValuePair<string, string>> TechList
      {
         get => _techList;
         private set => SetProperty( ref _techList, value );
      }

      private async Task LoadMentors()
      {
         Mentors.Clear();
         var mentors = _apiAccessService.GetMentors(_techFilter);
         TechList = _apiAccessService.GetTechList().Select( t=>new KeyValuePair<string,string>(t,t) ).ToList();
         if ( mentors?.Any() ?? false )
         {
            foreach ( var mentor in mentors )
            {
               Mentors.Add( mentor );
            }
         }
      }

      private async Task ExecuteLoadItemsCommand()
      {
         if ( IsBusy )
            return;
         IsBusy = true;
         try
         {
            await LoadMentors();
         }
         catch (Exception ex)
         {
            Debug.WriteLine( ex );
         }
         finally
         {
            IsBusy = false;
         }
      }
   }
}