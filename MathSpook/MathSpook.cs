using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathSpook
{
    public enum ConversionMode { 
        HTML,
        LaTeX,
        JSON
    }

    public partial class MathSpook : Form
    {
        public ConversionMode mode;

        public bool sendQueued;
        public int sendTicksWaited;

        public MathSpook() {
            InitializeComponent();

            sendQueued = false;
            sendTicksWaited = 0;

            mode = ConversionMode.LaTeX;

            webView.EnsureCoreWebView2Async();
        }

        private void initWebview() {
            Console.WriteLine("Initializing webview from thread " + Thread.CurrentThread.ManagedThreadId);
            string html = System.IO.File.ReadAllText("..\\..\\..\\index.html");
            webView.NavigateToString(html);
            webView.CoreWebView2.Settings.IsWebMessageEnabled = true;
        }
       
        private void hTMLLaTeXToolStripMenuItem_Click(object sender, EventArgs e) {
            mode = ConversionMode.HTML;
            convert();
        }

        private void onlyLaTeXtexToolStripMenuItem_Click(object sender, EventArgs e) {
            mode = ConversionMode.LaTeX;
            convert();
        }

        private void webView_CoreWebView2Ready(object sender, EventArgs e) {
            Console.WriteLine("Webview ready!");
            //webView.CoreWebView2.Navigate("http://reddit.com");

            // This fun little machination is necessary because we must set the webview's contents
            // from the UI thread, and this function gets called from somewhere else (the webview?)
            timer1.Enabled = true;
            timer1.Start();
        }

        private void webView_Click(object sender, EventArgs e) {
            
        }

        private void input_TextChanged(object sender, EventArgs e) {
            convert();
        }

        private void reinitializeWebviewToolStripMenuItem_Click(object sender, EventArgs e) {
            initWebview();
        }

        private void timer1_Tick(object sender, EventArgs e) {
            initWebview();
            timer1.Enabled = false;
        }

        private void jSONToolStripMenuItem_Click(object sender, EventArgs e) {
            mode = ConversionMode.JSON;
            convert();
        }

        public void convert() {
            sendQueued = true;
            sendTicksWaited = 0;
        }

        private void sendTextTimer_Tick(object sender, EventArgs e) {
            if (sendQueued) {
                sendTicksWaited += 1;

                if (sendTicksWaited >= 3) {
                    Convert c = new Convert(input.Text);

                    string json = c.toJSON();

                    switch (mode) {
                        case ConversionMode.JSON:
                            output.Text = json;
                            break;

                        case ConversionMode.HTML:
                            output.Text = c.toHTML();
                            break;

                        case ConversionMode.LaTeX:
                            output.Text = c.toLatex();
                            break;

                        default:
                            output.Text = "???";
                            break;
                    }

                    webView.CoreWebView2.PostWebMessageAsJson(json);
                    
                    sendQueued = false;
                    sendTicksWaited = 0;
                }
            }
        }

        private void splitTB_Panel2_Paint(object sender, PaintEventArgs e) {

        }

        private void reloadCmdsToolStripMenuItem_Click(object sender, EventArgs e) {
            Program.loadCommands();
            convert();
        }
    }
}
