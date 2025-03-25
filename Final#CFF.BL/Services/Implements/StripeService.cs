using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.DTOs.AparmentDTOs;
using Final_CFF.BL.DTOs.PaymentDTOs;
using Final_CFF.BL.Exceptions.Common;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Final_CFF.Core.Entity;
using Final_CFF.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Stripe;

namespace Final_CFF.BL.Services.Implements;

public class StripeService:IStripeService
{
    private readonly UserManager<User> _userManager;
    readonly StripeSettings _stripeSettings;
    public StripeService(UserManager<User> userManager, IOptions<StripeSettings> stripeSettings)
    {
        _userManager = userManager;
        _stripeSettings = stripeSettings.Value;
        StripeConfiguration.ApiKey = _stripeSettings.SecretKey;
    }

    public async Task<PaymentIntent> PaymentIntent(CreatePaymentDTO createPaymentDTO)
    {
        if (string.IsNullOrEmpty(createPaymentDTO.Email))
            throw new ArgumentException("Email is required");

        //if (string.IsNullOrEmpty(createPaymentDTO.PaymentMethod))
        //    throw new ArgumentException("Payment method is required");

        if (string.IsNullOrEmpty(createPaymentDTO.Currency))
            throw new ArgumentException("Currency is required");

        if (createPaymentDTO.Amount <= 0)
            throw new ArgumentException("Amount must be greater than zero");

        var amountInCents = createPaymentDTO.Amount * 100; // Stripe kuruş formatı

        var options = new PaymentIntentCreateOptions
        {
            Amount = amountInCents,
            Currency = createPaymentDTO.Currency.ToLower(), // USD, EUR gibi küçük harf olmalı
            //PaymentMethod = createPaymentDTO.PaymentMethod,
            ReceiptEmail = createPaymentDTO.Email,
            Description = createPaymentDTO.Description,
            Confirm = true,
            ReturnUrl = "https://yourwebsite.com/payment-success",
            AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
            {
                Enabled = true,
                AllowRedirects = "never"
            },
            PaymentMethod = "pm_card_visa",

        };

        var service = new PaymentIntentService();
        var paymentIntent = await service.CreateAsync(options);

        return paymentIntent;
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
