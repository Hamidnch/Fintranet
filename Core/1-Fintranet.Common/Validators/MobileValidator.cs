using _1_Fintranet.Common.Helpers;

namespace _1_Fintranet.Common.Validators
{
    public static class MobileValidator
    {
        public static bool Validate(string? phoneNumber)
        {
            return phoneNumber.IsValidMobileNumber();
        }
    }
}