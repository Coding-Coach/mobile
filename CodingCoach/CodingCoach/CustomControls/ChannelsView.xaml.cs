using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodingCoach.Core.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
   [XamlCompilation( XamlCompilationOptions.Compile )]
   public partial class ChannelsView
   {
      public ChannelsView()
      {
         InitializeComponent();
      }

      public static readonly BindableProperty ChannelsProperty = BindableProperty.Create(
         "Channels",
         typeof(ObservableCollection<string>),
         typeof(ChannelsView),
         new ObservableCollection<string>(),
         BindingMode.Default,
         null,
         ChannelsPropertyChanged );
      public ObservableCollection<Channel> Channels { get; set; }

      private static View CreateChannel( Channel channel )
      {
         var channelView = new ChannelView
         {
            ChannelType = (ChannelType) Enum.Parse( typeof(ChannelType), channel.Type )
         };
         var frame = new Frame
         {
            @class = new List<string>
            {
               "mentor-channel-container"
            },
            Content = channelView
         };
         return frame;
      }

      private static void ChannelsPropertyChanged( BindableObject bindable,
                                                   object         oldValue,
                                                   object         newValue )
      {
         if ( bindable is ChannelsView control )
         {
            control.ChannelsContainer.Children.Clear();
            if ( newValue is ObservableCollection<Channel> channels &&
                 channels.Any() )
            {
               foreach ( var channel in channels )
               {
                  control.ChannelsContainer.Children.Add( CreateChannel( channel ) );
               }
            }
         }
      }
   }
}