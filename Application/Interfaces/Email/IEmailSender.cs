using Application.DTOs.Email;

namespace Application.Interfaces.Email
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailRequest<string> request);
        Task SendEmailWithAttachmentAsync(EmailRequest<string> request, Stream fileStream, string fileName);
    }
}
