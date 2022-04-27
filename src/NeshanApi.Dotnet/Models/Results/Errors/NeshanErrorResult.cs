using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results.Errors
{
    public class NeshanErrorResult
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("code")]
        public int Code { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }
    }
}