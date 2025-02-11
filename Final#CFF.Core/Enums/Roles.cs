using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.Core.Enums;

public enum Roles
{
    Resident=1,
    BuildingManager=2,
    
    Admin= Resident | BuildingManager
}
