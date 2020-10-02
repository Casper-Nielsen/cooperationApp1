using Android.Webkit;

namespace cooperationApp1
{
    class WebChromeClientpublic : WebChromeClient
    {
        public string userid = "";

        public override void OnConsoleMessage(string message, int lineNumber, string sourceID)
        {
            if (message.Contains("userid."))
            {
                userid = message.Split("userid.")[1];
            }
            base.OnConsoleMessage(message, lineNumber, sourceID);
        }
    }
}