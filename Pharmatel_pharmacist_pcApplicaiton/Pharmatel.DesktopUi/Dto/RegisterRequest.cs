using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record RegisterRequest
    (
        string Username,
        string Password,
        string Role,
        string Email,
        string PhoneNumber,
        string PharmacyName,
        string PharmacistName,
        double Lat,
        double Lng
    );
}
