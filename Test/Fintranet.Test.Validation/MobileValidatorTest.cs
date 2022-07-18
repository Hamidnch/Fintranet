using _1_Fintranet.Common.Validators;

namespace Fintranet.Test.Validation
{
    public class MobileValidatorTest
    {
        [Theory]
        [InlineData("+989123456789", true)]
        [InlineData("+989124820700", true)]
        [InlineData("+31612345678", true)]
        [InlineData("+982188776655", false)]
        [InlineData("+60327306464", true)]
        public void MobileValidatorTest_ExpectedResult(string phoneNumber, bool expectedResult)
        {
            var testResult = MobileValidator.Validate(phoneNumber);
            //Assert.True(testResult);
            Assert.Equal(expectedResult, testResult);
            //Assert.Equals(expectedResult, testResult);
        }
    }
}
