using System;
using CheckIn.Adapter;
using CheckIn.Class;
using CheckIn.Common;

namespace CheckIn.Service
{
    public class QrCodeService
    {
        private readonly IEventDao _eventDao;

        public QrCodeService(IEventDao eventDao)
        {
            _eventDao = eventDao;
        }
        public GetQrCodeResponse GetEventQrCode(Profile profile, int eventId)
        {
            var qrCode = _eventDao.GetQrCode(eventId, profile.AccountId);
            return new GetQrCodeResponse(qrCode);
        }

        public EventCheckInResponse CheckIn(Profile profile, int eventId)
        {
            throw new NotImplementedException();
        }
    }
}