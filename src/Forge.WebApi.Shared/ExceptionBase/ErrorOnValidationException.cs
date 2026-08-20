namespace Forge.WebApi.Shared.ExceptionBase
{
    public class ErrorOnValidationException : ForgeWebApiException
    {
        public IList<string> ErrorMessages { get; set; }


        public ErrorOnValidationException(IList<string> errorMessages)
        {
            ErrorMessages = errorMessages;
        }
    }
}
