using Demo.Perestation.Setting;
using Demo.Perestation.Untilities;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;


namespace Demo.Perestation.Helpers
{
    public class MailService : IMailService
    {
        private readonly IOptions<MailSetting> _options;

        public MailService(IOptions<MailSetting> options)
        {
            _options = options;
        }

        public void Send(Email email)
        {
            var mail = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_options.Value.Email),
                Subject = email.Subject
            };
            mail.To.Add(MailboxAddress.Parse(email.To));
            mail.From.Add(new MailboxAddress(_options.Value.Email, _options.Value.DispalyName));

            var Builder = new BodyBuilder();

            Builder.TextBody = email.Body;

            mail.Body = Builder.ToMessageBody();

            using var smtp = new SmtpClient();

            smtp.Connect(_options.Value.Host,
                _options.Value.Port,
                MailKit.Security.SecureSocketOptions.StartTls);

            smtp.Authenticate(_options.Value.Email, _options.Value.Password);
            smtp.Send(mail);

            smtp.Disconnect(true);







        }
    }
}
