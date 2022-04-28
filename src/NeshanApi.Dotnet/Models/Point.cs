using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Point : IEquatable<Point>
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public List<double> Location { get; set; }

        [JsonProperty("index")]
        public int Index { get; set; }

        #region Equatablity

        public bool Equals(Point other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Location.Equals(other.Location) && Index == other.Index;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Point) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Location, Index);
        }

        #endregion
    }
}