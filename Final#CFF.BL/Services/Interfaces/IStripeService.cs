using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.PaymentDTOs;
using Stripe;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface IStripeService
    {
        Task<PaymentIntent > PaymentIntent(CreatePaymentDTO DTO);
        Task<Charge> CreateCharge(string token, decimal amount);
    }
}
