﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_CFF.BL.Services.Interfaces
{
    public  interface IEmailService
    {
        void SendEmailConfirmationAsync(string reciver,string name,string token);

    }
}
