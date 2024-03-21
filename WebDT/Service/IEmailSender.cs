using WebDT.Models;

namespace WebDT.Service
{
    public interface IEmailSender
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
