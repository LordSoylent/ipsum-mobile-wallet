using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;

namespace ipsum_mobile_wallet.Droid
{
    [Activity(Label = "ipsum-mobile-wallet", Icon = "@mipmap/icon", Theme = "@style/Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class SplashActivity : FormsAppCompatActivity
    {
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            await this.LoadPeers();

            // Create your application here
            StartActivity(typeof(MainActivity));
        }

        public override void OnBackPressed()
        {
        }

        private async Task<bool> LoadPeers()
        {
            System.Threading.Thread.Sleep(3000);

            return true;
        }
    }
}