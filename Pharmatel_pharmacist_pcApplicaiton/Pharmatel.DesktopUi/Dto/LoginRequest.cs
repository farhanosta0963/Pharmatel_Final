using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record LoginRequest
    (
        string Username,
        string Password,
        string Role = "PHARMACY"
    );
}
