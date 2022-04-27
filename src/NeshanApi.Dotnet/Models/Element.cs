using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Element : IEquatable<Element>
    {
        [JsonProperty("status")]
        public ElementStatus Status { get; set; }

        [JsonProperty("duration")]
        public Duration Duration { get; set; }

        [JsonProperty("distance")]
        public Distance Distance { get; set; }

        #region Equatablity

        public bool Equals(Element other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Status == other.Status &&
                   Duration.Equals(other.Duration) &&
                   Distance.Equals(other.Distance);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Element) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Status, Duration, Distance);
        }

        #endregion
    }
}