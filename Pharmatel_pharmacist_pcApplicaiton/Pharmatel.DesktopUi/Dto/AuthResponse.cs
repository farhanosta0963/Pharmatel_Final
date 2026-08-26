using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record AuthResponse
    (
        string Token,
        string AccountId,
        string Username,
        string Role,
        int PharmacyId
    );
}
