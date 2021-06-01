using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace OlxCrawl
{
    public static class SendMailNotification
    {

        public static void SendMail(string reciever, string outputFromOlx)
        {


            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("olx.crawl@gmail.com", "0lxCr@wl$$&"),
                EnableSsl = true,

            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("olx.crawl@gmail.com"),
                Subject = "Notification from OLX",
                Body = $"<p1>{outputFromOlx}</p1>",
                IsBodyHtml = true,
            };

            mailMessage.To.Add(reciever);

            smtpClient.Send(mailMessage);
        }

    }
}
