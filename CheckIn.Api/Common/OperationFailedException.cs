using System;

namespace CheckIn.Api.Common
{
    public class OperationFailedException : Exception
    {
        public OperationFailedException(string message): base(message)
        {
            ErrorMessage = message;
        }

        public string ErrorMessage { get; set; }
    }
}