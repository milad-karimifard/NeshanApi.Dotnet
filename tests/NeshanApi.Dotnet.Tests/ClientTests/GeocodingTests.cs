using System.Threading.Tasks;
using NeshanApi.Dotnet.Models.Results;
using NeshanApi.Dotnet.Tests.Factories;
using Newtonsoft.Json;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    /// <summary>
    /// Note : every run this tests gonna cost you. so be careful
    /// </summary>
    public class GeocodingTests
    {
        [Fact]
        public async Task Call_With_Iran_Address_Should_Be_Fine()
        {
            var testCase = NeshanClientFactory.GetInstance();
            var result = await testCase.Geocoding("تهران سعادت آباد");

            var expectedResultJson = @"
        {
            'location': {
                'x': 51.37574660751868,
                'y': 35.779594962946724
            },
            'status': 'OK'
        }";

            var expectedResult = JsonConvert.DeserializeObject<NeshanGeocodingResult>(expectedResultJson);
            Assert.Equal(expectedResult, result);
        }
    }   
}