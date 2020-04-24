using CheckIn.Adapter;
using CheckIn.Class;

namespace CheckIn.Service
{
    /// <summary>
    ///     QrCode服務元件
    /// </summary>
    public class QrCodeService
    {
        /// <summary>
        ///     活動的資料庫元件
        /// </summary>
        private readonly IEventDao _eventDao;

        public QrCodeService(IEventDao eventDao)
        {
            _eventDao = eventDao;
        }

        /// <summary>
        ///     取得活動QrCode
        /// </summary>
        /// <param name="profile">使用者資料</param>
        /// <param name="eventId">活動ID</param>
        /// <returns>活動QrCode</returns>
        public string GetEventQrCode(Profile profile, int eventId)
        {
            var qrCode = _eventDao.GetQrCode(eventId, profile.AccountID);
            return qrCode;
        }

        /// <summary>
        ///     活動報到
        /// </summary>
        /// <param name="profile">使用者資料</param>
        /// <param name="eventId">活動ID</param>
        /// <returns>報到成功或失敗</returns>
        public bool CheckIn(Profile profile, int eventId)
        {
            return _eventDao.UpdateQrCodeStatus(eventId, profile.AccountID, true);
        }

        /// <summary>
        ///     取消報到
        /// </summary>
        /// <param name="profile">使用者資料</param>
        /// <param name="eventId">活動ID</param>
        /// <returns>取消成功或失敗</returns>
        public bool Cancel(Profile profile, int eventId)
        {
            return _eventDao.DeleteQrCode(eventId, profile.AccountID);
        }
    }
}