using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIn.Common;

namespace CheckIn.Api.Controllers
{
    public class QrCodeController : ApiController
    {
        public GetQrCodeResponse GetQrCode([FromBody] GetQrCodeRequest request)
        {
            var getQrCodeResponse = new QrCodeService().GetMemberQrCode(request.EventId);
            return getQrCodeResponse;
        }
    }
}
