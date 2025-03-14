using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.Core.Enums;

namespace Final_CFF.BL.DTOs.PaymentDTOs;

public class CreatePaymentDTO
{
    public string Email { get; set; } // Kullanıcı e-postası
    public string Name { get; set; } // Kart sahibi adı
    public string Description { get; set; } // Ödeme açıklaması
    public int Amount { get; set; } // Stripe kuruş formatında (ör. 10 USD → 1000)
    public string Currency { get; set; } // "usd", "eur" vb. (küçük harf olmalı)
    public string PaymentMethod { get; set; } // Stripe Payment Method ID
    public bool Confirm { get; set; } // Ödemeyi direkt onaylayıp onaylamayacağı
}

