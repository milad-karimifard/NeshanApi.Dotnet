namespace NeshanApi.Dotnet.Exceptions
{
    public class NeshanKeyNotFoundException : BaseNeshanException
    {
        public NeshanKeyNotFoundException(string message) : base(480,message)
        {
        }
    }
}