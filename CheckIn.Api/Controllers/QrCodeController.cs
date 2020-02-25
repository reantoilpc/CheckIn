using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIn.Api.Common;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Controllers
{
    public class QrCodeController : BaseApiController
    {
        [ValidateAccessToken]
        [HttpPost]
        public GetQrCodeResponse GetQrCode([FromBody] GetQrCodeRequest request)
        {
            var getQrCodeResponse = new QrCodeService().GetMemberQrCode(request.EventId);
            return getQrCodeResponse;
        }
    }
}
