using System;
using Xunit;

namespace MyTest
{
    [Collection("ProgramInitCollection")]
    public class BaseTest
    {
        public IServiceProvider Provider { get; }


        public BaseTest(ProgramInitFixture programInitFixture)
        {
            Provider = programInitFixture.Provider;
        }
    }
}
