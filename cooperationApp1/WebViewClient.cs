using Android.Webkit;

namespace cooperationApp1
{
    class WebChromeClientpublic : WebChromeClient
    {
        public string userid = "";
        /// <summary>
        /// reads the console message from the javascript
        /// </summary>
        /// <param name="message">the message</param>
        public override void OnConsoleMessage(string message, int lineNumber, string sourceID)
        {
            //if it is user id then save it
            if (message.Contains("userid."))
            {
                userid = message.Split("userid.")[1];
            }
            base.OnConsoleMessage(message, lineNumber, sourceID);
        }
    }
}