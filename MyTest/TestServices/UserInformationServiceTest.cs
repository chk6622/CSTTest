using MyApi.Dto;
using MyApi.Services;
using Xunit;

namespace MyTest.TestServices
{
    public class UserInformationServiceTest : BaseTest
    {
        private IUserInformationService userInformationService;
        private IVerificationCodeHelper verificationCodeHelper;

        public UserInformationServiceTest(ProgramInitFixture programInitFixture) : base(programInitFixture)
        {
            this.userInformationService = Provider.GetService(typeof(IUserInformationService)) as IUserInformationService;
            this.verificationCodeHelper = this.Provider.GetService(typeof(IVerificationCodeHelper)) as IVerificationCodeHelper;

        }

        [Fact(DisplayName = "Test Add")]
        [Trait("Category", "Service")]
        public void AddShouldBeSuccessful()
        {
            // 1. Arrange
            var email = "abc@gamil.com";
            var vCode = this.verificationCodeHelper.getVerificationCode(email);
            UserInformationDto userInfo = new UserInformationDto() { FullName = "Tom", PhoneNumber = "02106817023", Email = email, VerificationCode = vCode };

            // 2. Act

            var result = this.userInformationService.AddUserInformation(userInfo);

            //3. Assert
            Assert.NotNull(result);

        }


        [Fact(DisplayName = "Test Add Null")]
        [Trait("Category", "Service")]
        public void AddShouldReturnFalse()
        {
            // 1. Arrange


            // 2. Act
            var result = this.userInformationService.AddUserInformation(null);

            //3. Assert
            Assert.Null(result);


        }

        [Fact(DisplayName = "Test Get")]
        [Trait("Category", "Service")]
        public async void GetShouldBeSuccessful()
        {
            // 1. Arrange
            var email = "abc@gamil.com";
            var vCode = this.verificationCodeHelper.getVerificationCode(email);
            UserInformationDto userInfo = new UserInformationDto() { FullName = "Tom", PhoneNumber = "02106817023", Email = email, VerificationCode = vCode };

            // 2. Act
            var result = this.userInformationService.AddUserInformation(userInfo);
            var obj = await this.userInformationService.GetUserInformationAsync(result.Id);

            //3. Assert
            Assert.NotNull(obj);
            Assert.Equal(userInfo.FullName, obj.FullName);
            Assert.Equal(userInfo.PhoneNumber, obj.PhoneNumber);
            Assert.Equal(userInfo.Email, obj.Email);

        }

        [Fact(DisplayName = "Test Get Null")]
        [Trait("Category", "Service")]
        public async void GetShouldBeNull()
        {
            // 1. Arrange
            Assert.NotNull(userInformationService);
            var id = -1;

            // 2. Act
            var obj = await this.userInformationService.GetUserInformationAsync(id);

            //3. Assert
            Assert.Null(obj);

        }
    }
}
