namespace Pharmatel.DesktopUi.Presentation
{
    partial class UploadForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            FormUpload = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            btnExit = new Guna.UI2.WinForms.Guna2Button();
            exitElipse = new Guna.UI2.WinForms.Guna2Elipse(components);
            label2 = new Label();
            btnUpload = new Guna.UI2.WinForms.Guna2Button();
            txtPath = new Guna.UI2.WinForms.Guna2TextBox();
            btnOk = new Guna.UI2.WinForms.Guna2Button();
            fileSelector = new OpenFileDialog();
            SuspendLayout();
            // 
            // FormUpload
            // 
            FormUpload.BorderRadius = 20;
            FormUpload.ContainerControl = this;
            FormUpload.DockIndicatorTransparencyValue = 0.6D;
            FormUpload.TransparentWhileDrag = true;
            // 
            // btnExit
            // 
            btnExit.CustomizableEdges = customizableEdges7;
            btnExit.DisabledState.BorderColor = Color.DarkGray;
            btnExit.DisabledState.CustomBorderColor = Color.DarkGray;
            btnExit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnExit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnExit.FillColor = Color.FromArgb(10, 126, 164);
            btnExit.Font = new Font("Segoe UI", 15F);
            btnExit.ForeColor = Color.White;
            btnExit.HoverState.FillColor = Color.FromArgb(40, 156, 194);
            btnExit.Location = new Point(12, 12);
            btnExit.Name = "btnExit";
            btnExit.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnExit.Size = new Size(70, 70);
            btnExit.TabIndex = 2;
            btnExit.Text = "X";
            btnExit.Click += btnExit_Click;
            // 
            // exitElipse
            // 
            exitElipse.BorderRadius = 8;
            exitElipse.TargetControl = btnExit;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.Font = new Font("Segoe UI", 20F);
            label2.ForeColor = Color.FromArgb(40, 156, 194);
            label2.Location = new Point(131, 83);
            label2.Name = "label2";
            label2.Size = new Size(626, 115);
            label2.TabIndex = 3;
            label2.Text = "اختر الملف (يجب أن يحتوي معرّف الدواء العام ومعرّفه في الصيدلية واسمه وكمّيته): ";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnUpload
            // 
            btnUpload.BorderRadius = 8;
            btnUpload.CustomizableEdges = customizableEdges5;
            btnUpload.DisabledState.BorderColor = Color.DarkGray;
            btnUpload.DisabledState.CustomBorderColor = Color.DarkGray;
            btnUpload.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnUpload.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnUpload.FillColor = Color.FromArgb(10, 126, 164);
            btnUpload.Font = new Font("Segoe UI", 9F);
            btnUpload.ForeColor = Color.White;
            btnUpload.HoverState.FillColor = Color.FromArgb(40, 156, 194);
            btnUpload.Location = new Point(131, 229);
            btnUpload.Name = "btnUpload";
            btnUpload.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnUpload.Size = new Size(137, 81);
            btnUpload.TabIndex = 13;
            btnUpload.Text = "تحديد ملف";
            btnUpload.Click += btnUpload_Click;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtPath.BorderRadius = 8;
            txtPath.BorderThickness = 2;
            txtPath.CustomizableEdges = customizableEdges3;
            txtPath.DefaultText = "";
            txtPath.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPath.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPath.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPath.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPath.FocusedState.BorderColor = Color.FromArgb(10, 126, 164);
            txtPath.Font = new Font("Segoe UI", 9F);
            txtPath.ForeColor = Color.Black;
            txtPath.HoverState.BorderColor = Color.FromArgb(10, 126, 164);
            txtPath.Location = new Point(302, 229);
            txtPath.Margin = new Padding(3, 4, 3, 4);
            txtPath.Name = "txtPath";
            txtPath.PlaceholderText = "مسار الملف";
            txtPath.RightToLeft = RightToLeft.No;
            txtPath.SelectedText = "";
            txtPath.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPath.Size = new Size(455, 81);
            txtPath.TabIndex = 14;
            txtPath.TextAlign = HorizontalAlignment.Center;
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
            btnOk.Font = new Font("Segoe UI", 9F);
            btnOk.ForeColor = Color.White;
            btnOk.HoverState.FillColor = Color.FromArgb(40, 156, 194);
            btnOk.Location = new Point(131, 347);
            btnOk.Name = "btnOk";
            btnOk.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnOk.Size = new Size(626, 81);
            btnOk.TabIndex = 15;
            btnOk.Text = "رفع الملف";
            btnOk.Click += btnOk_Click;
            // 
            // fileSelector
            // 
            fileSelector.FileOk += fileSelector_FileOk;
            // 
            // UploadForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(889, 505);
            Controls.Add(btnOk);
            Controls.Add(txtPath);
            Controls.Add(btnUpload);
            Controls.Add(label2);
            Controls.Add(btnExit);
            FormBorderStyle = FormBorderStyle.None;
            Name = "UploadForm";
            RightToLeft = RightToLeft.Yes;
            Text = "رفع ملف";
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm FormUpload;
        private Guna.UI2.WinForms.Guna2Button btnExit;
        private Guna.UI2.WinForms.Guna2Elipse exitElipse;
        private Label label2;
        private Guna.UI2.WinForms.Guna2Button btnUpload;
        private Guna.UI2.WinForms.Guna2Button btnOk;
        private Guna.UI2.WinForms.Guna2TextBox txtPath;
        private OpenFileDialog fileSelector;
    }
}