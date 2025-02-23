using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.AparmentDTOs;
using Final_CFF.BL.DTOs.PaymentDTOs;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Helpers;
using Final_CFF.Core.Entity;
using Final_CFF.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;

namespace Final_CFF.BL.Services.Implements;

public class StripeService(UserManager<User> _userManager, StripeSettings _stripeSettings)
{
    public PaymentService(IOptions<StripeSettings> stripeSettings)
    {
        StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
    }
    public async Task PaymentIntent(CreatePaymentDTO DTO)
    {
        var options = new CustomerCreateOptions
        {
            Email = DTO.Email,
            Name = DTO.Name,
            Description = DTO.Description,
        };
        var service = new CustomerService();
        Customer customer = service.Create(options);

        if (await _userManager.Users.AnyAsync(x => x.Email == DTO.Email))
        {
           throw new ExistException<User>();
        }
        if (await _userManager.Users.AnyAsync(x => x.UserName == DTO.Name))
        {
            throw new ExistException<User>();
        }
        var paymentIntentService = new PaymentIntentService();
        var paymentIntent = paymentIntentService.Create(new PaymentIntentCreateOptions
        {
            Amount = DTO.Amount,
            Currency =DTO.Currency.ToString(),
            PaymentMethod = DTO.PaymentMethod,
            Confirm = DTO.Confirm,
        });


    }



    public async Task<Charge> CreateCharge(string token, decimal amount)
    {
        var options = new ChargeCreateOptions
        { 
            Amount = (long)(amount * 100), 
            Currency = "usd",
            Description = "Ödəniş Təsviri",
            Source = token,
        };

        var service = new ChargeService();
        Charge charge = await service.CreateAsync(options);
        return charge;
    }
}
