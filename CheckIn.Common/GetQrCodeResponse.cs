namespace CheckIn.Common
{
    public class GetQrCodeResponse : ResponseBase<string>
    {
        public GetQrCodeResponse(string qrCode)
        {
            this.ResultData= qrCode;
        }
    }
}