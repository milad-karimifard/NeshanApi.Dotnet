namespace NeshanApi.Dotnet.Exceptions
{
    public class NeshanRateExceededException : BaseNeshanException
    {
        public NeshanRateExceededException(string message) : base(482, message)
        {
        }
    }
}

