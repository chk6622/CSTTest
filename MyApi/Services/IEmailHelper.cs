

namespace MyApi.Services
{
    public interface IEmailHelper
    {
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="emailAddress">email address</param>
        /// <param name="message">message</param>
        /// <returns>send successfully => true, or => false</returns>
        bool SendEmail(string emailAddress, string message);
    }
}
