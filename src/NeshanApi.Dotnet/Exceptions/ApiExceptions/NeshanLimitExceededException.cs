namespace NeshanApi.Dotnet.Exceptions.ApiExceptions
{
    public class NeshanLimitExceededException : BaseNeshanException
    {
        public NeshanLimitExceededException(string message) : base(481, message)
        {
        }
    }
}

