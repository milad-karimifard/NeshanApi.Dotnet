namespace NeshanApi.Dotnet.Exceptions.ApiExceptions
{
    public class NeshanKeyNotFoundException : BaseNeshanException
    {
        public NeshanKeyNotFoundException(string message) : base(480,message)
        {
        }
    }
}