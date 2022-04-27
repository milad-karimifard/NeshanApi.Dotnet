using System.Net.Http;
using NeshanApi.Dotnet.Implementations;
using NeshanApi.Dotnet.Interfaces;
using NeshanApi.Dotnet.Models.Configs;

namespace NeshanApi.Dotnet.Tests.Factories
{
    public class NeshanClientFactory
    {
        public static INeshanApiClient GetInstance()
        {
            return new NeshanApiClient(new HttpClient(), new NeshanConfig()
            {
                ApiKey = Constants.ApiKey
            });
        }
    }
}