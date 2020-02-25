namespace CheckIn.Adapter
{
    public interface IEventDao
    {
        string GetQrCode(int eventId, int accountId);
    }

    public class EventDao : IEventDao
    {
        public string GetQrCode(int eventId, int accountId)
        {
            throw new System.NotImplementedException();
        }
    }
}