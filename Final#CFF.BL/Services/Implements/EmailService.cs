using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;

namespace Final_CFF.BL.Services.Implements
{
    public class EmailService : IEmailService
    {
        readonly SmtpOptions _smtpOptions;
        public EmailService(IOptions<SmtpOptions> option)
        {
            _smtpOptions = option.Value;
        }
        public Task SendAsync()
        {
            throw new NotImplementedException();
        }
    }
}
