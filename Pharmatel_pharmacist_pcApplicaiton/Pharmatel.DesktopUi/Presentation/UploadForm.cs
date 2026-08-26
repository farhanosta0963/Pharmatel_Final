using CsvHelper;
using Pharmatel.DesktopUi.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class UploadForm : Form
    {
        Dashboard Parent;
        public UploadForm(Dashboard parent)
        {
            InitializeComponent();
            
            Parent = parent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            fileSelector.Filter = "Comma Separated Files (*.csv)|*.csv";

            fileSelector.ShowDialog();
        }

        private void fileSelector_FileOk(object sender, CancelEventArgs e)
        {
            txtPath.Text = fileSelector.FileName;
        }

        private async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                int failed = 0;

                using var reader = new StreamReader(fileSelector.FileName);
                using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

                var records = csv.GetRecords<PharmacyMedicines>();
                foreach (var medicine in records)
                {
                    HttpRequestMessage message = new(HttpMethod.Post, ApiDomain.Domain + $"/pharmacies/inventory");

                    message.Content = JsonContent.Create(new { MedicineId = medicine.MedicineId, Quantity = medicine.Quantity });

                    message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                    HttpResponseMessage response = await new HttpClient().SendAsync(message);

                    if (response.StatusCode != System.Net.HttpStatusCode.Created && response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        failed++;
                    }
                }

                if (failed > 0)
                {
                    MessageBox.Show($"فشل رفع معلومات {failed} دواء", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Parent.GetPharmacyMedicines();

                this.Close();
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
