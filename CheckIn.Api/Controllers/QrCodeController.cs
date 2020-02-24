using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckIn.Api.Controllers
{
    public class QrCodeController : ApiController
    {
        public GetQrCodeResponse GetQrCode([FromBody] GetQrCodeRequest request)
        {

            return new GetQrCodeResponse();
        }
    }

    public class GetQrCodeRequest
    {
    }

    public class GetQrCodeResponse : ResponseBase<string>
    {
    }

    public class ResponseBase<T>
    {
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}
