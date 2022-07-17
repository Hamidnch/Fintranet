using System.ComponentModel.DataAnnotations;

namespace _1_Fintranet.Common.Enums;

/// <summary>
/// محلهای حضور پزشک
/// </summary>
public enum PlaceName : byte
{
    [Display(Name = "مطب")]
    Office = 1,
    [Display(Name = "بیمارستان")]
    Hospital = 2,
    [Display(Name = "کلینیک یا درمانگاه")]
    Clinic = 3,
    [Display(Name = "سایر")]
    Other = 4
}