﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.Helpers
{
    public class EmailOptions
    {
        public const string Name = "SmtpSettings";
        public string Host { get; set; }
        public int Port { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
    }
}
