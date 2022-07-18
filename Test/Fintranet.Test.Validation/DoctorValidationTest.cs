using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Entities;
using _6_Fintranet.Framework.Validators;
using FluentValidation.TestHelper;

namespace Fintranet.Test.Validation
{
    public class DoctorValidationTest
    {
        private readonly DoctorValidator _doctorValidator;

        public DoctorValidationTest()
        {
            _doctorValidator = new DoctorValidator();
        }

        [Fact]
        public async Task EmailValidationAsync()
        {
            var doctor = new Doctor(
                "Hamid", "NCH", GenderType.Male, 1, "4323511086",
                "hamidnch2007@gmail.com", "678678",
                "09124820700", null, null,
                TurningMethod.ByPhone, 15, null);


            var result = await _doctorValidator.TestValidateAsync(doctor);

            result.ShouldNotHaveValidationErrorFor(c => c.Email);
        }
    }
}