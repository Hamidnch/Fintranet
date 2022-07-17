using _1_Fintranet.Common.Helpers;
using _1_Fintranet.Common.Validators;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Notifications;
using _3_Fintranet.Application.Features.Doctors.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Commands
{
    public record CreateDoctorCommand(DoctorDto<Guid> DoctorDto) : IRequest<DoctorDto<Guid>>
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
        public class CreateDoctorCommandCommandHandler : IRequestHandler<CreateDoctorCommand, DoctorDto<Guid>>
        {
            private readonly IMediator _mediator;
            private readonly IMapper _mapper;
            private readonly IDoctorManager<Guid> _doctorManager;
            public CreateDoctorCommandCommandHandler(IMapper mapper, IMediator mediator, IDoctorManager<Guid> doctorManager)
            {
                _mapper = mapper;
                _mediator = mediator;
                _doctorManager = doctorManager;
            }

            public async Task<DoctorDto<Guid>> Handle(CreateDoctorCommand request, CancellationToken cancellationToken)
            {
                //Doctor doctor = new Doctor(
                //    Guid.NewGuid(),
                //    request.DoctorDto.Firstname,
                //    request.DoctorDto.Lastname,
                //    request.DoctorDto.DateOfBirth,
                //    request.DoctorDto.PhoneNumber,
                //    request.DoctorDto.Email,
                //    request.DoctorDto.BankAccountNumber);

                var doctor = _mapper.Map<Doctor>(request.DoctorDto);

                //Store doctor in db
                DoctorDto<Guid>? response = await _doctorManager.CreateAsync(doctor: doctor);

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