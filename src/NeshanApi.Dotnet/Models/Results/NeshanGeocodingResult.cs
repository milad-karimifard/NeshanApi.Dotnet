using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class NeshanGeocodingResult : IEquatable<NeshanGeocodingResult>
    {
        [JsonProperty("status")] public string Status { get; set; }

        [JsonProperty("location")] public Location Location { get; set; }

        #region Equatablity

        public bool Equals(NeshanGeocodingResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Status == other.Status && Equals(Location, other.Location);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NeshanGeocodingResult) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, Location);
        }

        #endregion
    }
}