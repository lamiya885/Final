using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.CommonDTOs;
using Final_CFF.BL.Helpers;

namespace Final_CFF.BL.ExternalServices.Abstracts
{
    public interface ITokenHandler
    {
        string CreateToken(JwtDTO DTO);
    }
}
