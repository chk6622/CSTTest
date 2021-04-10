using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Services.Impl
{
    public class VerificationCodeHelper : IVerificationCodeHelper
    {
        public bool CheckVerificationCode(string verificationCode, string email)
        {
            throw new NotImplementedException();
        }

        public string GetRandomString(int length)
        {
            throw new NotImplementedException();
        }

        public string getVerificationCode(string email)
        {
            throw new NotImplementedException();
        }
    }
}
