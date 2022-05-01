using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Exceptions.ApiExceptions;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Tests.Factories;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    /// <summary>
    /// Note : every run this tests gonna cost you. so be careful
    /// </summary>
    public class MapMatchingTests
    {
        [Fact]
        public async Task MapMatching_With_One_Location_Should_Throw_Exception()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var point1 = new Location()
            {
                Latitude = 32.61616771501174,
                Longitude = 51.679540871364736
            };

            await Assert.ThrowsAsync<NeshanCoordinateParseException>(async () =>
                await testCase.MapMatching(new[]
                {
                    point1
                }));
        }

        [Fact]
        public async Task MapMatching_With_UnMappable_Location_Should_Throw_Exception()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var point1 = new Location()
            {
                Latitude = 32.61616771501174,
                Longitude = 51.679540871364736
            };

            var point2 = new Location()
            {
                Latitude = 32.657890919988404,
                Longitude = 51.66731146527911
            };

            await Assert.ThrowsAsync<HttpRequestException>(async () =>
                await testCase.MapMatching(new[]
                {
                    point1,
                    point2
                }));
        }

        [Fact]
        public async Task MapMatching_With_Two_Location_Should_Be_Fine()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var point1 = new Location()
            {
                Latitude = 35.71408603772724,
                Longitude = 51.38948100327411
            };

            var point2 = new Location()
            {
                Latitude = 35.723713699592125,
                Longitude = 51.41043905842645
            };


            var result = await testCase.MapMatching(new[]
            {
                point1,
                point2
            });
            
            Assert.True(result.SnappedPoints.Any());
        }
    }
}