using _1_Fintranet.Common.Enums;
using _2_Fintranet.Domain.Commons;
using _3_Fintranet.Application.Interfaces;

namespace _2_Fintranet.Domain.Entities
{
    /// <summary>
    /// Doctor office
    /// </summary>
    public class DoctorOffice : BaseEntity, IDisplayOrder
    {
        public PlaceName PlaceName { get; set; }
        /// <summary>
        /// Gets or sets the phone1
        /// </summary>
        public string? Phone1 { get; set; }
        /// <summary>
        /// Gets or sets the phone2
        /// </summary>
        public string? Phone2 { get; set; }
        /// <summary>
        /// Gets or sets the fax number
        /// </summary>
        public string? FaxNumber { get; set; }

        public string? Province { get; set; }
        public string? City { get; set; }
        public string? FullAddress { get; set; }

        /// <summary>
        /// Gets or sets the whats-up
        /// </summary>
        public string? WhatsUp { get; set; }

        #region IDisplayOrder
        /// <summary>
        /// Gets or sets the display order
        /// </summary>
        public int DisplayOrder { get; set; }

        #endregion IDisplayOrder
    }
}
