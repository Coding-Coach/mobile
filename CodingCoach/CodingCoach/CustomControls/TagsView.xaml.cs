using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
   [XamlCompilation( XamlCompilationOptions.Compile )]
   public partial class TagsView
   {
      public TagsView()
      {
         InitializeComponent();
      }

      public static readonly BindableProperty TagsProperty = BindableProperty.Create(
         "Tags",
         typeof(ObservableCollection<string>),
         typeof(TagsView),
         new ObservableCollection<string>(),
         BindingMode.Default,
         null,
         TagsPropertyChanged );
      public ObservableCollection<string> Tags { get; set; }

      private static View CreateTag( string tag )
      {
         var tagLabel = new Label
         {
            Text   = tag,
            @class = new List<string>
            {
               "mentor-tag"
            },
         };
         var frame = new Frame
         {
            @class = new List<string>
            {
               "mentor-tag-container"
            },
            Content         = tagLabel
         };
         return frame;
      }

      private static void TagsPropertyChanged( BindableObject bindable,
                                               object         oldValue,
                                               object         newValue )
      {
         if ( bindable is TagsView control )
         {
            control.TagsContainer.Children.Clear();
            if ( newValue is ObservableCollection<string> tags &&
                 tags.Any() )
            {
               foreach ( var tag in tags )
               {
                  control.TagsContainer.Children.Add( CreateTag( tag ) );
               }
            }
         }
      }
   }
}