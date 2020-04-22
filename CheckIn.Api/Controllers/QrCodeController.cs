using System.Web.Http;
using CheckIn.Adapter;
using CheckIn.Api.Common;
using CheckIn.Common;
using CheckIn.Service;

namespace CheckIn.Api.Controllers
{
    public class QrCodeController : ApiControllerBase
    {
        /// <summary>
        /// QrCode 服務
        /// </summary>
        private readonly QrCodeService _qrCodeService;

        public QrCodeController()
        {
            var eventDao = new EventDao();
            _qrCodeService = new QrCodeService(eventDao);
        }

        /// <summary>
        /// 取得QrCode
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ValidateAccessToken]
        public GetQrCodeResponse GetQrCode([FromBody] GetQrCodeRequest request)
        {
            var qrCode = _qrCodeService.GetEventQrCode(Profile, request.EventID);
            return new GetQrCodeResponse(qrCode);
        }

        /// <summary>
        /// 活動報到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [ValidateAccessToken]
        public EventCheckInResponse EventCheckIn([FromBody] EventCheckInRequest request)
        {
            var result = _qrCodeService.CheckIn(Profile, request.EventID);
            return new EventCheckInResponse(result);
        }

        /// <summary>
        /// 取消報到
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpDelete]
        [ValidateAccessToken]
        public CancelCheckInResponse CancelCheckIn([FromBody] CancelCheckInRequest request)
        {
            var result = _qrCodeService.Cancel(Profile, request.EventID);

            return new CancelCheckInResponse(result);
        }
    }
}