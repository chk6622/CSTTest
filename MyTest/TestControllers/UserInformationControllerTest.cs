using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using MyApi;
using MyApi.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace MyTest.TestControllers
{
    public class UserInformationControllerTest:BaseTest
    {
        private readonly HttpClient client = null;
        public UserInformationControllerTest(ProgramInitFixture programInitFixture) : base(programInitFixture)
        {
            var server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>());
            client = server.CreateClient();
        }

        [Fact(DisplayName = "Test get verification code method")]
        [Trait("Category", "Controller")]
        public async Task ShouldGetVerificationCode()
        {
            // 1. Arrange
            string email1 = "abc@gmail.com";
            string email2 = "abc";
            string email3 = "";


            // 2. Act
            var response1 = await client.GetAsync($"/UserInformation/getVerificationCode?email={email1}");
            var response2 = await client.GetAsync($"/UserInformation/getVerificationCode?email={email2}");
            var response3 = await client.GetAsync($"/UserInformation/getVerificationCode?email={email3}");

            // 3. Assert
            Assert.Equal(HttpStatusCode.OK, response1.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response3.StatusCode);
        }

        [Fact(DisplayName = "Test add user information method")]
        [Trait("Category", "Controller")]
        public async Task ShouldAddUserInformation()
        {
            // 1. Arrange
            string email1 = "abc1@gmail.com";
            var response = await client.GetAsync($"/UserInformation/getVerificationCodeTest?email={email1}");
            string VerificationCode1 = await response.Content.ReadAsStringAsync();
            UserInformationDto userInformationDto1 = new UserInformationDto()
            {
                FullName = "Tom",
                PhoneNumber = "12345678",
                Email = email1,
                VerificationCode = VerificationCode1
            };
            HttpContent content1 = new StringContent(JsonConvert.SerializeObject(userInformationDto1));
            content1.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


            UserInformationDto userInformationDto2 = new UserInformationDto()
            {
                FullName = "Tom",
                PhoneNumber = "12345678",
                Email = email1,
                VerificationCode = ""
            };
            HttpContent content2 = new StringContent(JsonConvert.SerializeObject(userInformationDto2));
            content2.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            string email2 = "bcd1@gamil.com";
            response = await client.GetAsync($"/UserInformation/getVerificationCodeTest?email={email2}");
            string VerificationCode2 = await response.Content.ReadAsStringAsync();
            UserInformationDto userInformationDto3 = new UserInformationDto()
            {
                FullName = "Tom",
                PhoneNumber = "12345678",
                Email = "abc",
                VerificationCode = VerificationCode2
            };
            HttpContent content3 = new StringContent(JsonConvert.SerializeObject(userInformationDto3));
            content3.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            UserInformationDto userInformationDto4 = new UserInformationDto()
            {
                FullName = "Tom",
                PhoneNumber = "12345678",
                Email = email2,
                VerificationCode = ""
            };
            HttpContent content4 = new StringContent(JsonConvert.SerializeObject(userInformationDto4));
            content4.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            UserInformationDto userInformationDto5 = new UserInformationDto()
            {
                FullName = "Tom",
                PhoneNumber = "abc",
                Email = email2,
                VerificationCode = VerificationCode2
            };
            HttpContent content5 = new StringContent(JsonConvert.SerializeObject(userInformationDto5));
            content5.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            UserInformationDto userInformationDto6 = new UserInformationDto()
            {
                FullName = "",
                PhoneNumber = "12345678",
                Email = email2,
                VerificationCode = VerificationCode2
            };
            HttpContent content6 = new StringContent(JsonConvert.SerializeObject(userInformationDto6));
            content6.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            UserInformationDto userInformationDto7 = new UserInformationDto()
            {
                FullName = "Mike",
                PhoneNumber = "12345678",
                Email = email2,
                VerificationCode = VerificationCode2
            };
            HttpContent content7 = new StringContent(JsonConvert.SerializeObject(userInformationDto7));
            content7.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            // 2. Act
            var response1 = await client.PostAsync($"/UserInformation/AddUserInformation", content1);
            var response2 = await client.PostAsync($"/UserInformation/AddUserInformation", content2);
            var response3 = await client.PostAsync($"/UserInformation/AddUserInformation", content3);
            var response4 = await client.PostAsync($"/UserInformation/AddUserInformation", content4);
            var response5 = await client.PostAsync($"/UserInformation/AddUserInformation", content5);
            var response6 = await client.PostAsync($"/UserInformation/AddUserInformation", content6);
            var response7 = await client.PostAsync($"/UserInformation/AddUserInformation", content7);



            // 3. Assert
            Assert.Equal(HttpStatusCode.Created, response1.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response2.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response3.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response4.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response5.StatusCode);
            Assert.Equal(HttpStatusCode.BadRequest, response6.StatusCode);
            Assert.Equal(HttpStatusCode.Created, response7.StatusCode);
        }
    }
}
