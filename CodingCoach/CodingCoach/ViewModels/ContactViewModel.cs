using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace CodingCoach.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        private ICommand _slackCommand;
        public ICommand SlackCommand => _slackCommand ?? (_slackCommand = new Command(OpenSlack));

        private ICommand _emailCommand;
        public ICommand EmailCommand => _emailCommand ?? (_emailCommand = new Command(async () => await ComposeEmail()));

        public ContactViewModel()
        {
            Title = "Contact";
        }

        private void OpenSlack()
        {
            Device.OpenUri(new Uri(Models.Constants.Urls.Slack));
        }

        private Task ComposeEmail()
        {
            //Remark: This will only work on a real iOS device and not on iOS simulator
            //https://github.com/xamarin/Essentials/issues/370

            return Email.ComposeAsync(new EmailMessage() { To = new List<string>() { Models.Constants.Emails.Contact } });
        }
    }
}