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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class PrescriptionDetails : Form
    {
        private string Id { get; set; }

        private Dashboard Parent { get; set; }

        public PrescriptionDetails(string id, Dashboard parent)
        {
            InitializeComponent();

            Id = id;
            Parent = parent;

            GetPrescription();


        }

        private async void GetPrescription()
        {
            try
            {
                HttpRequestMessage message = new(HttpMethod.Get, ApiDomain.Domain + $"/prescriptions/{Id}");

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("لم يتم جلب معلومات الوصفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Prescription? prescription = await response.Content.ReadFromJsonAsync<Prescription>();

                HttpRequestMessage messagePatient = new(HttpMethod.Get, ApiDomain.Domain + $"/patients/{prescription.PatientId}");

                messagePatient.Headers.Authorization = new AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                HttpResponseMessage responsePatient = await new HttpClient().SendAsync(messagePatient);

                Patient patient = await responsePatient.Content.ReadFromJsonAsync<Patient>();

                txtPatientId.Text = patient.Name.ToString();
                txtMedicineId.Text = prescription.MedicineId.ToString();
                txtDose.Text = prescription.Dose;
                txtFrequency.Text = prescription.Dose;
                txtStartDate.Value = prescription.StartDate;
                txtFoodRequirement.Text = prescription.FoodRequirements;
                txtNote.Text = prescription.Note;
                txtDoctor.Text = prescription.DoctorName;
                btnIsDone.Checked = prescription.IsDone;
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnSavePrescription_Click(object sender, EventArgs e)
        {
            try
            {
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
                bool isDone = btnIsDone.Checked;

                HttpRequestMessage message = new(HttpMethod.Put, ApiDomain.Domain + $"/prescriptions/{Id}");

                message.Headers.Authorization = new AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                message.Content = JsonContent.Create(new { pharmacyId, dose, frequency, startDate, byPharmacist, foodRequirement, note, byDoctor, doctorName, timeShift, isDone });

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("لم يتم تعديل الوصفة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                Parent.ResetPages();
                Parent.GetPrescriptions();

                this.Close();
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrescriptionDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
