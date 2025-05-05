using System.Net.Mail;
using System.Net;

namespace Demo.Perestation.Untilities
{
    public static class EmailSending
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("aslamterk784@gmail.com", "ljdhqddyuvdmbzsr");

            Client.Send("aslamterk784@gmail.com", email.To, email.Subject, email.Body);

        }
    }
}
