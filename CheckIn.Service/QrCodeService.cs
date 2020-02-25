using System;
using CheckIn.Class;
using CheckIn.Common;

namespace CheckIn.Service
{
    public class QrCodeService
    {
        public string GetEventQrCode(Profile profile, int eventId)
        {
            var eventService = new EventService();
            var qrCode = eventService.GetQrCode(eventId, profile.AccountId);
            return qrCode;
        }
    }
}