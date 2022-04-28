using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class TravelingSalesmanProblemResult : IEquatable<TravelingSalesmanProblemResult>
    {
        [JsonProperty("points")]
        public List<Point> Points { get; set; }

        #region Equatablity

        public bool Equals(TravelingSalesmanProblemResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Points.Equals(other.Points);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TravelingSalesmanProblemResult) obj);
        }

        public override int GetHashCode()
        {
            return (Points != null ? Points.GetHashCode() : 0);
        }

        #endregion
    }
}