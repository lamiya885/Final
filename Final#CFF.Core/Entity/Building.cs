using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;

namespace Final_CFF.Core.Entity;

public  class Building:BaseEntity
{
    public string BuildingName { get; set; }
    public ICollection<Apartment> Apartments { get; set; }
}
