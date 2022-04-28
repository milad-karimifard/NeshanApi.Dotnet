using System.Collections.Generic;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Models.Results;

namespace NeshanApi.Dotnet.Interfaces
{
    public interface INeshanApiClient
    {
        Task<NeshanReverseGeocodingResult> ReverseGeocoding(Location location);
        Task<NeshanGeocodingResult> Geocoding(string address);

        Task<NeshanDistanceMatrixResult> DistanceMatrix(
            DistanceMatrixType distanceMatrixType,
            IEnumerable<Location> origins,
            IEnumerable<Location> destinations);

        Task<LocationBasedSearchResult> LocationBasedSearch(Location location, string term);

        Task<TravelingSalesmanProblemResult> TravelingSalesmanProblem(
            IEnumerable<Location> waypoints,
            bool roundTrip = true,
            bool sourceIsAnyPoint = true,
            bool lastIsAnyPoint = true);
    }
}