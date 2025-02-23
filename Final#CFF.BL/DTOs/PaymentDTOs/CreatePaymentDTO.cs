using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Enums;

namespace Final_CFF.BL.DTOs.PaymentDTOs;

public class CreatePaymentDTO
{
    public string Email { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Amount { get; set; }
    public Currencies Currency {  get; set; }
    public string PaymentMethod { get; set; }
    public bool Confirm { get; set; }
}
