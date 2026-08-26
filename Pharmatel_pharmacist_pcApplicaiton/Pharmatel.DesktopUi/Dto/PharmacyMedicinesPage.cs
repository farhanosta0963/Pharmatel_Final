using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record PharmacyMedicinesPage
    (
        List<PharmacyMedicines> Content,
        int Page,
        int Size,
        int TotalElements,
        int TotalPages,
        bool Last
    );
}
