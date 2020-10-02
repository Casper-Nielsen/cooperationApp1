using Android.Webkit;

namespace cooperationApp1
{
    class WebChromeClientpublic : WebChromeClient
    {
        public string userid = "";

        public override bool OnConsoleMessage(ConsoleMessage consoleMessage)
        {
            return base.OnConsoleMessage(consoleMessage);
        }
        public override void OnConsoleMessage(string message, int lineNumber, string sourceID)
        {
            if (message.Contains("userid."))
            {
                userid = message.Split("userid.")[1];
            }
            base.OnConsoleMessage(message, lineNumber, sourceID);
        }
    }
    class WebViewClientpublic : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            if (true)
            {
                // magic
                return true;
            }
            return false;
        }
    }
}