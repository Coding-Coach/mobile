using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CodingCoach.Models;
using CodingCoach.ViewModels;

namespace CodingCoach.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   public partial class MentorsListPage : ContentPage
   {
      MentorsListViewModel viewModel;

      public MentorsListPage()
      {
         InitializeComponent();

         BindingContext = viewModel = new MentorsListViewModel();
      }

      protected override void OnAppearing()
      {
         base.OnAppearing();

         if (viewModel.Mentors.Count == 0)
            viewModel.LoadItemsCommand.Execute(null);
      }
   }
}