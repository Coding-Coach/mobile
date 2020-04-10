using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CodingCoach.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
   [XamlCompilation( XamlCompilationOptions.Compile )]
   public partial class ChannelsView
   {
      public ChannelsView()
      {
         try
         {
            InitializeComponent();
         }
         catch (Exception e)
         {
            Console.WriteLine( e );
         }
      }

      public static readonly BindableProperty ChannelsProperty = BindableProperty.Create(
         "Channels",
         typeof(ObservableCollection<Channel>),
         typeof(ChannelsView),
         new ObservableCollection<Channel>(),
         BindingMode.Default,
         null,
         ChannelsPropertyChanged );
      public ObservableCollection<Channel> Channels { get; set; }

      private static View CreateChannel( Channel channel )
      {
         var channelView = new ChannelView( (ChannelType) Enum.Parse( typeof(ChannelType), channel.Type ), channel.Id );
         return channelView;
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