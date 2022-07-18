using System.ComponentModel.DataAnnotations;

namespace _1_Fintranet.Common.Enums
{
    /// <summary>
    /// روشهای نوبت دهی
    /// </summary>
    public enum TurningMethod : byte
    {
        [Display(Name = "حضوری")]
        InPerson = 1,
        [Display(Name = "تلفنی")]
        ByPhone = 2,
        [Display(Name = "اینترنتی")]
        ByInternet = 3
    }
}