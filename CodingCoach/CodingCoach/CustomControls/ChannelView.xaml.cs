using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChannelView
    {
        public ChannelView()
        {
        }

      public ChannelView(ChannelType channelType)
      {
         InitializeComponent();
         ChannelType = channelType;
         SetProperties( channelType,this );
      }

      #region Id

      public static readonly BindableProperty IdProperty = BindableProperty.Create(
            "Id",
            typeof(string),
            typeof(ChannelView),
            "",
            BindingMode.Default);

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
            ChannelTypePropertyChanged);

        public ChannelType ChannelType { get; set; }


        private static void ChannelTypePropertyChanged(BindableObject bindable,
            object oldValue,
            object newValue)
        {
            if (bindable is ChannelView control)
            {
               SetProperties((ChannelType)newValue, control);
            }
        }

        private static void SetProperties( ChannelType newValue, ChannelView control )
        {
         control.ChannelIcon.Text = "";
         control.ChannelBrandIcon.Text = "";
         control.ChannelText.Text = "";

         switch ((ChannelType)newValue)
         {
            case ChannelType.email:
               control.ChannelIcon.Text = Icon.Email;
               control.ChannelIcon.IsVisible = true;
               control.ChannelBrandIcon.Text = "";
               control.ChannelBrandIcon.IsVisible = false;
               control.ChannelText.Text = "Email";
               break;

            case ChannelType.website:
               control.ChannelIcon.Text = Icon.Globe;
               control.ChannelIcon.IsVisible = true;
               control.ChannelBrandIcon.Text = "";
               control.ChannelBrandIcon.IsVisible = false;
               control.ChannelText.Text = "Website";
               break;

            case ChannelType.facebook:
               control.ChannelIcon.Text = "";
               control.ChannelIcon.IsVisible = false;
               control.ChannelBrandIcon.Text = BrandIcon.Facebook;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text = "Facebook";
               break;

            case ChannelType.github:
               control.ChannelIcon.Text = "";
               control.ChannelIcon.IsVisible = false;
               control.ChannelBrandIcon.Text = BrandIcon.Github;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text = "Github";
               break;

            case ChannelType.linkedin:
               control.ChannelIcon.Text = "";
               control.ChannelIcon.IsVisible = false;
               control.ChannelBrandIcon.Text = BrandIcon.Linkedin;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text = "Linkedin";
               break;

            case ChannelType.twitter:
               control.ChannelIcon.Text = "";
               control.ChannelIcon.IsVisible = false;
               control.ChannelBrandIcon.Text = BrandIcon.Twitter;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text = "Twitter";
               break;

            case ChannelType.slack:
               control.ChannelIcon.Text = "";
               control.ChannelIcon.IsVisible = false;
               control.ChannelBrandIcon.Text = BrandIcon.Slack;
               control.ChannelBrandIcon.IsVisible = true;
               control.ChannelText.Text = "Slack";
               break;
         }
      }

        #endregion
    }
}