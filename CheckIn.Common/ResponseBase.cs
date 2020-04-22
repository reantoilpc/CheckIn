namespace CheckIn.Common
{
    public class ResponseBase<T>
    {
        /// <summary>
        /// 回傳結果
        /// </summary>
        public T ResultData { get; set; }
        /// <summary>
        /// API回傳代碼
        /// </summary>
        public string ResultCode { get; set; }
        /// <summary>
        /// API回傳訊息
        /// </summary>
        public string ResultMessage { get; set; }
    }
}