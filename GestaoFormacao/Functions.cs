using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace GestaoFormacao
{
    public class Functions
    {
        public static void SendEmail(string email, string subject, string body)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("duarte.acn@gmail.com");
            mail.To.Add(email);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = Encoding.UTF8;
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Subject = mail.Subject;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new System.Net.NetworkCredential("duarte.acn@gmail.com", "dhojvgdcnxwrbqco");
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}