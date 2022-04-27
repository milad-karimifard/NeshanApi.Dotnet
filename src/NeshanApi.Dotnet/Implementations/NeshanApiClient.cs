using System;
using System.Net.Http;
using NeshanApi.Dotnet.Interfaces;
using NeshanApi.Dotnet.Models.Configs;

namespace NeshanApi.Dotnet.Implementations
{
    public class NeshanApiClient : INeshanApiClient
    {
        #region Properties

        private readonly HttpClient _client;
        private readonly NeshanConfig _config;

        #endregion

        #region Constructors

        public NeshanApiClient(
            HttpClient client,
            NeshanConfig config)
        {
            _client = client;
            _config = config;
            ConfigHttpClient();
        }

        #endregion

        #region Private Methods

        private void ConfigHttpClient()
        {
            _client.BaseAddress = new Uri("https://api.neshan.org/v4/");
            _client.DefaultRequestHeaders.Add("Api-Key", _config.ApiKey);
        }

        #endregion
    }
}