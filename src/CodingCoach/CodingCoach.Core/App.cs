using CodingCoach.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

namespace CodingCoach.Core
{
   public class App : MvxApplication
   {
      public override void Initialize()
      {
         CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();
         RegisterAppStart<HomeViewModel>();
      }
   }
}
