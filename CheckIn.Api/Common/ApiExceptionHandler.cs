using System.Web.Http.ExceptionHandling;

namespace CheckIn.Api.Common
{
    public class ApiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ApiExceptionResult(context.Request, context.Exception);
            base.Handle(context);
        }
    }
}