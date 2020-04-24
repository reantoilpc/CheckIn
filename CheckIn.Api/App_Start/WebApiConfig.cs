using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using CheckIn.Api.Common;

namespace CheckIn.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 設定和服務
            GlobalConfiguration.Configuration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );
        }
    }
}