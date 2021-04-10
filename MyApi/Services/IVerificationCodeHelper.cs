

namespace MyApi.Services
{
    public interface IVerificationCodeHelper
    {
        /// <summary>
        /// Get a verification code, and the code maps with the email address
        /// </summary>
        /// <param name="email">email address</param>
        /// <returns>the verification code</returns>
        string getVerificationCode(string email);



        /// <summary>
        /// check whether the verification code maps the email
        /// </summary>
        /// <param name="verificationCode"></param>
        /// <param name="email"></param>
        /// <returns>map => true, or => false</returns>
        bool CheckVerificationCode(string verificationCode, string email);



        /// <summary>
        /// Get a ramdon string
        /// </summary>
        /// <param name="length">the length of the string</param>
        /// <returns>the ramdon string</returns>
        public string GetRandomString(int length);
    }
}
