
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace iAudit.Droid
{
   // [Activity(Label = "SplashActivity", Icon = "@mipmap/icon", Theme = "@style/Splash", MainLauncher = true)]
    [Activity(Label = "iAudit", Icon = "@mipmap/icon", MainLauncher = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            StartActivity(typeof(MainActivity));
            Finish();
        }
    }
}
