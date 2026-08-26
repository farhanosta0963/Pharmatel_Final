using Microsoft.VisualBasic.Logging;
using Microsoft.Web.WebView2.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class MapForm : Form
    {
        Register Parent;
        Dashboard ParentDashboard;
        public MapForm(Register parent, Dashboard parentDashboard)
        {
            InitializeComponent();

            this.Parent = parent;
            ParentDashboard = parentDashboard;
        }

        private async void MapForm_Load(object sender, EventArgs e)
        {
            await mapViewer.EnsureCoreWebView2Async();

            // Listen for messages from JavaScript
            mapViewer.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

            // Load local HTML file
            string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "map.html");
            if (!File.Exists(htmlPath))
            {
                MessageBox.Show("map.html not found in output directory.");
                return;
            }

            mapViewer.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                await mapViewer.EnsureCoreWebView2Async();

                mapViewer.CoreWebView2.WebMessageReceived += CoreWebView2_WebMessageReceived;

                string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "map.html");

                if (!File.Exists(htmlPath))
                {
                    MessageBox.Show("map.html not found in output directory.");
                    return;
                }

                mapViewer.CoreWebView2.Navigate(new Uri(htmlPath).AbsoluteUri);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error initializing WebView2: " + ex.Message);
            }
        }

        private void CoreWebView2_WebMessageReceived(object sender, CoreWebView2WebMessageReceivedEventArgs e)
        {
            try
            {
                var coords = System.Text.Json.JsonDocument.Parse(e.WebMessageAsJson);
                string lat = coords.RootElement.GetProperty("lat").GetString();
                string lng = coords.RootElement.GetProperty("lng").GetString();

                if(Parent != null)
                {
                    Parent.SetLatLng(double.Parse(lat), double.Parse(lng));
                }

                if (ParentDashboard != null)
                {
                    ParentDashboard.SetLatLng(double.Parse(lat), double.Parse(lng));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error reading coordinates: " + ex.Message);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
