using System.Linq;
using NeshanApi.Dotnet.Exceptions;
using NeshanApi.Dotnet.Exceptions.ApiExceptions;
using NeshanApi.Dotnet.Models.Results.Errors;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Utilities
{
    public class NeshanApiErrorHandler
    {
        public static void Handle(string responseString, int responseStatusCode)
        {
            if (!IsNeshanSpecialStatusCode(responseStatusCode))
                return;

            HandleNeshanError(responseString, responseStatusCode);
        }

        #region Private Methods

        private static bool IsNeshanSpecialStatusCode(int statusCode)
        {
            var statusCodeList = new[] {470, 480, 481, 482, 483, 484, 485};
            return statusCodeList.Any(o => o == statusCode);
        }

        private static void HandleNeshanError(string responseString, int responseStatus)
        {
            var error = JsonConvert.DeserializeObject<NeshanErrorResult>(responseString);
            switch (responseStatus)
            {
                case 470:
                    throw new NeshanCoordinateParseException(error?.Message);
                case 480:
                    throw new NeshanKeyNotFoundException(error?.Message);
                case 481:
                    throw new NeshanLimitExceededException(error?.Message);
                case 482:
                    throw new NeshanRateExceededException(error?.Message);
                case 483:
                    throw new NeshanApiKeyTypeErrorException(error?.Message);
                case 484:
                    throw new NeshanApiWhiteListErrorException(error?.Message);
                case 485:
                    throw new NeshanApiServiceListErrorException(error?.Message);
            }
        }

        #endregion
    }
}