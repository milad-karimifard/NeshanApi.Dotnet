using System;
using System.Threading.Tasks;
using NeshanApi.Dotnet.Models;
using NeshanApi.Dotnet.Tests.Factories;
using Xunit;

namespace NeshanApi.Dotnet.Tests.ClientTests
{
    /// <summary>
    /// Note : every run this tests gonna cost you. so be careful
    /// </summary>
    public class LocationBasedSearchTests
    {
        [Fact]
        public async Task Call_With_Invalid_Term_Should_Return_Zero_Result()
        {
            var testCase = NeshanClientFactory.GetInstance();
            var location = new Location()
            {
                Latitude = 35.831827,
                Longitude = 50.978413
            };
            var term = Guid.NewGuid().ToString();
            var result = await testCase.LocationBasedSearch(location, term);
            Assert.Equal(0, result.Count);
        }
        
        [Fact]
        public async Task Call_With_Valid_Value_Should_Return_Correct_Result()
        {
            var testCase = NeshanClientFactory.GetInstance();
            var location = new Location()
            {
                Latitude = 35.831827,
                Longitude = 50.978413
            };
            
            var term = "سعادت آباد";
            var result = await testCase.LocationBasedSearch(location, term);

            var condition = result.Count > 0;
            
            Assert.True(condition);
        }
    }
}