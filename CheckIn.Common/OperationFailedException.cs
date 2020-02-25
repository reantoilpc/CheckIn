using System;

namespace CheckIn.Common
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