using System;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class OverviewPolyline : IEquatable<OverviewPolyline>
    {
        [JsonProperty("points")]
        public string Points { get; set; }

        #region Equatablity

        public bool Equals(OverviewPolyline other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Points == other.Points;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((OverviewPolyline) obj);
        }

        public override int GetHashCode()
        {
            return (Points != null ? Points.GetHashCode() : 0);
        }

        #endregion
    }
}