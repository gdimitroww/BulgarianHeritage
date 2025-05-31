using Microsoft.AspNetCore.Identity.UI.Services;

namespace BulgarianHeritage.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // For development purposes, just log the email instead of sending it
            Console.WriteLine($"Email to {email}: {subject}");
            Console.WriteLine($"Message: {htmlMessage}");
            return Task.CompletedTask;
        }
    }
} 