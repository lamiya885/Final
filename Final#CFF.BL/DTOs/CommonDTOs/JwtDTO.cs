using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.CommonDTOs
{
    public class JwtDTO
    {
        public string UserName {  get; set; }
        public string Email { get; set; }
        public string  Role { get; set; }
        public string FullName { get; set; }
    }
}
