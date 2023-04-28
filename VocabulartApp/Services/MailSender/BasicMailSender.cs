using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace SmartBSU.Services.MailSender
{
    public class BasicMailSender : IMailSender
    {
        private const string HOME_MAIL = "alexi9prokopchyk@mail.ru";
        private const string HOME_PASSWORD = "ggMdSLaLPSwq5Rm9TrZp";

        public void SendMail(string mailURL, out double code)
        {
            try {
                MailMessage mess = new MailMessage();
                mess.To.Add(mailURL); // адрес получателя
                mess.From = new MailAddress(HOME_MAIL);
                mess.Subject = "Registration on App"; // тема
                Random rnd = new Random();
                code = rnd.Next(1000,9999);
                code = 1111;
                mess.Body = "Your code for authorization\n" + code.ToString(); // текст сообщения
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.mail.ru"; //smtp-сервер отправителя
                client.Port = 25;
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(HOME_MAIL.Split('@')[0], HOME_PASSWORD);
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Send(mess); // отправка пользователю
                mess.To.Remove(mess.To[0]);              
                mess.Dispose();
            }
            catch (SmtpException)
            {
                throw new SmtpException("No Internen Connection");
            }

        }
    }
}
