using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.AparmentDTOs;

public class CreateApartmentDTO
{
    public int No { get; set; }
    public string BuildingName { get; set; }
    public Guid BuildingId { get; set; }
}
