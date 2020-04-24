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
        [SetUp]
        public void SetUp()
        {
            _profileDao = Substitute.For<IProfileDao>();
            _sha256Adapter = Substitute.For<IHash>();
            _authService = Substitute.For<IAuthService>();
            _authenticationService = new AuthenticationService(_profileDao, _sha256Adapter, _authService);
        }

        private AuthenticationService _authenticationService;
        private IProfileDao _profileDao;
        private string _accessToken;
        private IHash _sha256Adapter;
        private IAuthService _authService;

        private void ShouldThrow<TException>() where TException : Exception
        {
            TestDelegate action = () => _authenticationService.GetAccessToken("Ray", "Mypassword");
            Assert.Throws<TException>(action);
        }

        private void GivenAccessToken(string accessToken)
        {
            _authService.GetAccessToken(Arg.Any<string>()).Returns(accessToken);
        }

        private void GivenComputeHash(string hashPassword)
        {
            _sha256Adapter.ComputeHash(Arg.Any<string>()).Returns(hashPassword);
        }

        private void GivenHashPassword(string userName, string hashPassword)
        {
            _profileDao.GetHashPassword(userName).Returns(hashPassword);
        }

        private void AccessTokenShouldBe(string expected)
        {
            _accessToken = _authenticationService.GetAccessToken("Ray", "Mypassword");
            Assert.AreEqual(expected, _accessToken);
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
    }
}