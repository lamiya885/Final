using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Entity.Common;

namespace Final_CFF.Core.Entity;

public class Slider:BaseEntity
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public string ImageUrl {  get; set; }
}
