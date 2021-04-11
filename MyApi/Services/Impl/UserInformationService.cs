using Microsoft.EntityFrameworkCore;
using MyApi.Data;
using MyApi.Dto;
using MyApi.Entities;
using System.Threading.Tasks;

namespace MyApi.Services.Impl
{
    public class UserInformationService : IUserInformationService
    {
        private readonly MyDbContext myDbContext = null;
        private readonly IVerificationCodeHelper verificationCodeHelper = null;

        public UserInformationService(MyDbContext myDbContext, IVerificationCodeHelper verificationCodeHelper)
        {
            this.myDbContext = myDbContext;
            this.verificationCodeHelper = verificationCodeHelper;
        }

        public UserInformation AddUserInformation(UserInformationDto userInformationDto)
        {
            UserInformation userInfo = null;

            if (userInformationDto != null &&
                verificationCodeHelper.CheckVerificationCode(userInformationDto.VerificationCode, userInformationDto.Email))  //verify userInformation
            {
                userInfo = new UserInformation()
                {
                    FullName = userInformationDto.FullName,
                    PhoneNumber = userInformationDto.PhoneNumber,
                    Email = userInformationDto.Email
                };

                this.myDbContext.Add(userInfo);  //save

                this.myDbContext.SaveChanges();

            }

            return userInfo;
        }

        public async Task<UserInformation> GetUserInformationAsync(int id)
        {
            return await this.myDbContext.UserInformationSet.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
