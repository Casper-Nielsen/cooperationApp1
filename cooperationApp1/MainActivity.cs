using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace cooperationApp1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private WebView web_view;
        private string url = "http://192.168.43.86:4200/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Button button1 = FindViewById<Button>(Resource.Id.showloginbutton);
            button1.Click += ShowLogin;


            web_view = FindViewById<WebView>(Resource.Id.webview);
            web_view.Settings.JavaScriptEnabled = true;
            web_view.SetWebViewClient(new WebViewClient());
            web_view.Settings.JavaScriptEnabled = true;
            web_view.Settings.DatabaseEnabled = true;
            web_view.Settings.DomStorageEnabled = true;

            web_view.LoadUrl(url);
            var cookieHeader = CookieManager.Instance.GetCookie(url);
            StartForegroundServiceCompat<DemoService>();
        }

        private void ShowLogin(object sender, System.EventArgs e)
        {
            RelativeLayout layout = FindViewById<RelativeLayout>(Resource.Id.login);
            layout.Visibility = ViewStates.Visible;
        }

        public void StartForegroundServiceCompat<T>(Bundle args = null) where T : Service
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
