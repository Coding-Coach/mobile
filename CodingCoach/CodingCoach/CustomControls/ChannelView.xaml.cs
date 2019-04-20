using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
   [XamlCompilation( XamlCompilationOptions.Compile )]
   public partial class ChannelView
   {
      public ChannelView( ChannelType channelType,
                          string      id )
      {
         InitializeComponent();
         ChannelType = channelType;
         SetProperties( channelType, this );
         Id = id;
      }

      #region Id

      public static readonly BindableProperty IdProperty = BindableProperty.Create(
         "Id",
         typeof(string),
         typeof(ChannelView),
         "",
         BindingMode.Default );
      public string Id { get; set; }

      #endregion

      #region ChannelType

      public static readonly BindableProperty ChannelTypeProperty = BindableProperty.Create(
         "ChannelType",
         typeof(ChannelType),
         typeof(ChannelView),
         null,
         BindingMode.Default,
         null,
         ChannelTypePropertyChanged );
      public ChannelType ChannelType { get; set; }
      public string      ChannelLink { get; set; }

      private static void ChannelTypePropertyChanged( BindableObject bindable,
                                                      object         oldValue,
                                                      object         newValue )
      {
         if ( bindable is ChannelView control )
         {
            SetProperties( (ChannelType) newValue, control );
         }
      }

      private static void SetProperties( ChannelType newValue,
                                         ChannelView control )
      {
         control.ChannelIcon.Text      = "";
         control.ChannelBrandIcon.Text = "";
         control.ChannelText.Text      = "";
         control.ChannelLink           = "";
         switch ( (ChannelType) newValue )
         {
            case ChannelType.email:
               control.ChannelIcon.Text           = Icon.Email;
               control.ChannelIcon.IsVisible      = true;
               control.ChannelBrandIcon.Text      = "";
               control.ChannelBrandIcon.IsVisible = false;
               control.ChannelText.Text           = "Email";
               control.ChannelLink = "mailto:{0}";
               break;
            case ChannelType.website:
               control.ChannelIcon.Text           = Icon.Globe;
               control.ChannelIcon.IsVisible      = true;
               control.ChannelBrandIcon.Text      = "";
               control.ChannelBrandIcon.IsVisible = false;
               control.ChannelText.Text           = "Website";
               control.ChannelLink = "https://{0}";
               break;
            case ChannelType.facebook:
               control.ChannelIcon.Text           = "";
               control.ChannelIcon.IsVisible      = false;
               control.ChannelBrandIcon.Text      = BrandIcon.Facebook;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text           = "Facebook";
               control.ChannelLink = "https://www.facebook.com/{0}";
               break;
            case ChannelType.github:
               control.ChannelIcon.Text           = "";
               control.ChannelIcon.IsVisible      = false;
               control.ChannelBrandIcon.Text      = BrandIcon.Github;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text           = "Github";
               control.ChannelLink = "https://github.com/{0}";
               break;
            case ChannelType.linkedin:
               control.ChannelIcon.Text           = "";
               control.ChannelIcon.IsVisible      = false;
               control.ChannelBrandIcon.Text      = BrandIcon.Linkedin;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text           = "Linkedin";
               control.ChannelLink = "https://www.linkedin.com/in/{0}";
               break;
            case ChannelType.twitter:
               control.ChannelIcon.Text           = "";
               control.ChannelIcon.IsVisible      = false;
               control.ChannelBrandIcon.Text      = BrandIcon.Twitter;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text           = "Twitter";
               control.ChannelLink                = "https://twitter.com/{0}";
               break;
            case ChannelType.slack:
               control.ChannelIcon.Text           = "";
               control.ChannelIcon.IsVisible      = false;
               control.ChannelBrandIcon.Text      = BrandIcon.Slack;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text           = "Slack";
               control.ChannelLink = "https://coding-coach.slack.com/team/{0}";
               break;
         }
      }

      #endregion

      public ICommand ChannelTappedCommand { get; set; } = new Command<ChannelView>( ( control ) =>
      {
         try
         {
            var uriString = string.Format( control.ChannelLink, control.Id );
            Device.OpenUri( new Uri( uriString ) );
         }
         catch
         {
            Acr.UserDialogs.UserDialogs.Instance.Toast( $"Your device can't handle {control.ChannelText.Text} links" );
         }
      } );
   }
}