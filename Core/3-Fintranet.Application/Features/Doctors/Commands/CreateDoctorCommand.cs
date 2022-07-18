using _1_Fintranet.Common.Helpers;
using _1_Fintranet.Common.Validators;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Managers;
using _3_Fintranet.Application.Features.Doctors.Notifications;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Commands
{
    public record CreateDoctorCommand(DoctorDto DoctorDto) : IRequest<DoctorDto>
    {
        public class CreateDoctorCommandValidator : AbstractValidator<CreateDoctorCommand>
        {
            public CreateDoctorCommandValidator()
            {
                RuleFor(c => c.DoctorDto.FirstName)
                    .NotEmpty().WithMessage("Please ensure you have entered the first name")
                    .Length(2, 150).WithMessage("The first name must have between 2 and 150 characters");

                RuleFor(c => c.DoctorDto.LastName)
                    .NotEmpty().WithMessage("Please ensure you have entered the last name")
                    .Length(2, 150).WithMessage("The last name must have between 2 and 150 characters");

                RuleFor(c => c.DoctorDto.DateOfBirth)
                    .NotEmpty()
                    .Must(ValidationHelper.HaveMinimumAge)
                    .WithMessage("The doctor must have 18 years or more");

                RuleFor(c => c.DoctorDto.Email)
                    .NotEmpty()
                    //.EmailAddress()
                    .Must(EmailValidator.Validate)
                    .WithMessage("The doctor email must be valid email address.");

                RuleFor(c => c.DoctorDto.PhoneNumber)
                    .NotEmpty()
                    .Must(MobileValidator.Validate)
                    .WithMessage("The doctor mobile number is invalid.");
            }
        }
        public class CreateDoctorCommandCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto>
        {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDoctorManager _doctorManager;
            public CreateDoctorCommandCommandHandler(IMapper mapper, IMediator mediator, IDoctorManager doctorManager)
            {
                _mapper = mapper;
                _mediator = mediator;
                _doctorManager = doctorManager;
            }

            public async Task<DoctorDto> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                var doctor = _mapper.Map<Doctor>(request.DoctorDto);
                var response = await _doctorManager.CreateAsync(doctor: doctor);

                // Raising Event ...
                await _mediator.Publish(
                    new CreateDoctorEvent(id: response.Id), cancellationToken);

                // Send email notification
                await _mediator.Publish(new EmailNotification("Hamidnch2007@gmail.com",
                    $"New doctor with email {response?.Email} created."), cancellationToken);

                return response!;
            }
        }
    }
}