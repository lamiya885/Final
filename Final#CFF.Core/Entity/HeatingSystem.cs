using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;

namespace Final_CFF.Core.Entity
{
    public class HeatingSystem : BaseEntity
    {
        public double RadiatorTemperature { get; set; }
        public double HotWaterSupply { get; set; }
        public bool IsOn { get; set; }

    }
}
