using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Step : IEquatable<Step>
    {
        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("instruction")] public string Instruction { get; set; }

        [JsonProperty("distance")] public Distance Distance { get; set; }

        [JsonProperty("duration")] public Duration Duration { get; set; }

        [JsonProperty("polyline")] public string Polyline { get; set; }

        [JsonProperty("maneuver")] public string Maneuver { get; set; }

        [JsonProperty("start_location")] public List<double> StartLocation { get; set; }

        #region Equatablity

        public bool Equals(Step other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name &&
                   Instruction == other.Instruction &&
                   Distance.Equals(other.Distance) &&
                   Duration.Equals(other.Duration) &&
                   Polyline == other.Polyline &&
                   Maneuver == other.Maneuver &&
                   StartLocation.Equals(other.StartLocation);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Step) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Instruction, Distance, Duration, Polyline, Maneuver, StartLocation);
        }

        #endregion
    }
}