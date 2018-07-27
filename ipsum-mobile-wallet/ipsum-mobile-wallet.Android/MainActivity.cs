using System;
using Xamarin.Forms;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ipsum_mobile_wallet;
using Android.Util;
using Prism;
using ipsum_mobile_wallet.Interfaces;
using Prism.Ioc;
using ipsum_mobile_wallet.Views;

namespace ipsum_mobile_wallet.Droid
{
    [Activity(NoHistory = true, Theme = "@style/MainTheme", ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            LoadApplication(new App(new AndroidInitializer()));
        }

        public override void OnBackPressed()
        {
        }

        public class AndroidInitializer : IPlatformInitializer
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

