using System;
using System.Net.Http;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Exceptions.InternalExceptions;
using NeshanApi.Dotnet.Interfaces;
using NeshanApi.Dotnet.Models.Configs;
using NeshanApi.Dotnet.Models.Results;
using NeshanApi.Dotnet.Utilities;
using Newtonsoft.Json;

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

        #region Methods

        public async Task<NeshanReverseGeocodingResult> ReverseGeocoding(double latitude, double longitude)
        {
            var uri = $"reverse?lat={latitude}&lng={longitude}";
            var response = await _client.GetAsync(uri);
            var result = await HandleResponse<NeshanReverseGeocodingResult>(response);
            return result;
        }

        public async Task<NeshanGeocodingResult> Geocoding(string address)
        {
            var uri = $"geocoding?address={address}";
            var response = await _client.GetAsync(uri);
            var result = await HandleResponse<NeshanGeocodingResult>(response);

            if (result.Status == "NO_RESULT")
                throw new NeshanNoResultException();
        
            return result;
        }
        
        #endregion

        #region Private Methods

        private async Task<TResult> HandleResponse<TResult>(HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResult>(responseString);
            }

            var responseStatus = (int) response.StatusCode;

            NeshanApiErrorHandler.Handle(responseString, responseStatus);
            response.EnsureSuccessStatusCode();
            
            return default;
        }

        private void ConfigHttpClient()
        {
            _client.BaseAddress = new Uri("https://api.neshan.org/v4/");
            _client.DefaultRequestHeaders.Add("Api-Key", _config.ApiKey);
        }

        #endregion
    }
}