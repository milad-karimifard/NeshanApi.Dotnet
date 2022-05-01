using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NeshanApi.Dotnet.Models.Results
{
    public class NeshanMapMatchingResult : IEquatable<NeshanMapMatchingResult>
    {
        [JsonProperty("snappedPoints")]
        public List<SnappedPoint> SnappedPoints { get; set; }

        #region Equatablity

        public bool Equals(NeshanMapMatchingResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return SnappedPoints.Equals(other.SnappedPoints);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NeshanMapMatchingResult) obj);
        }

        public override int GetHashCode()
        {
            return (SnappedPoints != null ? SnappedPoints.GetHashCode() : 0);
        }

        #endregion
    }
}