using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class NeshanDistanceMatrixResult : IEquatable<NeshanDistanceMatrixResult>
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("rows")]
        public List<Row> Rows { get; set; }

        [JsonProperty("origin_addresses")]
        public List<string> OriginAddresses { get; set; }

        [JsonProperty("destination_addresses")]
        public List<string> DestinationAddresses { get; set; }

        #region Equatablity

        public bool Equals(NeshanDistanceMatrixResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return 
                Status == other.Status &&
                Rows == other.Rows &&
                OriginAddresses == other.OriginAddresses &&
                DestinationAddresses == other.DestinationAddresses;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NeshanDistanceMatrixResult) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, Rows, OriginAddresses, DestinationAddresses);
        }

        #endregion
    }
}