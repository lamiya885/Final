using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Final_CFF.BL.DTOs.SliderDTOs;

public class UpdateSliderDTO
{
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public IFormFile Image { get; set; }
}
