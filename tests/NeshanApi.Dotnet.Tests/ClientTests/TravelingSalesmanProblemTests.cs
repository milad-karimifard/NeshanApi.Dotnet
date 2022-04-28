using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Tests.Factories;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    /// <summary>
    /// Note : every run this tests gonna cost you. so be careful
    /// </summary>
    public class TravelingSalesmanProblemTests
    {
        [Fact]
        public async Task Call_With_Invalid_Parameter_Combination_Should_Throw_Exception()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var waypoints = GetWaypoints();

            await Assert.ThrowsAsync<HttpRequestException>(async () => await testCase.TravelingSalesmanProblem(waypoints, false, true, false));
        }

        private List<Location> GetWaypoints()
        {
            return new List<Location>()
            {
                new Location()
                {
                    Latitude = 35.69255236872789,
                    Longitude = 51.42680215156162
                },
                new Location()
                {
                    Latitude = 35.70633992618535,
                    Longitude = 51.31943208024953
                },
                new Location()
                {
                    Latitude = 35.75795814628502,
                    Longitude = 51.3014550545187
                },
                new Location()
                {
                    Latitude = 35.76982530760931,
                    Longitude = 51.42778184639005,
                },
                new Location()
                {
                    Latitude = 35.726278479806936,
                    Longitude = 51.52634912738196
                }
            };
        }
    }
}