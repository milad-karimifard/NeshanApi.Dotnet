using System.Collections.Generic;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Tests.Factories;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    public class DistanceMatrixTests
    {
        [Fact]
        public async Task Call_With_Iran_Locations_Should_Be_Fine()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var origins = new List<Location>()
            {
                new Location()
                {
                    Latitude = 36.3177579,
                    Longitude = 59.5323219
                },
                new Location()
                {
                    Latitude = 36.337115,
                    Longitude = 59.530621
                }
            };

            var destinations = new List<Location>()
            {
                new Location()
                {
                    Latitude = 36.35067,
                    Longitude = 59.5451965
                },
                new Location()
                {
                    Latitude = 36.337005,
                    Longitude = 59.530021
                }
            };

            var result = await testCase.DistanceMatrix(
                DistanceMatrixType.Car,
                origins,
                destinations);

            
            Assert.Equal("Ok", result.Status);
        }
    }
}