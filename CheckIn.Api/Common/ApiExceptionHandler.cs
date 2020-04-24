using System.Web.Http.ExceptionHandling;

namespace CheckIn.Api.Common
{
    /// <summary>
    /// 處理 Exception 類別
    /// </summary>
    public class ApiExceptionHandler : ExceptionHandler
    {
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ApiExceptionResult(context.Request, context.Exception);
            base.Handle(context);
        }
    }
}