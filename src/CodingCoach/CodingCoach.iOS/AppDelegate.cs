using Foundation;
using MvvmCross.Forms.Platforms.Ios.Core;

namespace CodingCoach.iOS
{
   // The UIApplicationDelegate for the application. This class is responsible for launching the 
   // User Interface of the application, as well as listening (and optionally responding) to 
   // application events from iOS.
   [Register( "AppDelegate" )]
   public partial class AppDelegate : MvxFormsApplicationDelegate<MvxFormsIosSetup<Core.App, CodingCoach.App>, Core.App,
      CodingCoach.App> { }
}