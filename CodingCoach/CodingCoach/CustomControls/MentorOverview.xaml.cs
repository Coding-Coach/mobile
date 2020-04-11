using CodingCoach.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CodingCoach.CustomControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MentorOverview
    {
        public MentorOverview()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty MentorProperty = BindableProperty.Create(
            "Mentor",
            typeof(MentorDto),
            typeof(MentorOverview));

        public MentorDto Mentor { 
            get => (MentorDto)GetValue(MentorProperty);
            set => SetValue(MentorProperty, value);
        }
    }
}