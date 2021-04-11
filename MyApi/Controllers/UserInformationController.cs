using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApi.Dto;

namespace MyApi.Controllers
{
    [Route("UserInformation")]
    [ApiController]
    public class UserInformationController : ControllerBase
    {
        [HttpPost("AddUserInformation", Name = nameof(AddUserInformation))]
        public ActionResult<UserInformationDto> AddUserInformation(UserInformationDto userInformationDto)
        {

            throw new Exception();
        }

        [HttpGet("getVerificationCode")]
        public ActionResult<string> GetVerificationCode([FromQuery] VerificationCodeDto verificationCodeDto)
        {
            throw new Exception();
            
        }



        /// <summary>
        /// get verification code by email, this endpoint is just for test.
        /// </summary>
        /// <param name="email"></param>
        /// <returns>the verification code</returns>
        [HttpGet("getVerificationCodeTest")]
        public ActionResult<string> GetVerificationCode(string email)
        {
            throw new Exception();
        }
    }
}