using System.Collections.Generic;
using System.Linq;

namespace CheckIn.Common
{
    public class ValidateAccessTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //base.OnActionExecuting(actionContext);
            if (actionContext.ControllerContext.Controller is BaseApiController baseApiController)
            {
                var headers = Enumerable.FirstOrDefault<KeyValuePair<string, IEnumerable<string>>>(baseApiController.Request.Headers, h => h.Key.Equals("AccessToken"));
                var accessToken = headers.Value.FirstOrDefault();

                var authenticationService = new AuthenticationService();
                authenticationService.ValidateAccessToken(accessToken);
            }
        }

    }
}