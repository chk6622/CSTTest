using MyApi.Services;
using Xunit;

namespace MyTest.TestServices
{
    public class VerificationCodeHelperTest : BaseTest
    {
        private IVerificationCodeHelper verificationCodeHelper;
        public VerificationCodeHelperTest(ProgramInitFixture programInitFixture) : base(programInitFixture)
        {
            this.verificationCodeHelper = this.Provider.GetService(typeof(IVerificationCodeHelper)) as IVerificationCodeHelper;
        }

        [Fact(DisplayName = "Test generating random code")]
        [Trait("Category", "Service")]
        public void ShouldGenerateRandomCode()
        {
            // 1. Arrange
            int size1 = 5;
            int size2 = 6;
            int size3 = 7;

            // 2. Act
            var result1 = this.verificationCodeHelper.GetRandomString(size1);
            var result2 = this.verificationCodeHelper.GetRandomString(size2);
            var result3 = this.verificationCodeHelper.GetRandomString(size3);

            //3. Assert
            Assert.True(result1.Length == size1);
            Assert.True(result2.Length == size2);
            Assert.True(result3.Length == size3);
        }

        [Fact(DisplayName = "Test get verification code")]
        [Trait("Category", "Service")]
        public void ShouldGetVerificationCode()
        {
            // 1. Arrange
            string email1 = "mytestxt@gmail.com";
            string email2 = "";

            // 2. Act
            string vCode1 = this.verificationCodeHelper.getVerificationCode(email1);
            string vCode2 = this.verificationCodeHelper.getVerificationCode(email2);

            //3. Assert
            Assert.NotNull(vCode1);
            Assert.Null(vCode2);
        }

        [Fact(DisplayName = "Test check verification code")]
        [Trait("Category", "Service")]
        public void ShouldCheckVerificationCode()
        {
            // 1. Arrange
            string email = "mytestxt@gmail.com";

            // 2. Act
            string vCode = this.verificationCodeHelper.getVerificationCode(email);

            bool result1 = this.verificationCodeHelper.CheckVerificationCode("", email);

            bool result2 = this.verificationCodeHelper.CheckVerificationCode(vCode, "");

            bool result3 = this.verificationCodeHelper.CheckVerificationCode(vCode, email);


            //3. Assert
            Assert.False(result1);
            Assert.False(result2);
            Assert.True(result3);
        }
    }
}
