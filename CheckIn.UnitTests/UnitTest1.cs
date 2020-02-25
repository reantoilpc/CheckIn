using System;
using System.Web.Configuration;
using CheckIn.Service;
using NUnit.Framework;

namespace CheckIn.UnitTests
{
    [TestFixture]
    public class AuthenticationServiceUnitTest
    {
        [Test]
        public void Is_Empty_AccessToken()
        {
            var authenticationService = new AuthenticationService();
            var accessToken = authenticationService.GetAccessToken("Ray", "Mypassword");

            Assert.AreEqual("", accessToken);
        }
    }
}