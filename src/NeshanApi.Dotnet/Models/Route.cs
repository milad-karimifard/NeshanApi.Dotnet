using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models
{
    public class Route : IEquatable<Route>
    {
        [JsonProperty("legs")] public List<Leg> Legs { get; set; }

        [JsonProperty("overview_polyline")] public OverviewPolyline OverviewPolyline { get; set; }

        #region Equatablity

        public bool Equals(Route other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Legs.Equals(other.Legs) &&
                   OverviewPolyline.Equals(other.OverviewPolyline);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Route) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Legs, OverviewPolyline);
        }

        #endregion
    }
}