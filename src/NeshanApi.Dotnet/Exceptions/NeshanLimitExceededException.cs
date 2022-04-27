namespace NeshanApi.Dotnet.Exceptions
{
    public class NeshanLimitExceededException : BaseNeshanException
    {
        public NeshanLimitExceededException(string message) : base(481, message)
        {
        }
    }
}

