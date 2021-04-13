

namespace MyApi.Services
{
    /// <summary>
    /// Email sending interface
    /// </summary>
    public interface IEmailHelper
    {
        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="emailAddress">target email address</param>
        /// <param name="message">the message you want to send</param>
        /// <returns>send successfully => true, or => false</returns>
        bool SendEmail(string emailAddress, string message);
    }
}
