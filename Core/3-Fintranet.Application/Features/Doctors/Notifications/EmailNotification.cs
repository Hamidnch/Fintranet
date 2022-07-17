using MediatR;
using Microsoft.Extensions.Logging;

namespace _3_Fintranet.Application.Features.Doctors.Notifications
{
    public class EmailNotification : INotification
    {
        public string EmailAddress { get; }
        public string EmailContent { get; }

        public EmailNotification(string emailAddress, string emailContent)
        {
            EmailAddress = emailAddress;
            EmailContent = emailContent;
        }

        public class EmailNotificationHandler : INotificationHandler<EmailNotification>
        {
            private readonly ILogger<EmailNotificationHandler> _logger;

            public EmailNotificationHandler(ILogger<EmailNotificationHandler> logger)
            {
                _logger = logger;
            }

            public Task Handle(EmailNotification notification, CancellationToken cancellationToken)
            {
                _logger.LogWarning("Sending Email to {EmailAddress} with content {EmailContent}",
                    notification.EmailAddress, notification.EmailContent);
                return Task.CompletedTask;
            }
        }
    }
}