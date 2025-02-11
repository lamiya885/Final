using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.Auth;

public class RegisterDTO
{
    public string FullName {  get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Repassword { get; set; }

}
