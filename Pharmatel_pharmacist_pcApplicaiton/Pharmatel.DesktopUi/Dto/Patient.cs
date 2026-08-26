using System;
using System.Collections.Generic;
using System.Text;

namespace Pharmatel.DesktopUi.Dto
{
    internal record Patient
    (
        int Id, 
        string Name,
        string Email,
        string PhoneNumber
    );
}
