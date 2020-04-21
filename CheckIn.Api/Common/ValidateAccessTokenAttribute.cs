using System.Linq;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using CheckIn.Adapter;
using CheckIn.Api.Controllers;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Common
{
    public class ValidateAccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ControllerContext.Controller is ApiControllerBase baseApiController)
            {
                var headers = baseApiController.Request.Headers.Where(h => h.Key.Equals("AccessToken")).ToList();

                if (headers.Any())
                {
                    var accessToken = headers.Single().Value.FirstOrDefault();

                    var profileDao = new ProfileDao();
                    var authService = new AuthService(profileDao);

                    if (!authService.Verify(accessToken))
                    {
                        throw new OperationFailedException("無效的Token");
                    }

                    baseApiController.Profile = authService.Profile;
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