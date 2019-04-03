using System;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace CodingCoach.Core.ViewModels
{
   public class HomeViewModel : MvxViewModel
   {
      public IMvxCommand ShowTimeCommand => new MvxCommand(ShowTime);
      private void ShowTime()
      {
         Text = DateTime.Now.ToFileTimeUtc().ToString();
      }

      private string _text = "Hello MvvmCross";
      public string Text
      {
         get { return _text; }
         set { SetProperty(ref _text, value); }
      }
   }
}
