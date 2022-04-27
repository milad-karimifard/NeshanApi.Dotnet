using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Location : IEquatable<Location>
    {
        [JsonProperty("y")] public double Latitude { get; set; }

        [JsonProperty("x")] public double Longitude { get; set; }

        #region Equatabllity

        public bool Equals(Location other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Latitude.Equals(other.Latitude) && Longitude.Equals(other.Longitude);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Location) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Latitude, Longitude);
        }

        #endregion
    }
}