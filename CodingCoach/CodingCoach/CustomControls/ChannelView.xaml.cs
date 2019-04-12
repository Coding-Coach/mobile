using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
                }

                // set image for channel
                // set text for channel
            }
        }

        #endregion
    }
}