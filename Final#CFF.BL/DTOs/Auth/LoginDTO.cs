using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.Auth
{
    public class LoginDTO
    {
        public string UserNameOrUserEmail { get; set; }
        public string Password { get; set; }
    }
}
