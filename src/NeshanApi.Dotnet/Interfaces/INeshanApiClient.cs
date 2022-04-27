using System.Collections.Generic;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Models.Results;

namespace NeshanApi.Dotnet.Interfaces
{
    public interface INeshanApiClient
    {
        Task<NeshanReverseGeocodingResult> ReverseGeocoding(double latitude, double longitude);
        Task<NeshanGeocodingResult> Geocoding(string address);

        Task<NeshanDistanceMatrixResult> DistanceMatrix(
            DistanceMatrixType distanceMatrixType,
            IEnumerable<Location> origins,
            IEnumerable<Location> destinations);
    }
}