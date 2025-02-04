using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;

namespace Final_CFF.Core.Entity;

public  class Apartment:BaseEntity
{
    public int HouseNo { get; set; }


    public Guid BuildingId { get; set; }
    public string BuildingName { get; set; }
    public Building Building { get; set; }

    public ICollection<User> Users { get; set; }

}
