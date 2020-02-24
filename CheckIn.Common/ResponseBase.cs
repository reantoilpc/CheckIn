namespace CheckIn.Common
{
    public class ResponseBase<T>
    {
        public T ResultData { get; set; }
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }
    }
}