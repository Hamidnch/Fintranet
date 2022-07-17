using _1_Fintranet.Common.Helpers;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace _1_Fintranet.Common.Validators
{
    public static class EmailValidator
    {
        public static bool Validate(string? email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            email = email.Trim().ToLower();

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$",
                    ValidationHelper.DomainMapper, RegexOptions.None,
                    TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return MailAddress.TryCreate(email, out _);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}