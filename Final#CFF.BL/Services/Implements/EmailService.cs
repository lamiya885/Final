using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Final_CFF.BL.Helpers;
using Final_CFF.BL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic;

namespace Final_CFF.BL.Services.Implements
{
    public class EmailService : IEmailService
    {
        readonly SmtpClient _client;
        readonly MailAddress _from;
        readonly HttpContext Context;
        public EmailService(IOptions<SmtpOptions> option, IHttpContextAccessor acc)
        {
            var opt = option.Value;
            _client = new(opt.Host, opt.Port);
            _client.Host = opt.Host;
            _client.Port = opt.Port;
            _client.Credentials = new NetworkCredential(opt.Sender, opt.Password);
            _client.EnableSsl = true;
            _from = new MailAddress(opt.Sender, "Commandant");
            Context = acc.HttpContext;
        }

        public void SendEmailConfirmationAsync(string reciver, string name, string token)
        {
            MailAddress to = new(reciver);
            MailMessage message = new MailMessage(_from, to);
            message.Subject = "Confirm  your email adress";
            string url = Context.Request.Scheme + "://" + Context.Request.Host + "/Account/VerifyEmail?token" + token;
            message.Body = EmailTemplates.VerifyEmail.Replace("__$name", name).Replace("__$link", url);
            message.IsBodyHtml = true;
            _client.Send(message);
        }
    }
}
