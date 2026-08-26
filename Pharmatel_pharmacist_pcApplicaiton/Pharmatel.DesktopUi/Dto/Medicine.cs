using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record Medicine
    (
        int Id,
        string Name,
        string BuyPrice,
        string SellPrice,
        string PharmaceuticalForm,
        string Box,
        string Capacity,
        string CapacityMetric,
        string Factory,
        bool ByPharmacist,
        string accountId,
        string DrugComposition
    );
}
