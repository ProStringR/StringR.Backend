using StringR.Backend.Controllers.v1;
using Xunit;

namespace StringR.Backend.Tests
{
    public class AuthenticationTest
    {
        [Fact]
        public void SecretKeyLengthTest()
        {
            Assert.Equal(512, AuthenticationController.SecretKey.Length);
        }
    }
}