using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CheckIn.Adapter;
using CheckIn.Api.Controllers;
using CheckIn.Service;

namespace CheckIn.Api.Common
{
    public class ValidateAccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.Controller is BaseApiController baseApiController)
            {
                var headers = baseApiController.Request.Headers.Where(h => h.Key.Equals("AccessToken")).ToList();

                if (headers.Any())
                {
                    var accessToken = headers.Single().Value.FirstOrDefault();

                    var profileDao = new ProfileDao();
                    var sha256Adapter = new Sha256Adapter();
                    var authService = new AuthService(profileDao);

                    var authenticationService = new AuthenticationService(profileDao, sha256Adapter, authService);
                    if (!authenticationService.ValidateAccessToken(accessToken))
                    {
                        throw new OperationFailedException("無效的Token");
                    }
                }
                else
                {
                    throw new OperationFailedException("無效的Token");
                }
            }

            base.OnActionExecuting(actionContext);
        }
    }
}