using System.Linq;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Exceptions.InternalExceptions;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Tests.Factories;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    /// <summary>
    /// Note : every run this tests gonna cost you. so be careful
    /// </summary>
    public class DirectionTests
    {
        [Fact]
        public async Task Direction_OutOfTehran_With_Destination_In_TrafficZone_Should_Return_NoRouteFound()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var origin = new Location()
            {
                Latitude = 32.61616771501174,
                Longitude = 51.679540871364736
            };

            var destination = new Location()
            {
                Latitude = 32.657890919988404,
                Longitude = 51.66731146527911
            };

            await Assert.ThrowsAsync<NeshanNoRouteFoundException>(async () => await testCase.Direction(
                DirectionVehicleType.Motorcycle,
                origin,
                destination,
                0,
                avoidTrafficZone: true,
                avoidOddEvenZone: true
            ));
        }
        
        [Fact]
        public async Task Direction_Should_Work_Fine()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var origin = new Location()
            {
                Latitude = 32.61616771501174,
                Longitude = 51.679540871364736
            };

            var destination = new Location()
            {
                Latitude = 32.657890919988404,
                Longitude = 51.66731146527911
            };

            var result = await testCase.Direction(
                DirectionVehicleType.Motorcycle,
                origin,
                destination,
                0
            );
            
            Assert.True(result.Routes.Any());
        }

        [Fact]
        public async Task DirectionWithOutTraffic_Should_Work_Fine()
        {
            var testCase = NeshanClientFactory.GetInstance();

            var origin = new Location()
            {
                Latitude = 32.61616771501174,
                Longitude = 51.679540871364736
            };

            var destination = new Location()
            {
                Latitude = 32.657890919988404,
                Longitude = 51.66731146527911
            };

            var result = await testCase.DirectionWithOutTraffic(
                origin,
                destination,
                0
            );
            
            Assert.True(result.Routes.Any());
        }
    }
}