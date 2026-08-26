using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record Pharmacy
    (
        int Id,
        string Name,
        double Lat,
        double Lng,
        string PharmacistName
    );
}
