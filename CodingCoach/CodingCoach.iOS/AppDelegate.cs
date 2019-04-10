using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using UIKit;

namespace CodingCoach.iOS
{
   // The UIApplicationDelegate for the application. This class is responsible for launching the 
   // User Interface of the application, as well as listening (and optionally responding) to 
   // application events from iOS.
   [Register( "AppDelegate" )]
   public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
   {
      //
      // This method is invoked when the application has loaded and is ready to run. In this 
      // method you should instantiate the window, load the UI into it and then make the window
      // visible.
      //
      // You have 17 seconds to return from this method, or iOS will terminate your application.
      //
      public override bool FinishedLaunching( UIApplication app,
                                              NSDictionary  options )
      {
         global::Xamarin.Forms.Forms.Init();
         ImageCircleRenderer.Init();

         // TODO: add the right name for ios font awesome brands
         foreach (var familyNames in UIFont.FamilyNames.Where(f => f.StartsWith("Font Awesome")).OrderBy(c => c).ToList())
         {
            Console.WriteLine(" * " + familyNames);
            foreach (var familyName in UIFont.FontNamesForFamilyName(familyNames).OrderBy(c => c).ToList())
            {
               Console.WriteLine(" *-- " + familyName);
            }
         }

         LoadApplication( new App() );
         return base.FinishedLaunching( app, options );
      }
   }
}