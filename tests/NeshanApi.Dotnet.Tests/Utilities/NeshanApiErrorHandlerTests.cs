using NeshanApi.Dotnet.Exceptions;
using NeshanApi.Dotnet.Exceptions.ApiExceptions;
using NeshanApi.Dotnet.Utilities;
using Xunit;

namespace NeshanApi.Dotnet.Tests.Utilities
{
    public class NeshanApiErrorHandlerTests
    {
        #region Tests

        [Fact]
        public void Handle_470_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanCoordinateParseException>(() => NeshanApiErrorHandler.Handle("", 470));
        }

        [Fact]
        public void Handle_480_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanKeyNotFoundException>(() => NeshanApiErrorHandler.Handle("", 480));
        }

        [Fact]
        public void Handle_481_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanLimitExceededException>(() => NeshanApiErrorHandler.Handle("", 481));
        }
        
        [Fact]
        public void Handle_482_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanRateExceededException>(() => NeshanApiErrorHandler.Handle("", 482));
        }
        
        [Fact]
        public void Handle_483_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanApiKeyTypeErrorException>(() => NeshanApiErrorHandler.Handle("", 483));
        }
        
        [Fact]
        public void Handle_484_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanApiWhiteListErrorException>(() => NeshanApiErrorHandler.Handle("", 484));
        }
        
        [Fact]
        public void Handle_485_StatusCode_Should_Throw_Exception()
        {
            Assert.Throws<NeshanApiServiceListErrorException>(() => NeshanApiErrorHandler.Handle("", 485));
        }

        #endregion
    }
}