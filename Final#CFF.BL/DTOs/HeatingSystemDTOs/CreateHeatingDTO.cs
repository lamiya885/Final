using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.HeatingSystemDTOs
{
    public class CreateHeatingDTO
    {
        public double RadiatorTemperature { get; set; }
        public double HotWaterSupply { get; set; }
        public bool IsOn { get; set; }
    }
}
