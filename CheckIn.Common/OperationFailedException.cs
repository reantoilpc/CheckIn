using System;

namespace CheckIn.Common
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException(string message) : base(message)
        {
            ErrorMessage = message;
        }

        /// <summary>
        ///     錯誤訊息
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}