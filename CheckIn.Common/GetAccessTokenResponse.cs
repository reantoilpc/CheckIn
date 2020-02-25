namespace CheckIn.Common
{
    public class GetAccessTokenResponse : ResponseBase<string>
    {
        public GetAccessTokenResponse(string token)
        {
            this.ResultData = token;
        }
    }
}