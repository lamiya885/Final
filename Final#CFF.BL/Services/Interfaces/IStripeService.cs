using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.PaymentDTOs;

namespace Final_CFF.BL.Services.Interfaces
{
    public interface IStripeService
    {
        Task PaymentIntent(CreatePaymentDTO DTO);

    }
}
