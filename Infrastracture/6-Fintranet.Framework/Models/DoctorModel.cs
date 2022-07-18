using _1_Fintranet.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace _6_Fintranet.Framework.Models
{
    public class DoctorModel
    {
        /// <summary>
        /// Doctor id
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Unique identifier of doctor
        /// </summary>
        public Guid DoctorGuid { get; set; }

        /// <summary>
        /// First name of doctor
        /// </summary>
        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Last name of doctor
        /// </summary>
        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }

        public string? FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Email of doctor
        /// </summary>
        [EmailAddress]
        public string? Email { get; set; }
        
        /// <summary>
        /// Gets or sets national code
        /// </summary>
        public string? NationalCode { get; set; }

        /// <summary>
        /// Date of birth of doctor
        /// </summary>
        [Required(ErrorMessage = "Please enter date of your birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Medical system number of doctor
        /// </summary>
        public string? MedicalSystemNumber { get; set; }

        /// <summary>
        /// Business mobile number of doctor
        /// </summary>
        public string? BusinessMobileNumber { get; set; }

        /// <summary>
        /// Personal mobile number of doctor
        /// </summary>
        public string? PersonalMobileNumber { get; set; }

        /// <summary>
        /// Phone number of doctor
        /// </summary>
        [Phone]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Turning method of doctor
        /// </summary>
        public TurningMethod? TurningMethod { get; set; }

        /// <summary>
        /// Gender type of doctor
        /// </summary>
        public GenderType GenderType { get; set; }

        /// <summary>
        /// Medical history of doctor
        /// </summary>
        public int? MedicalHistory { get; set; }

        /// <summary>
        /// National code of doctor
        /// </summary>
        public string? Website { get; set; }
    }
}
