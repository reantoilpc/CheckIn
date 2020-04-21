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
        public string GetEventQrCode(Profile profile, int eventId)
        {
            var qrCode = _eventDao.GetQrCode(eventId, profile.AccountID);
            return qrCode;
        }

        public bool CheckIn(Profile profile, int eventId)
        {
            return _eventDao.UpdateQrCodeStatus(eventId, profile.AccountID, true);
            
        }

        public bool Cancel(Profile profile, int eventId)
        {
            return _eventDao.DeleteQrCode(eventId, profile.AccountID);
        }
    }
}