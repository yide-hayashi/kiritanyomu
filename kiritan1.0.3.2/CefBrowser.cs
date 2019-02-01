using System;
using System.Windows.Forms;
using System.IO;
using CefSharp.WinForms;
using CefSharp;
using System.Threading;

namespace kiritannyomi
{
    public partial class CefBrowser : UserControl
    {
        public Form1 f;
        string url = "";
        string Htmlsource = "";
        FrameLoadEndEventArgs e;
        public CefBrowser()
        {
            InitializeComponent();
            
        }
        public void start(string url)
        {
            this.url = url;
            InitializeChromium();
        }
        public ChromiumWebBrowser browser;
        private void InitializeChromium()
        {
            
            if (!Directory.Exists(Application.StartupPath + "\\CachePath\\"))
                Directory.CreateDirectory(Application.StartupPath + "\\CachePath\\");

            CefSettings settings = new CefSettings();

            // Initialize cef with the provided settings
            settings.Locale = "ja-jp";
            settings.AcceptLanguageList = "ja-jp";
            settings.MultiThreadedMessageLoop = true;
            settings.PersistSessionCookies = true;
            settings.CachePath = Application.StartupPath + "\\CachePath\\";
            CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            Cef.Initialize(settings);
            
            // Create a browser component
            browser = new ChromiumWebBrowser(url);
            // Add it to the form and fill it to the form window.
            CallCSharpFunction CCF = new CallCSharpFunction(f);
            browser.RegisterJsObject("CallCsharp", CCF, new CefSharp.BindingOptions() { CamelCaseJavascriptNames = false });
            
            browser.Dock = DockStyle.Fill;
            Controls.Add(browser);
            browser.FrameLoadEnd += Browser_FrameLoadEnd;
            browser.FrameLoadStart += Browser_FrameLoadStart;
            browser.Load(url);
        }

        private void Browser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void Browser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            url = e.Url;
            if (url == "https://twitter.com/")
            {
                callJS();

            }
            Htmlsource = await e.Frame.GetSourceAsync();

        }
        public void callJS()
        {
            string jstop = @"
                window.scrollTo(310,0);
                document.body.style.overflowX = ""hidden"";
                run();

                function run() {

                if (document.getElementsByClassName(""new-tweets-bar js-new-tweets-bar"").length != 0) {
                    document.getElementsByClassName(""new-tweets-bar js-new-tweets-bar"")[0].click();

                    CallCsharp.Callkiritan(document.getElementsByClassName(""js-stream-item stream-item stream-item"")[0].innerText);
                    }
                    setTimeout(run,1000);
                }
                function test()
                {
                
                setTimeout(test,1000);
                }
            ";
            browser.ExecuteScriptAsync(jstop);
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }
        public string geturl()
        {
            return url;
        }
        public string gethtmlsource()
        {
            return Htmlsource.ToString();
        }
    }
   public class CallCSharpFunction
   {
        public Form1 Form1;
        public CallCSharpFunction(Form1 f)
        {
            this.Form1 = f;
        }
        public void Callkiritan(string s)
        {
            Form1.putoutkiritan(s);
        }
   }
}
