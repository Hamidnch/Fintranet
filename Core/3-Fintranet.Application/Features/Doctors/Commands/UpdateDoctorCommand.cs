using _1_Fintranet.Common.Helpers;
using _1_Fintranet.Common.Validators;
using _2_Fintranet.Domain.Entities;
using _3_Fintranet.Application.Features.Doctors.Dtos;
using _3_Fintranet.Application.Features.Doctors.Services;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace _3_Fintranet.Application.Features.Doctors.Commands
{
    public record UpdateDoctorCommand(DoctorDto DoctorDto) : IRequest<DoctorDto>
    {
        public class UpdateDoctorCommandValidator : AbstractValidator<UpdateDoctorCommand>
        {
            public UpdateDoctorCommandValidator()
            {
                RuleFor(c => c.DoctorDto.Id)
                    .NotEqual(0)
                    .WithMessage("The doctor id must not be zero");

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

        public record UpdateDoctorCommandHandler : IRequestHandler<UpdateDoctorCommand, DoctorDto>
        {
            private readonly IDoctorManager _doctorManager;
            private readonly IMapper _mapper;

            public UpdateDoctorCommandHandler(IDoctorManager doctorManager, IMapper mapper)
            {
                _doctorManager = doctorManager;
                _mapper = mapper;
            }

            public async Task<DoctorDto> Handle(UpdateDoctorCommand request, CancellationToken cancellationToken)
            {
                //var doctor = _mapper.Map<Doctor>(request.DoctorDto);
                //return await _doctorManager.UpdateAsync(doctor);

                var doctorDto = await _doctorManager.GetByEmailAsync(request.DoctorDto.Email, false);

                var doctor =
                //_mapper.Map<Doctor>(doctorDto);
                new Doctor
                {
                    Id = doctorDto.Id,
                    DoctorGuid = doctorDto.DoctorGuid,
                    FirstName = request.DoctorDto.FirstName,
                    LastName = request.DoctorDto.LastName,
                    Email = request.DoctorDto.Email,
                    DateOfBirth = request.DoctorDto.DateOfBirth,
                    PhoneNumber = request.DoctorDto.PhoneNumber,
                    MedicalSystemNumber = request.DoctorDto.MedicalSystemNumber,
                    BusinessMobileNumber = request.DoctorDto.BusinessMobileNumber,
                    Website = request.DoctorDto.Website,
                    NationalCode = request.DoctorDto.NationalCode
                };

                return await _doctorManager.UpdateAsync(doctor);
            }
        }
    }
}