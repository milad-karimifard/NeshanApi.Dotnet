using System.Threading.Tasks;
using NeshanApi.Dotnet.Models.Results;

namespace NeshanApi.Dotnet.Interfaces
{
    public interface INeshanApiClient
    {
        Task<NeshanReverseGeocodingResult> ReverseGeocoding(double latitude, double longitude);
    }
}