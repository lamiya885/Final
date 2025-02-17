using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Final_CFF.BL.DTOs.Auth;

public class RegisterDTO
{
    public string FullName {  get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [DataType(DataType.Password), Compare("Password", ErrorMessage = "Passwords do not match.")]
    public string Repassword { get; set; }
    public IFormFile Image { get; set; }    

}
