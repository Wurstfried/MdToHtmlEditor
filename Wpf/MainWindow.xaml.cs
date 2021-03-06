﻿using Markdig;
using Microsoft.Web.WebView2.Core;
using System;
using System.Reflection;
using System.Timers;
using System.Web;
using System.Windows;

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
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            await editor.EnsureCoreWebView2Async(null);
            editor.CoreWebView2.WebMessageReceived += UserTyped;
            timer.Elapsed += renderMD;

            var pathViewer = System.IO.Path.Combine(dirExec, "Resources", "viewer.html");
            var pathEditor = System.IO.Path.Combine(dirExec, "Resources", "editor.html");
            viewer.Source = new Uri(pathViewer);
            editor.Source = new Uri(pathEditor);
        }

        private async void renderMD(object sender, ElapsedEventArgs e)
        {
            timer.Stop();

            await Dispatcher.Invoke(async () =>
            {
                 if (lastMD == currentMD) return;
                 lastMD = currentMD;

                 var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                 var html = Markdown.ToHtml(currentMD, pipeline);

                 var script = $"editor.getModel().setValue('{HttpUtility.JavaScriptStringEncode(html)}')";
                 await viewer.ExecuteScriptAsync(script);
            });
        }

        private Timer timer = new Timer(250);
        private string dirExec = System.IO.Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        private string lastMD = "";
        private string currentMD = "";

        void UserTyped(object sender, CoreWebView2WebMessageReceivedEventArgs args)
        {
            timer.Stop();
            timer.Start();

            currentMD = args.TryGetWebMessageAsString();
        }

        private async void editor_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            await editor.CoreWebView2.ExecuteScriptAsync(@"document.body.onkeyup = function(){chrome.webview.postMessage(editor.getValue())}; document.body.onkeyup();");
        }
    }
}
