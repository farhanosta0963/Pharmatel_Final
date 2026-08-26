using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record PharmacyMedicines
    (
        int PharmacyMedicineId,
        int MedicineId,
        string MedicineName,
        int Quantity
        //double Price,
        //bool Available
    );
}
