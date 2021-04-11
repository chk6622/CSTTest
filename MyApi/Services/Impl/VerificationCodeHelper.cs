using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApi.Services.Impl
{
    public class VerificationCodeHelper : IVerificationCodeHelper
    {
        private static readonly char[] constant =
          {
            '0','1','2','3','4','5','6','7','8','9',
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
          };

        private readonly IEmailHelper emailHelper = null;
        private readonly IMemoryCache cache = null;

        public VerificationCodeHelper(IMemoryCache cache, IEmailHelper emailHelper)
        {
            this.emailHelper = emailHelper;
            this.cache = cache;
        }

        public bool CheckVerificationCode(string verificationCode, string email)
        {
            bool bReturn = false;
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(verificationCode))
            {
                this.cache.TryGetValue(email, out string vCode);  //get Verification Code from the cache
                if (vCode == verificationCode)
                {
                    this.cache.Remove(email);  //delete the eamil---verification code pair from cache
                    bReturn = true;
                }
            }
            return bReturn;
        }

        public string getVerificationCode(string email)
        {
            string sReturn = null;
            if (!string.IsNullOrWhiteSpace(email))
            {
                int length = 10;  //the length of verification code
                int expireTime = 10;  //cache expire time (minute)

                string vCode = GetRandomString(length);  //generate verification code

                this.cache.Set(email, vCode, TimeSpan.FromSeconds(60 * expireTime));  //set email-----Verification Code pair

                string emailContent = $"Hello, your verification code is {vCode} which will expire in {expireTime} minutes.";
                this.emailHelper.SendEmail(email, emailContent);  //send email

                sReturn = vCode;

            }
            return sReturn;
        }

        public string GetRandomString(int length)
        {
            StringBuilder newRandom = new StringBuilder(length);
            Random rd = new Random();
            int size = constant.Length;
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(constant[rd.Next(size)]);  //get a char randomly and add the char to StringBuilder
            }
            return newRandom.ToString();
        }
    }
}
