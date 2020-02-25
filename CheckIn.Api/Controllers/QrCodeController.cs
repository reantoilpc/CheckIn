using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CheckIn.Adapter;
using CheckIn.Api.Common;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Controllers
{
    public class QrCodeController : BaseApiController
    {
        private EventDao _eventDao;
        private QrCodeService _qrCodeService;

        public QrCodeController()
        {
            _eventDao = new EventDao();
            _qrCodeService = new QrCodeService(_eventDao);
        }

        [HttpGet]
        [ValidateAccessToken]
        public GetQrCodeResponse GetQrCode([FromBody] GetQrCodeRequest request)
        {
            var qrCode = _qrCodeService.GetEventQrCode(Profile, request.EventId);
            return new GetQrCodeResponse(qrCode);
        }

        [HttpPost]
        [ValidateAccessToken]
        public EventCheckInResponse EventCheckIn([FromBody]EventCheckInRequest request)
        {
             var result = _qrCodeService.CheckIn(Profile, request.EventId);
            return new EventCheckInResponse(result);
        }
    }
}
