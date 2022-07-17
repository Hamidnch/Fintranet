using MediatR;
using Microsoft.Extensions.Logging;

namespace _3_Fintranet.Application.Features.Doctors.Notifications
{
    public class CreateDoctorEvent : INotification
    {
        public Guid Id { get; set; }
        public CreateDoctorEvent(Guid id)
        {
            Id = id;
        }

        public class CreateDoctorEmailSenderHandler : INotificationHandler<CreateDoctorEvent>
        {
            public Task Handle(CreateDoctorEvent notification, CancellationToken cancellationToken)
            {
                // IMessageSender.Send($"Welcome {notification.FirstName} {notification.LastName} !");
                return Task.CompletedTask;
            }
        }

        public class CreateDoctorLoggerHandler : INotificationHandler<CreateDoctorEvent>
        {
            private readonly ILogger<CreateDoctorLoggerHandler> _logger;

            public CreateDoctorLoggerHandler(ILogger<CreateDoctorLoggerHandler> logger)
            {
                _logger = logger;
            }

            public Task Handle(CreateDoctorEvent notification, CancellationToken cancellationToken)
            {
                _logger.LogInformation($"New doctor has been created with Id: {notification.Id}");

                return Task.CompletedTask;
            }
        }
    }
}
