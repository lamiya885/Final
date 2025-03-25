using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;
using Final_CFF.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Final_CFF.Core.Entity;

public class User : IdentityUser
{
    
    public string FullName { get; set; }
    public string ImageUrl { get; set; }
    public Guid ApertmentId { get; set; }
    public int ApartmentNo { get; set; }
    public Apartment Apartment { get; set; }
   // public Guid BuildingId { get; set; }
   // public Building Building { get; set; }
}
