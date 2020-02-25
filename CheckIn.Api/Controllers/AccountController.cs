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
    public class AccountController : BaseApiController
    {
        [HttpPost]
        public GetAccessTokenResponse GetAccesstoken([FromBody] GetAccessTokenRequest request)
        {
            var profileDao = new ProfileDao();
            var sha256Adapter = new Sha256Adapter();
            var authService = new AuthService(profileDao);
            var authenticationService = new AuthenticationService(profileDao, sha256Adapter, authService);

            return authenticationService.Login(request.UserName, request.Password);
        }
    }
}