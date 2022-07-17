using _1_Fintranet.Common.Enums;
using _3_Fintranet.Application.Interfaces;

namespace _2_Fintranet.Domain.Entities
{
    /// <summary>
    /// Represents a Doctor
    /// </summary>
    public class Doctor : Person, IDisplayOrder
    {
        public Doctor()
        {
            DoctorGuid = Guid.NewGuid();
        }

        public Doctor(Guid doctorGuid, string? firstName, string? lastName, string? medicalSystemNumber)
            : base(firstName, lastName)
        {
            this.DoctorGuid = doctorGuid;
            this.MedicalSystemNumber = medicalSystemNumber;
        }

        public Doctor(string doctorGuid, string? firstName, string? lastName, string? medicalSystemNumber)
            : base(firstName, lastName)
        {
            this.DoctorGuid = Guid.Parse(doctorGuid);
            this.MedicalSystemNumber = medicalSystemNumber;
        }

        public Doctor(string? firstName, string? lastName, string? medicalSystemNumber) : base(firstName, lastName)
        {
            this.DoctorGuid = Guid.NewGuid();
            this.MedicalSystemNumber = medicalSystemNumber;
        }

        public Doctor(string? firstName, string? lastName, GenderType genderType,
            int pictureId, string? nationalCode, string? email, string? medicalSystemNumber,
            string? businessMobileNumber, string? personalMobileNumber, string? phoneNumber,
            TurningMethod? turningMethod, int? medicalHistory, string? website, int displayOrder) 
            : base(firstName, lastName, genderType, pictureId, nationalCode, email)
        {
            this.DoctorGuid = Guid.NewGuid();
            this.MedicalSystemNumber = medicalSystemNumber;
            this.BusinessMobileNumber = businessMobileNumber;
            this.PersonalMobileNumber = personalMobileNumber;
            this.PhoneNumber = phoneNumber;
            this.TurningMethod = turningMethod;
            this.MedicalHistory = medicalHistory;
            this.Website = website;
            this.DisplayOrder = displayOrder;
        }

        /// <summary>
        /// Gets or sets the doctor GUID
        /// </summary>
        public Guid DoctorGuid { get; set; }

        /// <summary>
        /// Gets or sets the medical system number
        /// </summary>
        public string? MedicalSystemNumber { get; set; }

        /// <summary>
        /// Gets or sets the Business mobile number
        /// </summary>
        public string? BusinessMobileNumber { get; set; }
        /// <summary>
        ///  Gets or sets the personal mobile number
        /// </summary>
        public string? PersonalMobileNumber { get; set; }
        /// <summary>
        ///  Gets or sets the Business phone number
        /// </summary>
        public string? PhoneNumber { get; set; }

        //public string FaxNumber { get; set; }
        /// <summary>
        /// روش نوبت دهی
        /// </summary>
        public TurningMethod? TurningMethod { get; set; }
        /// <summary>
        /// سابقه طبابت-به سال
        /// </summary>
        public int? MedicalHistory { get; set; }

        public string? Website { get; set; }


        private IReadOnlyCollection<DoctorDoctorOfficeMapping>? _doctorDoctorOfficeMappings;
        /// <summary>
        /// Gets or sets Doctor-Doctor office mappings
        /// </summary>
        public virtual IReadOnlyCollection<DoctorDoctorOfficeMapping>? DoctorDoctorOfficeMappings
        {
            get => _doctorDoctorOfficeMappings ??= new List<DoctorDoctorOfficeMapping>();
            protected set => _doctorDoctorOfficeMappings = value;
        }

        #region IDisplayOrder
        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion IDisplayOrder
    }
}