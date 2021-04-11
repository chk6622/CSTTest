using MyApi.Services;
using Xunit;

namespace MyTest.TestServices
{
    public class EmailHelperTest : BaseTest
    {
        private IEmailHelper emailHelper;
        public EmailHelperTest(ProgramInitFixture programInitFixture) : base(programInitFixture)
        {
            this.emailHelper = this.Provider.GetService(typeof(IEmailHelper)) as IEmailHelper;
        }

        [Fact(DisplayName = "Test send email successfully")]
        [Trait("Category", "Service")]
        public void ShouldSendEmailSuccess()
        {
            string email = "mytestxt@gmail.com";
            string message = "test";

            bool sendState = this.emailHelper.SendEmail(email, message);

            Assert.True(sendState);
        }



        [Fact(DisplayName = "Test failed to send email")]
        [Trait("Category", "Service")]
        public void ShouldSendEmailFail()
        {
            string email = "";
            string message = "test";

            bool sendState = this.emailHelper.SendEmail(email, message);

            Assert.False(sendState);

            email = "mytestxt@gamil.com";
            message = "";

            sendState = this.emailHelper.SendEmail(email, message);

            Assert.False(sendState);

            email = null;
            message = "";

            sendState = this.emailHelper.SendEmail(email, message);

            Assert.False(sendState);
        }
    }
}
