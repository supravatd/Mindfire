using System;
using System.Net.Mail;
using System.Net;

namespace MailSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("6638801af2fb3f", "5698daf9b86096"),
                EnableSsl = true
            };
            MailMessage message = new MailMessage("dwarisupravat@gmail.com", "supravatdwari@gmail.com")
            {
                Subject = "Test Mail",
                IsBodyHtml = true,
                Body = "<h1>Hello!!! from Supravat</h1>"
            };
            try
            {
                client.Send(message);
                Console.WriteLine("Sent");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: "+ex.Message);
            }
            Console.ReadLine();
        }
    }
}
