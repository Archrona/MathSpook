namespace MathSpook
{
    partial class MathSpook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.splitLR = new System.Windows.Forms.SplitContainer();
            this.splitTB = new System.Windows.Forms.SplitContainer();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hTMLLaTeXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlyLaTeXtexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jSONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reinitializeWebviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadCmdsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.sendTextTimer = new System.Windows.Forms.Timer(this.components);
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitLR)).BeginInit();
            this.splitLR.Panel1.SuspendLayout();
            this.splitLR.Panel2.SuspendLayout();
            this.splitLR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTB)).BeginInit();
            this.splitTB.Panel1.SuspendLayout();
            this.splitTB.Panel2.SuspendLayout();
            this.splitTB.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitLR
            // 
            this.splitLR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.splitLR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitLR.Location = new System.Drawing.Point(0, 0);
            this.splitLR.Name = "splitLR";
            // 
            // splitLR.Panel1
            // 
            this.splitLR.Panel1.Controls.Add(this.splitTB);
            this.splitLR.Panel1MinSize = 50;
            // 
            // splitLR.Panel2
            // 
            this.splitLR.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.splitLR.Panel2.Controls.Add(this.webView);
            this.splitLR.Panel2MinSize = 50;
            this.splitLR.Size = new System.Drawing.Size(2199, 1398);
            this.splitLR.SplitterDistance = 1238;
            this.splitLR.SplitterWidth = 6;
            this.splitLR.TabIndex = 0;
            // 
            // splitTB
            // 
            this.splitTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.splitTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitTB.Location = new System.Drawing.Point(0, 0);
            this.splitTB.Name = "splitTB";
            this.splitTB.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitTB.Panel1
            // 
            this.splitTB.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.splitTB.Panel1.Controls.Add(this.input);
            // 
            // splitTB.Panel2
            // 
            this.splitTB.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(38)))), ((int)(((byte)(34)))));
            this.splitTB.Panel2.Controls.Add(this.output);
            this.splitTB.Panel2.Controls.Add(this.menuStrip1);
            this.splitTB.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitTB_Panel2_Paint);
            this.splitTB.Size = new System.Drawing.Size(1238, 1398);
            this.splitTB.SplitterDistance = 638;
            this.splitTB.SplitterWidth = 6;
            this.splitTB.TabIndex = 0;
            // 
            // input
            // 
            this.input.AcceptsReturn = true;
            this.input.AcceptsTab = true;
            this.input.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.input.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.input.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.input.Location = new System.Drawing.Point(12, 12);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(1223, 610);
            this.input.TabIndex = 0;
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // output
            // 
            this.output.AcceptsReturn = true;
            this.output.AcceptsTab = true;
            this.output.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.output.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(38)))), ((int)(((byte)(34)))));
            this.output.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.output.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(240)))));
            this.output.Location = new System.Drawing.Point(12, 48);
            this.output.Multiline = true;
            this.output.Name = "output";
            this.output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(1223, 670);
            this.output.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formatToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.reloadCmdsToolStripMenuItem,
            this.fontToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1238, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hTMLLaTeXToolStripMenuItem,
            this.onlyLaTeXtexToolStripMenuItem,
            this.jSONToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(85, 29);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // hTMLLaTeXToolStripMenuItem
            // 
            this.hTMLLaTeXToolStripMenuItem.Name = "hTMLLaTeXToolStripMenuItem";
            this.hTMLLaTeXToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.hTMLLaTeXToolStripMenuItem.Text = "HTML";
            this.hTMLLaTeXToolStripMenuItem.Click += new System.EventHandler(this.hTMLLaTeXToolStripMenuItem_Click);
            // 
            // onlyLaTeXtexToolStripMenuItem
            // 
            this.onlyLaTeXtexToolStripMenuItem.Name = "onlyLaTeXtexToolStripMenuItem";
            this.onlyLaTeXtexToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.onlyLaTeXtexToolStripMenuItem.Text = "LaTeX";
            this.onlyLaTeXtexToolStripMenuItem.Click += new System.EventHandler(this.onlyLaTeXtexToolStripMenuItem_Click);
            // 
            // jSONToolStripMenuItem
            // 
            this.jSONToolStripMenuItem.Name = "jSONToolStripMenuItem";
            this.jSONToolStripMenuItem.Size = new System.Drawing.Size(160, 34);
            this.jSONToolStripMenuItem.Text = "JSON";
            this.jSONToolStripMenuItem.Click += new System.EventHandler(this.jSONToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reinitializeWebviewToolStripMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(82, 29);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // reinitializeWebviewToolStripMenuItem
            // 
            this.reinitializeWebviewToolStripMenuItem.Name = "reinitializeWebviewToolStripMenuItem";
            this.reinitializeWebviewToolStripMenuItem.Size = new System.Drawing.Size(271, 34);
            this.reinitializeWebviewToolStripMenuItem.Text = "Reinitialize Webview";
            this.reinitializeWebviewToolStripMenuItem.Click += new System.EventHandler(this.reinitializeWebviewToolStripMenuItem_Click);
            // 
            // reloadCmdsToolStripMenuItem
            // 
            this.reloadCmdsToolStripMenuItem.Name = "reloadCmdsToolStripMenuItem";
            this.reloadCmdsToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.reloadCmdsToolStripMenuItem.Text = "Reload Cmds";
            this.reloadCmdsToolStripMenuItem.Click += new System.EventHandler(this.reloadCmdsToolStripMenuItem_Click);
            // 
            // webView
            // 
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 0);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(955, 1398);
            this.webView.Source = new System.Uri("about:blank", System.UriKind.Absolute);
            this.webView.TabIndex = 0;
            this.webView.Text = "webView21";
            this.webView.ZoomFactor = 1D;
            this.webView.CoreWebView2Ready += new System.EventHandler<System.EventArgs>(this.webView_CoreWebView2Ready);
            this.webView.Click += new System.EventHandler(this.webView_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // sendTextTimer
            // 
            this.sendTextTimer.Enabled = true;
            this.sendTextTimer.Interval = 40;
            this.sendTextTimer.Tick += new System.EventHandler(this.sendTextTimer_Tick);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.fontToolStripMenuItem.Text = "Font";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(270, 34);
            this.toolStripMenuItem2.Text = "80%";
            // 
            // MathSpook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(15F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2199, 1398);
            this.Controls.Add(this.splitLR);
            this.Font = new System.Drawing.Font("Cambria", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "MathSpook";
            this.Text = "MathSpook";
            this.splitLR.Panel1.ResumeLayout(false);
            this.splitLR.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitLR)).EndInit();
            this.splitLR.ResumeLayout(false);
            this.splitTB.Panel1.ResumeLayout(false);
            this.splitTB.Panel1.PerformLayout();
            this.splitTB.Panel2.ResumeLayout(false);
            this.splitTB.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitTB)).EndInit();
            this.splitTB.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitLR;
        private System.Windows.Forms.SplitContainer splitTB;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hTMLLaTeXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onlyLaTeXtexToolStripMenuItem;
        private System.Windows.Forms.TextBox output;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reinitializeWebviewToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem jSONToolStripMenuItem;
        private System.Windows.Forms.Timer sendTextTimer;
        private System.Windows.Forms.ToolStripMenuItem reloadCmdsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

