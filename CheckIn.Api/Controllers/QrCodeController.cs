using System.Web.Http;
using CheckIn.Adapter;
using CheckIn.Api.Common;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Controllers
{
    public class QrCodeController : ApiControllerBase
    {
        private readonly QrCodeService _qrCodeService;

        public QrCodeController()
        {
            var eventDao = new EventDao();
            _qrCodeService = new QrCodeService(eventDao);
        }

        [HttpGet]
        [ValidateAccessToken]
        public GetQrCodeResponse GetQrCode([FromBody] GetQrCodeRequest request)
        {
            var qrCode = _qrCodeService.GetEventQrCode(Profile, request.EventID);
            return new GetQrCodeResponse(qrCode);
        }

        [HttpPut]
        [ValidateAccessToken]
        public EventCheckInResponse EventCheckIn([FromBody] EventCheckInRequest request)
        {
            var result = _qrCodeService.CheckIn(Profile, request.EventID);
            return new EventCheckInResponse(result);
        }

        [HttpDelete]
        [ValidateAccessToken]
        public CancelCheckInResponse CancelCheckIn([FromBody] CancelCheckInRequest request)
        {
            var result = _qrCodeService.Cancel(Profile, request.EventID);

            return new CancelCheckInResponse(result);
        }
    }
}