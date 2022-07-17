using System.ComponentModel.DataAnnotations;

namespace _1_Fintranet.Common.Enums;

/// <summary>
/// جنسیت
/// </summary>
public enum GenderType : byte
{
    [Display(Name = "مرد")]
    Male = 1,
    [Display(Name = "زن")]
    Female = 2
}