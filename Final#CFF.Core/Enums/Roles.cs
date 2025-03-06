using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.Core.Enums;

public enum Roles
{
    Resident=2,
    Admin=4,

    Moderator=Resident|Admin
}
