using _1_Fintranet.Common.Enums;
using _3_Fintranet.Application.Interfaces.Commons;

namespace _2_Fintranet.Domain.Entities
{
    public sealed class Patient : Person, IDisplayOrder
    {
        public Guid? DocumentNumber { get; set; }
        public string? MobileNumber { get; set; }

        public Patient(string? firstName, string? lastName, GenderType genderType, 
            string? mobileNumber): base(firstName, lastName, genderType)
        {
            this.DocumentNumber = Guid.NewGuid();
            this.MobileNumber = mobileNumber;
        }

        public Patient(string documentNumber, string? firstName, string? lastName, GenderType genderType,
            string? mobileNumber) : base(firstName, lastName, genderType)
        {
            this.DocumentNumber = Guid.Parse(documentNumber);
            this.MobileNumber = mobileNumber;
        }

        #region IDisplayOrder

        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion IDisplayOrder
    }
}
