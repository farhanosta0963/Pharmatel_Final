using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record MedicinesPage
    (
        List<Medicine> Content,
        int Page,
        int Size,
        int TotalElements,
        int TotalPages,
        bool Last
    );
}
