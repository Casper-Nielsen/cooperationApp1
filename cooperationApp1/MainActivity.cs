﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using System.Net;
using System.Threading.Tasks;

namespace cooperationApp1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private WebView web_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            string url = "http://192.168.43.86:4200/";
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Button button = FindViewById<Button>(Resource.Id.Enable_tracking_button);
            button.Click += Btn_EnableTracking;

            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new WebViewClient());
            web_view.Settings.DomStorageEnabled = true;
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.DatabaseEnabled = true;
            web_view.LoadUrl(url);

            StartForegroundService<DemoService>();
        }

        private void Btn_EnableTracking(object sender, System.EventArgs e)
        {
            System.Console.WriteLine(web_view.Url);
        }

        public void StartForegroundService<T>(Bundle args = null) where T : Service
        {
            var intent = new Intent(this, typeof(T));
            if (args != null)
            {
                intent.PutExtras(args);
            }

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                this.StartForegroundService(intent);
            }
            else
            {
                this.StartService(intent);
            }
        }


        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public override bool OnKeyDown(Android.Views.Keycode keyCode, Android.Views.KeyEvent e)
        {
            if (keyCode == Keycode.Back && web_view.CanGoBack())
            {
                web_view.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }
    }
}
