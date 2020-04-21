using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using CheckIn.Common;

namespace CheckIn.Api.Common
{
    public class ApiExceptionResult : IHttpActionResult
    {
        public ApiExceptionResult(HttpRequestMessage request, Exception exception)
        {
            Request = request;
            Exception = exception;
        }

        public HttpRequestMessage Request { get; set; }
        public Exception Exception { set; get; }


        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            ExceptionResponse response;
            if (Exception is OperationFailedException thisException)
                response = new ExceptionResponse(thisException.ErrorMessage);
            else
                response = new ExceptionResponse("系統發生錯誤!!");

            return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, response));
        }
    }
}