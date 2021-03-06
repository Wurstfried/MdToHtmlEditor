﻿namespace TestMonacoForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.viewer = new CefSharp.WinForms.ChromiumWebBrowser();
            this.editor = new CefSharp.WinForms.ChromiumWebBrowser();
            this.splitView = new System.Windows.Forms.SplitContainer();
            this.theme = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).BeginInit();
            this.splitView.Panel1.SuspendLayout();
            this.splitView.Panel2.SuspendLayout();
            this.splitView.SuspendLayout();
            this.SuspendLayout();
            // 
            // viewer
            // 
            this.viewer.ActivateBrowserOnCreation = false;
            this.viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewer.Location = new System.Drawing.Point(0, 0);
            this.viewer.Name = "viewer";
            this.viewer.Size = new System.Drawing.Size(612, 506);
            this.viewer.TabIndex = 1;
            this.viewer.IsBrowserInitializedChanged += new System.EventHandler(this.viewer_IsBrowserInitializedChanged);
            // 
            // editor
            // 
            this.editor.ActivateBrowserOnCreation = false;
            this.editor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editor.Location = new System.Drawing.Point(0, 0);
            this.editor.Name = "editor";
            this.editor.Size = new System.Drawing.Size(615, 506);
            this.editor.TabIndex = 0;
            this.editor.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.chromiumWebBrowser1_FrameLoadEnd);
            this.editor.JavascriptMessageReceived += new System.EventHandler<CefSharp.JavascriptMessageReceivedEventArgs>(this.chromiumWebBrowser1_JavascriptMessageReceived);
            this.editor.IsBrowserInitializedChanged += new System.EventHandler(this.editor_IsBrowserInitializedChanged);
            // 
            // splitView
            // 
            this.splitView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.splitView.Location = new System.Drawing.Point(0, 30);
            this.splitView.Name = "splitView";
            // 
            // splitView.Panel1
            // 
            this.splitView.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.splitView.Panel1.Controls.Add(this.editor);
            // 
            // splitView.Panel2
            // 
            this.splitView.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.splitView.Panel2.Controls.Add(this.viewer);
            this.splitView.Size = new System.Drawing.Size(1231, 506);
            this.splitView.SplitterDistance = 615;
            this.splitView.SplitterIncrement = 4;
            this.splitView.TabIndex = 2;
            // 
            // theme
            // 
            this.theme.FormattingEnabled = true;
            this.theme.Location = new System.Drawing.Point(12, 3);
            this.theme.Name = "theme";
            this.theme.Size = new System.Drawing.Size(170, 21);
            this.theme.TabIndex = 3;
            this.theme.SelectedIndexChanged += new System.EventHandler(this.theme_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1231, 536);
            this.Controls.Add(this.theme);
            this.Controls.Add(this.splitView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitView.Panel1.ResumeLayout(false);
            this.splitView.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitView)).EndInit();
            this.splitView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CefSharp.WinForms.ChromiumWebBrowser viewer;
        private CefSharp.WinForms.ChromiumWebBrowser editor;
        private System.Windows.Forms.SplitContainer splitView;
        private System.Windows.Forms.ComboBox theme;
    }
}

