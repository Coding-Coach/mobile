using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CodingCoach.Core.Services;
using Xamarin.Forms;
using CodingCoach.Models;
using CodingCoach.Services;
using CodingCoach.Views;

namespace CodingCoach.ViewModels
{
   public class ItemsViewModel : BaseViewModel
   {
      private readonly IDataStore<Item>             _dataStore;
      private readonly IApiAccessService            _apiAccessService;
      public           ObservableCollection<Item>   Items            { get; set; }
      public           ObservableCollection<Mentor> Mentors          { get; set; }
      public           Command                      LoadItemsCommand { get; set; }

      public ItemsViewModel() : this( DependencyService.Get<IDataStore<Item>>() ?? new MockDataStore(),
                                      DependencyService.Get<IApiAccessService>() ) { }

      public ItemsViewModel( IDataStore<Item>  dataStore,
                             IApiAccessService apiAccessService )
      {
         _dataStore        = dataStore;
         _apiAccessService = apiAccessService;
         Title             = "Mentors";
         Items             = new ObservableCollection<Item>();
         Mentors           = new ObservableCollection<Mentor>();
         LoadItemsCommand  = new Command( async () => await ExecuteLoadItemsCommand() );
         MessagingCenter.Subscribe<NewItemPage, Item>( this, "AddItem", async ( obj,
                                                                                item ) =>
         {
            var newItem = item as Item;
            Items.Add( newItem );
            await _dataStore.AddItemAsync( newItem );
         } );
      }

      async Task ExecuteLoadItemsCommand()
      {
         if ( IsBusy )
            return;
         IsBusy = true;
         try
         {

            Mentors.Clear();
            var mentors = _apiAccessService.GetMentors();
            if ( mentors?.Any() ?? false )
            {
               foreach ( var mentor in mentors )
               {
                  Mentors.Add( mentor );
               }
            }

            Items.Clear();
            var items = await _dataStore.GetItemsAsync( true );
            foreach ( var item in items )
            {
               Items.Add( item );
            }
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