namespace NeshanApi.Dotnet.Exceptions.ApiExceptions
{
    public class NeshanRateExceededException : BaseNeshanException
    {
        public NeshanRateExceededException(string message) : base(482, message)
        {
        }
    }
}

