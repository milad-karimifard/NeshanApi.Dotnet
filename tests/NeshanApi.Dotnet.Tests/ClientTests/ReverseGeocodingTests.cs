using System.Threading.Tasks;
using NeshanApi.Dotnet.Exceptions.ApiExceptions;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Models.Results;
using NeshanApi.Dotnet.Tests.Factories;
using Newtonsoft.Json;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    /// <summary>
    /// Note : every run this tests gonna cost you. so be careful
    /// </summary>
    public class ReverseGeocodingTests
    {
        [Fact]
        public async Task Call_With_NotIran_GeoLocation_Should_Throw_NeshanCoordinateParseException()
        {
            var testCase = NeshanClientFactory.GetInstance();
            var location = new Location()
            {
                Latitude = 0,
                Longitude = 0
            };
            await Assert.ThrowsAsync<NeshanCoordinateParseException>(async () => await testCase.ReverseGeocoding(location));
        }

        [Fact]
        public async Task Call_With_Iran_GeoLocation_Should_Be_Fine()
        {
            var testCase = NeshanClientFactory.GetInstance();
            var location = new Location()
            {
                Latitude = 35.831827,
                Longitude = 50.978413
            };
            var result = await testCase.ReverseGeocoding(location);

            var expectedResultJson = @"
        {
            'status': 'OK',
            'neighbourhood': 'جهانشهر',
            'municipality_zone': '',
            'state': 'استان البرز',
            'city': 'کرج',
            'in_traffic_zone': false,
            'in_odd_even_zone': false,
            'route_name': 'معبر بدون نام',
            'route_type': 'footway',
            'place': 'باغ فاتح',
            'district': 'بخش مرکزی شهرستان کرج',
            'formatted_address': 'کرج، بلوار جمهوری اسلامی',
            'village': null
        }";

            var expectedResult = JsonConvert.DeserializeObject<NeshanReverseGeocodingResult>(expectedResultJson);
            Assert.Equal(expectedResult, result);
        }
    }
}