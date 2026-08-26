using Pharmatel.DesktopUi.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class PrescriptionInfo : Form
    {
        private Dashboard Parent;
        public PrescriptionInfo(Dashboard parent)
        {
            InitializeComponent();

            this.Parent = parent;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrescriptionInfo_Load(object sender, EventArgs e)
        {

        }

        private void PrescriptionInfo_Load_1(object sender, EventArgs e)
        {

        }

        private async void btnAddPrescription_Click(object sender, EventArgs e)
        {
            try
            {
                HttpRequestMessage messagePatient = new(HttpMethod.Get, ApiDomain.Domain + $"/patients/by-username/{txtPatientId.Text}");

                messagePatient.Headers.Authorization = new AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                HttpResponseMessage responsePatient = await new HttpClient().SendAsync(messagePatient);

                Patient patient = await responsePatient.Content.ReadFromJsonAsync<Patient>();

                int patientId = patient.Id;
                int medicineId = int.Parse(txtMedicineId.Text);
                int pharmacyId = SessionInfo.AuthInfo!.PharmacyId;
                string dose = txtDose.Text;
                string frequency = txtFrequency.Text;
                DateTime startDate = txtStartDate.Value;
                bool byPharmacist = true;
                string foodRequirement = txtFoodRequirement.Text;
                string note = txtNote.Text;
                string doctorName = txtDoctor.Text;
                bool byDoctor = doctorName != string.Empty;
                int timeShift = 0;

                HttpRequestMessage message = new(HttpMethod.Post, ApiDomain.Domain + "/prescriptions");

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                message.Content = JsonContent.Create(new { patientId, medicineId, pharmacyId, dose, frequency, startDate, byPharmacist, foodRequirement, note, byDoctor, doctorName, timeShift });

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.Created)
                {
                    MessageBox.Show("لم تتم إضافة الوصفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Parent.GetPrescriptions();

                this.Close();
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void PrescriptionInfo_Load_2(object sender, EventArgs e)
        {

        }

        private void txtStartDate_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
