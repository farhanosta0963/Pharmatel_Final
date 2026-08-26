using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record Prescription
    (
        string Id,
        int PatientId,
        int MedicineId,
        string MedicineName,
        string Dose,
        string Frequency,
        DateTime StartDate,
        DateTime? EndDate,
        DateTime? IssuedAt,
        bool ByPharmacist,
        int PharmacyId,
        string FoodRequirements,
        string Note,
        bool ByDoctor,
        int TimeShift,
        string DoctorName,
        bool IsDone
    );
}
