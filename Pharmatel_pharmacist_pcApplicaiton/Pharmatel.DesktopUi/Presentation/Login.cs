using Pharmatel.DesktopUi.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.Json;
using System.Net.Http.Json;
using System.Net;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsername.Text.Length == 0 || txtPassword.Text.Length == 0)
                {
                    MessageBox.Show("الرجاء التحقق من اسم المستخدم وكلمة المرور", "فشل تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoginRequest request = new(txtUsername.Text, txtPassword.Text);

                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, ApiDomain.Domain + "/auth/login");

                message.Content = JsonContent.Create(request);

                HttpClient client = new HttpClient();

                HttpResponseMessage response = await client.SendAsync(message);

                AuthResponse? authResponse = await response.Content.ReadFromJsonAsync<AuthResponse>();

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    MessageBox.Show("الرجاء التحقق من اسم المستخدم وكلمة المرور", "فشل تسجيل الدخول", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (authResponse != null)
                {
                    SessionInfo.AuthInfo = authResponse;
                    new Dashboard().Show();
                    this.Hide();
                }
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
