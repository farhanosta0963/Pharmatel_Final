using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;
using Pharmatel.DesktopUi.Dto;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class Dashboard : Form
    {
        private DataTable Medicines { get; set; } = new DataTable();
        private int AllMedicinesPage { get; set; } = 0;
        private int AllMedicinesPageSize { get; set; } = 0;
        private bool IsLastPageAllMedicines { get; set; } = false;
        private string AllMedicinesName { get; set; } = string.Empty;


        private DataTable PharmacyMedicines { get; set; } = new DataTable();
        private int PharmacyMedicinesPage { get; set; } = 0;
        private int PharmacyMedicinesPageSize { get; set; } = 0;
        private bool IsLastPagePharmacyMedicines { get; set; } = false;
        private string PharmacyMedicinesName { get; set; } = string.Empty;


        private DataTable Prescriptions { get; set; } = new DataTable();
        private int PrescriptionsPage { get; set; } = 0;
        private int PrescriptionsPageSize { get; set; } = 0;
        private bool IsLastPagePrescriptions { get; set; } = false;
        private string PrescriptionsName { get; set; } = string.Empty;


        private string PharmacistName { get; set; } = string.Empty;

        public void ResetPages()
        {
            AllMedicinesPage = 0;
            PharmacyMedicinesPage = 0;
            PrescriptionsPage = 0;
        }

        public Dashboard()
        {
            InitializeComponent();

            GetMedicines();
            GetPharmacyMedicines();
            GetPrescriptions();


            btnPre.Enabled = false;
            btnPrePharm.Enabled = false;
            btnPrePres.Enabled = false;

            foreach (var row in allMedicinesList.Rows)
            {
                ((DataGridViewRow)row).Height = allMedicinesList.Height / allMedicinesList.Rows.Count;
            }

            foreach (var row in medicineList.Rows)
            {
                ((DataGridViewRow)row).Height = medicineList.Height / medicineList.Rows.Count;
            }

            foreach (var row in prescriptionList.Rows)
            {
                ((DataGridViewRow)row).Height = prescriptionList.Height / prescriptionList.Rows.Count;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                HttpRequestMessage request = new(HttpMethod.Get, ApiDomain.Domain + $"/pharmacies/{SessionInfo.AuthInfo!.PharmacyId}");

                HttpResponseMessage response = await new HttpClient().SendAsync(request);

                Pharmacy? pharmacy = await response.Content.ReadFromJsonAsync<Pharmacy>();

                this.lblPharmacy.Text = pharmacy!.Name;

                this.PharmacistName = pharmacy.PharmacistName;

                SetLatLng(pharmacy.Lat, pharmacy.Lng);

                foreach (var row in allMedicinesList.Rows)
                {
                    ((DataGridViewRow)row).Height = allMedicinesList.Height / allMedicinesList.Rows.Count;
                }

                foreach (var row in medicineList.Rows)
                {
                    ((DataGridViewRow)row).Height = medicineList.Height / medicineList.Rows.Count;
                }

                foreach (var row in prescriptionList.Rows)
                {
                    ((DataGridViewRow)row).Height = prescriptionList.Height / prescriptionList.Rows.Count;
                }

                GetInfo();
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public async void GetMedicines()
        {
            try
            {
                btnPre.Enabled = true;
                btnNext.Enabled = true;

                HttpRequestMessage message = new(HttpMethod.Get, ApiDomain.Domain + $"/medicines?page={AllMedicinesPage}&name={AllMedicinesName}");

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                MedicinesPage? medicines = await response.Content.ReadFromJsonAsync<MedicinesPage>();

                Medicines = new();
                Medicines.Columns.Add("المعرف");
                Medicines.Columns.Add("الاسم");
                Medicines.Columns.Add("سعر الشراء");
                Medicines.Columns.Add("سعر البيع");
                Medicines.Columns.Add("التركيبة الدوائية");
                Medicines.Columns.Add("المصنع");

                medicines!.Content.ForEach(m => Medicines.Rows.Add(m.Id, m.Name, m.BuyPrice, m.SellPrice, m.DrugComposition, m.Factory));

                allMedicinesList.DataSource = Medicines;

                AllMedicinesPageSize = medicines.Size;

                IsLastPageAllMedicines = medicines.Last;

                if (IsLastPageAllMedicines)
                {
                    btnNext.Enabled = false;
                }

                AllMedicinesPage = medicines.Page;

                if (AllMedicinesPage == 0)
                {
                    btnPre.Enabled = false;
                }

                foreach (var row in allMedicinesList.Rows)
                {
                    ((DataGridViewRow)row).Height = allMedicinesList.Height / allMedicinesList.Rows.Count;
                }
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allMedicnesList_SizeChanged(object sender, EventArgs e)
        {
            foreach (var row in allMedicinesList.Rows)
            {
                ((DataGridViewRow)row).Height = allMedicinesList.Height / allMedicinesList.Rows.Count;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (!IsLastPageAllMedicines)
            {
                AllMedicinesPage++;
            }

            GetMedicines();

            btnPre.Enabled = true;

            if (IsLastPageAllMedicines)
            {
                btnNext.Enabled = false;
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {

            if (AllMedicinesPage > 0)
            {
                AllMedicinesPage--;
            }

            GetMedicines();

            btnNext.Enabled = true;

            if (AllMedicinesPage == 0)
            {
                btnPre.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            AllMedicinesName = txtSearch.Text;

            AllMedicinesPage = 0;

            GetMedicines();
        }

        private void btnCancelSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;

            AllMedicinesName = string.Empty;

            GetMedicines();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (allMedicinesList.Rows.Count == 0)
            {
                return;
            }

            new MedcineInfo(Convert.ToInt32(allMedicinesList.SelectedRows[0].Cells["المعرف"].Value), this).Show();
        }

        public async void GetPharmacyMedicines()
        {
            try
            {
                btnPrePharm.Enabled = true;
                btnNextPharm.Enabled = true;


                HttpRequestMessage message = new(HttpMethod.Get, ApiDomain.Domain + $"/pharmacies/{SessionInfo.AuthInfo!.PharmacyId}/medicines?page={PharmacyMedicinesPage}&medicineName={PharmacyMedicinesName}");

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                PharmacyMedicinesPage? medicines = await response.Content.ReadFromJsonAsync<PharmacyMedicinesPage>();

                PharmacyMedicines = new();
                PharmacyMedicines.Columns.Add("المعرف");
                PharmacyMedicines.Columns.Add("المعرف العام");
                PharmacyMedicines.Columns.Add("الاسم");
                PharmacyMedicines.Columns.Add("الكمية");

                medicines!.Content.ForEach(m => PharmacyMedicines.Rows.Add(m.PharmacyMedicineId, m.MedicineId, m.MedicineName, m.Quantity));

                medicineList.DataSource = PharmacyMedicines;

                PharmacyMedicinesPageSize = medicines.Size;

                IsLastPagePharmacyMedicines = medicines.Last;

                if (IsLastPagePharmacyMedicines)
                {
                    btnNextPharm.Enabled = false;
                }

                PharmacyMedicinesPage = medicines.Page;

                if (PharmacyMedicinesPage == 0)
                {
                    btnPrePharm.Enabled = false;
                }

                foreach (var row in medicineList.Rows)
                {
                    ((DataGridViewRow)row).Height = medicineList.Height / medicineList.Rows.Count;
                }
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnShowPharm_Click(object sender, EventArgs e)
        {
            if(medicineList.Rows.Count == 0)
            {
                return;
            }
            new MedcineInfo(Convert.ToInt32(medicineList.SelectedRows[0].Cells["المعرف العام"].Value), this).Show();
        }

        private void btnNextPharm_Click(object sender, EventArgs e)
        {
            if (!IsLastPagePharmacyMedicines)
            {
                PharmacyMedicinesPage++;
            }

            GetPharmacyMedicines();

            btnPrePharm.Enabled = true;

            if (IsLastPagePharmacyMedicines)
            {
                btnNextPharm.Enabled = false;
            }
        }

        private void btnPrePharm_Click(object sender, EventArgs e)
        {
            if (PharmacyMedicinesPage > 0)
            {
                PharmacyMedicinesPage--;
            }

            GetPharmacyMedicines();

            btnNextPharm.Enabled = true;

            if (PharmacyMedicinesPage == 0)
            {
                btnPrePharm.Enabled = false;
            }
        }

        private void medicineList_SizeChanged(object sender, EventArgs e)
        {
            foreach (var row in medicineList.Rows)
            {
                ((DataGridViewRow)row).Height = medicineList.Size.Height / medicineList.RowCount;
            }
        }

        private void btnSearchPharm_Click(object sender, EventArgs e)
        {
            PharmacyMedicinesName = txtSearchPharm.Text;

            PharmacyMedicinesPage = 0;

            GetPharmacyMedicines();
        }

        private void btnCancelSearchPharm_Click(object sender, EventArgs e)
        {
            txtSearchPharm.Text = string.Empty;

            PharmacyMedicinesName = string.Empty;

            PharmacyMedicinesPage = 0;

            GetPharmacyMedicines();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public async void GetPrescriptions()
        {
            try
            {
                btnPrePres.Enabled = true;
                btnNextPres.Enabled = true;

                HttpRequestMessage message = new(HttpMethod.Get, ApiDomain.Domain + $"/prescriptionsForPharmacist?page={PrescriptionsPage}&medicineName={PrescriptionsName}");

                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                PrescriptionPage? prescriptions = await response.Content.ReadFromJsonAsync<PrescriptionPage>();

                Prescriptions = new();
                Prescriptions.Columns.Add("المعرف");
                Prescriptions.Columns.Add("معرف المريض");
                Prescriptions.Columns.Add("اسم الدواء");
                Prescriptions.Columns.Add("الجرعة");
                Prescriptions.Columns.Add("التكرار");
                Prescriptions.Columns.Add("تاريخ البدء");

                prescriptions!.Content.ForEach(p => Prescriptions.Rows.Add(p.Id, p.PatientId, p.MedicineName, p.Dose, p.Frequency, p.StartDate));

                prescriptionList.DataSource = Prescriptions;

                PrescriptionsPageSize = prescriptions.Size;

                IsLastPagePrescriptions = prescriptions.Last;

                if (IsLastPagePrescriptions)
                {
                    btnNextPres.Enabled = false;
                }

                PrescriptionsPage = prescriptions.Page;

                if (PrescriptionsPage == 0)
                {
                    btnPrePres.Enabled = false;
                }

                foreach (var row in prescriptionList.Rows)
                {
                    ((DataGridViewRow)row).Height = prescriptionList.Height / prescriptionList.Rows.Count;
                }
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddPrescription_Click(object sender, EventArgs e)
        {
            new PrescriptionInfo(this).Show();
        }

        private void btnShowPrescription_Click(object sender, EventArgs e)
        {
            if(prescriptionList.Rows.Count == 0)
            {
                return;
            }
            new PrescriptionDetails(prescriptionList.SelectedRows[0].Cells["المعرف"].Value.ToString(), this).Show();
        }

        private void btnNextPres_Click(object sender, EventArgs e)
        {
            if (!IsLastPagePrescriptions)
            {
                PrescriptionsPage++;
            }

            GetPrescriptions();

            btnPrePres.Enabled = true;

            if (IsLastPagePrescriptions)
            {
                btnNextPres.Enabled = false;
            }
        }

        private void btnPrePres_Click(object sender, EventArgs e)
        {
            if (PrescriptionsPage > 0)
            {
                PrescriptionsPage--;
            }

            GetPrescriptions();

            btnNextPres.Enabled = true;

            if (PrescriptionsPage == 0)
            {
                btnPrePres.Enabled = false;
            }
        }

        private void prescriptionList_SizeChanged(object sender, EventArgs e)
        {
            foreach (var row in prescriptionList.Rows)
            {
                ((DataGridViewRow)row).Height = prescriptionList.Height / prescriptionList.Rows.Count;
            }
        }

        private void btnSearchPres_Click(object sender, EventArgs e)
        {
            PrescriptionsName = txtSearchPres.Text;

            PrescriptionsPage = 0;

            GetPrescriptions();
        }

        private void btnCancelSearchPres_Click(object sender, EventArgs e)
        {
            txtSearchPres.Text = string.Empty;

            PrescriptionsName = txtSearchPres.Text;

            PrescriptionsPage = 0;

            GetPrescriptions();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            new UploadForm(this).Show();
        }

        double lat, lng;

        public void SetLatLng(double lat, double lng)
        {
            this.lat = lat;
            this.lng = lng;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNewPass.Text != string.Empty && txtNewPass.Text != txtConfirmPass.Text)
                {
                    MessageBox.Show("الرجاء إدخال كلمة المرور وتأكيدها بشكل صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string Password = txtNewPass.Text;
                string Name = txtPharmacy.Text;
                string PharmacistName = txtPharmacist.Text;
                double Lat = this.lat, Lng = this.lng;

                HttpRequestMessage message = new(HttpMethod.Put, ApiDomain.Domain + $"/pharmacies/{SessionInfo.AuthInfo.PharmacyId}");

                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                if (txtNewPass.Text == string.Empty)
                {
                    message.Content = JsonContent.Create(new { Name, PharmacistName, Lat, Lng });
                }
                else
                {
                    message.Content = JsonContent.Create(new { Password, Name, PharmacistName, Lat, Lng });
                }

                HttpResponseMessage response = await new HttpClient().SendAsync(message);

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("لم يتم حفظ التعديلات بشكل صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("تم حفظ التعديلات بشكل صحيح", "تم الحفظ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("خطأ بالاتصال", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GetInfo()
        {
            txtUsername.Text = SessionInfo.AuthInfo.Username;

            txtPharmacy.Text = this.lblPharmacy.Text;

            txtPharmacist.Text = this.PharmacistName;
        }

        private void btnGeoChange_Click(object sender, EventArgs e)
        {
            new MapForm(null, this).Show();
        }
    }
}
