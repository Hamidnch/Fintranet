using _1_Fintranet.Common.Interfaces;
using _2_Fintranet.Domain.Commons;

namespace _2_Fintranet.Domain.Entities
{
    /// <summary>
    /// Related table between doctor and doctor office
    /// </summary>
    public class DoctorDoctorOfficeMapping : BaseEntity, IDisplayOrder
    {
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
        public int DoctorOfficeId { get; set; }
        public virtual DoctorOffice? DoctorOffice { get; set; }
        public int DisplayOrder { get; set; }
    }
}