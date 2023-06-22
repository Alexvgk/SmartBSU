using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Text;
using Android.Content.Res;
using System.Configuration;
using Java.Lang;
using Android.OS;

namespace SmartBSU.Services.MailSender
{
    public class BasicMailSender : IMailSender
    {

        public void SendMail(string mailURL, out double code)
        {
            try
            {
                using (MailMessage mess = new MailMessage())
                {
                    mess.To.Add(mailURL); // адрес получателя
                    mess.From = new MailAddress("alexi9prokopchyk@mail.ru");
                    mess.Subject = "Registration on App"; // тема
                    Random rnd = new Random();
                    code = rnd.Next(1000, 9999);
                    //code = 1111;
                    mess.Body = "Your code for authorization\n" + code.ToString(); // текст сообщения

                    using (SmtpClient client = new SmtpClient())
                    {
                      //  client.Host = "smtp.mail.ru"; //smtp-сервер отправителя
                       // client.Port = 25;
                       // client.EnableSsl = true;
                       // client.Credentials = new NetworkCredential(mailURL.Split()[0], "ggMdSLaLPSwq5Rm9TrZp");
                       // client.DeliveryMethod = SmtpDeliveryMethod.Network;

                    //    client.SendMailAsync(mess); // асинхронная отправка письма
                    }

//                    mess.To.Remove(mess.To[0]);
                }
            }
            catch (SmtpException)
            {
                throw new SmtpException("No Internet Connection");
            }

        }
    }
}
