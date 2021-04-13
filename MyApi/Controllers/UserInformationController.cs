using Microsoft.AspNetCore.Mvc;
using MyApi.Dto;
using MyApi.Services;

namespace MyApi.Controllers
{
    [Route("UserInformation")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        private readonly IUserInformationService userInformationService = null;
        private readonly IVerificationCodeHelper verificationCodeHelper = null;

        public UserInformationController(IUserInformationService userInformationService, IVerificationCodeHelper verificationCodeHelper)
        {
            this.userInformationService = userInformationService;
            this.verificationCodeHelper = verificationCodeHelper;
        }


        /// <summary>
        /// Add user information end point
        /// </summary>
        /// <param name="userInformationDto">the user information data transfer object</param>
        /// <returns>ActionResult</returns>
        [HttpPost("AddUserInformation", Name = nameof(AddUserInformation))]
        public ActionResult<UserInformationDto> AddUserInformation(UserInformationDto userInformationDto)
        {

            var userInformation = this.userInformationService.AddUserInformation(userInformationDto);

            if (userInformation == null)
            {
                return BadRequest(new { message = "Please input the correct verification code." });
            }

            return CreatedAtRoute(nameof(AddUserInformation), new { Id = userInformationDto.Id }, userInformation);
        }


        /// <summary>
        /// Get verification code end point
        /// </summary>
        /// <param name="verificationCodeDto">verification code data transfer object</param>
        /// <returns>ActionResult</returns>
        [HttpGet("getVerificationCode")]
        public ActionResult<string> GetVerificationCode([FromQuery] VerificationCodeDto verificationCodeDto)
        {

            string vCode = this.verificationCodeHelper.getVerificationCode(verificationCodeDto.Email);

            if (string.IsNullOrWhiteSpace(vCode))
            {
                return BadRequest();
            }
            //throw new System.Exception("Server error!");
            return Ok(new { message = "The verification code has been sent to your email box." });
        }



        /// <summary>
        /// get verification code by email, this endpoint is just for test.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>the verification code</returns>
        [HttpGet("getVerificationCodeTest")]
        public ActionResult<string> GetVerificationCode(string email)
        {
            string vCode = this.verificationCodeHelper.getVerificationCode(email);

            if (string.IsNullOrWhiteSpace(vCode))
            {
                return BadRequest();
            }

            return Ok(vCode);
        }
    }
}