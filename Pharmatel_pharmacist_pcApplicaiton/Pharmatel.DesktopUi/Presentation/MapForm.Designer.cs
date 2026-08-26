namespace Pharmatel.DesktopUi.Presentation
{
    partial class MapForm
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            mapViewer = new Microsoft.Web.WebView2.WinForms.WebView2();
            fromMap = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            mapElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            btnOk = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)mapViewer).BeginInit();
            SuspendLayout();
            // 
            // mapViewer
            // 
            mapViewer.AllowExternalDrop = true;
            mapViewer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mapViewer.CreationProperties = null;
            mapViewer.DefaultBackgroundColor = Color.White;
            mapViewer.Location = new Point(0, 0);
            mapViewer.Name = "mapViewer";
            mapViewer.Size = new Size(800, 490);
            mapViewer.TabIndex = 0;
            mapViewer.ZoomFactor = 1D;
            // 
            // fromMap
            // 
            fromMap.BorderRadius = 20;
            fromMap.ContainerControl = this;
            fromMap.DockIndicatorTransparencyValue = 0.6D;
            fromMap.TransparentWhileDrag = true;
            // 
            // mapElipse
            // 
            mapElipse.BorderRadius = 20;
            mapElipse.TargetControl = mapViewer;
            // 
            // btnOk
            // 
            btnOk.Anchor = AnchorStyles.Bottom;
            btnOk.BorderRadius = 8;
            btnOk.CustomizableEdges = customizableEdges1;
            btnOk.DisabledState.BorderColor = Color.DarkGray;
            btnOk.DisabledState.CustomBorderColor = Color.DarkGray;
            btnOk.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnOk.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnOk.FillColor = Color.FromArgb(10, 126, 164);
            btnOk.Font = new Font("Segoe UI", 10F);
            btnOk.ForeColor = Color.White;
            btnOk.HoverState.FillColor = Color.FromArgb(40, 156, 194);
            btnOk.Location = new Point(288, 525);
            btnOk.Name = "btnOk";
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnOk.Size = new Size(225, 56);
            btnOk.TabIndex = 14;
            btnOk.Text = "موافق";
            btnOk.Click += btnOk_Click;
            // 
            // MapForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 607);
            Controls.Add(btnOk);
            Controls.Add(mapViewer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MapForm";
            Text = "MapForm";
            Load += MapForm_Load;
            ((System.ComponentModel.ISupportInitialize)mapViewer).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 mapViewer;
        private Guna.UI2.WinForms.Guna2BorderlessForm fromMap;
        private Guna.UI2.WinForms.Guna2Elipse mapElipse;
        private Guna.UI2.WinForms.Guna2Button btnOk;
    }
}