using MyApi.Dto;
using MyApi.Entities;
using System.Threading.Tasks;

namespace MyApi.Services
{
    public interface IUserInformationService
    {
        /// <summary>
        /// Add user information
        /// </summary>
        /// <param name="userInformationDto">user information dto</param>
        /// <returns>UserInformation</returns>
        UserInformation AddUserInformation(UserInformationDto userInformationDto);



        /// <summary>
        /// Get user information by id
        /// </summary>
        /// <param name="id">user information id</param>
        /// <returns>user information</returns>
        Task<UserInformation> GetUserInformationAsync(int id);
    }
}
