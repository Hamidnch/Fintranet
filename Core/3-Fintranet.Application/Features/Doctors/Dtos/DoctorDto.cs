using _1_Fintranet.Common.Enums;

namespace _3_Fintranet.Application.Features.Doctors.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public Guid DoctorGuid { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? NationalCode { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? MedicalSystemNumber { get; set; }
        public string? BusinessMobileNumber { get; set; }
        public string? PersonalMobileNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public TurningMethod? TurningMethod { get; set; }
        public GenderType GenderType { get; set; }
        public int? MedicalHistory { get; set; }
        public string? Website { get; set; }
    }
}