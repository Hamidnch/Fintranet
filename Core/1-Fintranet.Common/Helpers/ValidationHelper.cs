using PhoneNumbers;
using System.Globalization;
using System.Text.RegularExpressions;

namespace _1_Fintranet.Common.Helpers
{
    public static class ValidationHelper
    {
        private static readonly PhoneNumberUtil PhoneNumberUtil = PhoneNumberUtil.GetInstance();

        #region Private Methods

        private static PhoneNumber ParseToPhoneNumber(this string? phoneNumber)
        {
            return PhoneNumberUtil.Parse(phoneNumber, "US");
        }

        private static bool IsValidMobileType(this PhoneNumber p)
        {
            var numberType = PhoneNumberUtil.GetNumberType(p);
            return numberType == PhoneNumberType.MOBILE;
        }

        #endregion Private Methods


        #region Public Methods

        public static bool IsValidMobileNumber(this string? phoneNumber)
        {
            var p = phoneNumber.ParseToPhoneNumber();

            var isValidNumber = PhoneNumberUtil.IsValidNumber(p);

            var isValidMobile = p.IsValidMobileType();

            return isValidNumber && isValidMobile;
        }

        // Examines the domain part of the email and normalizes it.
        public static string DomainMapper(Match match)
        {
            // Use IdnMapping class to convert Unicode domain names.
            IdnMapping idn = new();

            // Pull out and process domain name (throws ArgumentException on invalid)
            var domainName = idn.GetAscii(match.Groups[2].Value);

            return match.Groups[1].Value + domainName;
        }

        public static bool HaveMinimumAge(DateTime birthDate)
        {
            return birthDate <= DateTime.Now.AddYears(-18);
        }

        #endregion Public Methods
    }
}