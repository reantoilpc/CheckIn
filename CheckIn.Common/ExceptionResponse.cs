namespace CheckIn.Common
{
    public class ExceptionResponse : ResponseBase<string>
    {
        public ExceptionResponse(string errorMessage)
        {
            ResultMessage = errorMessage;
        }
    }
}