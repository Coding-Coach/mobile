using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChannelView
    {
        public ChannelView()
        {
            InitializeComponent();
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
                control.ChannelIcon.Text = "";
                control.ChannelBrandIcon.Text = "";
                control.ChannelText.Text = "";

                switch ((ChannelType) newValue)
                {
                    case ChannelType.Email:
                        control.ChannelIcon.Text = Icon.Email;
                        control.ChannelIcon.IsVisible = true;
                        control.ChannelBrandIcon.Text = "";
                        control.ChannelBrandIcon.IsVisible = false;
                        control.ChannelText.Text = "Email";
                        break;

                    case ChannelType.Website:
                        control.ChannelIcon.Text = Icon.Globe;
                        control.ChannelIcon.IsVisible = true;
                        control.ChannelBrandIcon.Text = "";
                        control.ChannelBrandIcon.IsVisible = false;
                        control.ChannelText.Text = "Website";
                        break;

                    case ChannelType.Facebook:
                        control.ChannelIcon.Text = "";
                        control.ChannelIcon.IsVisible = false;
                        control.ChannelBrandIcon.Text = BrandIcon.Facebook;
                        control.ChannelBrandIcon.IsVisible = true;
                        control.ChannelText.Text = "Facebook";
                        break;

                    case ChannelType.Github:
                        control.ChannelIcon.Text = "";
                        control.ChannelIcon.IsVisible = false;
                        control.ChannelBrandIcon.Text = BrandIcon.Github;
                        control.ChannelBrandIcon.IsVisible = true;
                        control.ChannelText.Text = "Github";
                        break;

                    case ChannelType.Linkedin:
                        control.ChannelIcon.Text = "";
                        control.ChannelIcon.IsVisible = false;
                        control.ChannelBrandIcon.Text = BrandIcon.Linkedin;
                        control.ChannelBrandIcon.IsVisible = true;
                        control.ChannelText.Text = "Linkedin";
                        break;

                    case ChannelType.Twitter:
                        control.ChannelIcon.Text = "";
                        control.ChannelIcon.IsVisible = false;
                        control.ChannelBrandIcon.Text = BrandIcon.Twitter;
                        control.ChannelBrandIcon.IsVisible = true;
                        control.ChannelText.Text = "Twitter";
                        break;

                    case ChannelType.Slack:
                        control.ChannelIcon.Text = "";
                        control.ChannelIcon.IsVisible = false;
                        control.ChannelBrandIcon.Text = BrandIcon.Slack;
                        control.ChannelBrandIcon.IsVisible = true;
                        control.ChannelText.Text = "Slack";
                        break;
                }

                // set image for channel
                // set text for channel
            }
        }

        #endregion
    }
}