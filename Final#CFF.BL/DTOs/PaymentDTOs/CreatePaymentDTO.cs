using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.DTOs.PaymentDTOs;

public class CreatePaymentDTO
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public string Currency {  get; set; }
    public string PaymentMethod { get; set; }
    public bool Confirm { get; set; }
}
