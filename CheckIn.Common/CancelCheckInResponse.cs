namespace CheckIn.Common
{
    public class CancelCheckInResponse :ResponseBase<bool>
    {
        public CancelCheckInResponse(bool result)
        {
            ResultData = result;
        }
    }
}