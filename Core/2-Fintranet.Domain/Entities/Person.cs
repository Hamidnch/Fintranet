using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Commons;
using System.ComponentModel.DataAnnotations.Schema;

namespace _2_Fintranet.Domain.Entities
{
    public abstract class Person : BaseEntity
    {
        protected Person()
        {
        }

        protected Person(string? firstName, string? lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        protected Person(string? firstName, string? lastName, GenderType genderType)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GenderType = genderType;
        }

        protected Person(string? firstName, string? lastName, GenderType genderType,
            int pictureId, string? nationalCode, string? email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.GenderType = genderType;
            this.PictureId = pictureId;
            this.NationalCode = nationalCode;
            this.Email = email;
        }

        /// <summary>
        /// Get or set name
        /// </summary>
        public string? FirstName { get; set; }
        /// <summary>
        /// Get or set last name
        /// </summary>
        public string? LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName + " " + LastName}";

        /// <summary>
        /// Gets or sets gender type
        /// </summary>
        public GenderType GenderType { get; set; }

        /// <summary>
        /// Gets or sets the picture identifier
        /// </summary>
        public int PictureId { get; set; }
        /// <summary>
        /// National code
        /// </summary>
        public string? NationalCode { get; set; }
        /// <summary>
        /// Gets or sets email 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// Gets or sets the last IP address
        /// </summary>
        public string? LastIpAddress { get; set; }
        /// <summary>
        /// Gets or sets the date and time of last login
        /// </summary>
        public DateTime? LastLoginDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the date and time of last activity
        /// </summary>
        public DateTime LastActivityDateUtc { get; set; }
    }
}