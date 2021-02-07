using Markdig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace TestMonacoForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            splitView.Panel1.Controls.Add(editor);
            splitView.Panel2.Controls.Add(viewer);

            theme.SelectedValue = "vs-dark";

            var themes = new Dictionary<string, string>
            {
              {"Dark", "vs-dark"},
              {"Light", "vs"},
              {"High contrast", "hc-black"}
            };
            theme.DataSource = new BindingSource(themes, null);
            theme.DisplayMember = "Key";
            theme.ValueMember = "Value";


            timer.Elapsed += renderMD;
        }

        private System.Timers.Timer timer = new System.Timers.Timer(250);
        private string dirExec = Directory.GetParent(Assembly.GetExecutingAssembly().Location).FullName;
        private string lastMD = "";

        private void editor_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var pathEditor = Path.Combine(dirExec, "Resources", "editor.html");
            editor.GetBrowser().MainFrame.LoadUrl(pathEditor);
        }

        private void viewer_IsBrowserInitializedChanged(object sender, EventArgs e)
        {
            var pathViewer = Path.Combine(dirExec, "Resources", "viewer.html");
            viewer.GetBrowser().MainFrame.LoadUrl(pathViewer);
        }

        private void chromiumWebBrowser1_FrameLoadEnd(object sender, CefSharp.FrameLoadEndEventArgs e)
        {
            if (e.Frame.IsMain)
            {
                //In the main frame we inject some javascript that's run on mouseUp
                //You can hook any javascript event you like.
                e.Browser.MainFrame.EvaluateScriptAsync(@"
	                document.body.onkeyup = function()
	                {
		                //CefSharp.PostMessage can be used to communicate between the browser
		                //and .Net, in this case we pass a simple string,
		                //complex objects are supported, passing a reference to Javascript methods
		                //is also supported.
		                //See https://github.com/cefsharp/CefSharp/issues/2775#issuecomment-498454221 for details
		                CefSharp.PostMessage(window.getSelection().toString());
	                }
	            ");
            }
        }

        private void chromiumWebBrowser1_JavascriptMessageReceived(object sender, CefSharp.JavascriptMessageReceivedEventArgs e)
        {
            timer.Stop();
            timer.Start();
        }

        private void renderMD(object sender, EventArgs e)
        {
            timer.Stop();

            string script = string.Format("editor.getValue();");
            editor.GetBrowser().MainFrame.EvaluateScriptAsync(script).ContinueWith(x =>
            {
                var response = x.Result;

                if (response.Success && response.Result != null)
                {
                    var result = response.Result.ToString();
                    if (lastMD == result) return;
                    lastMD = result;

                    var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
                    var html = Markdown.ToHtml(result, pipeline);


                    script = $"editor.getModel().setValue('{HttpUtility.JavaScriptStringEncode(html)}')";
                    viewer.GetBrowser().MainFrame.EvaluateScriptAsync(script);
                }
            });
        }

        private void theme_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTheme = (sender as ComboBox).SelectedValue;
            var script = $"monaco.editor.setTheme('{selectedTheme}')";

            if(!editor.IsBrowserInitialized) return;
            if(!viewer.IsBrowserInitialized) return;
            editor.GetBrowser().MainFrame.EvaluateScriptAsync(script);
            viewer.GetBrowser().MainFrame.EvaluateScriptAsync(script);
        }
    }
}
