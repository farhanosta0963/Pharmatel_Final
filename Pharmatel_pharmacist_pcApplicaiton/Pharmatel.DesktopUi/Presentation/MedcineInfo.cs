using Pharmatel.DesktopUi.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Http.Json;
using System.Text;
using System.Windows.Forms;

namespace Pharmatel.DesktopUi.Presentation
{
    public partial class MedcineInfo : Form
    {
        private int MedicineId { get; set; }
        private int Quantity { get; set; }
        private int PharmacyMedicineId { get; set; }

        Dashboard Parent;

        public MedcineInfo(int medicineId, Dashboard parent)
        {
            InitializeComponent();

            MedicineId = medicineId;
            Parent = parent;

            GetMedicine();
        }

        private async void GetMedicine()
        {
            HttpRequestMessage message = new(HttpMethod.Get, ApiDomain.Domain + $"/medicines/{MedicineId}");

            HttpResponseMessage response = await new HttpClient().SendAsync(message);

            Medicine? medicine = await response.Content.ReadFromJsonAsync<Medicine>();

            lblName.Text = medicine!.Name;
            lblId.Text = medicine.Id.ToString();
            lblPharmaceuticalForm.Text = medicine.PharmaceuticalForm;
            lblBox.Text = medicine.Box;
            lblCapacity.Text = medicine.Capacity;
            lblCapacityMetric.Text = medicine.CapacityMetric;
            lblBuyPrice.Text = medicine.BuyPrice;
            lblSellPrice.Text = medicine.SellPrice;
            lbldDrugComposition.Text = medicine.DrugComposition;
            lblFactory.Text = medicine.Factory;

            GetQuantity();
        }

        private async void GetQuantity()
        {
            HttpRequestMessage messageQuantity = new(HttpMethod.Get, ApiDomain.Domain + $"/pharmacies/{SessionInfo.AuthInfo!.PharmacyId}/medicines");

            HttpResponseMessage responseQuantity = await new HttpClient().SendAsync(messageQuantity);

            PharmacyMedicinesPage? pharmacyMedicines = await responseQuantity.Content.ReadFromJsonAsync<PharmacyMedicinesPage>();

            var pharmacy_medicine = pharmacyMedicines!.Content.FirstOrDefault(pm => pm.MedicineId == MedicineId);

            if (pharmacy_medicine != null)
            {
                txtQuantity.Text = pharmacy_medicine.Quantity.ToString();
                Quantity = pharmacy_medicine.Quantity;
                PharmacyMedicineId = pharmacy_medicine.PharmacyMedicineId;
            }
        }

        private async void btnExit_Click(object sender, EventArgs e)
        {

            if (int.Parse(txtQuantity.Text) != Quantity)
            {
                if (Quantity == 0)
                {
                    HttpRequestMessage message = new(HttpMethod.Post, ApiDomain.Domain + $"/pharmacies/inventory");
                    
                    message.Content = JsonContent.Create(new { MedicineId = MedicineId, Quantity = int.Parse(txtQuantity.Text) });

                    message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                    HttpResponseMessage response = await new HttpClient().SendAsync(message);

                    if (response.StatusCode != System.Net.HttpStatusCode.Created)
                    {
                        MessageBox.Show("لم تتم إضافة الدواء", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else if (int.Parse(txtQuantity.Text) == 0)
                {
                    HttpRequestMessage message = new(HttpMethod.Delete, ApiDomain.Domain + $"/pharmacies/inventory/{PharmacyMedicineId}");

                    message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                    HttpResponseMessage response = await new HttpClient().SendAsync(message);

                    if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    {
                        MessageBox.Show("لم يتم حذف الدواء", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    HttpRequestMessage message = new(HttpMethod.Put, ApiDomain.Domain + $"/pharmacies/inventory/{PharmacyMedicineId}");
                    message.Content = JsonContent.Create(new { Quantity = int.Parse(txtQuantity.Text) });

                    message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", SessionInfo.AuthInfo!.Token);

                    HttpResponseMessage response = await new HttpClient().SendAsync(message);

                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("لم يتم تعديل الدواء", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            Parent.GetMedicines();
            Parent.GetPharmacyMedicines();

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = (int.Parse(txtQuantity.Text) + 1).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = (int.Parse(txtQuantity.Text) - 1).ToString();
        }
    }
}
