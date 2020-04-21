using System;
using CheckIn.Adapter;
using CheckIn.Common;
using CheckIn.Service;
using NSubstitute;
using NUnit.Framework;

namespace CheckIn.UnitTests
{
    [TestFixture]
    public class AuthenticationServiceUnitTest
    {
        private AuthenticationService authenticationService;
        private IProfileDao profileDao;
        private string accessToken;
        private IHash sha256Adapter;
        private IAuthService authService;

        [SetUp]
        public void SetUp()
        {
            profileDao = Substitute.For<IProfileDao>();
            sha256Adapter = Substitute.For<IHash>();
            authService = Substitute.For<IAuthService>();
            authenticationService = new AuthenticationService(profileDao, sha256Adapter, authService);
        }

        [Test]
        public void InValid_Should_Throw_Exception()
        {
            GivenHashPassword("Ray", "HashPassword");

            ShouldThrow<OperationFailedException>();
        }

        [Test]
        public void Is_Valid_Should_GetAccessToken()
        {
            GivenHashPassword("Ray", "HashPassword");
            GivenComputeHash("HashPassword");
            GivenAccessToken("AccessToken");
            AccessTokenShouldBe("AccessToken");
        }

        private void ShouldThrow<TException>() where TException : Exception
        {
            TestDelegate action = () => authenticationService.GetAccessToken("Ray", "Mypassword");
            Assert.Throws<TException>(action);
        }

        private void GivenAccessToken(string accessToken)
        {
            authService.GetAccessToken(Arg.Any<string>()).Returns(accessToken);
        }

        private void GivenComputeHash(string hashPassword)
        {
            sha256Adapter.ComputeHash(Arg.Any<string>()).Returns(hashPassword);
        }

        private void GivenHashPassword(string userName, string hashPassword)
        {
            profileDao.GetHashPassword(userName).Returns(hashPassword);
        }

        private void AccessTokenShouldBe(string expected)
        {
            accessToken = authenticationService.GetAccessToken("Ray", "Mypassword");
            Assert.AreEqual(expected, accessToken);
        }
    }
}