using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIn.Adapter;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public AccountController()
        {
            var profileDao = new ProfileDao();
            var sha256Adapter = new Sha256Adapter();
            var authService = new AuthService(profileDao);
            authenticationService = new AuthenticationService(profileDao, sha256Adapter, authService);
        }

        [HttpPost]
        public GetAccessTokenResponse GetAccessToken([FromBody] GetAccessTokenRequest request)
        {
            var accessToken = authenticationService.GetAccessToken(request.UserName, request.Password);

            return new GetAccessTokenResponse(accessToken);
        }
    }
}