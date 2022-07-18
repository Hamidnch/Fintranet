using _1_Fintranet.Common.Validators;

namespace Fintranet.Test.Validation
{
    public class EmailValidatorTest
    {
        [Theory]
        [InlineData("hamidnch2007@gmail.com", true)]
        [InlineData("xyz@gm.com", false)]
        [InlineData("hamidnch2001@yahoo.com", false)]
        [InlineData("hamidnch@ms.c", true)]
        public void EmailValidatorTest_ExpectedResult(string email, bool expectedResult)
        {
            var testResult = EmailValidator.Validate(email: email);
            Assert.Equal(expectedResult, testResult);
        }
    }
}