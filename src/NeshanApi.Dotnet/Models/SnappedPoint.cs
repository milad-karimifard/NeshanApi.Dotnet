using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class SnappedPoint : IEquatable<SnappedPoint>
    {
        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("originalIndex")]
        public double OriginalIndex { get; set; }

        #region Equatablity

        public bool Equals(SnappedPoint other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Location.Equals(other.Location) &&
                   OriginalIndex.Equals(other.OriginalIndex);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((SnappedPoint) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Location, OriginalIndex);
        }

        #endregion
    }
}