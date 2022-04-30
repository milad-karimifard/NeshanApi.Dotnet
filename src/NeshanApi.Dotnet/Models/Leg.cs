using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Leg : IEquatable<Leg>
    {
        [JsonProperty("summary")] public string Summary { get; set; }

        [JsonProperty("distance")] public Distance Distance { get; set; }

        [JsonProperty("duration")] public Duration Duration { get; set; }

        [JsonProperty("steps")] public List<Step> Steps { get; set; }

        #region Equatablity

        public bool Equals(Leg other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Summary == other.Summary &&
                   Distance.Equals(other.Distance) &&
                   Duration.Equals(other.Duration) &&
                   Steps.Equals(other.Steps);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Leg) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Summary, Distance, Duration, Steps);
        }

        #endregion
    }
}