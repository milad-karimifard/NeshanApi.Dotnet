using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Exceptions.InternalExceptions;
using NeshanApi.Dotnet.Interfaces;
using NeshanApi.Dotnet.Models;
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

        public async Task<NeshanReverseGeocodingResult> ReverseGeocoding(Location location)
        {
            var uri = $"v4/reverse?lat={location.Latitude}&lng={location.Longitude}";
            var response = await _client.GetAsync(uri);
            var result = await HandleResponse<NeshanReverseGeocodingResult>(response);
            return result;
        }

        public async Task<NeshanGeocodingResult> Geocoding(string address)
        {
            var uri = $"v4/geocoding?address={address}";
            var response = await _client.GetAsync(uri);
            var result = await HandleResponse<NeshanGeocodingResult>(response);

            if (result.Status == "NO_RESULT")
                throw new NeshanNoResultException();

            return result;
        }

        public async Task<NeshanDistanceMatrixResult> DistanceMatrix(
            DistanceMatrixType distanceMatrixType,
            IEnumerable<Location> origins,
            IEnumerable<Location> destinations)
        {
            var uri = $"v1/distance-matrix?type={distanceMatrixType.ToString()}";
            
            var originsUrl = string.Join('|', origins
                .Select(o => $"{o.Latitude},{o.Longitude}").ToList());
            
            var destinationsUrl = string.Join('|', destinations
                .Select(o => $"{o.Latitude},{o.Longitude}").ToList());

            uri += $"&origins={originsUrl}&destinations={destinationsUrl}";
            
            var response = await _client.GetAsync(uri);
            var result = await HandleResponse<NeshanDistanceMatrixResult>(response);
            return result;
        }

        public async Task<LocationBasedSearchResult> LocationBasedSearch(Location location, string term)
        {
            var uri = $"v1/search?term={term}&lat={location.Latitude}&lng={location.Longitude}";
            var response = await _client.GetAsync(uri);
            var result = await HandleResponse<LocationBasedSearchResult>(response);
            
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
            _client.BaseAddress = new Uri("https://api.neshan.org/");
            _client.DefaultRequestHeaders.Add("Api-Key", _config.ApiKey);
        }

        #endregion
    }
}