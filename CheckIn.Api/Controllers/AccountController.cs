using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIn.Common;

namespace CheckIn.Api.Controllers
{
    public class AccountController : BaseApiController
    {
        public GetAccessTokenResponse GetAccesstoken([FromBody] GetAccessTokenRequest request)
        {

            return new GetAccessTokenResponse();
        }
    }
}
