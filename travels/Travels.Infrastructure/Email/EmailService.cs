using Travels.Application.Abstractions.Email;
using Travels.Domain.Users;

namespace Travels.Infrastructure
{

    internal sealed class EmailService : IEmailService
    {
        public Task SendAsync(Email recipient, string subject, string body)
        {
            return Task.CompletedTask;
        }
    }
}