using System;
using System.Collections.Generic;
using System.Linq;
using ipsum_mobile_wallet;
using Foundation;
using UIKit;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using ipsum_mobile_wallet.Interfaces;
using ipsum_mobile_wallet.Views;

namespace ipsum_mobile_wallet.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new iOSInitializer()));

            return base.FinishedLaunching(app, options);
        }

        public class iOSInitializer : IPlatformInitializer
        {
            public void RegisterTypes(IContainerRegistry containerRegistry)
            {
                containerRegistry.Register<ISqlLiteDbAccess, SqlLiteDbAccess>();
                //containerRegistry.Register<ISnackBar, SnackBarAndroid>();
                //containerRegistry.Register<ICloseApplication, CloseApplicationAndroid>();
                containerRegistry.RegisterForNavigation<MainPage>();
                containerRegistry.RegisterForNavigation<ContentPage>();
                containerRegistry.RegisterForNavigation<NavigationPage>();
                containerRegistry.RegisterForNavigation<TabbedPage>();
            }
        }
    }
}
