using _1_Fintranet.Common.Validators;
using _2_Fintranet.Domain.Entities;
using FluentValidation;

namespace _6_Fintranet.Framework.Validators
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email must not be empty");
            RuleFor(x => x.Email)
                .Must(EmailValidator.Validate!)
                .WithMessage("Email is invalid.");
        }
    }
}