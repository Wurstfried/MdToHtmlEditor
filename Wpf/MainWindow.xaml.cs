using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //webView.NavigationStarting += EnsureHttps;
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await webView.EnsureCoreWebView2Async(null);
            webView.CoreWebView2.WebMessageReceived += UpdateHtml;

            
            
        }

        void UpdateHtml(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            // Do the timer stuff


            String uri = args.TryGetWebMessageAsString();
            //addressBar.Text = uri;
            webView.CoreWebView2.PostWebMessageAsString(uri);

            //await webView.CoreWebView2.AddScriptToExecuteOnDocumentCreatedAsync("window.chrome.webview.postMessage(window.document.URL);");
        }

        void EnsureHttps(object sender, CoreWebView2NavigationStartingEventArgs args)
        {
            

            string uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                args.Cancel = true;
            }
        }

        private async void webView_Loaded(object sender, RoutedEventArgs e)
        {
            //await webView.CoreWebView2.ExecuteScriptAsync(@"window.document.body.onkeyup = function(){window.chrome.webview.postMessage(window.document.URL)}");
        }

        private async void webView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            await webView.CoreWebView2.ExecuteScriptAsync(@"window.document.body.onkeyup = function(){window.chrome.webview.postMessage(window.document.URL)}");

        }
    }
}
