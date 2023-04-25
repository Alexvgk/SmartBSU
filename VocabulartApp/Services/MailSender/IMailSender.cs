using System;
using System.Collections.Generic;
using System.Text;

namespace SmartBSU.Services.MailSender
{
    public interface IMailSender
    {
        void SendMail(string mailURL, out double code);
    }
}
