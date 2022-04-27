namespace NeshanApi.Dotnet.Exceptions.ApiExceptions
{
    public class NeshanApiKeyTypeErrorException : BaseNeshanException
    {
        public NeshanApiKeyTypeErrorException(string message) : base(483, message)
        {
        }
    }
}

