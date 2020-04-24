using System.Web.Http;
using CheckIn.Adapter;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Controllers
{
    public class AccountController : ApiControllerBase
    {
        /// <summary>
        ///     認證元件
        /// </summary>
        private readonly AuthenticationService _authenticationService;

        public AccountController()
        {
            var profileDao = new ProfileDao();
            var sha256Adapter = new Sha256Adapter();
            var authService = new AuthService(profileDao);
            _authenticationService = new AuthenticationService(profileDao, sha256Adapter, authService);
        }

        /// <summary>
        ///     取得AccessToken
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public GetAccessTokenResponse GetAccessToken([FromBody] GetAccessTokenRequest request)
        {
            var accessToken = _authenticationService.GetAccessToken(request.UserName, request.Password);

            return new GetAccessTokenResponse(accessToken);
        }
    }
}